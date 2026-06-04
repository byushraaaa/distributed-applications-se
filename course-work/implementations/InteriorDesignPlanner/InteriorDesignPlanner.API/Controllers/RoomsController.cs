using InteriorDesignPlanner.API.DTOs;
using InteriorDesignPlanner.API.Models;
using InteriorDesignPlanner.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesignPlanner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomsController(IRoomService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms(
            string? type,
            string? style,
            string? sortBy,
            string? sortDirection,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var rooms = await _service.GetAllRoomsAsync();

            var query = rooms.AsQueryable();

            if (!string.IsNullOrWhiteSpace(type))
                query = query.Where(r => r.Type.Contains(type));

            if (!string.IsNullOrWhiteSpace(style))
                query = query.Where(r => r.Style.Contains(style));

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                query = sortBy.ToLower() switch
                {
                    "name" => sortDirection == "desc"
                        ? query.OrderByDescending(r => r.Name)
                        : query.OrderBy(r => r.Name),

                    "budget" => sortDirection == "desc"
                        ? query.OrderByDescending(r => r.Budget)
                        : query.OrderBy(r => r.Budget),

                    "size" => sortDirection == "desc"
                        ? query.OrderByDescending(r => r.Size)
                        : query.OrderBy(r => r.Size),

                    _ => query
                };
            }

            var result = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _service.GetRoomByIdAsync(id);

            if (room == null)
                return NotFound();

            return Ok(room);
        }

        [HttpPost]
        public async Task<ActionResult<Room>> CreateRoom(RoomDto dto)
        {
            var createdRoom = await _service.CreateRoomAsync(dto);

            return CreatedAtAction(
                nameof(GetRoom),
                new { id = createdRoom.Id },
                createdRoom);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, RoomDto dto)
        {
            var updated = await _service.UpdateRoomAsync(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var deleted = await _service.DeleteRoomAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}