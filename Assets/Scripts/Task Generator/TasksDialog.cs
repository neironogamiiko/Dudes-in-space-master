using System;
using Star_Ship;
using Star_Ship.EventArgs;
using Task_Generator.EventArgs;
using Task_Generator.Interfaces;
using Task_Generator.Models;
using UnityEngine;
using User_Interface.Tasks;
using Component = Task_Generator.Models.Component;

namespace Task_Generator
{
    /// <summary>
    ///     Tasks dialog that enables communication between multiple objects that require information about tasks.
    /// </summary>
    public class TasksDialog : MonoBehaviour, IMediator
    {
        [SerializeField] private Timer.Timer _timer;
        [SerializeField] private TasksListUIController _tasksListController;
        [SerializeField] private SpaceShip _spaceShip;

        private TaskAsigner _taskAssigner;

        public void Awake()
        {
            _taskAssigner = new TaskAsigner(this, _timer);
            _spaceShip.SetTaskAsigner(_taskAssigner);
            _spaceShip.SetTaskDialog(this);
        }

        public void Notify(Component sender, System.EventArgs args)
        {
            if (args is UpdateTasksListEventArgs)
            {
                var info = args as UpdateTasksListEventArgs;
                _tasksListController.UpdateTasks(info.Info);
                return;
            }
            
        }

    }
}