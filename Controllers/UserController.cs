using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoAPI.Models;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserHandler _userHandler;

        private ToDoListDBContext _dbContext;

        public UserController(IUserHandler userHandler, ToDoListDBContext context)
        {
            _userHandler = userHandler;
            _dbContext = context;
        }

        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public IActionResult CreateUser(string firstname, string lastname, string username, string email, string password)
        {
            return Ok(_userHandler.CreateUser(firstname, lastname, username, email, password));
        }

        [HttpPost("DeleteUser")]
        public IActionResult DeleteUser(Guid? id)
        {

            if (id == null)
            {
                id = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);
            }
            _userHandler.DeleteUser(id);

            return Ok();
        }


        [HttpGet("GetOneUser/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_userHandler.GetOneUser(id));
        }


        [HttpGet("GetUsers")]
        public IActionResult Get()
        {
            return Ok(_userHandler.GetUsers());
        }

        [HttpPut("EditProfile/{id}")]
        public IActionResult EditProfile(Guid id, string? firstName, string? lastName, string? email, string? password)
        {
            return Ok(_userHandler.EditProfile(id, firstName, lastName, email, password));
        }


        [HttpPut("ChangeAccess/{id}")]
        public IActionResult ChangeAccess(Guid id, Access access)
        {
            return Ok(_userHandler.ChangeAccess(id, access));
        }


    }
}
