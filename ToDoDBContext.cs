using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI
{
    public class ToDoListDBContext : DbContext
    {
        public DbSet<CreateUser> User { get; set; }
        public DbSet<CreateToDoList> ToDoLists { get; set; }
        public ToDoListDBContext(DbContextOptions<ToDoListDBContext> options) : base(options) { }
    }
}