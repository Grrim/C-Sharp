using System.ComponentModel;

namespace TaskManager.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        [DisplayName("Nazwa")]
        public string? TaskName { get; set; }
        [DisplayName("Opis")]
        public string? Description { get; set; }
        public bool Done { get; set; }
    }
}
