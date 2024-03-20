using System.Collections.Generic;
using System.Linq;
using TodoApp.Models;

namespace TodoApp.Models
{
    public class TaskRepository
    {
        private static List<Task> _tasks = new List<Task>
        {
            new Task { Id = 1, Title = "Task 1", Description = "Description for Task 1" },
            new Task { Id = 2, Title = "Task 2", Description = "Description for Task 2" },
            new Task { Id = 3, Title = "Task 3", Description = "Description for Task 3" }
        };

        public IEnumerable<Task> GetAllTasks()
        {
            return _tasks;
        }

        public Task GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void AddTask(Task task)
        {
            task.Id = _tasks.Count + 1;
            _tasks.Add(task);
        }

        public void UpdateTask(Task updatedTask)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
            if (existingTask != null)
            {
                existingTask.Title = updatedTask.Title;
                existingTask.Description = updatedTask.Description;
            }
        }

        public void DeleteTask(int id)
        {
            _tasks.RemoveAll(t => t.Id == id);
        }
    }
}
