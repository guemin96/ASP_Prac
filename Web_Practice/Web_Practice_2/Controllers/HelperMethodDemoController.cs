﻿using Microsoft.AspNetCore.Mvc;

namespace Web_Practice_2.Controllers
{
    public class HelperMethodDemoController : Controller
    {
        /// <summary>
        /// 메인 링크
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 폼 생성
        /// </summary>
        public IActionResult FormDemo()
        {
            return View();
        }
        /// <summary>
        /// 입력 요소
        /// </summary>
        public IActionResult InputDemo()
        {
            return View();
        }
        /// <summary>
        /// 선택 요소
        /// </summary>
        public IActionResult SelectDemo()
        {
            return View();
        }
        /// <summary>
         /// 강력한 형식의 뷰 : 특정 모델 클래스가 사용되는 뷰
         /// </summary>
        public IActionResult StronglyTypedDemo()
        {
            var stc = new StronglyTypedClass()
            {
                Id = 1,
                Name = "홍길동",
                Age = 21
            };
            return View(stc);
        }
        /// <summary>
         /// CSS class 속성 주기
         /// </summary>
        public IActionResult CSSClassDemo()
        {
            return View();
        }
        /// <summary>
         /// 부분 페이지
         /// </summary>
        public IActionResult PartialViewDemo()
        {
            return View();
        }
    }
}

/// <summary>
/// 강력한 형식의 뷰 페이지 테스트용 모델 클래스
/// </summary>
public class StronglyTypedClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}