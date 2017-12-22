//////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using Memento;

namespace Mfx2.Shared.Events
{
    public class TaskCompletedEvent : DomainEvent
    {
        public TaskCompletedEvent(Guid id)
        {
            TaskId = id;
        }

        public Guid TaskId { get; set; }
    }
}