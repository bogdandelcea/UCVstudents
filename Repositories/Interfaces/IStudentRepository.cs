using System.Collections.Generic;
using UCVstudents.Models;

namespace UCVstudents.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Create(Student student);
        void Update(Student student);
        void Delete(Student student);
        void Save();
    }
}
