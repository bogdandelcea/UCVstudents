using System.Collections.Generic;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;
using UCVstudents.Services.Interfaces;

namespace UCVstudents.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IRepositoryWrapper _repository;

        public DocumentService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IEnumerable<Document> GetAll() => _repository.Document.GetAll();
        public Document GetById(int id) => _repository.Document.GetById(id);

        public void Create(Document document)
        {
            _repository.Document.Create(document);
            _repository.Document.Save();
        }

        public void Update(Document document)
        {
            _repository.Document.Update(document);
            _repository.Document.Save();
        }

        public void Delete(int id)
        {
            var document = _repository.Document.GetById(id);
            if (document != null)
            {
                _repository.Document.Delete(document);
                _repository.Document.Save();
            }
        }
    }
}
