using System.Collections.Generic;

namespace Mission8_3_11.Models
{
    public interface ITaskRepository
    {
        // All tasks for Index view
        List<TaskItem> Tasks { get; }

        // All categories for dropdowns
        List<Category> Categories { get; }

        // CRUD operations
        void AddTask(TaskItem task);
        void UpdateTask(TaskItem task);
        void DeleteTask(TaskItem task);
        void Save();

        // Retrieve a tracked task by ID for editing
        TaskItem? GetTrackedTaskById(int id);
    }
}