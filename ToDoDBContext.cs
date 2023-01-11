using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;
using Task = ToDoAPI.Models.Task;

namespace ToDoAPI
{
    public class ToDoListDBContext : DbContext
    {
        public DbSet<CreateUser> User { get; set; }
        public DbSet<CreateToDoList> ToDoLists { get; set; }
        public DbSet<Task> Task { get; set; }
        public ToDoListDBContext(DbContextOptions<ToDoListDBContext> options) : base(options) { }

     
    }
}