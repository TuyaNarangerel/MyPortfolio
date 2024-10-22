using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly PortfolioDbContext _context;

    public ProjectsController(PortfolioDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
    {
        return await _context.Projects.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetProject(int id)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project == null)
        {
            return NotFound();
        }

        return project;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProject(int id, Project project)
    {
        if (id != project.Id)
        {
            return BadRequest();
        }

        _context.Entry(project).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Projects.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project == null)
        {
            return NotFound();
        }

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();

        return NoContent();
    }


}
