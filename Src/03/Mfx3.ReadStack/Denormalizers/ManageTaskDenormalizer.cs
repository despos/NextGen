//////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using System.Linq;
using Memento.Messaging.Postie;
using Mfx3.ReadStack.ReadModel;
using Mfx3.ReadStack.Repositories;
using Mfx3.Shared;
using Mfx3.Shared.Events;

namespace Mfx3.ReadStack.Denormalizers
{
    public class ManageTaskDenormalizer :
        IHandleMessages<TaskCreatedEvent>,
        IHandleMessages<TaskUpdatedEvent>,
        IHandleMessages<TaskDeletedEvent>,
        IHandleMessages<TaskCompletedEvent>
    {
        public void Handle(TaskCreatedEvent message)
        {
            var task = new PendingTask
            {
                TaskId = message.TaskId,
                Title = message.Title,
                Description = message.Description,
                DueDate = message.DueDate,
                Priority = message.Priority,
                Status = Status.ToDo        // Default status for new tasks (by design)
            };

            using (var context = new TaskContext())
            {
                context.PendingTasks.Add(task);
                context.SaveChanges();
            }
        }

        public void Handle(TaskUpdatedEvent message)
        {
            using (var context = new TaskContext())
            {
                var task = (from t in context.PendingTasks 
                            where t.TaskId == message.TaskId
                            select t).SingleOrDefault();
                if (task == null)
                    return;

                task.Title = message.Title;
                task.Description = message.Description;
                task.DueDate = message.DueDate;
                task.Priority = message.Priority;
                task.Status = message.Status;
                if (message.Status == Status.Completed)
                {
                    task.CompletionDate = DateTime.Today;
                }
                if (message.Status == Status.InProgress && 
                    task.Status != Status.InProgress)
                {
                    task.StartDate = DateTime.Today;
                    task.CompletionDate = null;
                }

                context.SaveChanges();
            }
        }

        public void Handle(TaskDeletedEvent message)
        {
            using (var context = new TaskContext())
            {
                var task = (from t in context.PendingTasks
                    where t.TaskId == message.TaskId
                    select t).SingleOrDefault();
                if (task == null)
                    return;

                context.PendingTasks.Remove(task);
                context.SaveChanges();
            }
        }

        public void Handle(TaskCompletedEvent message)
        {
            using (var context = new TaskContext())
            {
                var task = (from t in context.PendingTasks
                    where t.TaskId == message.TaskId
                    select t).SingleOrDefault();
                if (task == null)
                    return;

                task.Status =Status.Completed;
                task.CompletionDate = message.TimeStamp.Date;
                if (!task.StartDate.HasValue)
                    task.StartDate = message.TimeStamp.Date;
                context.SaveChanges();
            }
        }
    }
}