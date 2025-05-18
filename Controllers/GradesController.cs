using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using UCVstudents.Data;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;
using UCVstudents.Services.Interfaces;
using System.Dynamic;
using UCVstudents.Services;

namespace UCVstudents.Controllers
{
    [Authorize]
    public class GradesController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;
        private readonly IUserService _userService;

        public GradesController(IGradeService gradeService, IStudentService studentService, ISubjectService subjectService, IUserService userService, ITeacherService teacherService)
        {
            _gradeService = gradeService;
            _studentService = studentService;
            _subjectService = subjectService;
            _teacherService = teacherService;
            _userService = userService;
        }

        // GET: Grades
        public async Task<IActionResult> Index()
        {
            var grades = _gradeService.GetGrades();
            return View(grades);
        }

        // GET: Grades/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = _gradeService.GetGradeById(id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // GET: Grades/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_studentService.GetStudentsDropdown(), "StudentId", "StudentId");
            ViewData["SubjectId"] = new SelectList(_subjectService.GetSubjects(), "SubjectId", "SubjectId");
            return View();
        }

        // POST: Grades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GradeId,SubjectId,GradeValue,StudentId")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                _gradeService.CreateGrade(grade);
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_studentService.GetStudentsDropdown(), "StudentId", "StudentId", grade.StudentId);
            ViewData["SubjectId"] = new SelectList(_subjectService.GetSubjects(), "SubjectId", "SubjectId", grade.SubjectId);
            return View(grade);
        }

        // GET: Grades/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = _gradeService.GetGradeById(id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grade = _gradeService.GetGradeById(id);
            if (grade != null)
            {
                _gradeService.DeleteGrade(grade);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Grades(string id)
        {
            var student = _studentService.GetStudentByUserId(id);
            if (student == null)
            {
                return NotFound();
            }
            dynamic mymodel = new ExpandoObject();
            mymodel.Grades = _gradeService.GetGradesByStudentId(student.StudentId);
            mymodel.Subjects = _subjectService.GetSubjectsByStudentInfo(student.Faculty, student.YearOfStudy ?? 0);
            return View(mymodel);
        }

        public IActionResult GradesSubmit(string id)
        {
            var teacher = _teacherService.GetTeacherByUserId(id);
            if (teacher == null)
            {
                return NotFound();
            }

            dynamic mymodel = new ExpandoObject();
            mymodel.Grades = _gradeService.GetGrades();
            mymodel.Subjects = _subjectService.GetSubjectsByTeacherId(teacher.TeacherId);
            mymodel.Students = _studentService.GetStudents();
            return View(mymodel);
        }

        public IActionResult Edit(int id)
        {
            var grade = _gradeService.GetGradeById(id);
            if (grade == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_studentService.GetStudents(), "StudentId", "StudentId", grade.StudentId);
            ViewData["SubjectId"] = new SelectList(_subjectService.GetSubjects(), "SubjectId", "SubjectId", grade.SubjectId);
            return View(grade);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("GradeId,SubjectId,GradeValue,StudentId")] Grade grade)
        {
            if (id != grade.GradeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _gradeService.UpdateGrade(grade);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_studentService.GetStudents(), "StudentId", "StudentId", grade.StudentId);
            ViewData["SubjectId"] = new SelectList(_subjectService.GetSubjects(), "SubjectId", "SubjectId", grade.SubjectId);
            return View(grade);
        }

        private bool GradeExists(int id)
        {
            return _gradeService.GetGradeById(id) != null;
        }
    }
}
