using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TaskManagement.Mvc.Models;

namespace TaskManagement.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController()
        {
            _httpClient = new HttpClient();
            
            _httpClient.BaseAddress = new Uri("http://localhost:5048/api/");
        }

        public async Task<IActionResult> Index()
        {
            List<TaskItem> tasks = new List<TaskItem>();

            // Send Get Request to API to fetch all tasks
            HttpResponseMessage response = await _httpClient.GetAsync("tasks");

            if (response.IsSuccessStatusCode)
            {
                // Convert Json Data to C# List(Deserialize)
                var data = await response.Content.ReadAsStringAsync();
                tasks = JsonSerializer.Deserialize<List<TaskItem>>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<TaskItem>();
            }

            // Send data to View (HTML page)
            return View(tasks);
        }
    }
}