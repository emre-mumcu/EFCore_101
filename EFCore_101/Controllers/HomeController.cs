using EFCore_101.App_Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EFCore_101.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View(viewName: "_ContentViewerLayout", model: "Index");
    }
}