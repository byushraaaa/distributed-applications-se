using InteriorDesignPlanner.API.DTOs;
using InteriorDesignPlanner.API.Models;
using InteriorDesignPlanner.API.Repositories;

namespace InteriorDesignPlanner.API.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;

        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Room?> GetRoomByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Room> CreateRoomAsync(RoomDto dto)
        {
            var room = new Room
            {
                Name = dto.Name,
                Type = dto.Type,
                Size = dto.Size,
                Style = dto.Style,
                Budget = dto.Budget
            };

            return await _repository.CreateAsync(room);
        }

        public async Task<bool> UpdateRoomAsync(int id, RoomDto dto)
        {
            var existingRoom = await _repository.GetByIdAsync(id);

            if (existingRoom == null)
                return false;

            existingRoom.Name = dto.Name;
            existingRoom.Type = dto.Type;
            existingRoom.Size = dto.Size;
            existingRoom.Style = dto.Style;
            existingRoom.Budget = dto.Budget;

            await _repository.UpdateAsync(existingRoom);

            return true;
        }

        public async Task<bool> DeleteRoomAsync(int id)
        {
            var room = await _repository.GetByIdAsync(id);

            if (room == null)
                return false;

            await _repository.DeleteAsync(room);

            return true;
        }
    }
}