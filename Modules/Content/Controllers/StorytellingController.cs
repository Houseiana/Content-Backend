using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContentApi.Data;
using ContentApi.Modules.Content.Models;

namespace ContentApi.Modules.Content.Controllers;

[ApiController]
[Route("api/content/storytelling")]
[Authorize]
public class StorytellingController : ControllerBase
{
    private readonly AppDbContext _db;
    public StorytellingController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _db.StorytellingItems.OrderByDescending(i => i.CreatedAt).ToListAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var item = await _db.StorytellingItems.FindAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StorytellingItem body)
    {
        body.Id = Guid.NewGuid();
        body.CreatedAt = DateTime.UtcNow;
        body.UpdatedAt = DateTime.UtcNow;
        _db.StorytellingItems.Add(body);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = body.Id }, body);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] StorytellingItem body)
    {
        var item = await _db.StorytellingItems.FindAsync(id);
        if (item is null) return NotFound();

        item.Title = body.Title;
        item.Status = body.Status;
        item.Priority = body.Priority;
        item.Assignee = body.Assignee;
        item.DueDate = body.DueDate;
        item.Comments = body.Comments;
        item.Attachments = body.Attachments;
        item.LinkedIdea = body.LinkedIdea;
        item.Campaign = body.Campaign;
        item.OverviewJson = body.OverviewJson;
        item.AudienceJson = body.AudienceJson;
        item.CoreMessageJson = body.CoreMessageJson;
        item.EmotionalDirectionJson = body.EmotionalDirectionJson;
        item.FrameworkJson = body.FrameworkJson;
        item.HookJson = body.HookJson;
        item.NarrativeFlowJson = body.NarrativeFlowJson;
        item.BrandVoiceJson = body.BrandVoiceJson;
        item.VisualNotesJson = body.VisualNotesJson;
        item.CtaJson = body.CtaJson;
        item.UpdatedAt = DateTime.UtcNow;

        await _db.SaveChangesAsync();
        return Ok(item);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var item = await _db.StorytellingItems.FindAsync(id);
        if (item is null) return NotFound();
        _db.StorytellingItems.Remove(item);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
