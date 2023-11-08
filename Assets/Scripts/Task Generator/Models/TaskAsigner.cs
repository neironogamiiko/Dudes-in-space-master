using System;
using System.Collections.Generic;
using Game_Events;
using Star_Ship.Interfaces;
using Task_Generator.Interfaces;
using Task_Generator.Tasks;
using Timer.EventArgs;
using Timer.Interfaces;
using Random = UnityEngine.Random;

namespace Task_Generator.Models
{
    public class TaskAsigner : Component
    {
        private int _daysCounter;
        private ISpaceShip _spaceShip;

        private List<ITask> _tasks;
        private readonly IShipDayTimer _timer;

        public TaskAsigner(IMediator dialog, IShipDayTimer timer)
            : base(dialog)
        {
            _timer = timer;
            TaskGeneratorInstance = new ShipTaskGenerator();
            ShipEventGenerator = new ShipEventGenerator();
            _timer.OnNewDayStarted += OnNewDayStarted;
        }

        public ITaskGenerator TaskGeneratorInstance { get; }

        public IShipEventGenerator ShipEventGenerator { get; }

        public int TasksNumber => 1 + _daysCounter / 2;

        private void OnNewDayStarted(object sender, ShipDayArgs args)
        {
            _daysCounter = args.Days;
            if (args.IsSpecial)
                throw new NotImplementedException("Special events");
            // to do event logic;
            // ShipEventGenerator.GenerateEvent();
            // to do Implement interface

            GenerateNewTasks();
        }

        private int[] GenerateTaskIds()
        {
            var taskIds = new int[TasksNumber];

            for (var i = 0; i < TasksNumber; i++) taskIds[i] = Random.Range(0, TaskGeneratorInstance.TasksCount);

            return taskIds;
        }

        private void GenerateNewTasks()
        {
            if (_tasks == null)
                _tasks = new List<ITask>();

            var taskIds = GenerateTaskIds();

            for (var i = 0; i < TasksNumber; i++)
            {
                var id = taskIds[i];
                _tasks.Add(TaskGeneratorInstance.GenerateTask(id));
            }
        }
    }
}