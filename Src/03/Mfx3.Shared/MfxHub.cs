///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using Microsoft.AspNet.SignalR;

namespace Mfx3.Shared
{
    public class MfxHub : Hub
    {
        private readonly string _connectionId;
        public MfxHub(string connectionId)
        {
            _connectionId = connectionId;
        }

        public void NotifyResultOfAddNewTask(Guid taskId, string title)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<MfxHub>();
            hubContext
                .Clients
                .Client(_connectionId)
                .notifyResultOfAddNewTask(taskId.ToString(), title);
        }

        public void NotifySuccessfulUpdate(Guid taskId, string title)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<MfxHub>();
            hubContext
                .Clients
                .Client(_connectionId)
                .notifySuccessfulUpdate(taskId.ToString(), title);
        }

        public void NotifyNoChangesUpdate(Guid taskId, string title)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<MfxHub>();
            hubContext
                .Clients
                .Client(_connectionId)
                .notifyNoChangesUpdate(taskId.ToString(), title);
        }

        public void NotifyCantUpdate(Guid taskId, string title)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<MfxHub>();
            hubContext
                .Clients
                .Client(_connectionId)
                .notifyCantUpdate(taskId.ToString(), title);
        }
    }
}