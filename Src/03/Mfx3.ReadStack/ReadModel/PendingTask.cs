//////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using Mfx3.Shared;

namespace Mfx3.ReadStack.ReadModel
{
    public class PendingTask : Dto
    {
        public Guid TaskId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? StartDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}