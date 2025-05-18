using System.Collections.Generic;
using UCVstudents.Models;

namespace UCVstudents.Repositories.Interfaces
{
    public interface IDocumentRepository
    {
        IEnumerable<Document> GetAll();
        Document GetById(int id);
        void Create(Document document);
        void Update(Document document);
        void Delete(Document document);
        void Save();
    }
}
