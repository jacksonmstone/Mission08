using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission8_3_11.Models;

namespace Mission8_3_11.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskRepository _repo;

        public HomeController(ITaskRepository repo)
        {
            _repo = repo;
        }

        // GET /Home/Index
        public IActionResult Index()
        {
            return View(_repo.Tasks);
        }

        // ── ADD ──────────────────────────────────────────────────────────────

        // GET /Home/Add
        [HttpGet]
        public IActionResult Add()
        {
            PopulateCategoryDropdown();
            return View(new TaskItem());
        }

        // POST /Home/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(string Task, int Quadrant, int CategoryId, DateTime? DueDate)
        {
            var taskItem = new TaskItem
            {
                Task = Task,
                Quadrant = Quadrant,
                CategoryId = CategoryId,
                DueDate = DueDate
            };

            _repo.AddTask(taskItem);
            _repo.Save();

            return RedirectToAction(nameof(Index));
        }

        // ── EDIT ─────────────────────────────────────────────────────────────

        // GET /Home/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskItemId == id);
            if (task == null) return NotFound();
            PopulateCategoryDropdown();
            return View(task);
        }

        // POST /Home/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int TaskItemId, string Task, int Quadrant, int CategoryId, DateTime? DueDate, bool Completed = false)
        {
            // Get the tracked entity from the database
            var existingTask = _repo.GetTrackedTaskById(TaskItemId);
            if (existingTask == null)
            {
                return NotFound();
            }

            // Update properties
            existingTask.Task = Task;
            existingTask.Quadrant = Quadrant;
            existingTask.CategoryId = CategoryId;
            existingTask.DueDate = DueDate;
            existingTask.Completed = Completed;

            // Save changes to database
            _repo.Save();

            // Redirect to Index
            return RedirectToAction(nameof(Index));
        }

        // ── DELETE ───────────────────────────────────────────────────────────

        // POST /Home/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskItemId == id);
            if (task != null)
            {
                _repo.DeleteTask(task);
                _repo.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        // ── TOGGLE COMPLETE ──────────────────────────────────────────────────

        // POST /Home/ToggleComplete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleComplete(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskItemId == id);
            if (task != null)
            {
                task.Completed = !task.Completed;
                _repo.UpdateTask(task);
                _repo.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        // ── HELPER ───────────────────────────────────────────────────────────

        private void PopulateCategoryDropdown()
        {
            ViewBag.Categories = new SelectList(_repo.Categories, "CategoryId", "CategoryName");
        }
    }
}
