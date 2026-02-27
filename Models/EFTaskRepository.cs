using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mission8_3_11.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskDbContext _context;

        public EFTaskRepository(TaskDbContext context)
        {
            _context = context;
        }

        // Include Category so views can display CategoryName without extra queries
        public List<TaskItem> Tasks => _context.Tasks.Include(t => t.Category).ToList();

        public List<Category> Categories => _context.Categories.ToList();

        public void AddTask(TaskItem task)
        {
            _context.Tasks.Add(task);
        }

        public void UpdateTask(TaskItem task)
        {
            _context.Tasks.Update(task);
        }

        public void DeleteTask(TaskItem task)
        {
            _context.Tasks.Remove(task);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}