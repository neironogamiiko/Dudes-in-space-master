using Task_Generator.Tasks;

namespace Task_Generator.EventArgs
{
    public class TaskEventArgs : System.EventArgs
    {
        // IsSpecial - определяет будет ли это таск, или ивент. true - событие, false - таск.
        public TaskEventArgs(ITask task)
        {
            TaskInstance = task;
        }

        public ITask TaskInstance { get; }
    }
}