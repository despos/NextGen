///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using TaskZero.ReadStack.ReadModel;

namespace TaskZero.Server.Models.Task
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