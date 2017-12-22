///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Collections.Generic;
using Mfx1.ReadStack.ReadModel;

namespace Mfx1.Server.Models.Home
{
    public class TaskIndexViewModel : ViewModelBase
    {
        public TaskIndexViewModel()
        {
            Tasks = new List<PendingTask>();
        }

        public IList<PendingTask> Tasks { get; set; }
    }
}