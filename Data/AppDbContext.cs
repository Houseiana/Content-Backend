using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ContentApi.Modules.Shared.Models;
using ContentApi.Modules.Content.Models;

namespace ContentApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    // ── Shared ──
    public DbSet<User> Users => Set<User>();

    // ── Content ──
    public DbSet<Section> Sections => Set<Section>();
    public DbSet<Idea> Ideas => Set<Idea>();
    public DbSet<StorytellingItem> StorytellingItems => Set<StorytellingItem>();
    public DbSet<ScriptItem> ScriptItems => Set<ScriptItem>();
    public DbSet<FilmingItem> FilmingItems => Set<FilmingItem>();
    public DbSet<EditingItem> EditingItems => Set<EditingItem>();
    public DbSet<CinematicItem> CinematicItems => Set<CinematicItem>();
    public DbSet<SoundsItem> SoundsItems => Set<SoundsItem>();
    public DbSet<LutsItem> LutsItems => Set<LutsItem>();
    public DbSet<WorkspaceProject> WorkspaceProjects => Set<WorkspaceProject>();
    public DbSet<WorkspaceNode> WorkspaceNodes => Set<WorkspaceNode>();
    public DbSet<WorkspaceWire> WorkspaceWires => Set<WorkspaceWire>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ── User ──
        modelBuilder.Entity<User>(e =>
        {
            e.HasIndex(u => u.Username).IsUnique();
            e.HasIndex(u => u.Email).IsUnique();
        });

        // ── Idea JSON columns ──
        modelBuilder.Entity<Idea>(e =>
        {
            e.Property(i => i.DescriptionPointsJson).HasColumnType("jsonb");
        });

        // ── Storytelling JSON columns ──
        modelBuilder.Entity<StorytellingItem>(e =>
        {
            e.Property(s => s.OverviewJson).HasColumnType("jsonb");
            e.Property(s => s.AudienceJson).HasColumnType("jsonb");
            e.Property(s => s.CoreMessageJson).HasColumnType("jsonb");
            e.Property(s => s.EmotionalDirectionJson).HasColumnType("jsonb");
            e.Property(s => s.FrameworkJson).HasColumnType("jsonb");
            e.Property(s => s.HookJson).HasColumnType("jsonb");
            e.Property(s => s.NarrativeFlowJson).HasColumnType("jsonb");
            e.Property(s => s.BrandVoiceJson).HasColumnType("jsonb");
            e.Property(s => s.VisualNotesJson).HasColumnType("jsonb");
            e.Property(s => s.CtaJson).HasColumnType("jsonb");
        });

        // ── Script JSON columns ──
        modelBuilder.Entity<ScriptItem>(e =>
        {
            e.Property(s => s.OverviewJson).HasColumnType("jsonb");
            e.Property(s => s.HookJson).HasColumnType("jsonb");
            e.Property(s => s.FrameworkJson).HasColumnType("jsonb");
            e.Property(s => s.OnScreenTextJson).HasColumnType("jsonb");
            e.Property(s => s.ScenesJson).HasColumnType("jsonb");
            e.Property(s => s.VoiceJson).HasColumnType("jsonb");
            e.Property(s => s.CtaJson).HasColumnType("jsonb");
            e.Property(s => s.FilmingNotesJson).HasColumnType("jsonb");
            e.Property(s => s.EditingNotesJson).HasColumnType("jsonb");
            e.Property(s => s.ApprovalJson).HasColumnType("jsonb");
        });

        // ── Detail-based items JSON columns ──
        modelBuilder.Entity<FilmingItem>(e =>
        {
            e.Property(f => f.DetailsJson).HasColumnType("jsonb");
        });
        modelBuilder.Entity<EditingItem>(e =>
        {
            e.Property(f => f.DetailsJson).HasColumnType("jsonb");
        });
        modelBuilder.Entity<CinematicItem>(e =>
        {
            e.Property(f => f.DetailsJson).HasColumnType("jsonb");
        });
        modelBuilder.Entity<SoundsItem>(e =>
        {
            e.Property(f => f.DetailsJson).HasColumnType("jsonb");
        });
        modelBuilder.Entity<LutsItem>(e =>
        {
            e.Property(f => f.DetailsJson).HasColumnType("jsonb");
        });

        // ── Workspace relationships ──
        modelBuilder.Entity<WorkspaceNode>()
            .HasOne(n => n.Project)
            .WithMany(p => p.Nodes)
            .HasForeignKey(n => n.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<WorkspaceWire>()
            .HasOne(w => w.Project)
            .WithMany(p => p.Wires)
            .HasForeignKey(w => w.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // ── Seed admin user (password: admin123) ──
        // Pre-computed BCrypt hash for "admin123" to avoid non-deterministic seed data
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Username = "admin",
            PasswordHash = "$2a$11$K3rZp0Gv7Ue0qN0GZQZ6OeVLQ5VJ8X1W8FVJ5VdKJGQ2Z8oK5Xnq",
            DisplayName = "Admin",
            Role = "admin",
            Avatar = "#6C5CE7",
            Email = "admin@contentops.io",
            Permissions = new List<string> { "all" },
            Status = "active",
            CreatedAt = new DateTime(2026, 1, 15, 0, 0, 0, DateTimeKind.Utc),
        });

        // ── Seed sections ──
        modelBuilder.Entity<Section>().HasData(
            new Section { Id = Guid.Parse("10000000-0000-0000-0000-000000000001"), Key = "ideas", Name = "Ideas", Icon = "ideas", Color = "#6C5CE7", Description = "Raw ideas, concepts, campaign topics" },
            new Section { Id = Guid.Parse("10000000-0000-0000-0000-000000000002"), Key = "storytelling", Name = "Storytelling", Icon = "storytelling", Color = "#A29BFE", Description = "Narrative structure, hooks, emotional angles" },
            new Section { Id = Guid.Parse("10000000-0000-0000-0000-000000000003"), Key = "script", Name = "Script", Icon = "script", Color = "#00D2FF", Description = "Script drafts, versions, approvals" },
            new Section { Id = Guid.Parse("10000000-0000-0000-0000-000000000004"), Key = "filming", Name = "Filming", Icon = "filming", Color = "#54A0FF", Description = "Shot list, filming status, locations, equipment" },
            new Section { Id = Guid.Parse("10000000-0000-0000-0000-000000000005"), Key = "editing", Name = "Editing", Icon = "editing", Color = "#00C48C", Description = "Editing tasks, revisions, editor notes" },
            new Section { Id = Guid.Parse("10000000-0000-0000-0000-000000000006"), Key = "cinematic", Name = "Cinematic", Icon = "cinematic", Color = "#FFA502", Description = "Cinematic shots, mood references, sequences" },
            new Section { Id = Guid.Parse("10000000-0000-0000-0000-000000000007"), Key = "sounds", Name = "Sounds", Icon = "sounds", Color = "#FF4757", Description = "Sound effects, voiceovers, music assets" },
            new Section { Id = Guid.Parse("10000000-0000-0000-0000-000000000008"), Key = "luts", Name = "LUTs", Icon = "luts", Color = "#7C4DFF", Description = "Color presets, grading references" },
            new Section { Id = Guid.Parse("10000000-0000-0000-0000-000000000009"), Key = "resources", Name = "Resources", Icon = "resources", Color = "#1E90FF", Description = "Raw files, documents, references" },
            new Section { Id = Guid.Parse("10000000-0000-0000-0000-00000000000A"), Key = "libraries", Name = "Libraries", Icon = "libraries", Color = "#FF6348", Description = "Reusable assets, templates, archived materials" }
        );
    }
}
