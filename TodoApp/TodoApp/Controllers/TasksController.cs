using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskRepository _taskRepository;

        public TasksController(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IActionResult Index()
        {
            var tasks = _taskRepository.GetAllTasks();
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Task task)
        {
            _taskRepository.AddTask(task);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(Task task)
        {
            _taskRepository.UpdateTask(task);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _taskRepository.DeleteTask(id);
            return RedirectToAction("Index");
        }
    }
}
