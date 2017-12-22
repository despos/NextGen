///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Linq;
using System.Web.Mvc;
using MfxDemo1.Common.Features.AutoComplete;
using Expoware.Youbiquitous.Mvc.Features.AutoComplete;

namespace MfxDemo1.Controllers
{
    public class HintController : Controller
    {
        public JsonResult Countries([Bind(Prefix = "q")] string filter = "")
        {
            var list = (from country in SampleCountryRepository.AllBy(filter)
                        select new AutoCompleteItem()
                        {
                            id = country.ThreeLetterISOLanguageName,
                            label = country.ThreeLetterISOLanguageName,
                            value = country.DisplayName
                        }).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}