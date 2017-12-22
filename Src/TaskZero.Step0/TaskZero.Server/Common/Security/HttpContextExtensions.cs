///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System.Web;

namespace TaskZero.Server.Common.Security
{
    public static class HttpContextExtensions
    {
        public static TaskZeroPrincipal YouStartAppPrincipal(this HttpContext context)
        {
            var appUser = context.User as TaskZeroPrincipal;
            if (appUser == null)
                return new TaskZeroPrincipal(context.User);
            return appUser;
        }

        public static TaskZeroPrincipal YouStartAppPrincipal(this HttpContextBase context)
        {
            var appUser = context.User as TaskZeroPrincipal;
            if (appUser == null)
                return new TaskZeroPrincipal(context.User);
            return appUser;
        }
    }
}