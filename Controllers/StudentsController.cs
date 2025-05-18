using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using UCVstudents.Models;
using UCVstudents.Services.Interfaces;

namespace UCVstudents.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IUserService _userService;

        public StudentsController(IStudentService studentService, IUserService userService)
        {
            _studentService = studentService;
            _userService = userService;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var students = _studentService.GetStudents();
            return View(students);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,Name,Email,PhoneNr,Class,Group,Subgroup,Scholarship,FinalGrade,Faculty,Sex,CNP,Age,YearOfStudy,Semester,UserId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.CreateStudent(student);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id", student.UserId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id", student.UserId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,Name,Email,PhoneNr,Class,Group,Subgroup,Scholarship,FinalGrade,Faculty,Sex,CNP,Age,YearOfStudy,Semester,UserId")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _studentService.UpdateStudent(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id", student.UserId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student != null)
            {
                _studentService.DeleteStudent(student);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProfileStudentEdit(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return View(id);
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id", student.UserId);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProfileStudentEdit(int id, [Bind("StudentId,Name,Email,PhoneNr,Class,Group,Subgroup,Scholarship,FinalGrade,Faculty,Sex,CNP,Age,YearOfStudy,Semester,UserId")] Student student)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _studentService.UpdateStudent(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id", student.UserId);
            return View(student);
        }

        public IActionResult StudentList()
        {
            var students = _studentService.GetStudents();
            return View(students);
        }

        private bool StudentExists(int id)
        {
            return _studentService.GetStudentById(id) != null;
        }
    }
}
