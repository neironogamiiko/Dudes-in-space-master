using Star_Ship;

namespace Task_Generator.Tasks
{
    public class ShturmanTask : ITask
    {
        public float Time { get; } = 20f;
        public Roles RoleToSolve => Roles.Shturman;
    }
}