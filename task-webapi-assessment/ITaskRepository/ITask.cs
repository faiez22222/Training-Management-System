using System.Collections.Generic;
using TaskApi.Models;

namespace TaskApi.ITaskRepository
{
    public interface ITask
    {
        void AddTask(Models.Task task);
        IEnumerable<Models.Task> GetAllTasks();
        Models.Task GetTaskById(int taskId);
        void UpdateTask(Models.Task task);
        void DeleteTask(int taskId);

        void AddSubTask(SubTask subTask);
        IEnumerable<SubTask> GetSubTasksByTaskId(int taskId);
    }
}
