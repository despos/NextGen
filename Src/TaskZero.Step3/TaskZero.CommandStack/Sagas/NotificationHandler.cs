///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Memento.Messaging.Postie;
using TaskZero.CommandStack.Commands;
using TaskZero.Shared;

namespace TaskZero.CommandStack.Sagas
{
    public class NotificationHandler : 
        IHandleMessages<AddNewTaskNotifyCommand>,
        IHandleMessages<UpdateTaskNotifyCommand>
    {
        public void Handle(AddNewTaskNotifyCommand message)
        {
            // Notify back
            var hub = new TaskZeroHub(message.SignalrConnectionId);
            hub.NotifyResultOfAddNewTask(message.TaskId, message.Title);
        }

        public void Handle(UpdateTaskNotifyCommand message)
        {
            // Notify back
            var hub = new TaskZeroHub(message.SignalrConnectionId);
            hub.NotifyResultOfUpdateTask(message.TaskId, message.Title);
        }
    }
}