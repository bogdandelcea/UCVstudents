using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using UCVstudents.Models;
using UCVstudents.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;

namespace UCVstudents.Controllers
{
    [Authorize]
    public class DocumentsController : Controller
    {
        private readonly IDocumentService _documentService;
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DocumentsController(IDocumentService documentService, IUserService userService, IWebHostEnvironment webHostEnvironment)
        {
            _documentService = documentService;
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            var docs = _documentService.GetDocuments();
            return View(docs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = _documentService.GetDocumentById(id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id");
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentId,Link,Type,UserId")] Document document)
        {
            if (ModelState.IsValid)
            {
                _documentService.CreateDocument(document);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id", document.UserId);
            return View(document);
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = _documentService.GetDocumentById(id);
            if (document == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id", document.UserId);
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocumentId,Link,Type,UserId")] Document document)
        {
            if (id != document.DocumentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _documentService.UpdateDocument(document);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(document.DocumentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id", document.UserId);
            return View(document);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = _documentService.GetDocumentById(id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var document = _documentService.GetDocumentById(id);
            if (document != null)
            {
                _documentService.DeleteDocument(document);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Documents(string id)
        {
            var document = _documentService.GetDocumentsByUserId(id);
            return View(document);
        }

        public IActionResult Timetables()
        {
            return View();
        }

        public IActionResult Certificates()
        {
            var document = _documentService.GetDocuments();
            return View(document);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int documentId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                // Handle the error condition
                return RedirectToAction("Error");
            }

            // Find the document by ID
            var document = _documentService.GetDocumentById(documentId);

            if (document == null)
            {
                // Handle the error condition
                return RedirectToAction("Error");
            }

            // Save the file to the wwwroot/doc/Documents directory
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "doc", "Documents");
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Update the document's link in the database
            document.Link = uniqueFileName;
            _documentService.UpdateDocument(document);

            return RedirectToAction("Documents", new { id = document.UserId });
        }

        private bool DocumentExists(int id)
        {
            return _documentService.GetDocumentById(id) != null;
        }
    }
}
