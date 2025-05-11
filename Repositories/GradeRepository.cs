using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UCVstudents.Data;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;

namespace UCVstudents.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDbContext _context;

        public GradeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Grade> GetAll()
        {
            return _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .ToList();
        }

        public Grade GetById(int id)
        {
            return _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .FirstOrDefault(g => g.GradeId == id);
        }

        public void Create(Grade grade) => _context.Grades.Add(grade);
        public void Update(Grade grade) => _context.Grades.Update(grade);
        public void Delete(Grade grade) => _context.Grades.Remove(grade);
        public void Save() => _context.SaveChanges();
    }
}
