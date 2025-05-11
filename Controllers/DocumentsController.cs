using Microsoft.AspNetCore.Mvc;
using UCVstudents.Models;
using UCVstudents.Services.Interfaces;


using Microsoft.AspNetCore.Mvc;
using UCVstudents.Models;
using UCVstudents.Services.Interfaces;

namespace UCVstudents.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        // GET: Document
        public IActionResult Index()
        {
            var documents = _documentService.GetAll();
            return View(documents);
        }

        // GET: Document/Details/5
        public IActionResult Details(int id)
        {
            var document = _documentService.GetById(id);
            if (document == null)
                return NotFound();

            return View(document);
        }

        // GET: Document/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Document/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("DocumentId,Link,Type,UserId")] Document document)
        {
            if (ModelState.IsValid)
            {
                _documentService.Create(document);
                return RedirectToAction(nameof(Index));
            }
            return View(document);
        }

        // GET: Document/Edit/5
        public IActionResult Edit(int id)
        {
            var document = _documentService.GetById(id);
            if (document == null)
                return NotFound();

            return View(document);
        }

        // POST: Document/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("DocumentId,Link,Type,UserId")] Document document)
        {
            if (id != document.DocumentId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _documentService.Update(document);
                return RedirectToAction(nameof(Index));
            }
            return View(document);
        }

        // GET: Document/Delete/5
        public IActionResult Delete(int id)
        {
            var document = _documentService.GetById(id);
            if (document == null)
                return NotFound();

            return View(document);
        }

        // POST: Document/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _documentService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
