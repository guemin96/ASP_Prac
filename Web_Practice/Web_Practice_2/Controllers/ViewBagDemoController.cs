using Microsoft.AspNetCore.Mvc;

namespace Web_Practice_2.Controllers
{
    public class ViewBagDemoController : Controller
    {
        /// <summary>
        /// ViewBagㄱ 개체로 컨트롤러에서 뷰로 데이터 전달
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewBag.Name = "박용준";  //ViewData["Name"]는 동일 표현
            ViewBag.Age = 21;
            ViewBag.원하는모든단어 = "모든 값...";

            ViewBag.Address = "Bag세종시";
            //ViewData["Address"] = "Data세종시...";
            return View();
        }
    }
}
