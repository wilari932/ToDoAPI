using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface IListHandler 
    {
        CreateToDoList CreateNewToDoList(CreateToDoList toDoList);

        IEnumerable <CreateToDoList> GetLists();

        void DeleteList(CreateToDoList item);
    }
}
