///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Web.Configuration;
using System.Web.Mvc;
using TaskZero.Server.Application;
using TaskZero.Server.Models;

namespace TaskZero.Server.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly TaskService _service = new TaskService(TaskZeroApplication.Bus);

        public ActionResult Index()
        {
            var model = ViewModelBase.Default("ADMIN");
            return View(model);
        }
        
        public ActionResult ConfigEncrypt()
        {
            ProtectSection("connectionStrings", "RSAProtectedConfigurationProvider");
            return RedirectToAction("index");
        }

        public ActionResult ConfigDecrypt()
        {
            UnprotectSection("connectionStrings");
            return RedirectToAction("index");
        }

        public ActionResult ReadModel()
        {
            _service.RegenerateReadModel();
            return RedirectToAction("index");
        }

        private void ProtectSection(string sectionName, string provider)
        {
            var config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
            var section = config.GetSection(sectionName);

            if (section != null && !section.SectionInformation.IsProtected)
            {
                section.SectionInformation.ProtectSection(provider);
                config.Save();
            }
        }

        private void UnprotectSection(string sectionName)
        {
            var config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
            var section = config.GetSection(sectionName);

            if (section != null && section.SectionInformation.IsProtected)
            {
                section.SectionInformation.UnprotectSection();
                config.Save();
            }
        }
    }
}