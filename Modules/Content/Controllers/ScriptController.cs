using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContentApi.Data;
using ContentApi.Modules.Content.Models;

namespace ContentApi.Modules.Content.Controllers;

[ApiController]
[Route("api/content/script")]
[Authorize]
public class ScriptController : ControllerBase
{
    private readonly AppDbContext _db;
    public ScriptController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _db.ScriptItems.OrderByDescending(i => i.CreatedAt).ToListAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var item = await _db.ScriptItems.FindAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ScriptItem body)
    {
        body.Id = Guid.NewGuid();
        body.CreatedAt = DateTime.UtcNow;
        body.UpdatedAt = DateTime.UtcNow;
        _db.ScriptItems.Add(body);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = body.Id }, body);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ScriptItem body)
    {
        var item = await _db.ScriptItems.FindAsync(id);
        if (item is null) return NotFound();

        item.Title = body.Title;
        item.Status = body.Status;
        item.Priority = body.Priority;
        item.Assignee = body.Assignee;
        item.Reviewer = body.Reviewer;
        item.DueDate = body.DueDate;
        item.Comments = body.Comments;
        item.Attachments = body.Attachments;
        item.RevisionCount = body.RevisionCount;
        item.Campaign = body.Campaign;
        item.RelatedStory = body.RelatedStory;
        item.ScriptCode = body.ScriptCode;
        item.OverviewJson = body.OverviewJson;
        item.HookJson = body.HookJson;
        item.FrameworkJson = body.FrameworkJson;
        item.FullScript = body.FullScript;
        item.VoiceoverScript = body.VoiceoverScript;
        item.OnScreenTextJson = body.OnScreenTextJson;
        item.ScenesJson = body.ScenesJson;
        item.VoiceJson = body.VoiceJson;
        item.CtaJson = body.CtaJson;
        item.FilmingNotesJson = body.FilmingNotesJson;
        item.EditingNotesJson = body.EditingNotesJson;
        item.ApprovalJson = body.ApprovalJson;
        item.UpdatedAt = DateTime.UtcNow;

        await _db.SaveChangesAsync();
        return Ok(item);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var item = await _db.ScriptItems.FindAsync(id);
        if (item is null) return NotFound();
        _db.ScriptItems.Remove(item);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
