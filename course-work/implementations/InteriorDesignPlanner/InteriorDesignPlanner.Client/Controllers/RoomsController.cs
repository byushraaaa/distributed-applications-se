using InteriorDesignPlanner.Client.Models;
using InteriorDesignPlanner.Client.Services;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesignPlanner.Client.Controllers
{
    public class RoomsController : Controller
    {
        private readonly ApiService _apiService;

        public RoomsController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Auth");
            }

            var rooms = await _apiService.GetRoomsAsync(token);

            return View(rooms);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomViewModel room)
        {
            var token = HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Auth");
            }

            await _apiService.CreateRoomAsync(room, token);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var token = HttpContext.Session.GetString("JwtToken");

            var room = await _apiService.GetRoomByIdAsync(id, token);

            return View(room);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoomViewModel room)
        {
            var token = HttpContext.Session.GetString("JwtToken");

            await _apiService.UpdateRoomAsync(room, token);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetString("JwtToken");

            await _apiService.DeleteRoomAsync(id, token);

            return RedirectToAction(nameof(Index));
        }
    }
}