﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_Practice_2.Models;

namespace Web_Practice_2.Controllers
{
    public class ViewWithListOfDemoController : Controller
    {
        /// <summary>
        /// 컨트롤러에서 컬렉션 형태의 데이터를 뷰 페이지로 전송하기
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            List<DemoModel> models = new List<DemoModel>()
            {
                new DemoModel{Id=1,Name="홍길동"},
                new DemoModel{Id=2,Name="백두산"},
                new DemoModel{Id=3,Name="임꺽정"}

            };
            return View(models);
        }
    }
}
