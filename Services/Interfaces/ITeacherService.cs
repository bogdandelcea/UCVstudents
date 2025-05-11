using System.Collections.Generic;
using UCVstudents.Models;

namespace UCVstudents.Services.Interfaces
{
    public interface ITeacherService
    {
        IEnumerable<Teacher> GetAll();
        Teacher GetById(int id);
        void Create(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(int id);
    }
}
