using Microsoft.EntityFrameworkCore.Storage;
using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface IListHandler 
    {
        //CreateToDoList CreateNewToDoList(string id, string listTitle);
        CreateToDoList CreateNewToDoList(CreateToDoList list);
        IEnumerable<CreateToDoList> GetLists();   //Funkar
        Guid GetRecentViewedList();
        //void DeleteList(Guid? id);
        CreateToDoList ChangeListName(string value);
        CreateToDoList ViewOneList(Guid id);
        CreateToDoList WeeklyList(Guid? id);
        IEnumerable<CreateToDoList> GetCurrentUsersLists();

        //IEnumerable<CreateToDoList> GetCurrentUsersLists(System.Security.Principal.IIdentity identity, string userId);  //Gamla
    }
}
