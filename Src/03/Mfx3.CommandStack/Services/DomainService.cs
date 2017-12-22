//////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Memento.Persistence;

namespace Mfx3.CommandStack.Services
{
    public class DomainService
    {
        public DomainService(IEventStore eventStore, IRepository repository)
        {
            EventStore = eventStore;
            Repository = repository;
        }

        public IEventStore EventStore { get; private set; }
        public IRepository Repository { get; private set; }
    }
}