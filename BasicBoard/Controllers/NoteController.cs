using BasicBoard.Data;
using BasicBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BasicBoard.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _db;
        public NoteController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int page = 1)
        {
            int totalCount = _db.Notes.FromSql($"Select * from Notes").Count();
            int countList = 10;
            int totalPage = totalCount / countList;
            if (totalCount % countList > 0) totalPage++;
            if (totalCount < page) page = totalPage;

            int countPage = 10;
            int startPage = ((page - 1) / countPage) * countPage + 1;
            int endPage = startPage + countPage - 1;
            if (totalPage < endPage) endPage = totalPage;

            int startCount = ((page - 1) * countPage) + 1;
            int endCount = startCount + 9;

            ViewBag.StartPage = startPage;
            ViewBag.EndPage = endPage;
            ViewBag.Page = page;
            ViewBag.TotalPage = totalPage;

            var StartCount = new SqlParameter("StartCount", startCount);
            var EndCount = new SqlParameter("EndCount", endCount);

            var objNoteList = _db.Notes.FromSql($"EXECUTE dbo.NEW_PagingNote @StartCount = {StartCount}, @EndCount ={EndCount}").ToList();

            //IEnumerable<Note> objNoteList = _db.Notes.ToList();
            return View(objNoteList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note objNote)
        {
            if (objNote.Name == null)
            {
                ModelState.AddModelError("CustomError", "The Name is mandatory");
            }
            objNote.UserId = "auto-gen";
            _db.Notes.Add(objNote);
            _db.SaveChanges();
            TempData["success"] = "Note inserted successfully";
            
            return RedirectToAction("Index","Note");
        }


        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var noteFromDb = _db.Notes.Find(Id);

            if (noteFromDb == null)
            {
                return NotFound();
            }
            return View(noteFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note objNote)
        {
            objNote.UserId = "auto-gen";
            _db.Notes.Update(objNote);
            _db.SaveChanges();
            TempData["success"] = "Note edited successfully";


            return RedirectToAction("Index", "Note");
        }

        public IActionResult Delete(int? Id)
        {
            if (Id==null || Id==0)
            {
                return NotFound();
            }
            var noteFromDb = _db.Notes.Find(Id);

            if (noteFromDb == null)
            {
                return NotFound();
            }
            return View(noteFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.Notes.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Notes.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Note deleted successfully";


            return RedirectToAction("Index", "Note");
        }
        public IActionResult Detail(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var noteFromDb = _db.Notes.Find(Id);
            if (noteFromDb == null)
            {
                return NotFound();
            }
            noteFromDb.ReadCount++;
            _db.Notes.Update(noteFromDb);
            _db.SaveChanges();
            return View(noteFromDb);
        }
    }
}
