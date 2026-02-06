using Microsoft.AspNetCore.Mvc;
using BT04.Data;
using BT04.Models;

namespace BT04.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. Danh sách
        public IActionResult Index()
        {
            return View(_context.Todos.ToList());
        }

        // 2. Thêm mới (GET)
        public IActionResult Create()
        {
            return View();
        }

        // 3. Thêm mới (POST)
        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // 4. Sửa (GET)
        public IActionResult Edit(int id)
        {
            return View(_context.Todos.Find(id));
        }

        // 5. Sửa (POST)
        [HttpPost]
        public IActionResult Edit(Todo todo)
        {
            _context.Todos.Update(todo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // 6. Chi tiết
        public IActionResult Details(int id)
        {
            return View(_context.Todos.Find(id));
        }

        // 7. Xóa
        public IActionResult Delete(int id)
        {
            var todo = _context.Todos.Find(id);
            _context.Todos.Remove(todo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
