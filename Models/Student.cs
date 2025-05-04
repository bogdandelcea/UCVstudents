using System.ComponentModel.DataAnnotations;

namespace UCVstudents.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string RegistrationNumber { get; set; } = string.Empty;

        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
    }
}
