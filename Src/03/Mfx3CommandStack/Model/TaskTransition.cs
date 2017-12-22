//////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//  

using System;

namespace Mfx3.CommandStack.Model
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