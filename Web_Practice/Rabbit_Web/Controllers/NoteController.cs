﻿using Microsoft.AspNetCore.Http;
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
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY")==null)
            {
                //로그인이 안된 상태
                return RedirectToAction("Login", "Account");
            }
            using (var db = new AspnetNoteDbContext()) 
            {
                var list = db.Notes.ToList();
                return View(list);
            }
        }
        /// <summary>
        /// 게시판 상세
        /// </summary>
        /// <param name="noteNo"></param>
        /// <returns></returns>
        public IActionResult Detail(int noteNo)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태
                return RedirectToAction("Login", "Account");

            }
            using (var db = new AspnetNoteDbContext() )
            {
                var note = db.Notes.FirstOrDefault(x => x.NoteNo.Equals(noteNo));
                return View(note);
            }
        }
        /// <summary>
        /// 게시물 추가
        /// </summary>
        /// <returns></returns>
        public IActionResult Add() {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Note model)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태
                return RedirectToAction("Login", "Account");
            }
            model.UserNo = int.Parse(HttpContext.Session.GetInt32("USER_LOGIN_KEY").ToString());

            if (ModelState.IsValid)
            {
                using(var db = new AspnetNoteDbContext())
                {
                    db.Notes.Add(model);
                    if (db.SaveChanges() >0) //Commit이 한개 이상일 경우 True
                    {
                        return Redirect("Index");   //동일한 컨트롤러에서는 Redirect, 다른 컨트롤러의 경우 RedirectToAction
                    }

                }
                ModelState.AddModelError(string.Empty, "게시물을 저장할 수 없습니다.");
            }
            return View(model);
        }

        /// <summary>
        /// 게시물 수정
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit() {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
        

        /// <summary>
        /// 게시물 삭제
        /// </summary>
        /// <returns></returns>
        public IActionResult Delete() {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}
