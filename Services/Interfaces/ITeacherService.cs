using UCVstudents.Models;

namespace UCVstudents.Services.Interfaces
{
    public interface ITeacherService
    {
        void CreateTeacher(Teacher teacher);
    
        void DeleteTeacher(Teacher teacher);

        void UpdateTeacher(Teacher teacher);

        List<Teacher> GetTeachers();

        List<Teacher> GetTeachersDropdown();

        Teacher GetTeacherByUserId(string id);

        Teacher GetTeacherById(int id);
    }
}

