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
using TaskZero.CommandStack.Commands;
using TaskZero.ReadStack.Repositories;
using TaskZero.Server.Models.Task;

namespace TaskZero.Server.Application
{
    public class TaskService : ApplicationServiceBase
    {
        private readonly ProjectionManager _manager = new ProjectionManager();

        public TaskService(IBus bus) : base(bus)
        {
        }


        #region QUERY methods
        public TaskViewModel GetDefaultTask()
        {
            var model = new TaskViewModel();
            return model;
        }

        public TaskViewModel GetTask(Guid id)
        {
            var model = new TaskViewModel { Task = _manager.FindById(id) };
            return model;
        }
        #endregion


        #region COMMAND methods
        public void QueueAddOrSaveTask(TaskInputModel input)
        {
            Command command;
            var isNewTask = (input.TaskId == Guid.Empty);
            if (isNewTask)
            {
                command = new AddNewTaskCommand(
                    input.Title,
                    input.Description,
                    input.DueDate,
                    input.Priority,
                    input.SignalrConnectionId);
            }
            else
            {
                command = new UpdateTaskCommand(
                    input.TaskId,
                    input.Title,
                    input.Description,
                    input.DueDate,
                    input.Priority,
                    input.Status,
                    input.SignalrConnectionId);
            }

            Bus.Send(command);
        }

        public void QueueDeleteTask(Guid id, string signalrConnectionId)
        {
            var command = new DeleteTaskCommand(id, signalrConnectionId);
            Bus.Send(command);
        }

        public void QueueCompleteTask(Guid id, string signalrConnectionId)
        {
            var command = new MarkCompletedTaskCommand(id, signalrConnectionId);
            Bus.Send(command);
        }

        public void RegenerateReadModel()
        {
            var command = new RegenerateReadModelCommand();
            Bus.Send(command);
        }
        #endregion
    }
}