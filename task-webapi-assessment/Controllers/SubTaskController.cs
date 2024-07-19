using Microsoft.AspNetCore.Mvc;
using TaskApi.ITaskRepository;
using TaskApi.Models;

namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTaskController : ControllerBase
    {
        private readonly ITask _taskRepository;

        public SubTaskController(ITask taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpPost]
        public IActionResult AddSubTask([FromBody] SubTask subTask)
        {
            _taskRepository.AddSubTask(subTask);
            return Ok();
        }

        [HttpGet("{taskId}")]
        public IActionResult GetSubTasksByTaskId(int taskId)
        {
            var subTasks = _taskRepository.GetSubTasksByTaskId(taskId);
            return Ok(subTasks);
        }
    }
}
