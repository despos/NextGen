///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using Memento;

namespace TaskZero.CommandStack.Commands
{
    public class NotifyCommand : Command
    {
        public NotifyCommand(string connectionId = "")
        {
            SignalrConnectionId = connectionId;
        }

        public string SignalrConnectionId { get; }
    }
}
