using Microsoft.EntityFrameworkCore;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;
using UCVstudents.Services.Interfaces;

namespace UCVstudents.Services
{
    public class TeacherService: ITeacherService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public TeacherService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null.");
            }

            _repositoryWrapper.TeacherRepository.Create(teacher);
            _repositoryWrapper.Save();
        }

        public void DeleteTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null.");
            }

            if (teacher.TeacherId <= 0)
            {
                throw new ArgumentException("Invalid TeacherId.", nameof(teacher.TeacherId));
            }

            _repositoryWrapper.TeacherRepository.Delete(teacher);
            _repositoryWrapper.Save();
        }

        public void UpdateTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null.");
            }

            if (teacher.TeacherId <= 0)
            {
                throw new ArgumentException("Invalid TeacherId.", nameof(teacher.TeacherId));
            }

            _repositoryWrapper.TeacherRepository.Update(teacher);
            _repositoryWrapper.Save();
        }

        public List<Teacher> GetTeachers()
        {
            try
            {
                return _repositoryWrapper.TeacherRepository.FindAll().Include(t => t.User).ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving teachers.", ex);
            }
        }

        public List<Teacher> GetTeachersDropdown()
        {
            try
            {
                return _repositoryWrapper.TeacherRepository.FindAll().ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving teachers for dropdown.", ex);
            }
        }

        public Teacher GetTeacherByUserId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Invalid UserId.", nameof(id));
            }

            try
            {
                var teacher = _repositoryWrapper.TeacherRepository.FindByCondition(c => c.UserId == id).FirstOrDefault();

                if (teacher == null)
                {
                    throw new ArgumentNullException(nameof(teacher), "Teacher not found.");
                }

                return teacher;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving the teacher by user ID.", ex);
            }
        }

        public Teacher GetTeacherById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid TeacherId.", nameof(id));
            }

            try
            {
                var teacher = _repositoryWrapper.TeacherRepository.FindByCondition(c => c.TeacherId == id)
                    .Include(t => t.User)
                    .FirstOrDefault();

                if (teacher == null)
                {
                    throw new ArgumentNullException(nameof(teacher), "Teacher not found.");
                }

                return teacher;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving the teacher by ID.", ex);
            }
        }
    }
}
