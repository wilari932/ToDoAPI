using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public CreateToDoList AddTask(Task task)   
        {
            var listID = Guid.Parse(ListDictionary.id["ListId"]);
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

        
        public Task DeleteTask(Guid id) //Här fick jag inte sätta props för då gick de inte o deleta den direkt i blazor
        {
            var listID = Guid.Parse(ListDictionary.id["ListId"]);
            var deleteTask = _dbContext.Task.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(deleteTask);
            _dbContext.SaveChanges();
            return deleteTask;
        }

        public Task GetSingelTask(Guid id) //oklart om den ens behlvs
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



