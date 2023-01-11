using Microsoft.EntityFrameworkCore.Storage;
using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface IListHandler 
    {
        CreateToDoList CreateNewToDoList(Guid id, string listTitle);
        IEnumerable <CreateToDoList> GetLists();
        void DeleteList(Guid id);
        CreateToDoList ChangeListName(Guid id, string value);
        CreateToDoList ViewOneList(Guid id);
        IEnumerable<CreateToDoList> GetCurrentUsersLists(System.Security.Principal.IIdentity identity, string userId);
    }
}
