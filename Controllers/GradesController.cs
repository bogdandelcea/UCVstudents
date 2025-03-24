using Microsoft.AspNetCore.Mvc;

namespace UCVstudents.Controllers
{
    public class GradesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
