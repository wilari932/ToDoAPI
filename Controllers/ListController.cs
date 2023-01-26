using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using ToDoAPI.Models;
using ToDoAPI.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;


namespace ToDoAPI.Controllers
{
    [AllowAnonymous]
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

        [HttpGet("ShowList/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_listHandler.ViewOneList(id));
        }

        [HttpGet("ViewSingleList")]
        public IActionResult GetRecentViewedList()
        {
            return Ok(_listHandler.GetRecentViewedList());
        }

        //[HttpPost("CreateNewToDoList")]
        //public IActionResult CreateNewToDoList(string listTitle)
        //{
        //    var identity = HttpContext.User.Identity;
        //    var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;

        //    return Ok(_listHandler.CreateNewToDoList(userId, listTitle));
        //}


        [HttpPost("CreateNewToDoList")]
        public IActionResult CreateNewToDoList(CreateToDoList list)
        {

            //var identity = HttpContext.User.Identity;
            //var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;

            return Ok(_listHandler.CreateNewToDoList(list));
        }


        [HttpGet("GetAllLists")]
        public IActionResult Get()
        {
          
            return Ok(_listHandler.GetLists());
        }

        //[HttpGet("GetCurrentUserLists")]
        //public IActionResult GetCurrentUserLists()
        //{
        //    var identity = HttpContext.User.Identity;
        //    var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        //    return Ok(_listHandler.GetCurrentUsersLists(identity, userId));
        //}

        [HttpPut("EditList")]
        public IActionResult Put(string listTitle)
        {
            return Ok(_listHandler.ChangeListName(listTitle)); 
        }

        //[HttpDelete("DeleteList")]
        //public IActionResult Delete(Guid? id)
        //{
        //    _listHandler.DeleteList(id);
        //    return Ok();   
        //}

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
