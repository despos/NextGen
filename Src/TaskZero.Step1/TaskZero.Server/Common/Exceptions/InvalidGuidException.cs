///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


namespace TaskZero.Server.Common.Exceptions
{
    public class InvalidGuidException : TaskZeroException
    {
        public InvalidGuidException(string message) : base(message)
        {
        }

        public InvalidGuidException(int code, string message) : base(code, message)
        {
        }

    }
}