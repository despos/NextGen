///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using Memento.Domain;
using TaskZero.Shared;
using TaskZero.Shared.Events;

namespace TaskZero.CommandStack.Model
{
    public class Task : Aggregate, IApplyEvent<TaskCreatedEvent>
    {
        public Task()
        {
            Priority = Priority.Normal;
            Status = Status.ToDo;
            Enabled = true;
            Deleted = false;
        }

        // COMMON PROPERTIES
        public bool Deleted { get; set; }
        public bool Enabled { get; set; }

        // SPECIFIC PROPERTIES
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }

        public void ApplyEvent(
            [AggregateId("TaskId")] TaskCreatedEvent theEvent)
        {
            TaskId = theEvent.TaskId;
            Title = theEvent.Title;
            Description = theEvent.Description;
            DueDate = theEvent.DueDate;
            Priority = theEvent.Priority;
        }

        public void ApplyEvent(
            [AggregateId("TaskId")] TaskUpdatedEvent theEvent)
        {
            // No need to change TaskId 

            // Copy values over
            Title = theEvent.Title;
            Description = theEvent.Description;
            DueDate = theEvent.DueDate;
            Priority = theEvent.Priority;
            Status = theEvent.Status;
        }

        public void UpdateModel(string title, string description, DateTime? dueDate, Priority priority, Status status)
        {
            var updated = new TaskUpdatedEvent(TaskId, title, description, dueDate, priority, status);
            RaiseEvent(updated);
        }

        public static class Factory
        {
            public static Task NewTaskFrom(string title, string descrition, DateTime? dueDate = null, Priority priority = Priority.Normal)
            {
                var task = new Task();
                var created = new TaskCreatedEvent(Guid.NewGuid(), title, descrition, dueDate, priority);
                task.RaiseEvent(created);
                return task;
            }
        }
    }
}