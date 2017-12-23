///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Memento.Messaging.Postie;
using TaskZero.ReadStack.ReadModel;
using TaskZero.ReadStack.Repositories;
using TaskZero.Shared;
using TaskZero.Shared.Events;

namespace TaskZero.ReadStack.Denormalizers
{
    public class ManageTaskDenormalizer :
        IHandleMessages<TaskCreatedEvent> 
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
    }
}