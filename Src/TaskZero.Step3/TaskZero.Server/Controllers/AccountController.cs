///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System;
using System.Web.Mvc;
using TaskZero.Server.Application;
using TaskZero.Server.Common;
using TaskZero.Server.Common.Security;
using TaskZero.Server.Models;
using TaskZero.Server.Models.Account;
using TaskZero.Server.Resources;
using TaskZero.Shared;

namespace TaskZero.Server.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _service = new AccountService();

        /// <summary>
        /// Presents the LOGIN page
        /// </summary>
        /// <returns>Redirect</returns>
        [HttpGet]
        public ActionResult Login(LoginInputModel input)
        {
            var model = new LoginViewModel(input);
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
                return Json(CommandResponse.Ok.AddRedirectUrl(input.ReturnUrl));
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