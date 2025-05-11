using Microsoft.AspNetCore.Mvc;
using UCVstudents.Models;
using UCVstudents.Services.Interfaces;

namespace UCVstudents.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public IActionResult Index() => View(_teacherService.GetAll());

        public IActionResult Details(int id)
        {
            var teacher = _teacherService.GetById(id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _teacherService.Create(teacher);
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        public IActionResult Edit(int id)
        {
            var teacher = _teacherService.GetById(id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }

        [HttpPost]
        public IActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _teacherService.Update(teacher);
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        public IActionResult Delete(int id)
        {
            var teacher = _teacherService.GetById(id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _teacherService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
