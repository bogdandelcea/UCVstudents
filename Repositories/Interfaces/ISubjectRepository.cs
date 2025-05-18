using System.Collections.Generic;
using UCVstudents.Models;

namespace UCVstudents.Repositories.Interfaces
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAll();
        Subject GetById(int id);
        void Create(Subject subject);
        void Update(Subject subject);
        void Delete(Subject subject);
        void Save();
    }
}
