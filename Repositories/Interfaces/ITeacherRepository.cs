using UCVstudents.Models;

namespace UCVstudents.Repositories.Interfaces
{
    public interface ITeacherRepository 
    {
       IEnumerable<Teacher> GetAll();
    }
}
