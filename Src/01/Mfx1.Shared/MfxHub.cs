///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using System.Threading;
using Microsoft.AspNet.SignalR;

namespace Mfx1.Shared
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

        public void NotifyResultOfUpdateTask(Guid taskId, string title)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<MfxHub>();
            hubContext
                .Clients
                .Client(_connectionId)
                .notifyResultOfUpdateTask(taskId.ToString(), title);
        }
    }
}