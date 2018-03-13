///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using System.Collections.Generic;
using System.Linq;
using Memento.Persistence;
using TaskZero.CommandStack.Model;
using TaskZero.Shared.Events;

namespace TaskZero.CommandStack.Services
{
    public class HistoryService : DomainService
    {
        public HistoryService(IEventStore eventStore, IRepository repository)
            : base(eventStore, repository)
        {
        }

        public TaskHistory GetTaskHistory(Guid taskId, DateTime? when)
        {
            if (!when.HasValue)
                when = DateTime.Now;

            var eventMapping = new List<EventMapping>
            {
                new EventMapping {AggregateIdPropertyName = "TaskId", EventType = typeof (TaskCreatedEvent)},
                new EventMapping {AggregateIdPropertyName = "TaskId", EventType = typeof (TaskDeletedEvent)},
                new EventMapping {AggregateIdPropertyName = "TaskId", EventType = typeof (TaskCompletedEvent)},
                new EventMapping {AggregateIdPropertyName = "TaskId", EventType = typeof (TaskUpdatedEvent)},
            };

            var taskEvents = EventStore.RetrieveEvents(taskId, when.Value, eventMapping, null).ToList();
            var transitions = new List<TaskTransition>();
            foreach (var ev in taskEvents.OrderBy(e => e.TimeStamp))
            {
                var task = Repository.GetById<Task>(taskId, ev.TimeStamp);
                if (task.DueDate.HasValue)
                    task.DueDate = task.DueDate.Value.ToLocalTime();
                transitions.Add(new TaskTransition(ev.ShortName(), ev.TimeStamp, task));
            }

            var history = new TaskHistory(taskId, when.Value, transitions);
            return history;
        }
    }
}