using Microsoft.EntityFrameworkCore;
using UCVstudents.Data;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;

namespace UCVstudents.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }

    }
}
