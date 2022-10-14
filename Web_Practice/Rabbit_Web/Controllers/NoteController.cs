using Microsoft.AspNetCore.Mvc;
using Rabbit_Web.DataContext;
using Rabbit_Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rabbit_Web.Controllers {
    public class NoteController : Controller {
        /// <summary>
        /// 게시판 리스트
        /// </summary>
        /// <returns></returns>
        public IActionResult Index() {

            using (var db = new AspnetNoteDbContext()) 
            {
                var list = db.Notes.ToList();
                return View(list);
            }
        }

        /// <summary>
        /// 게시물 추가
        /// </summary>
        /// <returns></returns>
        public IActionResult Add() {
            return View();
        }

        /// <summary>
        /// 게시물 수정
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit() {
            return View();
        }

        /// <summary>
        /// 게시물 삭제
        /// </summary>
        /// <returns></returns>
        public IActionResult Delete() {
            return View();
        }
    }
}
