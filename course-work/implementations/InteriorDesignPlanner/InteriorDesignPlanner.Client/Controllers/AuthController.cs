using InteriorDesignPlanner.Client.Models;
using InteriorDesignPlanner.Client.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InteriorDesignPlanner.Client.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApiService _apiService;

        public AuthController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var response = await _apiService.LoginAsync(model);

            if (!response.Contains("token"))
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View(model);
            }

            var json = JsonDocument.Parse(response);

            var token = json.RootElement.GetProperty("token").GetString();

            HttpContext.Session.SetString("JwtToken", token);

            return RedirectToAction("Index", "Rooms");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _apiService.RegisterAsync(model);

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JwtToken");

            return RedirectToAction("Login");
        }
    }
}