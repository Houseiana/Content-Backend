using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContentApi.Data;
using ContentApi.Modules.Content.Models;

namespace ContentApi.Modules.Content.Controllers;

[ApiController]
[Route("api/content/filming")]
[Authorize]
public class FilmingController : ControllerBase
{
    private readonly AppDbContext _db;
    public FilmingController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _db.FilmingItems.OrderByDescending(i => i.CreatedAt).ToListAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var item = await _db.FilmingItems.FindAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FilmingItem body)
    {
        body.Id = Guid.NewGuid();
        body.CreatedAt = DateTime.UtcNow;
        body.UpdatedAt = DateTime.UtcNow;
        _db.FilmingItems.Add(body);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = body.Id }, body);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] FilmingItem body)
    {
        var item = await _db.FilmingItems.FindAsync(id);
        if (item is null) return NotFound();

        item.Title = body.Title;
        item.Status = body.Status;
        item.Priority = body.Priority;
        item.Assignee = body.Assignee;
        item.DueDate = body.DueDate;
        item.Comments = body.Comments;
        item.Attachments = body.Attachments;
        item.DetailsJson = body.DetailsJson;
        item.UpdatedAt = DateTime.UtcNow;

        await _db.SaveChangesAsync();
        return Ok(item);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var item = await _db.FilmingItems.FindAsync(id);
        if (item is null) return NotFound();
        _db.FilmingItems.Remove(item);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
