using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Task
    {
        [Key]
        public int ListId { get; set; }
        public string TaskTitle { get; set; }
        public bool Completed { get; set; }

    }
}
