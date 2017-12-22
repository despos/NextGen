///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Web.Security;

namespace MfxDemo2.Common.Security
{
    public class AppAuthentication
    {
        public static void SignInWithApplication(string username, bool rememberMe = true)
        {
            //var durationInHours = rememberMe ? 240 : 8;
            ////var userData = SerializeUserInfoInternal(user, rememberMe);

            //var authTicket = new FormsAuthenticationTicket(
            //    1,                                          // version number
            //    user.UserName,                              // name of the user
            //    DateTime.Now,                               // issue date
            //    DateTime.Now.AddHours(durationInHours),     // expiration
            //    true,                                       // survives browser sessions
            //    null);                                      // user data (serialized)

            //var ticket = FormsAuthentication.Encrypt(authTicket);
            //var cookie = FormsAuthentication.GetAuthCookie(FormsAuthentication.FormsCookieName, rememberMe);
            //cookie.Value = ticket;
            //HttpContext.Current.Response.Cookies.Add(cookie);

            // Simple way to attach one (or more) additional claims)
            //FormsAuthentication.SetAuthCookie(username + "|" + CultureInfo.CurrentUICulture, rememberMe);

            FormsAuthentication.SetAuthCookie(username, rememberMe);
        }

        public static void SignOutFromApplication()
        {
            FormsAuthentication.SignOut();
        }
    }
}