using System.Collections.Generic;
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

        public IEnumerable<Student> GetAll() => _repository.Student.GetAll();

        public Student GetById(int id) => _repository.Student.GetById(id);

        public void Create(Student student)
        {
            _repository.Student.Create(student);
            _repository.Student.Save();
        }

        public void Update(Student student)
        {
            _repository.Student.Update(student);
            _repository.Student.Save();
        }

        public void Delete(int id)
        {
            var student = _repository.Student.GetById(id);
            if (student != null)
            {
                _repository.Student.Delete(student);
                _repository.Student.Save();
            }
        }
    }
}
