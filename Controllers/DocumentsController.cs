using Microsoft.AspNetCore.Mvc;
using UCVstudents.Models;
using UCVstudents.Services.Interfaces;

namespace UCVstudents.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly IDocumentsService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public IActionResult Index() => View(_documentService.GetAll());

        public IActionResult Details(int id)
        {
            var document = _documentService.GetById(id);
            if (document == null) return NotFound();
            return View(document);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Document document)
        {
            if (ModelState.IsValid)
            {
                _documentService.Create(document);
                return RedirectToAction("Index");
            }
            return View(document);
        }

        public IActionResult Edit(int id)
        {
            var document = _documentService.GetById(id);
            if (document == null) return NotFound();
            return View(document);
        }

        [HttpPost]
        public IActionResult Edit(Document document)
        {
            if (ModelState.IsValid)
            {
                _documentService.Update(document);
                return RedirectToAction("Index");
            }
            return View(document);
        }

        public IActionResult Delete(int id)
        {
            var document = _documentService.GetById(id);
            if (document == null) return NotFound();
            return View(document);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _documentService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
