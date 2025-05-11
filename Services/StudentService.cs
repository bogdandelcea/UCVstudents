using System.Collections.Generic;
using System.Threading.Tasks;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;
using UCVstudents.Services.Interfaces;

namespace UCVstudents.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepositoryWrapper _repository;

        public StudentService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            // Va fi async când implementăm repo-ul
            return await Task.FromResult(_repository.Student.GetAll());
        }
    }
}
