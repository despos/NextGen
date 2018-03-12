///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Linq;
using Memento.Messaging.Postie;
using TaskZero.ReadStack.Repositories;
using TaskZero.Server.Models.Home;

namespace TaskZero.Server.Application
{
    public class DashboardService : ApplicationServiceBase
    {
        private readonly ProjectionManager _manager = new ProjectionManager();

        public DashboardService(IBus bus) : base(bus)
        {
        }

        public TaskIndexViewModel GetTaskIndexViewModel()
        {
            var model = new TaskIndexViewModel
            {
                Tasks = (from t in _manager.PendingTasks select t).ToList()
            };
            return model;
        }
    }
}