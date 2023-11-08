using Star_Ship;

namespace Task_Generator.Tasks
{
    public class EngineerTask : ITask
    {
        public float Time { get; } = 15f;
        public Roles RoleToSolve => Roles.Electric;
    }
}