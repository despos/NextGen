//////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using Memento;

namespace Mfx1.CommandStack.Commands
{
    public class NotifyCommand : Command
    {
        public NotifyCommand(string connectionId = "")
        {
            SignalrConnectionId = connectionId;
        }

        public string SignalrConnectionId { get; private set; }
    }
}
