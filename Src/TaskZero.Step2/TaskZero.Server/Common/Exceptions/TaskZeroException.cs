///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System;
using System.Collections.Generic;

namespace TaskZero.Server.Common.Exceptions
{
    public class TaskZeroException : Exception
    {
        public TaskZeroException(string message)
            : this(0, message)
        {
        }
        public TaskZeroException(int code, string message)
            : base(message)
        {
            IsAppSpecificError = true;
            AdditionalInfo = string.Empty;
            StatusCode = code;
            RecoveryLinks = new List<RecoveryLink>();
        }

        public string Title { get; set; }
        public string AdditionalInfo { get; set; }
        public int StatusCode { get; set; }
        public bool IsAppSpecificError { get; set; }
        public List<RecoveryLink> RecoveryLinks { get; private set; }

        public TaskZeroException AddRecoveryLink(string text, string url)
        {
            RecoveryLinks.Add(new RecoveryLink(text, url));
            return this;
        }
        public TaskZeroException AddRecoveryLink(RecoveryLink link)
        {
            RecoveryLinks.Add(link);
            return this;
        }
    }

    public class RecoveryLink
    {
        public RecoveryLink(string text, string url)
        {
            Text = text;
            Url = url;
        }

        public string Text { get; private set; }
        public string Url { get; private set; }
    }
}