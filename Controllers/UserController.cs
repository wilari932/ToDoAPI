using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoAPI.Models;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers
{
    [AllowAnonymous]
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

        //[AllowAnonymous]
        //[HttpPost("CreateUser")]
        //public IActionResult CreateUser(string firstname, string lastname, string username, string email, string password)
        //{
        //    return Ok(_userHandler.CreateUser(firstname, lastname, username, email, password));  // vanliga
        //}


        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public IActionResult CreateUser()
        {
           var user = Request.ReadFromJsonAsync<CreateUser>().Result;

            //return Ok(_userHandler.CreateUser(newUser));


            try
            {
                return Ok(_userHandler.CreateUser(user).Result);
            }
            catch (Exception e) when (e.InnerException is InvalidOperationException)
            {
                return BadRequest("Username and Password is required");
            }
            catch (Exception e) when (e.InnerException is UnauthorizedAccessException)
            {
                return BadRequest("Invalid login");
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with creating the token");
            }
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


        [AllowAnonymous]
        [HttpGet("GetAllUsers")]
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




        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login()
        {
            var user = Request.ReadFromJsonAsync<CreateUser>().Result;

            try
            {
                return Ok(_userHandler.Authenticate(user.UserName, user.Password).Result);
            }
            catch (Exception e) when (e.InnerException is InvalidOperationException)
            {
                return BadRequest("Username and Password is required");
            }
            catch (Exception e) when (e.InnerException is UnauthorizedAccessException)
            {
                return BadRequest("Invalid login");
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong with creating the token");
            }


        }


    }
}
