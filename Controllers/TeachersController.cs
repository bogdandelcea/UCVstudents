using Microsoft.AspNetCore.Mvc;

namespace UCVstudents.Controllers
{
    public class TeachersController : Controller
    {
      private readonly ITeacherService _teacherSerivce;
      
      public TeacherController(ITeacherService teacherService)
      {
         _teacherService = teacherService;
      }
        public async Task<IActionResult> Index()
        {
            var teachers = await _teacherService.GetAllTeachersAsync();
            return View(teachers);
        }
    }
}
