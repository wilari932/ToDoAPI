using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITaskHandler _taskHandler;

        public TaskController(ITaskHandler taskHandler)
        {
            _taskHandler = taskHandler;

        }

        [HttpPost("AddTask/{id}")]
        public IActionResult AddTask(Guid id, string taskTitle)
        {
            return Ok(_taskHandler.AddTask(id, taskTitle));
        }

        [HttpPost("GetTasks")]
        public IActionResult GetTasks(Guid id)
        {
            return Ok(_taskHandler.GetTasks(id));
        }

        [HttpPut("EditTask/{id}")]
        public IActionResult EditTaskName(Guid id, string taskTitle)
        {
            return Ok(_taskHandler.EditTaskName(id, taskTitle));
        }

        [HttpDelete("DeleteTask/{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            _taskHandler.DeleteTask(id);
            return Ok();
        }


    }
}

