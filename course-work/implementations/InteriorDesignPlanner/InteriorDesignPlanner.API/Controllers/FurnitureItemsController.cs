using InteriorDesignPlanner.API.Data;
using InteriorDesignPlanner.API.DTOs;
using InteriorDesignPlanner.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InteriorDesignPlanner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FurnitureItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FurnitureItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FurnitureItem>>> GetFurnitureItems(
            string? category,
            string? material,
            string? sortBy,
            string? sortDirection,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var query = _context.FurnitureItems.AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
                query = query.Where(f => f.Category.Contains(category));

            if (!string.IsNullOrWhiteSpace(material))
                query = query.Where(f => f.Material.Contains(material));

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                query = sortBy.ToLower() switch
                {
                    "name" => sortDirection == "desc"
                        ? query.OrderByDescending(f => f.Name)
                        : query.OrderBy(f => f.Name),

                    "price" => sortDirection == "desc"
                        ? query.OrderByDescending(f => f.Price)
                        : query.OrderBy(f => f.Price),

                    _ => query
                };
            }

            var result = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FurnitureItem>> GetFurnitureItem(int id)
        {
            var furnitureItem = await _context.FurnitureItems.FindAsync(id);

            if (furnitureItem == null)
                return NotFound();

            return Ok(furnitureItem);
        }

        [HttpPost]
        public async Task<ActionResult<FurnitureItem>> CreateFurnitureItem(FurnitureItemDto dto)
        {
            var furnitureItem = new FurnitureItem
            {
                Name = dto.Name,
                Category = dto.Category,
                Price = dto.Price,
                Material = dto.Material,
                Color = dto.Color,
                IsAvailable = dto.IsAvailable
            };

            _context.FurnitureItems.Add(furnitureItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetFurnitureItem),
                new { id = furnitureItem.Id },
                furnitureItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFurnitureItem(int id, FurnitureItemDto dto)
        {
            var furnitureItem = await _context.FurnitureItems.FindAsync(id);

            if (furnitureItem == null)
                return NotFound();

            furnitureItem.Name = dto.Name;
            furnitureItem.Category = dto.Category;
            furnitureItem.Price = dto.Price;
            furnitureItem.Material = dto.Material;
            furnitureItem.Color = dto.Color;
            furnitureItem.IsAvailable = dto.IsAvailable;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFurnitureItem(int id)
        {
            var furnitureItem = await _context.FurnitureItems.FindAsync(id);

            if (furnitureItem == null)
                return NotFound();

            _context.FurnitureItems.Remove(furnitureItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}