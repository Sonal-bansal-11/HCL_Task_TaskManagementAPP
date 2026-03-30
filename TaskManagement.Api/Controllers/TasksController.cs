using Microsoft.AspNetCore.Mvc;
using TaskManagement.Api.Models;
using TaskManagement.Api.Services;

namespace TaskManagement.Api.Controllers
{
    // [Route] decides url of Controller (here: api/tasks)
    [Route("api/[controller]")]
    // [ApiController] ensures Model Validation (like Title is Required) automatically
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        // Dependency Injection to get service instance through constructor
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks); // 200 OK status with list of tasks in response body
        }

        // GET: api/tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null) return NotFound(); // 404 Not Found if task with given ID does not exist

            return Ok(task);
        }

        // POST: api/tasks (To create a new task)
        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task)
        {
            var createdTask = await _taskService.CreateTaskAsync(task);

            // 201 Created status with Location header pointing to the newly created task's URL and the created task in response body
            return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
        }

        // PUT: api/tasks/5 (update a specific task)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskItem task)
        {
            var updatedTask = await _taskService.UpdateTaskAsync(id, task);

            if (updatedTask == null) return BadRequest("Task ID mismatch or Task not found.");

            return NoContent(); // 204 NoContent (Update Successful but there is no data to send)
        }

        // DELETE: api/tasks/5 (TO Delete a specific task)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var success = await _taskService.DeleteTaskAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}