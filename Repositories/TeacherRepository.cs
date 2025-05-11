using System.Collections.Generic;
using System.Linq;
using UCVstudents.Data;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;

namespace UCVstudents.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Teacher> GetAll() => _context.Teachers.ToList();
        public Teacher GetById(int id) => _context.Teachers.Find(id);
        public void Create(Teacher teacher) => _context.Teachers.Add(teacher);
        public void Update(Teacher teacher) => _context.Teachers.Update(teacher);
        public void Delete(Teacher teacher) => _context.Teachers.Remove(teacher);
        public void Save() => _context.SaveChanges();
    }
}
