///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
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
using Mfx1.CommandStack.Sagas;
using Mfx1.ReadStack.Denormalizers;
using Mfx1.Server.Common;
using Mfx1.Server.Common.Security;
using Mfx1.Server.Controllers;
using Microsoft.Practices.Unity;

namespace Mfx1.Server
{
    public class MfxApplication : HttpApplication
    {
        public static IBus Bus { get; private set; }
        public static IRepository AggregateRepository { get; private set; }

        public static YbqAppSettings AppSettings { get; private set; }

        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            CultureAttribute.Register();

            // Load configuration data
            AppSettings = YbqAppSettings.Initialize();

            // Configure the MementoFX
            var container = MementoStartup.UnityConfig<InMemoryBus, MongoDbEventStore>();

            // Save global references to the FX core elements
            Bus = container.Resolve<IBus>();
            AggregateRepository = container.Resolve<IRepository>();

            // Add sagas and handlers to the bus
            Bus.RegisterSaga<ManageTaskSaga>();
            Bus.RegisterHandler<ManageTaskDenormalizer>();
            Bus.RegisterHandler<NotificationHandler>();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //var exception = Server.GetLastError();

            //var httpContext = ((HttpApplication)sender).Context;
            //httpContext.Response.Clear();
            //httpContext.ClearError();
            //InvokeErrorAction(httpContext, exception);
        }


        protected void Application_PostAuthenticateRequest()
        {
            var customPrincipal = new YbqAppPrincipal(User);
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
