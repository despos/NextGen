//////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Memento.Messaging.Postie;
using Mfx1.CommandStack.Commands;
using Mfx1.Shared;

namespace Mfx1.CommandStack.Sagas
{
    public class NotificationHandler : 
        IHandleMessages<AddNewTaskNotifyCommand>,
        IHandleMessages<UpdateTaskNotifyCommand>
    {
        public void Handle(AddNewTaskNotifyCommand message)
        {
            // Notify back
            var hub = new MfxHub(message.SignalrConnectionId);
            hub.NotifyResultOfAddNewTask(message.TaskId, message.Title);
        }

        public void Handle(UpdateTaskNotifyCommand message)
        {
            // Notify back
            var hub = new MfxHub(message.SignalrConnectionId);
            hub.NotifyResultOfUpdateTask(message.TaskId, message.Title);
        }
    }
}