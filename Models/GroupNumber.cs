using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UCVstudents.Models
{
    public class GroupNumber
    {

        [Key]
        public Guid GroupNoId { get; set; }
        [ForeignKey("YearOfStudyId")]
        public YearOfStudy? YearOfStudy { get; set; }

        [ForeignKey("SpecializationId")]
        public Specialization? Specialization { get; set; }
        public int Number { get; set; }
        public int StudentsNumber { get; set; }
    }
}
