using System.ComponentModel.DataAnnotations;

namespace UCVstudents.Models
{
    public class Specialization
    {
        [Key]
        public Guid SpecializationId { get; set; }
        public string SpecName { get; set; } = string.Empty;
    }
}
