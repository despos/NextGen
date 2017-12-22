///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Mfx2.ReadStack.ReadModel;

namespace MfxDemo2.Models.Task
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