using System.Collections.Generic;

namespace Mission8_3_11.Models
{
    public interface ITaskRepository
    {
        List<TaskItem> Tasks { get; }
        List<Category> Categories { get; }

        void AddTask(TaskItem task);
        void UpdateTask(TaskItem task);
        void DeleteTask(TaskItem task);
        void Save();
    }
}