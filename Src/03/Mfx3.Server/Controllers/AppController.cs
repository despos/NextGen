///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Expoware.Youbiquitous.Mvc.Filters;
using Mfx3.Shared;
using MfxDemo3.Common.Exceptions;
using MfxDemo3.Models;
using MfxDemo3.Resources;

namespace MfxDemo3.Controllers
{
    public class AppController : Controller
    {
        /// <summary>
        /// Switch the current UI culture
        /// </summary>
        /// <param name="id"></param>
        /// <param name="returnUrl"></param>
        public void Lang(string id, string returnUrl)
        {
            // Set culture to use next
            CultureAttribute.SavePreferredCulture(HttpContext.Response, id);

            // Return to the calling URL (or go to the site's home page)
            HttpContext.Response.Redirect(returnUrl);
        }


        /// <summary>
        /// Generic error page to show in case of unhandled exceptions
        /// </summary>
        /// <returns>HTML</returns>
        public ActionResult Error(Exception exception)
        {
            Response.TrySkipIisCustomErrors = true;
            var code = GetStatusCode(exception);

            var message = string.Format(Strings_Errors.Msg_Error500, code);
            var additionalInfo = string.Empty;
            var appSpecific = (exception is YbqAppException);

            if (code == 404)
            {
                message = Strings_Errors.Msg_Error404;
            }
            if (code == 500)
            {
                if (appSpecific)
                    message = exception.Message;
                else
                {
                    additionalInfo = exception.Message;
                }
            }

            var model = new ErrorViewModel(message, appSpecific)
            {
                ErrorOccurred = { StatusCode = code, AdditionalInfo = additionalInfo }
            };
            if (appSpecific)
            {
                var actualException = (YbqAppException)exception;
                model.ErrorOccurred.RecoveryLinks.Clear();
                model.ErrorOccurred.RecoveryLinks.AddRange(actualException.RecoveryLinks);
            }
            return View("error", model);
        }

        [NonAction]
        public ActionResult HandleException(Exception exception, bool showFriendlyMessage = true)
        {
            try
            {
                // LogException(exception);
            }
            catch (Exception)
            {
                // Nothing to do
            }

            var msg = CreateMessageFromException(exception);
            return Json(CommandResponse.Fail.AddMessage(msg));
        }

        #region PRIVATE
        private static int GetStatusCode(Exception exception)
        {
            var httpException = exception as HttpException;
            if (httpException == null)
                return (int)HttpStatusCode.InternalServerError;
            return httpException.GetHttpCode();
        }

        private string CreateMessageFromException(Exception exception)
        {
            // Used in JSON response

            var message = Strings_Errors.Msg_Error500;
            if (exception is YbqAppException)
                message = exception.Message;
            return message;
        }
        #endregion
    }
}