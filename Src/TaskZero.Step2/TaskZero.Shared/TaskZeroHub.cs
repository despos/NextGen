///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System;
using Microsoft.AspNet.SignalR;

namespace TaskZero.Shared
{
    public class TaskZeroHub : Hub
    {
        private readonly string _connectionId;
        public TaskZeroHub(string connectionId)
        {
            _connectionId = connectionId;
        }

        public void NotifyResultOfAddNewTask(Guid taskId, string title)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<TaskZeroHub>();
            hubContext
                .Clients
                .Client(_connectionId)
                .notifyResultOfAddNewTask(taskId.ToString(), title);
        }

        public void NotifyResultOfUpdateTask(Guid taskId, string title)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<TaskZeroHub>();
            hubContext
                .Clients
                .Client(_connectionId)
                .notifyResultOfUpdateTask(taskId.ToString(), title);
        }
    }
}