//////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Memento.Messaging.Postie;
using Mfx1.ReadStack.ReadModel;
using MfxDemo1.Models.Home;
using System.Linq;
using Mfx1.ReadStack.Repositories;

namespace MfxDemo1.Application
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