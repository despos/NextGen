///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using Memento;

namespace TaskZero.Shared.Events
{
    public class TaskUpdatedEvent : DomainEvent
    {
        public TaskUpdatedEvent(Guid id, string title, string description, DateTime? dueDate, Priority priority, Status status)
        {
            TaskId = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Status = status;
        }

        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
