using Microsoft.AspNetCore.Mvc;

namespace UCVstudents.Controllers
{
    public class TeachersController : Controller
    {
     private readonly ITeacherService _teacherService
       public TeachersController(ITeacherService teacherService)
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
