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

        public CreateToDoList CreateNewToDoList(string listTitle)
        {
            var newList = new CreateToDoList()
            {
                ListTitle = listTitle,
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

        public void DeleteList(int id)
        {

            var selectedList = _dbContext.ToDoLists.FirstOrDefault(x => x.ListId == id);
            _dbContext.ToDoLists.Remove(selectedList);
            _dbContext.SaveChanges();
        }

        public CreateToDoList ChangeListName(int id, string listTitle)
        {
            var list = _dbContext.ToDoLists.FirstOrDefault(x => x.ListId == id);
            list.ListTitle = listTitle;            
            _dbContext.SaveChanges();
            return list;
        }


        public CreateToDoList ViewOneList(int id)
        {
            var list = _dbContext.ToDoLists.FirstOrDefault(x => x.ListId == id);
            return list;
        }



    }
}
