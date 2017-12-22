//////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//  

using System;
using System.Collections.Generic;

namespace Mfx3.CommandStack.Model
{
    public class TaskHistory
    {
        public TaskHistory(Guid taskId, DateTime when, IEnumerable<TaskTransition> transitions)
        {
            TaskId = taskId;
            When = when;
            Events = transitions;
        }

        public Guid TaskId { get; set; }
        public DateTime When { get; set; }
        public IEnumerable<TaskTransition> Events { get; }
    }
}