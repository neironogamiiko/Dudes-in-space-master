using System.Collections.Generic;
using Star_Ship;

namespace Task_Generator.EventArgs
{
    public class UpdateTasksListEventArgs : System.EventArgs
    {
        public IEnumerable<TaskToSolveInfo> Info { get; set; }
    }
}