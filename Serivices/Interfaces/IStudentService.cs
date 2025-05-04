using System.Collections.Generic;
using System.Threading.Tasks;
using UCVstudents.Models;

namespace UCVstudents.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
    }
}
