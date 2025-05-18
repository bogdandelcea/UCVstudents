using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using UCVstudents.Data;
using UCVstudents.Models;
using UCVstudents.Services.Interfaces;

namespace UCVstudents.Controllers
{
    [Authorize]
    public class SubjectsController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;

        public SubjectsController(ISubjectService subjectService, ITeacherService teacherService)
        {
            _subjectService = subjectService;
            _teacherService = teacherService;
        }

        // GET: Subjects
        public async Task<IActionResult> Index()
        {
            var subjects = _subjectService.GetSubjectsPage();
            return View(subjects);
        }

        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = _subjectService.GetSubjectById(id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subjects/Create
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_teacherService.GetTeachersDropdown(), "TeacherId", "TeacherId");
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,Name,NrCredits,YearOfStudy,Semester,Faculty,Type,TeacherId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                _subjectService.CreateSubject(subject);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_teacherService.GetTeachersDropdown(), "TeacherId", "TeacherId", subject.TeacherId);
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = _subjectService.GetSubjectById(id);
            if (subject == null)
            {
                return NotFound();
            }
            ViewData["TeacherId"] = new SelectList(_teacherService.GetTeachersDropdown(), "TeacherId", "TeacherId", subject.TeacherId);
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectId,Name,NrCredits,YearOfStudy,Semester,Faculty,Type,TeacherId")] Subject subject)
        {
            if (id != subject.SubjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _subjectService.UpdateSubject(subject);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.SubjectId))
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
            ViewData["TeacherId"] = new SelectList(_teacherService.GetTeachersDropdown(), "TeacherId", "TeacherId", subject.TeacherId);
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = _subjectService.GetSubjectById(id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = _subjectService.GetSubjectById(id);
            if (subject != null)
            {
                _subjectService.DeleteSubject(subject);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult SubjectList(string id)
        {
            var teacher = _teacherService.GetTeacherByUserId(id);
            if (teacher == null)
            {
                return NotFound();
            }
            var subjects = _subjectService.GetSubjectsByTeacherId(teacher.TeacherId);

            if (subjects == null)
            {
                return NotFound();
            }

            return View(subjects);
        }

        private bool SubjectExists(int id)
        {
            return _subjectService.GetSubjectById(id) != null;
        }
    }
}
