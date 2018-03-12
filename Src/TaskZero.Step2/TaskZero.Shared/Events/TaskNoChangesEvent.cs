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
    public class TaskNoChangesEvent : DomainEvent
    {
        public TaskNoChangesEvent(Guid id)
        {
            TaskId = id;
        }

        public Guid TaskId { get; set; }
    }
}