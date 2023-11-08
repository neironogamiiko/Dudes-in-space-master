using System;
using Task_Generator.EventArgs;
using Task_Generator.Tasks;

namespace Task_Generator.Interfaces
{
    public interface ITaskGenerator
    {
        bool IsAnySubscriber { get; }
        int TasksCount { get; }
        event Action<object, TaskEventArgs> OnTaskGenerated;
        ITask GenerateTask(int taskId);
    }
}