using Microsoft.EntityFrameworkCore;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;
using UCVstudents.Services.Interfaces;

namespace UCVstudents.Services
{
    public class GradeService: IGradeService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public GradeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateGrade(Grade grade)
        {
            if (grade == null)
            {
                throw new ArgumentNullException(nameof(grade), "Grade cannot be null.");
            }

            if (grade.StudentId <= 0)
            {
                throw new ArgumentException("Invalid StudentId.", nameof(grade.StudentId));
            }

            if (grade.SubjectId <= 0)
            {
                throw new ArgumentException("Invalid SubjectId.", nameof(grade.SubjectId));
            }

            if (grade.GradeValue < 0 || grade.GradeValue > 100)
            {
                throw new ArgumentException("Score must be between 0 and 100.", nameof(grade.GradeValue));
            }

            _repositoryWrapper.GradeRepository.Create(grade);
            _repositoryWrapper.Save();
        }

        public void DeleteGrade(Grade grade)
        {
            if (grade == null)
            {
                throw new ArgumentNullException(nameof(grade), "Grade cannot be null.");
            }

            if (grade.GradeId <= 0)
            {
                throw new ArgumentException("Invalid GradeId.", nameof(grade.GradeId));
            }

            _repositoryWrapper.GradeRepository.Delete(grade);
            _repositoryWrapper.Save();
        }

        public void UpdateGrade(Grade grade)
        {
            if (grade == null)
            {
                throw new ArgumentNullException(nameof(grade), "Grade cannot be null.");
            }

            if (grade.GradeId <= 0)
            {
                throw new ArgumentException("Invalid GradeId.", nameof(grade.GradeId));
            }

            if (grade.StudentId <= 0)
            {
                throw new ArgumentException("Invalid StudentId.", nameof(grade.StudentId));
            }

            if (grade.SubjectId <= 0)
            {
                throw new ArgumentException("Invalid SubjectId.", nameof(grade.SubjectId));
            }

            if (grade.GradeValue < 0 || grade.GradeValue > 100)
            {
                throw new ArgumentException("Score must be between 0 and 100.", nameof(grade.GradeValue));
            }

            _repositoryWrapper.GradeRepository.Update(grade);
            _repositoryWrapper.Save();
        }

        public Grade GetGradeById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid grade ID.");
            }

            var grade = _repositoryWrapper.GradeRepository.FindByCondition(c => c.GradeId == id).Include(g => g.Student)
                .Include(g => g.Subject).FirstOrDefault()!;

            if (grade == null)
            {
                throw new ArgumentNullException("Grade not found.");
            }

            return grade;
        }

        public List<Grade> GetGrades()
        {
            try
            {
                return _repositoryWrapper.GradeRepository.FindAll()
                    .Include(g => g.Student)
                    .Include(g => g.Subject)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving grades.", ex);
            }
        }

        public List<Grade> GetGradesByStudentId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid StudentId.", nameof(id));
            }

            try
            {
                return _repositoryWrapper.GradeRepository.FindByCondition(c => c.StudentId == id)
                    .Include(g => g.Student)
                    .Include(g => g.Subject)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving grades by student ID.", ex);
            };
        }
        public Grade GetGradeBySubjectIdAndStudentId(int subjectId, int studentId)
        {
            if (subjectId <= 0)
            {
                throw new ArgumentException("Invalid SubjectId.", nameof(subjectId));
            }

            if (studentId <= 0)
            {
                throw new ArgumentException("Invalid StudentId.", nameof(studentId));
            }

            try
            {
                var grade = _repositoryWrapper.GradeRepository.FindByCondition(c => c.SubjectId == subjectId && c.StudentId == studentId).FirstOrDefault();

                if (grade == null)
                {
                    throw new ArgumentNullException(nameof(grade), "Grade not found.");
                }

                return grade;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving the grade by subject and student ID.", ex);
            }
        }


    }
}
