using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class CreateToDoList
    {
        [Key]
        public int ListId { get; set; }
        public int UserId { get; set; } 
        public string ListTitle { get; set; }
        public List<Task> Task { get; set; }
        public string Date { get; set; }
        public bool ThisWeek { get; set; }
        public bool Expired { get; set; }
    

    }
}
