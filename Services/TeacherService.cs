using System.Collections.Generic;
using System.Threading.Tasks;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;
using UCVstudents.Services.Interfaces;

namespace UCVstudents.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepositoryWrapper _repository;

        public TeacherService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Teacher>> GetAllTeacherAsync()
        {
            // Va fi async când implementăm repo-ul
            return await Task.FromResult(_repository.Teacher.GetAll());
        }
    }
}
