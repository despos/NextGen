///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Collections.Generic;
using Mfx1.ReadStack.ReadModel;
using Mfx1.Shared;

namespace MfxDemo1.Models.Home
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