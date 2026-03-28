using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContentApi.Data;

namespace ContentApi.Modules.Content.Controllers;

[ApiController]
[Route("api/content/sections")]
[Authorize]
public class SectionsController : ControllerBase
{
    private readonly AppDbContext _db;
    public SectionsController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _db.Sections.ToListAsync());
}
