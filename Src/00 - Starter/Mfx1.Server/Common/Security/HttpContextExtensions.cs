///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System.Web;

namespace Mfx1.Server.Common.Security
{
    public static class HttpContextExtensions
    {
        public static MfxAppPrincipal YouStartAppPrincipal(this HttpContext context)
        {
            var appUser = context.User as MfxAppPrincipal;
            if (appUser == null)
                return new MfxAppPrincipal(context.User);
            return appUser;
        }

        public static MfxAppPrincipal YouStartAppPrincipal(this HttpContextBase context)
        {
            var appUser = context.User as MfxAppPrincipal;
            if (appUser == null)
                return new MfxAppPrincipal(context.User);
            return appUser;
        }
    }
}