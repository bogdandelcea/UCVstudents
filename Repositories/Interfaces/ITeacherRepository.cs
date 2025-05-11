using System.Collections.Generic;
using UCVstudents.Models;

namespace UCVstudents.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetAll();
        Teacher GetById(int id);
        void Create(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(Teacher teacher);
        void Save();
    }
}
