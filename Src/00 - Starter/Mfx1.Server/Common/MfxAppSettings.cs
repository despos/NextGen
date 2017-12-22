///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System;
using System.Configuration;
using Expoware.Youbiquitous.Extensions;
using Expoware.Youbiquitous.Mvc.Features.Localization;

namespace Mfx1.Server.Common
{
    public class MfxAppSettings
    {
        protected MfxAppSettings()
        {
            CultureManager = CultureManager.Empty();
        }

        /// <summary>
        /// Application title
        /// </summary>
        public string ApplicationTitle { get; private set; }

        /// <summary>
        /// Whether it should provide internal details of unexpected 500 errors
        /// </summary>
        public bool ShouldShowErrorDetails { get; private set; }

        /// <summary>
        /// Indicates the tier of the app and determines the features to enable.
        /// </summary>
        public int ApplicationTier { get; private set; }

        /// <summary>
        /// Lists the cultures supported by the application
        /// </summary>
        public CultureManager CultureManager { get; private set; }

        public static MfxAppSettings Initialize()
        {
            var titleBase0 = ConfigurationManager.AppSettings["sk:app-title-base0"] ?? String.Empty;
            var shouldShowErrorDetails = (ConfigurationManager.AppSettings["sk:show-error-details"] ?? "false").ToBool();
            var appLevel = (ConfigurationManager.AppSettings["sk:app-tier"] ?? "0").ToInt();
            var cultures = ConfigurationManager.AppSettings["sk:app-supported-cultures"] ?? String.Empty;

            var settings = new MfxAppSettings
            {
                ApplicationTitle = String.Format("{0}", titleBase0),
                ShouldShowErrorDetails = shouldShowErrorDetails,
                ApplicationTier = appLevel,
                CultureManager = CultureManager.Import(cultures)
            };

            return settings;
        }
    }
}