using System.Collections.Generic;
using System.Linq;
using UCVstudents.Data;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;

namespace UCVstudents.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll() => _context.Students.ToList();

        public Student GetById(int id) => _context.Students.Find(id);

        public void Create(Student student) => _context.Students.Add(student);

        public void Update(Student student) => _context.Students.Update(student);

        public void Delete(Student student) => _context.Students.Remove(student);

        public void Save() => _context.SaveChanges();
    }
}
