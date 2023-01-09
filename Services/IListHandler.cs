using Microsoft.EntityFrameworkCore.Storage;
using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface IListHandler 
    {
        CreateToDoList CreateNewToDoList(string listTitle);
        IEnumerable <CreateToDoList> GetLists();
        void DeleteList(int id);
        CreateToDoList ChangeListName(int id, string value);
        CreateToDoList ViewOneList(int id);
    }
}
