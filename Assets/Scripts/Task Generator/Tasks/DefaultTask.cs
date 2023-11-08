using Star_Ship;

namespace Task_Generator.Tasks
{
    /// <summary>
    ///     Default task that can be completed at any component.
    /// </summary>
    public class DefaultTask : ITask
    {
        public DefaultTask()
        {
            Time = 1f;
            RoleToSolve = Roles.ALL;
        }

        public float Time { get; }
        public Roles RoleToSolve { get; }

        /// <summary>
        ///     Overriding the method ToString helps to deal with component that must be fixed.
        /// </summary>
        /// <returns> Task text that must tell user how to deal with his problem in the game. </returns>
        public override string ToString()
        {
            return "Example text that specifies: you need to do something with anything!\n";
        }
    }
}