using Microsoft.AspNetCore.Mvc;

namespace UCVstudents.Controllers
{
    public class TeachersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
