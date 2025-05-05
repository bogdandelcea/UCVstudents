using System.Collections.Generic;
using System.Threading.Tasks;
using UCVstudents.Models;

namespace UCVstudents.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();
    }
}
