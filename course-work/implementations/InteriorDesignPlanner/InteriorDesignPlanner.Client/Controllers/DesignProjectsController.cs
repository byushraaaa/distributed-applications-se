using InteriorDesignPlanner.Client.Models;
using InteriorDesignPlanner.Client.Services;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesignPlanner.Client.Controllers
{
    public class DesignProjectsController : Controller
    {
        private readonly ApiService _apiService;

        public DesignProjectsController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            var projects = await _apiService.GetDesignProjectsAsync(token);

            return View(projects);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DesignProjectViewModel project)
        {
            var token = HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            await _apiService.CreateDesignProjectAsync(project, token);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var token = HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            var project = await _apiService.GetDesignProjectByIdAsync(id, token);

            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DesignProjectViewModel project)
        {
            var token = HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            await _apiService.UpdateDesignProjectAsync(project, token);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            await _apiService.DeleteDesignProjectAsync(id, token);

            return RedirectToAction(nameof(Index));
        }
    }
}