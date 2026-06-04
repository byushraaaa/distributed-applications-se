using InteriorDesignPlanner.Client.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace InteriorDesignPlanner.Client.Services
{
    public class ApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> LoginAsync(object data)
        {
            var client = _httpClientFactory.CreateClient("InteriorDesignPlannerAPI");

            var json = JsonSerializer.Serialize(data);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync(
                "api/Auth/login",
                content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> RegisterAsync(object data)
        {
            var client = _httpClientFactory.CreateClient("InteriorDesignPlannerAPI");

            var json = JsonSerializer.Serialize(data);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync(
                "api/Auth/register",
                content);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<List<RoomViewModel>> GetRoomsAsync(string token)
        {
            var client = _httpClientFactory.CreateClient("InteriorDesignPlannerAPI");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetStringAsync("api/Rooms");

            var rooms = JsonSerializer.Deserialize<List<RoomViewModel>>(
                response,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return rooms ?? new List<RoomViewModel>();
        }

        public async Task CreateRoomAsync(RoomViewModel room, string token)
        {
            var client = _httpClientFactory.CreateClient("InteriorDesignPlannerAPI");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var json = JsonSerializer.Serialize(room);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            await client.PostAsync("api/Rooms", content);
        }

        public async Task<RoomViewModel?> GetRoomByIdAsync(int id, string token)
        {
            var client = _httpClientFactory.CreateClient("InteriorDesignPlannerAPI");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetStringAsync($"api/Rooms/{id}");

            return JsonSerializer.Deserialize<RoomViewModel>(
                response,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public async Task UpdateRoomAsync(RoomViewModel room, string token)
        {
            var client = _httpClientFactory.CreateClient("InteriorDesignPlannerAPI");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var json = JsonSerializer.Serialize(room);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            await client.PutAsync($"api/Rooms/{room.Id}", content);
        }

        public async Task DeleteRoomAsync(int id, string token)
        {
            var client = _httpClientFactory.CreateClient("InteriorDesignPlannerAPI");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            await client.DeleteAsync($"api/Rooms/{id}");
        }
        public async Task<List<DesignProjectViewModel>> GetDesignProjectsAsync(string token)
        {
            var client = _httpClientFactory.CreateClient("InteriorDesignPlannerAPI");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetStringAsync("api/DesignProjects");

            var projects = JsonSerializer.Deserialize<List<DesignProjectViewModel>>(
                response,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return projects ?? new List<DesignProjectViewModel>();
        }

        public async Task CreateDesignProjectAsync(DesignProjectViewModel project, string token)
        {
            var client = _httpClientFactory.CreateClient("InteriorDesignPlannerAPI");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var json = JsonSerializer.Serialize(project);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await client.PostAsync("api/DesignProjects", content);
        }

        public async Task<DesignProjectViewModel?> GetDesignProjectByIdAsync(int id, string token)
        {
            var client = _httpClientFactory.CreateClient("InteriorDesignPlannerAPI");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetStringAsync($"api/DesignProjects/{id}");

            return JsonSerializer.Deserialize<DesignProjectViewModel>(
                response,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public async Task UpdateDesignProjectAsync(DesignProjectViewModel project, string token)
        {
            var client = _httpClientFactory.CreateClient("InteriorDesignPlannerAPI");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var json = JsonSerializer.Serialize(project);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await client.PutAsync($"api/DesignProjects/{project.Id}", content);
        }

        public async Task DeleteDesignProjectAsync(int id, string token)
        {
            var client = _httpClientFactory.CreateClient("InteriorDesignPlannerAPI");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            await client.DeleteAsync($"api/DesignProjects/{id}");
        }

        public async Task<List<FurnitureItemViewModel>> GetFurnitureItemsAsync(string token)
        {
            var client = _httpClientFactory.CreateClient("InteriorDesignPlannerAPI");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetStringAsync("api/FurnitureItems");

            var items = JsonSerializer.Deserialize<List<FurnitureItemViewModel>>(
                response,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return items ?? new List<FurnitureItemViewModel>();
        }

        public async Task CreateFurnitureItemAsync(FurnitureItemViewModel item, string token)
        {
            var client = _httpClientFactory.CreateClient("InteriorDesignPlannerAPI");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var json = JsonSerializer.Serialize(item);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await client.PostAsync("api/FurnitureItems", content);
        }

        public async Task<FurnitureItemViewModel?> GetFurnitureItemByIdAsync(int id, string token)
        {
            var client = _httpClientFactory.CreateClient("InteriorDesignPlannerAPI");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetStringAsync($"api/FurnitureItems/{id}");

            return JsonSerializer.Deserialize<FurnitureItemViewModel>(
                response,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public async Task UpdateFurnitureItemAsync(FurnitureItemViewModel item, string token)
        {
            var client = _httpClientFactory.CreateClient("InteriorDesignPlannerAPI");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var json = JsonSerializer.Serialize(item);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await client.PutAsync($"api/FurnitureItems/{item.Id}", content);
        }

        public async Task DeleteFurnitureItemAsync(int id, string token)
        {
            var client = _httpClientFactory.CreateClient("InteriorDesignPlannerAPI");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            await client.DeleteAsync($"api/FurnitureItems/{id}");
        }
    }
}