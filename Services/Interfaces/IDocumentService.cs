using System.Collections.Generic;
using UCVstudents.Models;

namespace UCVstudents.Services.Interfaces
{
    public interface IDocumentService
    {
        IEnumerable<Document> GetAll();
        Document GetById(int id);
        void Create(Document document);
        void Update(Document document);
        void Delete(int id);
    }
}
