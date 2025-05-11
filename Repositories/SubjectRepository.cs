using System.Collections.Generic;
using System.Linq;
using UCVstudents.Data;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;

namespace UCVstudents.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Subject> GetAll() => _context.Subjects.ToList();
        public Subject GetById(int id) => _context.Subjects.Find(id);
        public void Create(Subject subject) => _context.Subjects.Add(subject);
        public void Update(Subject subject) => _context.Subjects.Update(subject);
        public void Delete(Subject subject) => _context.Subjects.Remove(subject);
        public void Save() => _context.SaveChanges();
    }
}
