using Star_Ship;

namespace Task_Generator.Tasks
{
    public class MedicTask : ITask
    {
        public float Time { get; } = 15f;
        Roles ITask.RoleToSolve => Roles.Medic;
    }
}