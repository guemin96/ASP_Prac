using Microsoft.AspNetCore.Mvc;

namespace Web_Practice_2.Controllers
{
    public class RazorDemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Demo1()
        {
            return View();
        }
        public IActionResult Demo2()
        {
            return View();
        }
    }
}
