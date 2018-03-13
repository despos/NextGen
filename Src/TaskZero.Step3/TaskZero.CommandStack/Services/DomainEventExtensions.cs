///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Memento;

namespace TaskZero.CommandStack.Services
{
    public static class DomainEventExtensions
    {
        public static string ShortName(this DomainEvent theEvent)
        {
            var type = theEvent.GetType().ToString().ToLower();
            if (type.Contains("created"))
                return "CREATED";
            if (type.Contains("completed"))
                return "COMPLETED";
            if (type.Contains("deleted"))
                return "DELETED";
            if (type.Contains("updated"))
                return "UPDATED";
            return "";
        }
    }
}