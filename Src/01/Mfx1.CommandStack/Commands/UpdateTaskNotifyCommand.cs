//////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System;

namespace Mfx1.CommandStack.Commands
{
    public class UpdateTaskNotifyCommand : NotifyCommand
    {
        public UpdateTaskNotifyCommand(string connectionId) 
            : base(connectionId)
        {
        }

        public Guid TaskId { get; set; }
        public string Title { get; set; }
    }
}
