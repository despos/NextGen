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
using TaskZero.Server.Common.Exceptions;
using TaskZero.Server.Models.Task;
using TaskZero.Shared;

namespace TaskZero.Server.Controllers
{
    [Authorize]
    public class TaskController : AppController 
    {
        private readonly TaskService _service = new TaskService(TaskZeroApplication.Bus);

        #region ADD TASK
        [HttpGet]
        public ActionResult New()
        {
            var model = _service.GetDefaultTask();
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(TaskInputModel input)
        {
            // If it doesn't crash a serious bus has the message
            // in store and will eventually deliver it.
            // To update the UI, you should actually wait for 
            // the operation to complete. It's only started here.
            try
            {
                _service.QueueAddOrSaveTask(input);
            }
            catch (Exception exception)
            {
                return HandleException(exception);
            }

            // Message delivered
            var response = new CommandResponse(true)
                .SetPartial()
                .AddMessage("Delivered");
            return Json(response);
        }
        #endregion

        #region EDIT TASK
        [HttpGet]
        public ActionResult Edit(string id) /* to bypass model binding and possible exceptions on GUID */
        {
            Guid guid;
            var outcome = Guid.TryParse(id, out guid);
            if (!outcome)
                throw new InvalidGuidException("Could not find specified task");

            var model = _service.GetTask(guid);
            return View(model);
        }
        #endregion

    }
}