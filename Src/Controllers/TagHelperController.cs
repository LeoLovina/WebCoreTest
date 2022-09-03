using Microsoft.AspNetCore.Mvc;
using WebCoreTest.Models;

namespace WebCoreTest.Controllers
{
	public class TagHelperController : Controller
	{
        private readonly ToDoContext _db;
		public TagHelperController (ToDoContext context)
        {
            _db = context;

            // EnsureCreated() is used to call OnModelCreating for In-Memory databases as migration is not possible
            _db.Database.EnsureCreated();
        }
        public IActionResult Index()
		{
            WebInfo info = _db.Info.First();
            return View(info);
		}
	}
}
