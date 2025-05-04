using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UCVstudents.Services.Interfaces;

namespace UCVstudents.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return View(students);
        }
    }
}
