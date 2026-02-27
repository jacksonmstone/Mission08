using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission8_3_11.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskItemId { get; set; }

        [Required]
        public string Task { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        [Range(1, 4)]
        public int Quadrant { get; set; }

        // Foreign Key
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public bool Completed { get; set; } = false;
    }
}