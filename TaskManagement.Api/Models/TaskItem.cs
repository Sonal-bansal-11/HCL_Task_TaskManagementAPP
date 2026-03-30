using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Api.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        // [Required] ensures that without Title no task can be saved (Model Validation)
        [Required(ErrorMessage = "Task title is required")]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; } = false;
    }
}