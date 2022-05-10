using Microsoft.AspNetCore.Mvc;

namespace NBPApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
