using System.Collections.Generic;
using Star_Ship;
using UnityEngine;

namespace User_Interface.Tasks
{
    /// <summary>
    ///     Controller that is responsible for enabling/disabling visibility of the Tasks List Frame.
    /// </summary>
    /// <remarks> Testing remarks comment. </remarks>
    public class TasksListUIController : MonoBehaviour
    {
        [SerializeField] private TasksListItem _tasksListItem;

        public void UpdateTasks(IEnumerable<TaskToSolveInfo> taskToSolveInfos)
        {
            RemoveAllItems();
            foreach (var info in taskToSolveInfos) AddNewItem(info);
        }

        private void AddNewItem(TaskToSolveInfo info)
        {
            var instance = Instantiate(_tasksListItem, transform);
            instance.SetImage(info.Icon);
            instance.SetText(
                $"({info.TasksInQueue}){info.ComponentName} is broken : must be fixed with {info.RoleToSolve}! ({info.Time} seconds)");
        }

        private void RemoveAllItems()
        {
            var childrenCount = transform.childCount;
            for (var i = 0; i < childrenCount; i++) Destroy(transform.GetChild(i).gameObject);
        }
    }
}


