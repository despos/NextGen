///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using Expoware.Youbiquitous.Extensions;
using TaskZero.Server.Common;

namespace TaskZero.Server.Models
{
    public class ViewModelBase
    {
        protected ViewModelBase(string pageTitle = "STEP #1")
        {
            Settings = TaskZeroApplication.AppSettings;
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

        public TaskZeroSettings Settings { get; private set; }
    }
}