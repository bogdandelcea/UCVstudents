using UCVstudents.Data;
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

        // Vom adăuga metode în pasul următor (ex: GetAll, GetById etc.)
    }
}
