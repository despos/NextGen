///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Expoware.Youbiquitous.Mvc.Filters;
using Memento.Messaging.Postie;
using Memento.Persistence;
using Memento.Persistence.MongoDB;
using TaskZero.Server.Common;
using TaskZero.Server.Common.Security;
using TaskZero.Server.Controllers;
using Microsoft.Practices.Unity;
using TaskZero.CommandStack.Sagas;
using TaskZero.ReadStack.Denormalizers;

namespace TaskZero.Server
{
    public class TaskZeroApplication : System.Web.HttpApplication
    {
        public static IBus Bus { get; private set; }
        public static IRepository AggregateRepository { get; private set; }
        public static IEventStore EventStore { get; private set; }
        public static TaskZeroSettings AppSettings { get; private set; }

        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            CultureAttribute.Register();

            // Load configuration data
            AppSettings = TaskZeroSettings.Initialize();

            // Configure the MementoFX
            var container = MementoStartup.UnityConfig<InMemoryBus, MongoDbEventStore>();

            // Save global references to the FX core elements
            Bus = container.Resolve<IBus>();
            AggregateRepository = container.Resolve<IRepository>();
            EventStore = container.Resolve<IEventStore>();

            // Add sagas and handlers to the bus
            Bus.RegisterSaga<ManageTaskSaga>();
            Bus.RegisterHandler<NotificationHandler>();
            Bus.RegisterHandler<ManageTaskDenormalizer>();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            //var httpContext = ((HttpApplication)sender).Context;
            //httpContext.Response.Clear();
            //httpContext.ClearError();
            //InvokeErrorAction(httpContext, exception);
        }


        protected void Application_PostAuthenticateRequest()
        {
            var customPrincipal = new TaskZeroPrincipal(User);
            HttpContext.Current.User = customPrincipal;
        }


        #region PRIVATE (Error handling)
        private static void InvokeErrorAction(HttpContext httpContext, Exception exception)
        {
            var routeData = new RouteData();
            routeData.Values["controller"] = "app";
            routeData.Values["action"] = "error";
            routeData.Values["exception"] = exception;

            using (var controller = new AppController())
            {
                ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
            }
        }
        #endregion
    }
}
