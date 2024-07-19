using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskApi.ITaskRepository;
using TaskApi.Models;

namespace TaskApi.ITaskRepository
{
    public class TaskRepository : ITask
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context;
        }

        public void AddTask(Models.Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public IEnumerable<Models.Task> GetAllTasks()
        {
            return _context.Tasks.Include(t => t.SubTasks).ToList();
        }

        public Models.Task GetTaskById(int taskId)
        {
            return _context.Tasks.Include(t => t.SubTasks).FirstOrDefault(t => t.Id == taskId);
        }

        public void UpdateTask(Models.Task task)
        {
            var existingTask = _context.Tasks.Include(t => t.SubTasks).FirstOrDefault(t => t.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Name = task.Name;
                existingTask.Description = task.Description;
                existingTask.CreatedBy = task.CreatedBy;
                existingTask.CreatedOn = task.CreatedOn;

                existingTask.SubTasks.Clear();
                foreach (var subTask in task.SubTasks)
                {
                    existingTask.SubTasks.Add(new SubTask
                    {
                        SubTaskName = subTask.SubTaskName,
                        CreatedBy = subTask.CreatedBy,
                        CreatedOn = subTask.CreatedOn,
                        Description = subTask.Description,
                        TaskId = existingTask.Id // Make sure TaskId is correctly set
                    });
                }

                _context.SaveChanges();
            }
        }


        public void DeleteTask(int taskId)
        {
            var task = GetTaskById(taskId);
            if (task != null && !task.SubTasks.Any())
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public void AddSubTask(SubTask subTask)
        {
            _context.SubTasks.Add(subTask);
            _context.SaveChanges();
        }

        public IEnumerable<SubTask> GetSubTasksByTaskId(int taskId)
        {
            return _context.SubTasks.Where(st => st.TaskId == taskId).ToList();
        }
    }
}
