///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using Expoware.Youbiquitous.Extensions;
using Mfx1.Server.Common;

namespace Mfx1.Server.Models
{
    public class ViewModelBase
    {
        protected ViewModelBase(string pageTitle = "")
        {
            Settings = MfxApplication.AppSettings;
            if (pageTitle.IsNullOrWhitespace())
                pageTitle = Settings.ApplicationTitle;
            PageTitle = pageTitle;
        }

        public static ViewModelBase Default(string title = "")
        {
            var model = new ViewModelBase(title);
            return model;
        }

        public string PageTitle { get; set; }

        public MfxAppSettings Settings { get; private set; }
    }
}