using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;
using UCVstudents.Services.Interfaces;

namespace UCVstudents.Services
{
    public class StudentService: IStudentService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public StudentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");
            }

            if (string.IsNullOrEmpty(student.Name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(student.Name));
            }

            if (!Regex.IsMatch(student.PhoneNr, @"^\d{10}$"))
            {
                throw new ArgumentException("Phone number must be exactly 10 digits.", nameof(student.PhoneNr));
            }

            if (student.Scholarship == null)
            {
                throw new ArgumentException("Scholarship must be a boolean value.", nameof(student.Scholarship));
            }

            if (student.Sex != "M" && student.Sex != "F")
            {
                throw new ArgumentException("Sex must be 'M' or 'F'.", nameof(student.Sex));
            }

            if (!Regex.IsMatch(student.CNP, @"^\d{13}$"))
            {
                throw new ArgumentException("CNP must be exactly 13 digits.", nameof(student.CNP));
            }

            if (student.YearOfStudy < 1 || student.YearOfStudy > 6)
            {
                throw new ArgumentException("Year of study must be between 1 and 6.", nameof(student.YearOfStudy));
            }

            if (student.Semester < 1 || student.Semester > 2)
            {
                throw new ArgumentException("Semester must be 1 or 2.", nameof(student.Semester));
            }

            _repositoryWrapper.StudentRepository.Create(student);
            _repositoryWrapper.Save();
        }

        public void DeleteStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");
            }

            if (student.StudentId <= 0)
            {
                throw new ArgumentException("Invalid StudentId.", nameof(student.StudentId));
            }

            _repositoryWrapper.StudentRepository.Delete(student);
            _repositoryWrapper.Save();
        }

        public void UpdateStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");
            }

            if (student.StudentId <= 0)
            {
                throw new ArgumentException("Invalid StudentId.", nameof(student.StudentId));
            }

            if (string.IsNullOrEmpty(student.Name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(student.Name));
            }

            if (!Regex.IsMatch(student.PhoneNr, @"^\d{10}$"))
            {
                throw new ArgumentException("Phone number must be exactly 10 digits.", nameof(student.PhoneNr));
            }

            if (student.Scholarship == null)
            {
                throw new ArgumentException("Scholarship must be a boolean value.", nameof(student.Scholarship));
            }

            if (student.Sex != "M" && student.Sex != "F")
            {
                throw new ArgumentException("Sex must be 'M' or 'F'.", nameof(student.Sex));
            }

            if (!Regex.IsMatch(student.CNP, @"^\d{13}$"))
            {
                throw new ArgumentException("CNP must be exactly 13 digits.", nameof(student.CNP));
            }

            if (student.YearOfStudy < 1 || student.YearOfStudy > 6)
            {
                throw new ArgumentException("Year of study must be between 1 and 6.", nameof(student.YearOfStudy));
            }

            if (student.Semester < 1 || student.Semester > 2)
            {
                throw new ArgumentException("Semester must be 1 or 2.", nameof(student.Semester));
            }

            _repositoryWrapper.StudentRepository.Update(student);
            _repositoryWrapper.Save();
        }

        public Student GetStudentById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid StudentId.", nameof(id));
            }

            try
            {
                var student = _repositoryWrapper.StudentRepository.FindByCondition(c => c.StudentId == id)
                    .Include(s => s.User)
                    .FirstOrDefault();

                if (student == null)
                {
                    throw new ArgumentNullException(nameof(student), "Student not found.");
                }

                return student;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving the student by ID.", ex);
            }
        }

        public Student GetStudentByUserId(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null; // sau aruncă doar aici dacă vrei

            try
            {
                var student = _repositoryWrapper.StudentRepository
                    .FindByCondition(c => c.UserId == id)
                    .FirstOrDefault();

                // ✅ NU mai arunci dacă e null
                return student;
            }
            catch
            {
                return null; // fallback safe
            }
        }


        public Student GetStudentByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Invalid email.", nameof(email));
            }

            try
            {
                var student = _repositoryWrapper.StudentRepository.FindByCondition(c => c.Email == email)
                    .Include(s => s.User)
                    .FirstOrDefault();

                if (student == null)
                {
                    throw new ArgumentNullException(nameof(student), "Student not found.");
                }

                return student;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving the student by email.", ex);
            }
        }

        public List<Student> GetStudents()
        {
            try
            {
                return _repositoryWrapper.StudentRepository.FindAll().Include(s => s.User).ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving students.", ex);
            }

        }

        public List<Student> GetStudentsDropdown()
        {
            try
            {
                return _repositoryWrapper.StudentRepository.FindAll().ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving students for dropdown.", ex);
            }
        }
    }
}
