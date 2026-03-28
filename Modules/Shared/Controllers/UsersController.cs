using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContentApi.Data;
using ContentApi.Modules.Shared.Models;

namespace ContentApi.Modules.Shared.Controllers;

[ApiController]
[Route("api/users")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _db;
    public UsersController(AppDbContext db) => _db = db;

    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _db.Users
            .Select(u => new
            {
                u.Id, u.Username, u.DisplayName, u.Role,
                u.Avatar, u.Email, u.Permissions, u.Status, u.CreatedAt
            })
            .ToListAsync();
        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user is null) return NotFound();
        return Ok(new
        {
            user.Id, user.Username, user.DisplayName, user.Role,
            user.Avatar, user.Email, user.Permissions, user.Status, user.CreatedAt
        });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] User body)
    {
        var user = await _db.Users.FindAsync(id);
        if (user is null) return NotFound();

        user.DisplayName = body.DisplayName;
        user.Email = body.Email;
        user.Role = body.Role;
        user.Avatar = body.Avatar;
        user.Status = body.Status;

        if (!string.IsNullOrEmpty(body.PasswordHash))
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(body.PasswordHash);

        await _db.SaveChangesAsync();
        return Ok(new
        {
            user.Id, user.Username, user.DisplayName, user.Role,
            user.Avatar, user.Email, user.Permissions, user.Status
        });
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user is null) return NotFound();
        _db.Users.Remove(user);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{id:guid}/permissions")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> UpdatePermissions(Guid id, [FromBody] List<string> permissions)
    {
        var user = await _db.Users.FindAsync(id);
        if (user is null) return NotFound();
        user.Permissions = permissions;
        await _db.SaveChangesAsync();
        return Ok(new { user.Id, user.Permissions });
    }
}
