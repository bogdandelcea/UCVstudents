using System.ComponentModel.DataAnnotations;

namespace UCVstudents.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Description { get; set; }

        [Range(1, 30)]
        public int? Credits { get; set; }

        [StringLength(100)]
        public string? Faculty { get; set; }
    }
}
