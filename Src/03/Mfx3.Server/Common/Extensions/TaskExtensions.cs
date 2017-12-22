// /////////////////////////////////////////////////////////////////
// 
// MfxDemo1
// Copyright (c) Youbiquitous srls 2017
// 
// Author: Dino Esposito (http://youbiquitous.net)
//  

using Mfx3.CommandStack.Model;
using Mfx3.Shared;

namespace MfxDemo3.Common.Extensions
{
    public static class TaskExtensions  
    {
        public static string ToColor(this Task pendingTask, Priority priority)
        {
            switch (priority)
            {
                case Priority.Urgent:
                    return "#f00";
                case Priority.High:
                    return "#f80";
                case Priority.Normal:
                    return "#0c0";
                case Priority.Low:
                    return "#0f8";
                default:
                    return "transparent";
            }
        }

        
    }
}