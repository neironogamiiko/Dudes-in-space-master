using System.Collections.Generic;

namespace Star_Ship.EventArgs
{
    public class ComponentUpdatedArgs : System.EventArgs
    {
        public IEnumerable<TaskToSolveInfo> Tasks { get; set; }
    }
}