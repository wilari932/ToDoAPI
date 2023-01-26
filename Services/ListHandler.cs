using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System;
using System.Reflection.Metadata.Ecma335;
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

        //public CreateToDoList CreateNewToDoList(string id, string listTitle)
        //{
        //    var newList = new CreateToDoList()
        //    {
        //        Id = Guid.NewGuid(),
        //        CreateUserId = Guid.Parse(id),
        //        ListTitle = listTitle,
        //        Task = new List<Task>(),
        //        Date = DateTime.Now.ToString("G"),
        //        ThisWeek = false,
        //        Expired = false,

        //    };

        //    _dbContext.ToDoLists.Add(newList);
        //    _dbContext.SaveChanges();   
        //    return newList; 
        //}
        public Guid GetRecentViewedList()    
        {
            Guid listId = Guid.Parse(ListDictionary.id["ListId"]);

            return listId;
        }

        public IEnumerable<CreateToDoList> GetLists()    //Funkar
        {

            return _dbContext.ToDoLists.ToList();
        }

        public CreateToDoList CreateNewToDoList(CreateToDoList list) // nya, funkar
        {
            ListDictionary.id["ListId"] = list.Id.ToString();
            Guid listId = Guid.Parse(ListDictionary.id["ListId"]);
            list.CreateUserId = Guid.Parse(UserDictionary.userId["UserId"]);
            _dbContext.ToDoLists.Add(list);
            _dbContext.SaveChanges();
            return list;
        }

        //public void DeleteList(Guid? id)
        //{
        //    if (id == null)
        //    {

        //        var selectedList = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == listID);
        //        _dbContext.ToDoLists.Remove(selectedList);
        //        _dbContext.SaveChanges();
        //        return;
        //    }
        //    else
        //    {
        //        var selectedList = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == id);
        //        _dbContext.ToDoLists.Remove(selectedList);
        //        _dbContext.SaveChanges();
        //        return;
        //    }
        //}

        public CreateToDoList ChangeListName(string listTitle)
        {
            var listID = Guid.Parse(ListDictionary.id["ListId"]);
            var list = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == listID);
            list.ListTitle = listTitle;            
            _dbContext.SaveChanges();
            return list;
        }


        public CreateToDoList ViewOneList(Guid id)
        {
       

            //ListDictionary.id["ListId"] = id.ToString();
            var list = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == id);
            return list;
        }

        public IEnumerable<CreateToDoList> GetCurrentUsersLists()   //Funkar
        {
            var userId = Guid.Parse(UserDictionary.userId["UserId"]);
            var lists = _dbContext.ToDoLists.Where(x => x.CreateUserId == userId).ToList();
            //if(lists == null)
            //{
            //    return NotFoundDirectoryContents();
            //}
            return lists;
        }

        public IEnumerable<CreateToDoList> SortLists(Sort option, string userId)
        {
            var lists = _dbContext.ToDoLists.Where(x => x.CreateUserId == Guid.Parse(userId)).ToList().OrderBy(x => x.Date);  
            //if (option == Sort.Name) // Funkar, men toList?
            //{
            //    lists = _dbContext.ToDoLists.Where(x => x.CreateUserId == Guid.Parse(userId)).OrderBy(x => x.ListTitle);
            //}
            //if (option == Sort.Descending) 
            //{
            //    lists = _dbContext.ToDoLists.Where(x => x.CreateUserId == Guid.Parse(userId)).OrderBy(x => x.Date);
            //}  
            //if (option == Sort.Ascending)
            //{
            //    lists = _dbContext.ToDoLists.Where(x => x.CreateUserId == Guid.Parse(userId)).OrderByDescending(x => x.Date);
            //}
            _dbContext.SaveChanges();
            return lists;
        }


        public CreateToDoList WeeklyList(Guid? id)
        {
            if(id == null)
            {
                id = Guid.Parse(ListDictionary.id["ListId"]);
            }
            var list = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == id);
            list.ThisWeek = true;
            _dbContext.SaveChanges();
            return list;
        }




    }
}
