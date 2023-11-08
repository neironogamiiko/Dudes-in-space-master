using System;
using System.Collections.Generic;
using Star_Ship.EventArgs;
using Star_Ship.Interfaces;
using Task_Generator;
using Task_Generator.EventArgs;
using Task_Generator.Models;
using UnityEngine;
using Random = UnityEngine.Random;
using Component_ = Task_Generator.Models.Component;

namespace Star_Ship
{
    /// <summary>
    ///     One of the main objects in the game. <br />
    ///     Connects all <see cref="ShipComponent" /> together. <br />
    ///     Interacts with <see cref="TasksDialog" />.
    /// </summary>
    public class SpaceShip : MonoBehaviour, ISpaceShip
    {
        private List<IShipComponent>_shipComponents;

        private TaskAsigner _taskAsigner;
        private TasksDialog _tasksDialog;

        private void Awake()
        {
            LoadShipComponents();
        }

        /// <summary>
        ///     Asigns <see cref="_taskAsigner" />
        /// </summary>
        /// <param name="asigner"> Object to set. </param>
        public void SetTaskAsigner(TaskAsigner asigner)
        {
            if (_taskAsigner != null)
                _taskAsigner.TaskGeneratorInstance.OnTaskGenerated -= OnTaskGenerated;

            _taskAsigner = asigner;
            _taskAsigner.TaskGeneratorInstance.OnTaskGenerated += OnTaskGenerated;
        }

        /// <summary>
        ///     Method is being called whenever new task was generated in <see cref="TaskAsigner" />
        /// </summary>
        /// <param name="sender"> instance of <see cref="TaskAsigner" /> </param>
        /// <param name="args"> arguments </param>
        /// <exception cref="IndexOutOfRangeException"> Is called if there's no ship components were found. </exception>
        public void OnTaskGenerated(object sender, TaskEventArgs args)
        {
            var components = _shipComponents;
            var arrayOfComponents = components.ToArray();
            var randIndex = Random.Range(0, 4);
            if (arrayOfComponents.Length == 0) throw new IndexOutOfRangeException("Space Ship");
            arrayOfComponents[randIndex].AddTask(args.TaskInstance);
        }

        public event Action<object, ComponentUpdatedArgs> OnComponentUpdated;

        public event Action<object, ShipComponentLoadedArgs> OnShipComponentLoaded;

        /// <summary>
        ///     Gathers all components in specified gameObject component and adds them to <see cref="_shipComponents" />
        /// </summary>
        private void LoadShipComponents()
        {
            _shipComponents = new List<IShipComponent>(GetComponentsInChildren<IShipComponent>());
            
            foreach (var comp in _shipComponents)
            {
                if (((IShipComponentInformation)comp).ComponentInformation._moduleType == ShipComponentInformation.ModuleType.Module)
                {
                    comp.OnShipComponentFixed += OnShipComponentUpdated;
                    comp.OnShipComponentBroken += OnShipComponentUpdated;
                    comp.OnShipComponentNotPossibleToFix += OnShipComponentUpdated;

                }
            }

            Debug.Log("Ship components loaded!");
            
            OnShipComponentLoaded?.Invoke(this, new ShipComponentLoadedArgs(_shipComponents));
        }


        /// <summary>
        ///     Called only whenever any component is fixed. Invokes <see cref="OnFixedComponent" />.
        /// </summary>
        /// <param name="sender"> sender of the arguments</param>
        /// <param name="args"> arguments </param>
        public void OnShipComponentUpdated(object sender, ShipComponentArgs args)
        {
            IEnumerable<TaskToSolveInfo> gatheredTasks = GatherAllTasks();
            
            OnComponentUpdated?.Invoke(this, new ComponentUpdatedArgs
            {
                Tasks = gatheredTasks
            });
            _tasksDialog.Notify(new Component_(_tasksDialog), new UpdateTasksListEventArgs
            {
                Info = gatheredTasks
            });
        }

        /// <summary>
        ///     Gathers all the tasks from all over ship components that are placed in <see cref="_shipComponents" />)
        /// </summary>
        /// <returns>
        ///     Returns collection <see cref="IEnumerable{T}" /> of information about each task that must be done in each
        ///     component.
        /// </returns>
        public List<TaskToSolveInfo> GatherAllTasks()
        {
            var tasksToSolve = new List<TaskToSolveInfo>();
            foreach (var comp in _shipComponents)
            {
                
                    var task = comp.GetCurrentTask();
                    var tasksInComponent = comp.CountTasks();
                    if (task != null)
                        tasksToSolve.Add(new TaskToSolveInfo
                        {
                            ComponentName = comp.Transform.name,
                            RoleToSolve = task.RoleToSolve,
                            Time = task.Time,
                            TasksInQueue = tasksInComponent,
                            Icon = ((IShipComponentInformation)comp).ComponentInformation._sprite
                        });
                
                
            }

            return tasksToSolve;
        }

        public void SetTaskDialog(TasksDialog tasksDialog)
        {
            _tasksDialog = tasksDialog;
        }
    }
}