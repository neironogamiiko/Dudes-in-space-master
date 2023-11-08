using System.Collections.Generic;
using Task_Generator.Interfaces;
using Task_Generator.Tasks;

namespace Task_Generator.Models
{
    public class TasksList : Component
    {
        protected IMediator _dialog;

        public TasksList(IMediator dialog)
            : base(dialog)
        {
        }

        private IEnumerable<ITask> _tasks { get; set; }

        public void AssignNewTasks(IEnumerable<ITask> newTasks)
        {
            _tasks = newTasks;
        }
    }
}