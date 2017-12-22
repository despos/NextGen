//////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Memento.Messaging.Postie;
using Memento.Persistence;
using Mfx1.CommandStack.Commands;
using Mfx1.CommandStack.Model;

namespace Mfx1.CommandStack.Sagas
{
    public class ManageTaskSaga : Saga,
        IAmStartedBy<AddNewTaskCommand>,
        IHandleMessages<UpdateTaskCommand>,
        IHandleMessages<DeleteTaskCommand>
    {
        public ManageTaskSaga(IBus bus, IEventStore eventStore, IRepository repository)
            : base(bus, eventStore, repository)
        {
        }

        public void Handle(AddNewTaskCommand message)
        {
            var task = Task.Factory.NewTaskFrom(
                message.Title, message.Description, message.DueDate, message.Priority);
            Repository.Save(task);

            // Notify back
            var notification = new AddNewTaskNotifyCommand(message.SignalrConnectionId)
            {
                TaskId = task.TaskId,
                Title = task.Title
            };
            Bus.Send(notification);
        }

        public void Handle(UpdateTaskCommand message)
        {
            // Dehydrates all events from event store for given aggregate
            var task = Repository.GetById<Task>(message.TaskId);

            // Triggers the UPDATE-GENERAL event
            task.UpdateModel(message.Title, message.Description, message.DueDate, message.Priority, message.Status);
            Repository.Save(task);

            // Notify back
            var notification = new UpdateTaskNotifyCommand(message.SignalrConnectionId)
            {
                TaskId = task.TaskId,
                Title = task.Title
            };
            Bus.Send(notification);
        }

        public void Handle(DeleteTaskCommand message)
        {
            var task = Repository.GetById<Task>(message.TaskId);
            task.MarkAsDeleted();
            Repository.Save(task);
        }
    }
}