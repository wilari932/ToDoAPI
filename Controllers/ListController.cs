using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using ToDoAPI.Models;
using ToDoAPI.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;


namespace ToDoAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {

        private readonly IListHandler _listHandler;

        private ToDoListDBContext _dbContext;

        public ListController(IListHandler listHandler, ToDoListDBContext context)
        {
            _listHandler = listHandler;
            _dbContext = context;
        }

        [HttpGet("OneList")]
        public IActionResult Get(Guid id)
        {
            return Ok(_listHandler.ViewOneList(id));
        }

        [HttpPost("CreateNewToDoList")]
        public IActionResult CreateNewToDoList(string listTitle)
        {
            var identity = HttpContext.User.Identity;
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
            return Ok(_listHandler.CreateNewToDoList(userId,listTitle));
        }

        [HttpGet("GetLists")]
        public IActionResult Get()
        {
            return Ok(_listHandler.GetLists());
        }

        [HttpGet("GetCurrentUserLists")]
        public IActionResult GetCurrentUserLists()
        {
            var identity = HttpContext.User.Identity;
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
            return Ok(_listHandler.GetCurrentUsersLists(identity, userId));
        }

        [HttpPut("EditList")]
        public IActionResult Put(string listTitle)
        {
            return Ok(_listHandler.ChangeListName(listTitle)); 
        }

        [HttpDelete("DeleteList")]
        public IActionResult Delete(Guid? id)
        {
            _listHandler.DeleteList(id);
            return Ok();   
        }

        [HttpPut("SortLists")]
        public IActionResult SortLists(Sort option)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
            return Ok(_listHandler.SortLists(option, userId));
        }


        [HttpPut("WeeklyList")]
        public IActionResult WeeklyList(Guid? id)
        {

            return Ok(_listHandler.WeeklyList(id));
        }



    }
}
