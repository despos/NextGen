///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Memento.Messaging.Postie;

namespace MfxDemo1.Application
{
    public class ApplicationServiceBase
    {
        public ApplicationServiceBase(IBus bus)
        {
            Bus = bus;
        }
        public IBus Bus { get;  }
    }
}