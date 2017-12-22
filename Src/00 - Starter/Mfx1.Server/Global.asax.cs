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
using Mfx1.Server.Common;
using Mfx1.Server.Common.Security;
using Mfx1.Server.Controllers;


namespace Mfx1.Server
{
    public class MfxApplication : System.Web.HttpApplication
    {
        public static MfxAppSettings AppSettings { get; private set; }

        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            CultureAttribute.Register();

            // Load configuration data
            AppSettings = MfxAppSettings.Initialize();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            var httpContext = ((HttpApplication)sender).Context;
            httpContext.Response.Clear();
            httpContext.ClearError();
            InvokeErrorAction(httpContext, exception);
        }


        protected void Application_PostAuthenticateRequest()
        {
            var customPrincipal = new MfxAppPrincipal(User);
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
