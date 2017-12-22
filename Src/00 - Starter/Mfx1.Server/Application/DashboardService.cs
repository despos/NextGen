///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Mfx1.Server.Models.Home;

namespace Mfx1.Server.Application
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