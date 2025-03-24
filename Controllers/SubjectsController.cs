using Microsoft.AspNetCore.Mvc;

namespace UCVstudents.Controllers
{
    public class SubjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
