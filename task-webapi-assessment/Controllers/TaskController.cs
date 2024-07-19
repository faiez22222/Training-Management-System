using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskApi.ITaskRepository;
using TaskApi.Models;

namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITask _taskRepository;

        public TaskController(ITask taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddTask([FromBody] Models.Task task)
        {
            _taskRepository.AddTask(task);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var _log4net = log4net.LogManager.GetLogger(typeof(TaskController));
            _log4net.Info("Info from Log4net");
            _log4net.Error("Error Occurred");
            throw new NullReferenceException("Null reference exception thrown");
            var tasks = _taskRepository.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] Models.Task task)
        {
            var existingTask = _taskRepository.GetTaskById(id);
            if (existingTask == null)
            {
                return NotFound();
            }
            task.Id = id;
            _taskRepository.UpdateTask(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var existingTask = _taskRepository.GetTaskById(id);
            if (existingTask == null || existingTask.SubTasks.Any())
            {
                return BadRequest();
            }
            _taskRepository.DeleteTask(id);
            return NoContent();
        }
    }
}
