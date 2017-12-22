///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using Mfx1.Shared;

namespace Mfx1.Server.Models.Task
{
    public class TaskInputModel  
    {
        public TaskInputModel()
        {
            DueDate = null;
            Priority = Priority.NotSet;
            Status = Status.ToDo;
        }

        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }

        public string SignalrConnectionId { get; set; }
    }
}