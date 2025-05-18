using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UCVstudents.Models;
using UCVstudents.Services.Interfaces;


namespace UCVstudents.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IUserService _userService;
        private readonly ITeacherService _teacherService;
        private readonly ISubjectService _subjectService;
        

        public HomeController(IStudentService setService, IUserService userService, ITeacherService teacherService, 
            ISubjectService subjectService)
        {
            _studentService = setService;
            _userService = userService;
            _teacherService = teacherService;
            _subjectService = subjectService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Profile(string id)
        {
            var student = _studentService.GetStudentByUserId(id);
            if (student != null)
            {
                return View(student);
            }
            var teacher = _teacherService.GetTeacherByUserId(id);
            if (teacher != null)
            {
                return View(teacher);
            }
            return NotFound();
        }
    }
}
