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
    public class DesignProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DesignProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesignProject>>> GetProjects(
            string? style,
            string? roomType,
            string? sortBy,
            string? sortDirection,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var query = _context.DesignProjects.AsQueryable();

            if (!string.IsNullOrWhiteSpace(style))
                query = query.Where(p => p.Style.Contains(style));

            if (!string.IsNullOrWhiteSpace(roomType))
                query = query.Where(p => p.RoomType.Contains(roomType));

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                query = sortBy.ToLower() switch
                {
                    "title" => sortDirection == "desc"
                        ? query.OrderByDescending(p => p.Title)
                        : query.OrderBy(p => p.Title),

                    "budget" => sortDirection == "desc"
                        ? query.OrderByDescending(p => p.Budget)
                        : query.OrderBy(p => p.Budget),

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
        public async Task<ActionResult<DesignProject>> GetProject(int id)
        {
            var project = await _context.DesignProjects.FindAsync(id);

            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<DesignProject>> CreateProject(DesignProjectDto dto)
        {
            var project = new DesignProject
            {
                Title = dto.Title,
                Description = dto.Description,
                Style = dto.Style,
                RoomType = dto.RoomType,
                Budget = dto.Budget
            };

            _context.DesignProjects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetProject),
                new { id = project.Id },
                project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, DesignProjectDto dto)
        {
            var project = await _context.DesignProjects.FindAsync(id);

            if (project == null)
                return NotFound();

            project.Title = dto.Title;
            project.Description = dto.Description;
            project.Style = dto.Style;
            project.RoomType = dto.RoomType;
            project.Budget = dto.Budget;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.DesignProjects.FindAsync(id);

            if (project == null)
                return NotFound();

            _context.DesignProjects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}