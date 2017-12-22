///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System;
using System.Web.Mvc;
using Mfx1.Server.Application;
using Mfx1.Server.Common;
using Mfx1.Server.Common.Security;
using Mfx1.Server.Models;
using Mfx1.Server.Models.Account;
using Mfx1.Server.Resources;

namespace Mfx1.Server.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _service = new AccountService();

        /// <summary>
        /// Presents the LOGIN page
        /// </summary>
        /// <returns>Redirect</returns>
        [HttpGet]
        public ActionResult Login()
        {
            var model = ViewModelBase.Default();
            return View(model);
        }

        /// <summary>
        /// Validate provided credentials
        /// </summary>
        /// <param name="input">Values of the login input form</param>
        /// <returns>JSON command response</returns>
        [HttpPost]
        public JsonResult Auth(LoginInputModel input)
        {
            var response = _service.TryAuthenticate(input);
            if (response.Success)
            {
                AppAuthentication.SignInWithApplication(response.Key);
                return Json(CommandResponse.Ok.AddRedirectUrl(Url.Action("index", "home")));
            }

            return Json(CommandResponse.Fail.AddMessage(response.Message));
        }

        /// <summary>
        /// Logs current user out
        /// </summary>
        /// <returns>Redirect</returns>
        public ActionResult Logout()
        {
            AppAuthentication.SignOutFromApplication();
            return RedirectToAction("index", "home");
        }

        /// <summary>
        /// Presents the RECOVER PASSWORD page
        /// </summary>
        /// <returns>Redirect</returns>
        [HttpGet]
        public ActionResult Recover()
        {
            var model = ViewModelBase.Default();
            return View(model);
        }

        /// <summary>
        /// Resets the password
        /// </summary>
        /// <param name="email">Email address to send new password</param>
        /// <returns>Redirect</returns>
        [HttpPost]
        public JsonResult Recover(string email)
        {
            // Do some work and return
            var success = DateTime.Now.Second % 2;
            if (success > 0)
                return Json(CommandResponse.Ok.AddMessage(Strings_UI.Account_PassworcChanged));

            return Json(CommandResponse.Fail.AddMessage(Strings_UI.Account_CouldntChangePassword));
        }

        #region PRIVATE

        #endregion
    }
}