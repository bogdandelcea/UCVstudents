using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCVstudents.Data;
using UCVstudents.Models;

namespace UCVstudents.Controllers
{
    public class GradesController : Controller
    {
        private readonly IGradeService _gradeService;

        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        public IActionResult Index() => View(_gradeService.GetAll());

        public IActionResult Details(int id)
        {
            var grade = _gradeService.GetById(id);
            if (grade == null) return NotFound();
            return View(grade);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Grade grade)
        {
            if (ModelState.IsValid)
            {
                _gradeService.Create(grade);
                return RedirectToAction("Index");
            }
            return View(grade);
        }

        public IActionResult Edit(int id)
        {
            var grade = _gradeService.GetById(id);
            if (grade == null) return NotFound();
            return View(grade);
        }

        [HttpPost]
        public IActionResult Edit(Grade grade)
        {
            if (ModelState.IsValid)
            {
                _gradeService.Update(grade);
                return RedirectToAction("Index");
            }
            return View(grade);
        }

        public IActionResult Delete(int id)
        {
            var grade = _gradeService.GetById(id);
            if (grade == null) return NotFound();
            return View(grade);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _gradeService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
