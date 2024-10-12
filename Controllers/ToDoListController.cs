using Microsoft.AspNetCore.Mvc;
using SimpleToDoApp.Data;
using SimpleToDoApp.Models;
using System.Threading.Tasks;
using System.Linq;

namespace SimpleToDoApp.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly ToDoAppDbContext _db;

        public ToDoListController(ToDoAppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            var lists = _db.ToDoItems.ToList();
            return View(lists);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ToDoItem toDoItem)
        {
            _db.ToDoItems.Add(toDoItem);
            _db.SaveChanges();
            return RedirectToAction("Details");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var toDoItem = await _db.ToDoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return NotFound();
            }
            return View(toDoItem);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ToDoItem toDoItem)
        {
            var existingItem = await _db.ToDoItems.FindAsync(toDoItem.Id);
            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Title = toDoItem.Title;
            existingItem.Description = toDoItem.Description;
            //existingItem.CreatedDate = toDoItem.CreatedDate;
            existingItem.DueDate = toDoItem.DueDate;
            existingItem.IsCompleted = toDoItem.IsCompleted;

            _db.ToDoItems.Update(existingItem);
            _db.SaveChanges();

            return RedirectToAction("Details");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var toDoItem = await _db.ToDoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return NotFound();
            }
            return View(toDoItem);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ToDoItem toDoItem)
        {
            var existingItem = await _db.ToDoItems.FindAsync(toDoItem.Id);
            if (existingItem == null)
            {
                return NotFound();
            }

            _db.ToDoItems.Remove(existingItem);

            await _db.SaveChangesAsync();
            return RedirectToAction("Details");
        }
    }
}
