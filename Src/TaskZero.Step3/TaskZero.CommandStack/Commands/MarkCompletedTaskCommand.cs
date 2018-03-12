///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System;

namespace TaskZero.CommandStack.Commands
{
    public class MarkCompletedTaskCommand : NotifyCommand
    {
        public MarkCompletedTaskCommand(Guid id,
            string connectionId) : base(connectionId)
        {
            TaskId = id;
        }

        public Guid TaskId { get; set; }
    }
}