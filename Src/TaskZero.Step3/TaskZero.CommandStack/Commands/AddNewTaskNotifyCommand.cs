﻿///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System;

namespace TaskZero.CommandStack.Commands
{
    public class AddNewTaskNotifyCommand : NotifyCommand
    {
        public AddNewTaskNotifyCommand(string connectionId) 
            : base(connectionId)
        {
        }

        public Guid TaskId { get; set; }
        public string Title { get; set; }
    }
}
