using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UCVstudents.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Exemplu de entități (activează doar dacă ai creat modelele)
        public DbSet<Student> Students { get; set; }
        // public DbSet<Teacher> Teachers { get; set; }
        // public DbSet<Subject> Subjects { get; set; }
        // public DbSet<Grade> Grades { get; set; }
        // public DbSet<Document> Documents { get; set; }
    }
}
