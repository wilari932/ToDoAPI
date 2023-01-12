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

        [HttpPost("AddTask")]
        public IActionResult AddTask(string taskTitle)
        {
            return Ok(_taskHandler.AddTask(taskTitle));
        }

        [HttpPost("GetTasks")]
        public IActionResult GetTasks(Guid id)
        {
            return Ok(_taskHandler.GetTasks(id));
        }

        [HttpPut("EditTask")]
        public IActionResult EditTaskName(string taskTitle)
        {
            return Ok(_taskHandler.EditTaskName(taskTitle));
        }

        [HttpGet("GetSingelTask")]
        public IActionResult GetSingelTask(Guid id)
        {
            return Ok(_taskHandler.GetSingelTask(id));
        }

        [HttpDelete("DeleteTask")]
        public IActionResult DeleteTask()
        {
            _taskHandler.DeleteTask();
            return Ok();
        }

        [HttpPut("Completed")]
        public IActionResult MarkAsComplete(bool completed)
        {
            return Ok(_taskHandler.MarkAsComplete(completed));
        }


    }
}

