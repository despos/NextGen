///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System.Web.Mvc;
using MfxDemo2.Application;

namespace MfxDemo2.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly DashboardService _service = new DashboardService(MfxApplication.Bus);

        public ActionResult Index()
        {
            var model = _service.GetTaskIndexViewModel();
            model.PageTitle = "Step #2";
            return View(model);
        }

        public ActionResult TaskList()
        {
            var model = _service.GetTaskIndexViewModel();
            return PartialView("pv_TaskDashboard", model);
        }
    }
}