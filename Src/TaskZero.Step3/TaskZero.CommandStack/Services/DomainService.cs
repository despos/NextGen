///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Memento.Persistence;

namespace TaskZero.CommandStack.Services
{
    public class DomainService 
    {
        public DomainService(IEventStore eventStore, IRepository repository)
        {
            EventStore = eventStore;
            Repository = repository;
        }

        public IEventStore EventStore { get; }
        public IRepository Repository { get; }
    }
}