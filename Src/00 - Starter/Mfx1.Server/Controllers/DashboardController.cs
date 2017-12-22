///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System.Web.Mvc;
using Mfx1.Server.Application;

namespace Mfx1.Server.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly DashboardService _service = new DashboardService();

        public ActionResult Index()
        {
            var model = _service.GetTaskIndexViewModel();
            model.PageTitle = "Step #1";
            return View(model);
        }

        public ActionResult TaskList()
        {
            var model = _service.GetTaskIndexViewModel();
            return PartialView("pv_TaskDashboard", model);
        }
    }
}