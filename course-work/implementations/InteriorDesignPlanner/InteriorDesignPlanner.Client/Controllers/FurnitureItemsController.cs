using InteriorDesignPlanner.Client.Models;
using InteriorDesignPlanner.Client.Services;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesignPlanner.Client.Controllers
{
    public class FurnitureItemsController : Controller
    {
        private readonly ApiService _apiService;

        public FurnitureItemsController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            var items = await _apiService.GetFurnitureItemsAsync(token);

            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FurnitureItemViewModel item)
        {
            var token = HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            await _apiService.CreateFurnitureItemAsync(item, token);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var token = HttpContext.Session.GetString("JwtToken");

            var item = await _apiService.GetFurnitureItemByIdAsync(id, token);

            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FurnitureItemViewModel item)
        {
            var token = HttpContext.Session.GetString("JwtToken");

            await _apiService.UpdateFurnitureItemAsync(item, token);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetString("JwtToken");

            await _apiService.DeleteFurnitureItemAsync(id, token);

            return RedirectToAction(nameof(Index));
        }
    }
}