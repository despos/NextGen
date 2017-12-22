///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Configuration;
using System.Web.Configuration;
using System.Web.Mvc;
using MfxDemo1.Models;

namespace MfxDemo1.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(ViewModelBase.Default());
        }

        public ActionResult Encrypt()
        {
            ProtectSection("connectionStrings", "RSAProtectedConfigurationProvider");
            return RedirectToAction("index");
        }

        public ActionResult Decrypt()
        {
            UnprotectSection("connectionStrings");
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