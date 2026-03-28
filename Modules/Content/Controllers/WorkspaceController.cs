using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContentApi.Data;
using ContentApi.Modules.Content.Models;

namespace ContentApi.Modules.Content.Controllers;

[ApiController]
[Route("api/content/workspace")]
[Authorize]
public class WorkspaceController : ControllerBase
{
    private readonly AppDbContext _db;
    public WorkspaceController(AppDbContext db) => _db = db;

    // ── Projects ──

    [HttpGet("projects")]
    public async Task<IActionResult> GetProjects()
        => Ok(await _db.WorkspaceProjects
            .OrderByDescending(p => p.CreatedAt)
            .Select(p => new { p.Id, p.Title, p.CreatedAt })
            .ToListAsync());

    [HttpGet("projects/{id:guid}")]
    public async Task<IActionResult> GetProject(Guid id)
    {
        var project = await _db.WorkspaceProjects
            .Include(p => p.Nodes)
            .Include(p => p.Wires)
            .FirstOrDefaultAsync(p => p.Id == id);
        return project is null ? NotFound() : Ok(project);
    }

    [HttpPost("projects")]
    public async Task<IActionResult> CreateProject([FromBody] WorkspaceProject body)
    {
        body.Id = Guid.NewGuid();
        body.CreatedAt = DateTime.UtcNow;
        body.Nodes = new();
        body.Wires = new();
        _db.WorkspaceProjects.Add(body);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProject), new { id = body.Id }, body);
    }

    [HttpPut("projects/{id:guid}")]
    public async Task<IActionResult> UpdateProject(Guid id, [FromBody] WorkspaceProject body)
    {
        var project = await _db.WorkspaceProjects.FindAsync(id);
        if (project is null) return NotFound();
        project.Title = body.Title;
        await _db.SaveChangesAsync();
        return Ok(project);
    }

    [HttpDelete("projects/{id:guid}")]
    public async Task<IActionResult> DeleteProject(Guid id)
    {
        var project = await _db.WorkspaceProjects
            .Include(p => p.Nodes)
            .Include(p => p.Wires)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (project is null) return NotFound();
        _db.WorkspaceProjects.Remove(project);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    // ── Nodes ──

    [HttpPost("projects/{projectId:guid}/nodes")]
    public async Task<IActionResult> AddNode(Guid projectId, [FromBody] WorkspaceNode body)
    {
        if (!await _db.WorkspaceProjects.AnyAsync(p => p.Id == projectId))
            return NotFound("Project not found");

        body.Id = Guid.NewGuid();
        body.ProjectId = projectId;
        _db.WorkspaceNodes.Add(body);
        await _db.SaveChangesAsync();
        return Ok(body);
    }

    [HttpDelete("nodes/{id:guid}")]
    public async Task<IActionResult> DeleteNode(Guid id)
    {
        var node = await _db.WorkspaceNodes.FindAsync(id);
        if (node is null) return NotFound();
        _db.WorkspaceNodes.Remove(node);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    // ── Wires ──

    [HttpPost("projects/{projectId:guid}/wires")]
    public async Task<IActionResult> AddWire(Guid projectId, [FromBody] WorkspaceWire body)
    {
        if (!await _db.WorkspaceProjects.AnyAsync(p => p.Id == projectId))
            return NotFound("Project not found");

        body.Id = Guid.NewGuid();
        body.ProjectId = projectId;
        _db.WorkspaceWires.Add(body);
        await _db.SaveChangesAsync();
        return Ok(body);
    }

    [HttpDelete("wires/{id:guid}")]
    public async Task<IActionResult> DeleteWire(Guid id)
    {
        var wire = await _db.WorkspaceWires.FindAsync(id);
        if (wire is null) return NotFound();
        _db.WorkspaceWires.Remove(wire);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
