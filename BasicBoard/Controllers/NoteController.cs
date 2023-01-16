using BasicBoard.Data;
using BasicBoard.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicBoard.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _db;
        public NoteController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Note> objNoteList = _db.Notes.ToList();
            return View(objNoteList);
        }
    }
}
