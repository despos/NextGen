///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using TaskZero.Server.Models.Home;

namespace TaskZero.Server.Application
{
    public class DashboardService : ApplicationServiceBase
    {
        public TaskIndexViewModel GetTaskIndexViewModel()
        {
            var model = new TaskIndexViewModel();
            return model;
        }
    }
}