///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using Mfx1.ReadStack.ReadModel;
using Mfx1.Shared;

namespace MfxDemo1.Models.Task
{
    public class TaskViewModel : ViewModelBase
    {
        public TaskViewModel()
        {
            Task = new PendingTask();
        }

        public PendingTask Task { get; set; }
    }
}