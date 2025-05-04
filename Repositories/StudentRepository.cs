using UCVstudents.Data;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;

namespace UCVstudents.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }
    }
}
