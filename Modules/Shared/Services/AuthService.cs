using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ContentApi.Modules.Shared.Models;

namespace ContentApi.Modules.Shared.Services;

public class AuthService
{
    private readonly string _jwtKey;
    private readonly string _issuer;

    public AuthService(IConfiguration config)
    {
        _jwtKey = config["Jwt:Key"] ?? "SuperSecretKeyForContentOpsDashboard2026!@#$";
        _issuer = config["Jwt:Issuer"] ?? "ContentApi";
    }

    public string GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim("displayName", user.DisplayName),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _issuer,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
