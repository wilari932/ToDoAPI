using ToDoAPI.Models;
using Task = ToDoAPI.Models.Task;

namespace ToDoAPI.Services
{
    public interface ITaskHandler
    {
        CreateToDoList AddTask(Guid id, string title);
        IEnumerable<Task> GetTasks(Guid id);
        Task EditTaskName (Guid id, string taskTitle);
        //CreateToDoList CreateNewToDoList(string listTitle);
        //IEnumerable<CreateToDoList> GetLists();
        void DeleteTask(Guid id);
        //CreateToDoList ChangeTaskName(int id, string value);
    }
}
