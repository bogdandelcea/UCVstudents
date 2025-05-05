using UCVstudents.Data;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;

namespace UCVstudents.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
       private readonly ApplicationDbContext _context;
        public TeacherRepository(ApplicationDbContext context)
       {
            _context = context;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers.ToList();
        }
    }
}
