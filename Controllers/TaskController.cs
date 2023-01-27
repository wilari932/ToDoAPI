using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITaskHandler _taskHandler;

        public TaskController(ITaskHandler taskHandler)
        {
            _taskHandler = taskHandler;

        }

        [HttpPost("AddTask")]    //Funkar
        public IActionResult AddTask(ToDoAPI.Models.Task task)
        {
            return Ok(_taskHandler.AddTask(task));
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

        [HttpDelete("DeleteTask/{id}")]  //Funkar
        public IActionResult DeleteTask(Guid id)
        {
           
            return Ok(_taskHandler.DeleteTask(id));
        }

        [HttpPut("Completed")]
        public IActionResult MarkAsComplete(bool completed)
        {
            return Ok(_taskHandler.MarkAsComplete(completed));
        }


    }
}

