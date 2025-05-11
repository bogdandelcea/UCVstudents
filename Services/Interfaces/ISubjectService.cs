using System.Collections.Generic;
using UCVstudents.Models;

namespace UCVstudents.Services.Interfaces
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetAll();
        Subject GetById(int id);
        void Create(Subject subject);
        void Update(Subject subject);
        void Delete(int id);
    }
}
