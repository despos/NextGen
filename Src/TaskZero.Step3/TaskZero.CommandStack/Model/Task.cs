///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using Expoware.Youbiquitous.Core.Extensions;
using Memento.Domain;
using TaskZero.Shared;
using TaskZero.Shared.Events;

namespace TaskZero.CommandStack.Model
{
    public class Task : Aggregate, 
        IApplyEvent<TaskCreatedEvent>,
        IApplyEvent<TaskUpdatedEvent>,
        IApplyEvent<TaskDeletedEvent>,
        IApplyEvent<TaskCompletedEvent>
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

        public void ApplyEvent(
            [AggregateId("TaskId")] TaskDeletedEvent theEvent)
        {
            Deleted = true;
        }

        public void ApplyEvent(
            [AggregateId("TaskId")] TaskCompletedEvent @event)
        {
            Status = Status.Completed;
        }

        #region BEHAVIOR

        public bool IsSameContent(string title, string description, DateTime? dueDate, Priority priority, Status status)
        {
            // Compare to current values
            var utcDueDate = dueDate?.ToUniversalTime();
            return (Title.EqualsAny(title) &&
                    Description.EqualsAny(description) &&
                    DueDate == utcDueDate &&
                    Priority == priority &&
                    Status == status);
        }

        public bool CanUpdate(string title, string description, DateTime? dueDate, Priority priority, Status status)
        {
            if (title.IsNullOrWhitespace())
                return false;

            // For demo purposes only: not on Sundays
            if (dueDate.HasValue && dueDate.Value.DayOfWeek == DayOfWeek.Sunday)
                return false;
            return true;
        }

        public void UpdateModel(string title, string description, DateTime? dueDate, Priority priority, Status status)
        {
            var updated = new TaskUpdatedEvent(TaskId, title, description, dueDate, priority, status);
            RaiseEvent(updated);
        }

        public void MarkAsDeleted()
        {
            var deleted = new TaskDeletedEvent(TaskId);
            RaiseEvent(deleted);
        }

        public void MarkAsCompleted()
        {
            var completed = new TaskCompletedEvent(TaskId);
            RaiseEvent(completed);
        }
        #endregion

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