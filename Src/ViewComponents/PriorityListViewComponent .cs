using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WebCoreTest.Models;

namespace WebCoreTest.ViewComponents
{
    public class PriorityListViewComponent : ViewComponent
    {
        private readonly ToDoContext db;
        public PriorityListViewComponent(ToDoContext context)
        {
            db = context;
        }

        // InvokeAsync is called from a view, and it can take an arbitrary number of arguments.
        public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
        {
            var viewName = "default";
            if (maxPriority>3)
            {
                viewName = "PVC";
            }
            var items = await GetItemsAsync(maxPriority, isDone);
            return View(viewName, items);
        }

        private Task<List<TodoItem>> GetItemsAsync(int maxPriority, bool isDone)
        {
            return db.ToDo.Where(x => x.IsDone == isDone &&
                                      x.Priority <= maxPriority).ToListAsync();
        }
    }
}
