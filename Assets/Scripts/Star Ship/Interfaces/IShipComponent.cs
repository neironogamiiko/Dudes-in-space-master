using System;
using Star_Ship.EventArgs;
using Task_Generator.Tasks;
using UnityEngine;

namespace Star_Ship.Interfaces
{
    public interface IShipComponent
    {
        /// <summary>
        ///     <see cref="Roles" />> Role that is responsible for handling this task.
        /// </summary>
        Roles RoleToSolve { get; }

        /// <summary>
        ///     Explicit transform property, so <see cref="Transform" /> from MonoBehaviour could be accessed in the interface.
        /// </summary>
        Transform Transform { get; }

        /// <summary>
        ///     Event that is triggered whenever interacted astronaut is not ok for current task.
        /// </summary>
        event Action<object, ShipComponentArgs> OnShipComponentNotPossibleToFix;

        /// <summary>
        ///     Event triggered whenever task was successfully completed.
        /// </summary>
        event Action<object, ShipComponentArgs> OnShipComponentFixed;

        /// <summary>
        ///     Event triggered whenver component has a new task assigned.
        /// </summary>
        event Action<object, ShipComponentArgs> OnShipComponentBroken;

        /// <summary>
        ///     Adds task to the tasks queue. Must be fixed after all the previous tasks.
        /// </summary>
        /// <param name="Task"> Task to add. </param>
        void AddTask(ITask Task);

        void SetSlider(GameObject slider);

        /// <summary>
        ///     Removes task from the queue of tasks.
        /// </summary>
        void RemoveTask();

        /// <summary>
        ///     Get current task that must be solved in this component.
        /// </summary>
        /// <returns> Task in form <see cref="ITask" />. </returns>
        ITask GetCurrentTask();

        /// <summary>
        ///     Interact method that checks if passed astronaut is ok to solve it's current task or not.
        /// </summary>
        /// <param name="astronaut"> Astronaut that tries to interact with tihs ship component. </param>
        void Interact(IAstronaut astronaut);

        /// <summary>
        ///     Counts number of tasks in this ship component.
        /// </summary>
        /// <returns> <see cref="int" /> Number of tasks to solve in this ship component. </returns>
        int CountTasks();
    }
}