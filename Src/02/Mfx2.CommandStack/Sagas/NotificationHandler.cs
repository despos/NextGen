//////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Memento.Messaging.Postie;
using Mfx2.CommandStack.Commands;
using Mfx2.Shared;

namespace Mfx2.CommandStack.Sagas
{
    public class NotificationHandler : 
        IHandleMessages<AddNewTaskNotifyCommand>,
        IHandleMessages<UpdateTaskNotifyCommand>,
        IHandleMessages<NoUpdatesNotifyCommand>,
        IHandleMessages<CantUpdateNotifyCommand>
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
            hub.NotifySuccessfulUpdate(message.TaskId, message.Title);
        }
        
        public void Handle(NoUpdatesNotifyCommand message)
        {
            // Notify back
            var hub = new MfxHub(message.SignalrConnectionId);
            hub.NotifyNoChangesUpdate(message.TaskId, message.Title);
        }

        public void Handle(CantUpdateNotifyCommand message)
        {
            // Notify back
            var hub = new MfxHub(message.SignalrConnectionId);
            hub.NotifyCantUpdate(message.TaskId, message.Title);
        }
    }
}