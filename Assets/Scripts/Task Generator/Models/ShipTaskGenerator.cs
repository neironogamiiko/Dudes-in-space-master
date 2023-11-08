using System;
using Task_Generator.EventArgs;
using Task_Generator.Factories;
using Task_Generator.Interfaces;
using Task_Generator.Tasks;

namespace Task_Generator.Models
{
    public class ShipTaskGenerator : ITaskGenerator
    {
        private readonly IFactory[] taskList =
        {
            new FactoryEngineerTask(),
            new FactoryMechanicTask(),
            new FactoryMedicTask(),
            new FactoryScientistTask(),
            new FactoryShturmanTask()
        };

        public event Action<object, TaskEventArgs> OnTaskGenerated;
        public bool IsAnySubscriber => OnTaskGenerated != null;
        public int TasksCount => taskList.Length;

        public ITask GenerateTask(int id)
        {
            var task = taskList[id].Create();
            OnTaskGenerated?.Invoke(this, new TaskEventArgs(task));
            return task;
        }
    }
}