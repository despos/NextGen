///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using Mfx1.Server.Common.Exceptions;
using Mfx1.Server.Resources;

namespace Mfx1.Server.Models
{
    public class ErrorViewModel : ViewModelBase
    {
        public ErrorViewModel(string message, bool isAppSpecific = false)
        {
            ErrorOccurred = new MfxAppException(message)
            {
                Title = Strings_Errors.Msg_SomethingWentWrong,
                IsAppSpecificError = isAppSpecific
            };
        }

        public MfxAppException ErrorOccurred { get; private set; }
    }
}