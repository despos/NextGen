﻿///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using MfxDemo1.Common;
using Expoware.Youbiquitous.Extensions;

namespace MfxDemo1.Models
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

        public YbqAppSettings Settings { get; private set; }
    }
}