using InteriorDesignPlanner.API.DTOs;
using InteriorDesignPlanner.API.Models;

namespace InteriorDesignPlanner.API.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync();

        Task<Room?> GetRoomByIdAsync(int id);

        Task<Room> CreateRoomAsync(RoomDto dto);

        Task<bool> UpdateRoomAsync(int id, RoomDto dto);

        Task<bool> DeleteRoomAsync(int id);
    }
}