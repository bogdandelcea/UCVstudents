using System.Collections.Generic;
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

        public IEnumerable<Teacher> GetAll() => _repository.Teacher.GetAll();
        public Teacher GetById(int id) => _repository.Teacher.GetById(id);
        public void Create(Teacher teacher)
        {
            _repository.Teacher.Create(teacher);
            _repository.Teacher.Save();
        }

        public void Update(Teacher teacher)
        {
            _repository.Teacher.Update(teacher);
            _repository.Teacher.Save();
        }

        public void Delete(int id)
        {
            var teacher = _repository.Teacher.GetById(id);
            if (teacher != null)
            {
                _repository.Teacher.Delete(teacher);
                _repository.Teacher.Save();
            }
        }
    }
}
