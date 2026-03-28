namespace ContentApi.Modules.Content.Models;

public class ScriptItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Status { get; set; } = "Draft";
    public string Priority { get; set; } = "Medium";
    public string Assignee { get; set; } = string.Empty;
    public string Reviewer { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    public int Comments { get; set; }
    public int Attachments { get; set; }
    public int RevisionCount { get; set; }
    public string Campaign { get; set; } = string.Empty;
    public string RelatedStory { get; set; } = string.Empty;
    public string ScriptCode { get; set; } = string.Empty;
    public string OverviewJson { get; set; } = "{}";
    public string HookJson { get; set; } = "{}";
    public string FrameworkJson { get; set; } = "{}";
    public string FullScript { get; set; } = string.Empty;
    public string VoiceoverScript { get; set; } = string.Empty;
    public string OnScreenTextJson { get; set; } = "{}";
    public string ScenesJson { get; set; } = "[]";
    public string VoiceJson { get; set; } = "{}";
    public string CtaJson { get; set; } = "{}";
    public string FilmingNotesJson { get; set; } = "{}";
    public string EditingNotesJson { get; set; } = "{}";
    public string ApprovalJson { get; set; } = "{}";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
