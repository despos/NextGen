//////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System;
using System.Linq;
using Mfx2.ReadStack.ReadModel;

namespace Mfx2.ReadStack.Repositories
{
    public class ProjectionManager : IDisposable
    {
        private readonly TaskContext _context = null;

        public ProjectionManager()
        {
            _context = new TaskContext();
            _context.Configuration.AutoDetectChangesEnabled = false;
        }

        public IQueryable<PendingTask> PendingTasks => _context.PendingTasks;

        public void Dispose()
        {
            _context?.Dispose();
        }

        public PendingTask FindById(Guid id)
        {
            var task = (from t in PendingTasks where t.TaskId == id select t).SingleOrDefault();
            return task;
        }
    }
}