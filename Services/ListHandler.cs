using Microsoft.EntityFrameworkCore;
using System;
using ToDoAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using Task = ToDoAPI.Models.Task;

namespace ToDoAPI.Services
{
    public class ListHandler : IListHandler
    {
        private readonly ToDoListDBContext _dbContext;
        public ListHandler(ToDoListDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CreateToDoList CreateNewToDoList(Guid id,string listTitle)
        {
            var newList = new CreateToDoList()
            {
                Id = Guid.NewGuid(),
                CreateUserId = id,
                ListTitle = listTitle,
                Task = new List<Task>(),
                Date = DateTime.Now.ToString("G"),
                ThisWeek = false,
                Expired = false,
                
            };

            _dbContext.ToDoLists.Add(newList);
            _dbContext.SaveChanges();   
            return newList; 
        }

        public IEnumerable<CreateToDoList> GetLists()
        {
            return _dbContext.ToDoLists.ToList();
        }

        public void DeleteList(Guid id)
        {

            var selectedList = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == id);
            _dbContext.ToDoLists.Remove(selectedList);
            _dbContext.SaveChanges();
        }

        public CreateToDoList ChangeListName(Guid id, string listTitle)
        {
            var list = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == id);
            list.ListTitle = listTitle;            
            _dbContext.SaveChanges();
            return list;
        }


        public CreateToDoList ViewOneList(Guid id)
        {
            var list = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == id);
            //var tasks = _dbContext.ToDoLists.Include(task => task.ListId== id);
            //var tasks = _dbContext.Task.First(x => x.ListId == id);

            return list;
        }

        public IEnumerable<CreateToDoList> GetCurrentUsersLists(System.Security.Principal.IIdentity identity, string userId)
        {

            var lists = _dbContext.ToDoLists.Where(x => x.CreateUserId == Guid.Parse(userId));
            return lists;

        }




    }
}
