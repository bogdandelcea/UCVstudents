using UCVstudents.Models;

namespace UCVstudents.Services.Interfaces
{
    public interface ISubjectService
    {
        void CreateSubject(Subject subject);

        void DeleteSubject(Subject subject);

        void UpdateSubject(Subject subject);

        Subject GetSubjectById(int id);

        List<Subject> GetSubjects();

        List<Subject> GetSubjectsPage();

        List<Subject> GetSubjectsByStudentInfo(string faculty, int year);

        List<Subject> GetSubjectsByTeacherId(int id);
    }
}

