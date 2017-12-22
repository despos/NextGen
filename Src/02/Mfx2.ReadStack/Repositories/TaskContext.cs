//////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System.Data.Entity;
using Mfx2.ReadStack.ReadModel;

namespace Mfx2.ReadStack.Repositories
{
    public class TaskContext : DbContext
    {
        public TaskContext()
            : base("MfxDemoDb")
        {
        }

        public DbSet<PendingTask> PendingTasks { get; set; }
    }
}