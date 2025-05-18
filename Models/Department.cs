using System.ComponentModel.DataAnnotations;

namespace UCVstudents.Models
{
    public class Department
    {
        [Key]
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
    }
}
