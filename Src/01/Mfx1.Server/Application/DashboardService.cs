//////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Linq;
using Memento.Messaging.Postie;
using Mfx1.ReadStack.Repositories;
using Mfx1.Server.Models.Home;

namespace Mfx1.Server.Application
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