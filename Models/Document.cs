using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace UCVstudents.Models
{   
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        public string? Link { get; set; }
        public string? Type { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }
    }
}   
    
