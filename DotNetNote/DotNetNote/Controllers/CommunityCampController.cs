using DotNetNote.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DotNetNote.Controllers
{
    public class CommunityCampController : Controller
    {
        //글 조회, 생성, 삭제를 담당하는 객체
        private ICommunityCampJoinMemberRepository _repository; 
        
        public CommunityCampController( ICommunityCampJoinMemberRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var list = _repository.GetAll();

            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(CommunityCampJoinMember model)
        {
            //서버 측 유효성 검사
            if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("Email", "이메일을 입력하시오.");
            }
            if (ModelState.IsValid)
            {
                ViewBag.Result = $"커뮤니티: {model.CommunityName}, 이름 : {model.Name}";

                //저장
                _repository.AddMember(model);
                TempData["Message"] = "데이터가 저장되었습니다.";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(CommunityCampJoinMember model)
        {
            if (ModelState.IsValid)
            {
                _repository.DeleteMember(model);
                TempData["Message"] = "데이터가 삭제되었습니다.";

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult ComCampAdmin()
        {
            var list = _repository.GetAll();

            return View(list);
        }
    }
}
