using Microsoft.EntityFrameworkCore;
using System;
using ToDoAPI.Models;
using Task = ToDoAPI.Models.Task;

namespace ToDoAPI.Services
{
    public class TaskHandler : ITaskHandler
    {
        private readonly ToDoListDBContext _dbContext;
        public TaskHandler(ToDoListDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CreateToDoList AddTask(Guid id, string title)
        {
            var selectedList = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == id);

            var task = new Task()
            {
                TaskTitle = title,
                Completed = false,
                CreateToDoListId = id,
                Id = Guid.NewGuid()
            };

            _dbContext.Task.Add(task);  
            _dbContext.SaveChanges();

            return _dbContext.ToDoLists.Include(x => x.Task).FirstOrDefault(x => x.Id == id);

        }


        public IEnumerable<Task> GetTasks(Guid id)
        {
            var tasks = _dbContext.Task.Where(x => x.CreateToDoListId == id);

            return tasks;

        }

        public Task EditTaskName(Guid id, string taskTitle)
        {
            var task = _dbContext.Task.FirstOrDefault(x => x.Id == id);
            task.TaskTitle = taskTitle;
            _dbContext.SaveChanges();
            return task;
        }


        public void DeleteTask(Guid id)
        {

            var task = _dbContext.Task.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(task);
            _dbContext.SaveChanges();
        }




    }

}



