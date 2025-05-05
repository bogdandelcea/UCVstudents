using UCVStudents.Data;
using UCVStudents.Models;
using UCVStudents.Repositories.Interfaces;

namespace UCVStudents.Repositories
{
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
    }
}
