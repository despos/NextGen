///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using TaskZero.ReadStack.ReadModel;
using TaskZero.Shared;

namespace TaskZero.Server.Common.Extensions
{
    public static class PendingTaskExtensions  
    {
        public static string ToColor(this PendingTask pendingTask, Priority priority)
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

        public static DateTime DueDateForDisplay(this PendingTask pendingTask)
        {
            return pendingTask.DueDate ?? DateTime.MaxValue;
        }

        public static string EffortForDisplay(this PendingTask pendingTask)
        {
            var effort = "";
            if (pendingTask.Status == Status.Completed)
            {
                if (pendingTask.StartDate.HasValue && pendingTask.CompletionDate.HasValue)
                {
                    var ts = pendingTask.CompletionDate.Value - pendingTask.StartDate.Value;
                    if (ts.Days <= 0)
                        return "Less than a day";
                    effort = String.Format("{0} day(s)", ts.Days);
                }
            }
            return effort;
        }
    }
}