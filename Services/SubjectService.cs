using Microsoft.EntityFrameworkCore;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;
using UCVstudents.Services.Interfaces;

namespace UCVstudents.Services
{
    public class SubjectService: ISubjectService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public SubjectService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateSubject(Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject), "Subject cannot be null.");
            }
            _repositoryWrapper.SubjectRepository.Create(subject);
            _repositoryWrapper.Save();
        }

        public void DeleteSubject(Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject), "Subject cannot be null.");
            }

            if (subject.SubjectId <= 0)
            {
                throw new ArgumentException("Invalid SubjectId.", nameof(subject.SubjectId));
            }
            _repositoryWrapper.SubjectRepository.Delete(subject);
            _repositoryWrapper.Save();
        }

        public void UpdateSubject(Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject), "Subject cannot be null.");
            }

            if (subject.SubjectId <= 0)
            {
                throw new ArgumentException("Invalid SubjectId.", nameof(subject.SubjectId));
            }

            _repositoryWrapper.SubjectRepository.Update(subject);
            _repositoryWrapper.Save();
        }

        public Subject GetSubjectById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid SubjectId.", nameof(id));
            }

            try
            {
                var subject = _repositoryWrapper.SubjectRepository.FindByCondition(c => c.SubjectId == id)
                    .Include(s => s.Teacher)
                    .FirstOrDefault();

                if (subject == null)
                {
                    throw new ArgumentNullException(nameof(subject), "Subject not found.");
                }

                return subject;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving the subject by ID.", ex);
            }
        }

        public List<Subject> GetSubjects()
        {
            try
            {
                return _repositoryWrapper.SubjectRepository.FindAll().ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving subjects.", ex);
            }
        }

        public List<Subject> GetSubjectsPage()
        {
            try
            {
                return _repositoryWrapper.SubjectRepository.FindAll().Include(s => s.Teacher).ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving subjects for the page.", ex);
            }
        }

        public List<Subject> GetSubjectsByStudentInfo(string faculty, int year)
        {
            if (string.IsNullOrEmpty(faculty))
            {
                throw new ArgumentException("Invalid faculty.", nameof(faculty));
            }

            if (year <= 0)
            {
                throw new ArgumentException("Invalid year.", nameof(year));
            }

            try
            {
                return _repositoryWrapper.SubjectRepository.FindByCondition(c => c.Faculty == faculty && c.YearOfStudy <= year).ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving subjects by student info.", ex);
            }
        }

        public List<Subject> GetSubjectsByTeacherId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid TeacherId.", nameof(id));
            }

            try
            {
                return _repositoryWrapper.SubjectRepository.FindByCondition(c => c.TeacherId == id).ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving subjects by teacher ID.", ex);
            }
        }
    }
}
