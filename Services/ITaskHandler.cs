using ToDoAPI.Models;
using Task = ToDoAPI.Models.Task;

namespace ToDoAPI.Services
{
    public interface ITaskHandler
    {
        CreateToDoList AddTask(string title);
        IEnumerable<Task> GetTasks(Guid id);
        Task EditTaskName (string title);
        Task GetSingelTask(Guid id);

        Task MarkAsComplete(bool completed);
        //CreateToDoList CreateNewToDoList(string listTitle);
        //IEnumerable<CreateToDoList> GetLists();
        void DeleteTask();
        //CreateToDoList ChangeTaskName(int id, string value);
    }
}
