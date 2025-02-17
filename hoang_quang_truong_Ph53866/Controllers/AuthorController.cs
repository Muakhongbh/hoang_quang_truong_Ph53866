using hoang_quang_truong_Ph53866.Models;
using Microsoft.AspNetCore.Mvc;

namespace hoang_quang_truong_Ph53866.Controllers
{
    public class AuthorController : Controller
    {
        private readonly MyDbContext _context;

        public AuthorController(MyDbContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách tác giả
        public IActionResult Index()
        {
            var authors = _context.Authors.ToList();
            return View(authors);
        }

        // Hiển thị form thêm tác giả
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý form thêm tác giả
        [HttpPost]
        public IActionResult Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index", "Author");
        }

        // Hiển thị form sửa tác giả
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // Xử lý form sửa tác giả
        [HttpPost]
        public IActionResult Edit(int id, Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
            return RedirectToAction("Index", "Author");
        }

        // Xác nhận xóa tác giả
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            _context.SaveChanges();
            return RedirectToAction("Index", "Author");
        }
    }
}
