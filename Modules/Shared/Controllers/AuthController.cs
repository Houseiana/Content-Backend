using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContentApi.Data;
using ContentApi.Modules.Shared.DTOs;
using ContentApi.Modules.Shared.Models;
using ContentApi.Modules.Shared.Services;

namespace ContentApi.Modules.Shared.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly AuthService _auth;

    public AuthController(AppDbContext db, AuthService auth)
    {
        _db = db;
        _auth = auth;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
        if (user is null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return Unauthorized(new { message = "Invalid username or password" });

        var token = _auth.GenerateToken(user);
        return Ok(new LoginResponseDto(token, new
        {
            user.Id,
            user.Username,
            user.DisplayName,
            user.Role,
            user.Avatar,
            user.Email,
            user.Permissions,
            user.Status
        }));
    }

    [HttpPost("register")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Register([FromBody] CreateUserDto dto)
    {
        if (await _db.Users.AnyAsync(u => u.Username == dto.Username))
            return Conflict(new { message = "Username already exists" });

        if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
            return Conflict(new { message = "Email already exists" });

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = dto.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            DisplayName = dto.DisplayName,
            Email = dto.Email,
            Role = dto.Role,
            Permissions = dto.Permissions ?? new List<string>(),
            Status = "active",
            CreatedAt = DateTime.UtcNow
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(Login), new
        {
            user.Id,
            user.Username,
            user.DisplayName,
            user.Role,
            user.Email,
            user.Permissions,
            user.Status
        });
    }
}
