///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Mfx1.ReadStack.ReadModel;

namespace Mfx1.Server.Models.Task
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