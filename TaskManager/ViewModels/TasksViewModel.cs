using BOL;
using System.Collections.Generic;

namespace TaskManager.ViewModels
{
    public class TasksViewModel
    {
        public IEnumerable<TaskStatus> TaskStatuses { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
        public Task Task { get; set; }
    }
}