using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCVstudents.Data;
using UCVstudents.Models;

namespace UCVstudents.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;
        private readonly UserManager<IdentityUser> _userManager;

        public DocumentController(IDocumentService documentService, UserManager<IdentityUser> userManager)
        {
            _documentService = documentService;
            _userManager = userManager;
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
            ViewData["UserId"] = new SelectList(_userManager.Users, "Id", "UserName");
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
            ViewData["UserId"] = new SelectList(_userManager.Users, "Id", "UserName", document.UserId);
            return View(document);
        }

        // GET: Document/Edit/5
        public IActionResult Edit(int id)
        {
            var document = _documentService.GetById(id);
            if (document == null)
                return NotFound();

            ViewData["UserId"] = new SelectList(_userManager.Users, "Id", "UserName", document.UserId);
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
            ViewData["UserId"] = new SelectList(_userManager.Users, "Id", "UserName", document.UserId);
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
