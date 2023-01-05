using Microsoft.EntityFrameworkCore;
using System;
using ToDoAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace ToDoAPI.Services
{
    public class ListHandler : IListHandler
    {
        private readonly ToDoListDBContext _dbContext;
        public ListHandler(ToDoListDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CreateToDoList CreateNewToDoList(CreateToDoList toDoList)
        {


            var newList = new CreateToDoList()
            {
                ListTitle = toDoList.ListTitle,
                //Task = new List<Task>(),
                Date = DateTime.Now.ToString("G"),
                ThisWeek = false,
                Expired = false,
                //Id = json[userId].ToDoList.Count + 1,

            };

            _dbContext.ToDoLists.Add(newList);
            _dbContext.SaveChanges();   

            return newList;

            
        }




        public IEnumerable<CreateToDoList> GetLists()
        {

            return _dbContext.ToDoLists.ToList();


        }




        public void DeleteList(CreateToDoList item)
        {

            _dbContext.ToDoLists.Select(x => x.ListId == item.ListId);
            _dbContext.Remove(item);
            _dbContext.SaveChanges();

        }


    }
}
