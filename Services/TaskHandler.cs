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

        public CreateToDoList AddTask(string title)
        {
            //var selectedList = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == id);

            var listID = Guid.Parse(ListDictionary.id["ListId"]);            
            var task = new Task()
            {
                TaskTitle = title,
                Completed = false,
                CreateToDoListId = listID,
                Id = Guid.NewGuid()
            };

            _dbContext.Task.Add(task);  
            _dbContext.SaveChanges();

            return _dbContext.ToDoLists.Include(x => x.Task).FirstOrDefault(x => x.Id == listID);

        }


        public IEnumerable<Task> GetTasks(Guid id)
        {
            var tasks = _dbContext.Task.Where(x => x.CreateToDoListId == id);

            return tasks;

        }

        public Task EditTaskName(string taskTitle)
        {
            var taskId = Guid.Parse(ListDictionary.id["TaskId"]);
            var task = _dbContext.Task.FirstOrDefault(x => x.Id == taskId);

            task.TaskTitle = taskTitle;
            _dbContext.SaveChanges();
            return task;
        }

        
        public void DeleteTask()
        {
            var taskId = Guid.Parse(ListDictionary.id["TaskId"]);

            var task = _dbContext.Task.FirstOrDefault(x => x.Id == taskId);
            _dbContext.Remove(task);
            _dbContext.SaveChanges();
        }

        public Task GetSingelTask(Guid id)
        {
            ListDictionary.id["TaskId"] = id.ToString();
            var task = _dbContext.Task.FirstOrDefault(x => x.Id == id);
            return task;
        }


        public Task MarkAsComplete(bool completed)
        {
            var taskId = Guid.Parse(ListDictionary.id["TaskId"]);
            var task = _dbContext.Task.FirstOrDefault(x => x.Id == taskId);
            task.Completed = !task.Completed;
            _dbContext.SaveChanges();
            return task;
        }




    }

}



