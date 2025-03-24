using Microsoft.AspNetCore.Mvc;

namespace UCVstudents.Controllers
{
    public class DocumentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
