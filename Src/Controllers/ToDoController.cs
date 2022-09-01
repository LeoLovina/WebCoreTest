using Microsoft.AspNetCore.Mvc;
using WebCoreTest.Models;

namespace WebCoreTest.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext _db;
        public ToDoController(ToDoContext context)
        {
            _db = context;

            // EnsureCreated() is used to call OnModelCreating for In-Memory databases as migration is not possible
            _db.Database.EnsureCreated();
        }
        public IActionResult Index()
        {
            var model = _db.ToDo.ToList();
            return View(model);
        }
    }
}
