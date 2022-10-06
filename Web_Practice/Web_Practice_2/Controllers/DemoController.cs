using Microsoft.AspNetCore.Mvc;

namespace Web_Practice_2.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View("Default");
        }
        public IActionResult ContentResultDemo()
        {
            return Content("ContentResult 반환값");
        }
    }
}
