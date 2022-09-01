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

        public IActionResult IndexVC()
        {
            // call the view component directly from the controller
            return ViewComponent("PriorityList", new { maxPriority = 3, isDone = false });
        }
    }
}
