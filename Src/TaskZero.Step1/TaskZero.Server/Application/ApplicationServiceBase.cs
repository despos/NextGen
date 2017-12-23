///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using Memento.Messaging.Postie;

namespace TaskZero.Server.Application
{
    public class ApplicationServiceBase
    {
        public ApplicationServiceBase(IBus bus)
        {
            Bus = bus;
        }
        public IBus Bus { get; }
    }
}