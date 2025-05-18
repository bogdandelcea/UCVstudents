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
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IUserService _userService;


        public TeachersController(ITeacherService teacherService, IUserService userService)
        {
            _teacherService = teacherService;
            _userService = userService;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            var teachers = _teacherService.GetTeachers();
            return View(teachers);
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = _teacherService.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id");
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherId,Name,Email,Sex,CNP,Age,PhoneNr,Role,Faculty,UserId")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _teacherService.CreateTeacher(teacher);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id", teacher.UserId);
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = _teacherService.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id", teacher.UserId);
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherId,Name,Email,Sex,CNP,Age,PhoneNr,Role,Faculty,UserId")] Teacher teacher)
        {
            if (id != teacher.TeacherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _teacherService.UpdateTeacher(teacher);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.TeacherId))
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
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id", teacher.UserId);
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = _teacherService.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher = _teacherService.GetTeacherById(id);
            if (teacher != null)
            {
               _teacherService.DeleteTeacher(teacher);
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult ProfileTeacherEdit(int id)
        {
            var teacher = _teacherService.GetTeacherById(id);
            if (teacher == null)
            {
                return View(id);
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id", teacher.UserId);
            return View(teacher);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProfileTeacherEdit(int id, [Bind("TeacherId,Name,Email,Sex,CNP,Age,PhoneNr,Role,Faculty,UserId")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _teacherService.UpdateTeacher(teacher);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id", teacher.UserId);
            return View(teacher);

        }

        private bool TeacherExists(int id)
        {
            return _teacherService.GetTeacherById(id) != null;
        }
    }
}
