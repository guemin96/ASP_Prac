using Web_Practice_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web_Practice_2.Controllers
{
    public class ViewWithModelDemoController : Controller
    {
        public IActionResult Index()
        {
            DemoModel dm = new DemoModel();
            dm.Id = 1;
            dm.Name = "홍길동";
            return View(dm);
        }
    }
}
