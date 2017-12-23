///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System.Web.Mvc;
using TaskZero.Server.Application;

namespace TaskZero.Server.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly DashboardService _service = new DashboardService(TaskZeroApplication.Bus);

        public ActionResult Index()
        {
            var model = _service.GetTaskIndexViewModel();
            return View(model);
        }

        public ActionResult TaskList()
        {
            var model = _service.GetTaskIndexViewModel();
            return PartialView("pv_TaskDashboard", model);
        }
    }
}