///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using TaskZero.CommandStack.Model;
using TaskZero.Shared;

namespace TaskZero.Server.Common.Extensions
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