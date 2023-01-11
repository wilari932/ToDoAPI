using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class CreateToDoList
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("CreateUserId")]   
        public Guid CreateUserId { get; set; } 
        public string ListTitle { get; set; }
        public ICollection<Task> Task { get; set; }
        public string Date { get; set; }
        public bool ThisWeek { get; set; }
        public bool Expired { get; set; }

        public CreateToDoList()
        {
            Task = new List<Task>();    
        }
    

    }
}
