using System.Collections.Generic;
using UCVstudents.Models;

namespace UCVstudents.Services.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Create(Student student);
        void Update(Student student);
        void Delete(int id);
    }
}
