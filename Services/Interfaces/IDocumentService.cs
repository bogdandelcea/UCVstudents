using UCVstudents.Models;

namespace UCVstudents.Services.Interfaces
{
    public interface IDocumentService
    {
        void CreateDocument(Document document);

        void DeleteDocument(Document document);

        void UpdateDocument(Document document);

        Document GetDocumentById(int id);

        List<Document> GetDocumentsByUserId(string id);

        List<Document> GetDocuments();

    }
}

