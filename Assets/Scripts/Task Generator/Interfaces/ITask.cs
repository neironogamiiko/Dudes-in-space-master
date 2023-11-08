using Star_Ship;

namespace Task_Generator.Tasks
{
    public interface ITask
    {
        /// <summary>
        ///     Time in seconds.
        /// </summary>
        float Time { get; }

        /// <summary>
        ///     Role that is responsible for maintaining this Task.
        /// </summary>
        Roles RoleToSolve { get; }
    }
}