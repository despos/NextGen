///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using TaskZero.Shared;

namespace TaskZero.ReadStack.ReadModel
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