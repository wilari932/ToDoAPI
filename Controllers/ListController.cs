using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using ToDoAPI.Models;
using ToDoAPI.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoAPI.Controllers
{
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

        // GET: api/<ListController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<ListController>/5
        [HttpGet("OneList")]
        public IActionResult Get(int id)
        {
            return Ok(_listHandler.ViewOneList(id));
        }

        // POST api/<ListController>
        [HttpPost("CreateNewToDoList")]
        public IActionResult CreateNewToDoList(string listTitle)
        {
            return Ok(_listHandler.CreateNewToDoList(listTitle));
        }

        [HttpGet("GetLists")]
        public IActionResult Get()
        {
            return Ok(_listHandler.GetLists());
        }



        //PUT api/<ListController>/5
        [HttpPut("EditList")]
        public IActionResult Put(int id, string listTitle)
        {

            return Ok(_listHandler.ChangeListName(id, listTitle));
        }


        // DELETE api/<ListController>/5
        [HttpDelete("DeleteList")]
        public IActionResult Delete(int id)
        {

            _listHandler.DeleteList(id);

            return Ok();
            
        }



    }
}
