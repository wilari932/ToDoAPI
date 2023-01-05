using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class CreateUser
    {
        [Key]
        public int Id { get; set; }
        public static int startId = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool AccessLevelOne { get; set; }
        public bool AccessLevelMod { get; set; }
        public bool AccessLevelAdm { get; set; }
        public List<CreateToDoList> ToDoList { get; set; }
    }
}
