///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;

namespace TaskZero.CommandStack.Model
{
    public class TaskTransition
    {
        public TaskTransition(string action, DateTime when, Task temp)
        {
            Action = action;
            When = when;
            CurrentTask = temp;
        }

        public string Action { get; set; }
        public DateTime When { get; set; }
        public Task CurrentTask { get; set; }
    }
}