using System.Collections.Generic;
using UCVstudents.Models;

namespace UCVstudents.Repositories.Interfaces
{
    public interface IGradeRepository
    {
        IEnumerable<Grade> GetAll();
        Grade GetById(int id);
        void Create(Grade grade);
        void Update(Grade grade);
        void Delete(Grade grade);
        void Save();
    }
}
