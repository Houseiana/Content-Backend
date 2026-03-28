using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContentApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CinematicItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Priority = table.Column<string>(type: "text", nullable: false),
                    Assignee = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Comments = table.Column<int>(type: "integer", nullable: false),
                    Attachments = table.Column<int>(type: "integer", nullable: false),
                    DetailsJson = table.Column<string>(type: "jsonb", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinematicItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EditingItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Priority = table.Column<string>(type: "text", nullable: false),
                    Assignee = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Comments = table.Column<int>(type: "integer", nullable: false),
                    Attachments = table.Column<int>(type: "integer", nullable: false),
                    DetailsJson = table.Column<string>(type: "jsonb", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditingItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmingItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Priority = table.Column<string>(type: "text", nullable: false),
                    Assignee = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Comments = table.Column<int>(type: "integer", nullable: false),
                    Attachments = table.Column<int>(type: "integer", nullable: false),
                    DetailsJson = table.Column<string>(type: "jsonb", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmingItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ideas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Priority = table.Column<string>(type: "text", nullable: false),
                    Assignee = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Comments = table.Column<int>(type: "integer", nullable: false),
                    Attachments = table.Column<int>(type: "integer", nullable: false),
                    MainIdea = table.Column<string>(type: "text", nullable: false),
                    SubIdea = table.Column<string>(type: "text", nullable: false),
                    Resources = table.Column<List<string>>(type: "text[]", nullable: false),
                    Researches = table.Column<List<string>>(type: "text[]", nullable: false),
                    Bases = table.Column<List<string>>(type: "text[]", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    ValueImportance = table.Column<string>(type: "text", nullable: false),
                    TrendsBased = table.Column<List<string>>(type: "text[]", nullable: false),
                    SameNiche = table.Column<List<string>>(type: "text[]", nullable: false),
                    DifferentNiche = table.Column<List<string>>(type: "text[]", nullable: false),
                    DescriptionPointsJson = table.Column<string>(type: "jsonb", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LutsItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Priority = table.Column<string>(type: "text", nullable: false),
                    Assignee = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Comments = table.Column<int>(type: "integer", nullable: false),
                    Attachments = table.Column<int>(type: "integer", nullable: false),
                    DetailsJson = table.Column<string>(type: "jsonb", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LutsItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScriptItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Priority = table.Column<string>(type: "text", nullable: false),
                    Assignee = table.Column<string>(type: "text", nullable: false),
                    Reviewer = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Comments = table.Column<int>(type: "integer", nullable: false),
                    Attachments = table.Column<int>(type: "integer", nullable: false),
                    RevisionCount = table.Column<int>(type: "integer", nullable: false),
                    Campaign = table.Column<string>(type: "text", nullable: false),
                    RelatedStory = table.Column<string>(type: "text", nullable: false),
                    ScriptCode = table.Column<string>(type: "text", nullable: false),
                    OverviewJson = table.Column<string>(type: "jsonb", nullable: false),
                    HookJson = table.Column<string>(type: "jsonb", nullable: false),
                    FrameworkJson = table.Column<string>(type: "jsonb", nullable: false),
                    FullScript = table.Column<string>(type: "text", nullable: false),
                    VoiceoverScript = table.Column<string>(type: "text", nullable: false),
                    OnScreenTextJson = table.Column<string>(type: "jsonb", nullable: false),
                    ScenesJson = table.Column<string>(type: "jsonb", nullable: false),
                    VoiceJson = table.Column<string>(type: "jsonb", nullable: false),
                    CtaJson = table.Column<string>(type: "jsonb", nullable: false),
                    FilmingNotesJson = table.Column<string>(type: "jsonb", nullable: false),
                    EditingNotesJson = table.Column<string>(type: "jsonb", nullable: false),
                    ApprovalJson = table.Column<string>(type: "jsonb", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScriptItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoundsItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Priority = table.Column<string>(type: "text", nullable: false),
                    Assignee = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Comments = table.Column<int>(type: "integer", nullable: false),
                    Attachments = table.Column<int>(type: "integer", nullable: false),
                    DetailsJson = table.Column<string>(type: "jsonb", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundsItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StorytellingItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Priority = table.Column<string>(type: "text", nullable: false),
                    Assignee = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Comments = table.Column<int>(type: "integer", nullable: false),
                    Attachments = table.Column<int>(type: "integer", nullable: false),
                    LinkedIdea = table.Column<string>(type: "text", nullable: false),
                    Campaign = table.Column<string>(type: "text", nullable: false),
                    OverviewJson = table.Column<string>(type: "jsonb", nullable: false),
                    AudienceJson = table.Column<string>(type: "jsonb", nullable: false),
                    CoreMessageJson = table.Column<string>(type: "jsonb", nullable: false),
                    EmotionalDirectionJson = table.Column<string>(type: "jsonb", nullable: false),
                    FrameworkJson = table.Column<string>(type: "jsonb", nullable: false),
                    HookJson = table.Column<string>(type: "jsonb", nullable: false),
                    NarrativeFlowJson = table.Column<string>(type: "jsonb", nullable: false),
                    BrandVoiceJson = table.Column<string>(type: "jsonb", nullable: false),
                    VisualNotesJson = table.Column<string>(type: "jsonb", nullable: false),
                    CtaJson = table.Column<string>(type: "jsonb", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorytellingItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Permissions = table.Column<List<string>>(type: "text[]", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkspaceProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkspaceProjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkspaceNodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Comp = table.Column<string>(type: "text", nullable: false),
                    ItemTitle = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    X = table.Column<double>(type: "double precision", nullable: false),
                    Y = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkspaceNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkspaceNodes_WorkspaceProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "WorkspaceProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkspaceWires",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    FromNodeId = table.Column<string>(type: "text", nullable: false),
                    ToNodeId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkspaceWires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkspaceWires_WorkspaceProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "WorkspaceProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Color", "Description", "Icon", "Key", "Name" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "#6C5CE7", "Raw ideas, concepts, campaign topics", "ideas", "ideas", "Ideas" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "#A29BFE", "Narrative structure, hooks, emotional angles", "storytelling", "storytelling", "Storytelling" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "#00D2FF", "Script drafts, versions, approvals", "script", "script", "Script" },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "#54A0FF", "Shot list, filming status, locations, equipment", "filming", "filming", "Filming" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "#00C48C", "Editing tasks, revisions, editor notes", "editing", "editing", "Editing" },
                    { new Guid("10000000-0000-0000-0000-000000000006"), "#FFA502", "Cinematic shots, mood references, sequences", "cinematic", "cinematic", "Cinematic" },
                    { new Guid("10000000-0000-0000-0000-000000000007"), "#FF4757", "Sound effects, voiceovers, music assets", "sounds", "sounds", "Sounds" },
                    { new Guid("10000000-0000-0000-0000-000000000008"), "#7C4DFF", "Color presets, grading references", "luts", "luts", "LUTs" },
                    { new Guid("10000000-0000-0000-0000-000000000009"), "#1E90FF", "Raw files, documents, references", "resources", "resources", "Resources" },
                    { new Guid("10000000-0000-0000-0000-00000000000a"), "#FF6348", "Reusable assets, templates, archived materials", "libraries", "libraries", "Libraries" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "CreatedAt", "DisplayName", "Email", "PasswordHash", "Permissions", "Role", "Status", "Username" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "#6C5CE7", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Admin", "admin@contentops.io", "$2a$11$K3rZp0Gv7Ue0qN0GZQZ6OeVLQ5VJ8X1W8FVJ5VdKJGQ2Z8oK5Xnq", new List<string> { "all" }, "admin", "active", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkspaceNodes_ProjectId",
                table: "WorkspaceNodes",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkspaceWires_ProjectId",
                table: "WorkspaceWires",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinematicItems");

            migrationBuilder.DropTable(
                name: "EditingItems");

            migrationBuilder.DropTable(
                name: "FilmingItems");

            migrationBuilder.DropTable(
                name: "Ideas");

            migrationBuilder.DropTable(
                name: "LutsItems");

            migrationBuilder.DropTable(
                name: "ScriptItems");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "SoundsItems");

            migrationBuilder.DropTable(
                name: "StorytellingItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WorkspaceNodes");

            migrationBuilder.DropTable(
                name: "WorkspaceWires");

            migrationBuilder.DropTable(
                name: "WorkspaceProjects");
        }
    }
}
