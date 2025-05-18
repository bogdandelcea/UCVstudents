using UCVstudents.Models;

namespace UCVstudents.Services.Interfaces
{
    public interface IStudentService
    {
        void CreateStudent(Student student);

        void DeleteStudent(Student student);

        void UpdateStudent(Student student);

        Student GetStudentById(int id);

        Student GetStudentByUserId(string id);

        Student GetStudentByEmail(string email);

        List<Student> GetStudents();

        List<Student> GetStudentsDropdown();
    }
}

