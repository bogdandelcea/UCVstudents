using UCVstudents.Models;

namespace UCVstudents.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
    }
}
