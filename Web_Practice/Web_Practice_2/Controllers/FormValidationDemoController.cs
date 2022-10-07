using Microsoft.AspNetCore.Mvc;
using Web_Practice_2.Models;

namespace Web_Practice_2.Controllers
{
    public class FormValidationDemoController : Controller
    {
        // [1] 따라하기 1: 폼 유효성 검사 테스트용 메인 페이지 작성 
        #region Main Page
        public IActionResult Index()
        {
            return View();
        }
        #endregion
        // [2] 따라하기 2: 순수 HTML과 JavaScript를 사용한 유효성 검사 
        #region HTML
        public IActionResult Html()     //[HttpGet] 특성이 생략된 상태
        {
            return View();
        }

        //[HttpPost] 특성이 생략된 상태
        public IActionResult HtmlProcess(string txtName, string txtContent)
        {
            ViewBag.ResultString = $"이름: {txtName}, 내용: {Request.Form["txtContent"]}";
            return View();
        }
        #endregion

        #region
        [HttpGet]
        public IActionResult HelperMethod()
        {
            return View();
        }
        [HttpPost]
        public IActionResult HelperMethod(string txtName, string txtContent)
        {
            ViewBag.ResultString = $"이름 : {txtName}, 내용 : {txtContent}";
            return View();
        }
        #endregion

        #region Strongly type View + Model Binding
        public IActionResult StronglyTypeView()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StronglyTypeView(MaximModel model)
        {

            return View();
        }
        #endregion
        #region Strongly type View + Model Binding
        public IActionResult ModelValidation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ModelValidation(MaximModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "이름을 입력하세요.");
            }
            if (string.IsNullOrEmpty(model.Content))
            {
                ModelState.AddModelError("Name", "내용을 입력하세요.");
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "모든 에러");
            }
            if (ModelState.IsValid)
            {
                return View("Completed");
            }

            return View();
        }
        public IActionResult Completed()
        {
            return View();
        }
        #endregion

        #region
        public IActionResult ClientValidation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ClientValidation(MaximModel model)
        {
            if (ModelState.IsValid)
            {
                return View("Completed");
            }
            return View();
        }
        #endregion

        #region
        public IActionResult TagHelperValidation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TagHelperValidation( MaximModel model)
        {
            if (ModelState.IsValid)
            {
                return View("Completed");
            }
            return View();
        }
        #endregion
    }
}
