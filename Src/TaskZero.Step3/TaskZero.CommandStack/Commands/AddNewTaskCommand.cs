///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System;
using TaskZero.Shared;

namespace TaskZero.CommandStack.Commands
{
    public class AddNewTaskCommand : NotifyCommand
    {
        public AddNewTaskCommand(string title, 
            string description, 
            DateTime? dueDate, 
            Priority priority, 
            string connectionId) : base(connectionId)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Priority Priority { get; set; }
    }
}