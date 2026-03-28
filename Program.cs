using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ContentApi.Data;
using ContentApi.Modules.Shared;
using ContentApi.Modules.Content;

var builder = WebApplication.CreateBuilder(args);

// ── Railway port binding ──
var port = Environment.GetEnvironmentVariable("PORT") ?? "5100";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// ── Database ──
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ── JWT Authentication ──
var jwtKey = builder.Configuration["Jwt:Key"] ?? "SuperSecretKeyForContentOpsDashboard2026!@#$";
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"] ?? "ContentApi",
            ValidAudience = builder.Configuration["Jwt:Issuer"] ?? "ContentApi",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

// ── Module Registration ──
builder.Services.AddSharedModule();
builder.Services.AddContentModule();
// Future modules: services.AddMarketingModule(), services.AddAnalyticsModule(), etc.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ── CORS ──
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        var origins = builder.Configuration.GetSection("Cors:Origins").Get<string[]>()
            ?? new[] { "http://localhost:3000", "http://localhost:3001", "http://localhost:3333" };
        policy.WithOrigins(origins)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

// ── Auto-migrate database & ensure admin password ──
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();

    // Fix admin password hash on startup (seed data uses a placeholder)
    var admin = db.Users.FirstOrDefault(u => u.Username == "admin");
    if (admin != null && !BCrypt.Net.BCrypt.Verify("admin123", admin.PasswordHash))
    {
        admin.PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123");
        db.SaveChanges();
    }
}

// ── Middleware pipeline ──
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
