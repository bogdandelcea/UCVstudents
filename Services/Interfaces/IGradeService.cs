using System.Collections.Generic;
using UCVstudents.Models;

namespace UCVstudents.Services.Interfaces
{
    public interface IGradeService
    {
        IEnumerable<Grade> GetAll();
        Grade GetById(int id);
        void Create(Grade grade);
        void Update(Grade grade);
        void Delete(int id);
    }
}
