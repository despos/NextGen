///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Web.Mvc;
using Mfx1.Server.Models;

namespace Mfx1.Server.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(ViewModelBase.Default());
        }
    }
}