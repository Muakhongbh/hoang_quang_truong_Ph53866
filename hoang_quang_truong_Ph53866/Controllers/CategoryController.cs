using hoang_quang_truong_Ph53866.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace hoang_quang_truong_Ph53866.Controllers
{
    public class CategoryController : Controller
    {
            private readonly MyDbContext _context;

            public CategoryController(MyDbContext context)
            {
                _context = context;
            }

            // Hiển thị danh sách thể loại
            public IActionResult Index()
            {
                var categories = _context.Categories.ToList();
                return View(categories);
            }

            // Hiển thị form thêm thể loại
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            // Xử lý form thêm thể loại
            [HttpPost]
            public IActionResult Create(Category category)
            {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index", " Category");
        }

            // Hiển thị form sửa thể loại
            [HttpGet]
            public IActionResult Edit(int id)
            {
                var category = _context.Categories.Find(id);
                if (category == null)
                {
                    return NotFound();
                }
                return View(category);
            }

            // Xử lý form sửa thể loại
            [HttpPost]
            public IActionResult Edit(int id, Category category)
            {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

            // Xác nhận xóa thể loại
            [HttpPost, ActionName("Delete")]
            public IActionResult DeleteConfirmed(int id)
            {
                var category = _context.Categories.Find(id);
                if (category == null)
                {
                    return NotFound();
                }

                _context.Categories.Remove(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
    }
