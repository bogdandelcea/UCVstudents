using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace UCVstudents.Models
{
    public class Subgroup
    {
        [Key]
        public Guid SubgroupId { get; set; }

        [ForeignKey("GroupNoId")]
        public GroupNumber? GroupNumber { get; set; }
        public string StudentsNumber { get; set; } = string.Empty;
        public string TimetableURL { get; set; } = string.Empty;

    }
}
