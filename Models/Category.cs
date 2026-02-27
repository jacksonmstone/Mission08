using System.ComponentModel.DataAnnotations;

namespace Mission8_3_11.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        // Navigation property
        public List<TaskItem> Tasks { get; set; }
    }
}