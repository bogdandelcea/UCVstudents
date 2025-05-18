using Microsoft.AspNetCore.Mvc;
using UCVstudents.Models;
using UCVstudents.Services.Interfaces;

namespace UCVstudents.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        public IActionResult Index() => View(_subjectService.GetAll());

        public IActionResult Details(int id)
        {
            var subject = _subjectService.GetById(id);
            if (subject == null) return NotFound();
            return View(subject);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _subjectService.Create(subject);
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        public IActionResult Edit(int id)
        {
            var subject = _subjectService.GetById(id);
            if (subject == null) return NotFound();
            return View(subject);
        }

        [HttpPost]
        public IActionResult Edit(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _subjectService.Update(subject);
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        public IActionResult Delete(int id)
        {
            var subject = _subjectService.GetById(id);
            if (subject == null) return NotFound();
            return View(subject);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            _subjectService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
