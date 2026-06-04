using InteriorDesignPlanner.API.Models;

namespace InteriorDesignPlanner.API.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllAsync();

        Task<Room?> GetByIdAsync(int id);

        Task<Room> CreateAsync(Room room);

        Task UpdateAsync(Room room);

        Task DeleteAsync(Room room);
    }
}