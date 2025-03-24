using Microsoft.AspNetCore.Mvc;

namespace UCVstudents.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
