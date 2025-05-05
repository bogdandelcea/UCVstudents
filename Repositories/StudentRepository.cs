using Microsoft.EntityFrameworkCore;
using UCVStudents.Data;
using UCVStudents.Models;
using UCVStudents.Repositories.Interfaces;

namespace UCVStudents.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }

    }
}
