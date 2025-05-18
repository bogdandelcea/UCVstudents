using Microsoft.EntityFrameworkCore;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;
using UCVstudents.Services.Interfaces;

namespace UCVstudents.Services
{
    public class DocumentService: IDocumentService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public DocumentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateDocument(Document document)
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document), "Document cannot be null.");
            }

            _repositoryWrapper.DocumentRepository.Create(document);
            _repositoryWrapper.Save();
        }

        public void DeleteDocument(Document document)
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document), "Document cannot be null.");
            }

            if (document.DocumentId <= 0)
            {
                throw new ArgumentException("Invalid DocumentId.", nameof(document.DocumentId));
            }

            _repositoryWrapper.DocumentRepository.Delete(document);
            _repositoryWrapper.Save();
        }

        public void UpdateDocument(Document document)
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document), "Document cannot be null.");
            }

            if (document.DocumentId <= 0)
            {
                throw new ArgumentException("Invalid DocumentId.", nameof(document.DocumentId));
            }

            _repositoryWrapper.DocumentRepository.Update(document);
            _repositoryWrapper.Save();
        }

        public Document GetDocumentById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid DocumentId.", nameof(id));
            }

            try
            {
                var document = _repositoryWrapper.DocumentRepository.FindByCondition(c => c.DocumentId == id)
                    .Include(d => d.User)
                    .FirstOrDefault();

                if (document == null)
                {
                    throw new ArgumentNullException(nameof(document), "Document not found.");
                }

                return document;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving the document by ID.", ex);
            }
        }

        public List<Document> GetDocuments()
        {
            try
            {
                return _repositoryWrapper.DocumentRepository.FindAll().ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving documents.", ex);
            }
        }

        public List<Document> GetDocumentsByUserId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Invalid UserId.", nameof(id));
            }

            try
            {
                return _repositoryWrapper.DocumentRepository.FindByCondition(c => c.UserId == id)
                    .Include(d => d.User)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving documents by user ID.", ex);
            }
        }
    }
}
