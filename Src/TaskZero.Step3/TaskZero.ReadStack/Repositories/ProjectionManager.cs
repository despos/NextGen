///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System;
using System.Linq;
using TaskZero.ReadStack.ReadModel;

namespace TaskZero.ReadStack.Repositories
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