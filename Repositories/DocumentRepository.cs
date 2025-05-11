using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UCVstudents.Data;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;

namespace UCVstudents.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Document> GetAll()
        {
            return _context.Documents
                .Include(d => d.User)
                .ToList();
        }

        public Document GetById(int id)
        {
            return _context.Documents
                .Include(d => d.User)
                .FirstOrDefault(d => d.DocumentId == id);
        }

        public void Create(Document document) => _context.Documents.Add(document);
        public void Update(Document document) => _context.Documents.Update(document);
        public void Delete(Document document) => _context.Documents.Remove(document);
        public void Save() => _context.SaveChanges();
    }
}
