using Microsoft.AspNetCore.Mvc;

namespace EFCore_101.Controllers
{
    public class Chapter1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
