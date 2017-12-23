///////////////////////////////////////////////////////////////////
//
// NEXT-GEN demos
// Copyright (c) Youbiquitous srls 2018
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using Memento;
using Memento.Messaging.Postie;
using TaskZero.Server.Models.Home;
using TaskZero.Server.Models.Task;

namespace TaskZero.Server.Application
{
    public class TaskService : ApplicationServiceBase
    {
        public TaskService(IBus bus) : base(bus)
        {
        }


        #region QUERY methods
        public TaskViewModel GetDefaultTask()
        {
            var model = new TaskViewModel();
            return model;
        }
        #endregion


        #region COMMAND methods
        public void QueueAddOrSaveTask(TaskInputModel input)
        {
            var command = new AddNewTaskCommand(
                input.Title,
                input.Description,
                input.DueDate,
                input.Priority,
                input.SignalrConnectionId);
            Bus.Send(command);
        }
        #endregion
    }
}