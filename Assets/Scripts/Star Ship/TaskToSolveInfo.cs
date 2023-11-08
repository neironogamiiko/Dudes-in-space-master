using UnityEngine;

namespace Star_Ship
{
    public class TaskToSolveInfo
    {
        public string ComponentName { get; set; }
        public float Time { get; set; }
        public Roles RoleToSolve { get; set; }
        public Sprite Icon { get; set; }
        public int TasksInQueue { get; set; }
    }
}