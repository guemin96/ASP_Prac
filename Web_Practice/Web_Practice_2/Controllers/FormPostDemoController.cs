using Microsoft.AspNetCore.Mvc;

namespace Web_Practice_2.Controllers
{
    public class FormPostDemoController : Controller
    {
        /// <summary>
        /// 폼 데이터 전송 및 받기
        /// </summary>
        /// <returns></returns>
        [HttpGet]   // /FormPostDemo/Index
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]  // /FormPostDemo/Index
        public IActionResult Index(string name, string content)
        {
            //ViewBag.Result = $"이름 : {Request.Form["name"]}," + $"내용 : {Request.Form["content"]}";
            ViewBag.Result = $"이름 : {name}, 내용 : {content}";
            return View();
        }


    }
}
