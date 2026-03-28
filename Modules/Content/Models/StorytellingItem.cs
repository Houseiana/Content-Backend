namespace ContentApi.Modules.Content.Models;

public class StorytellingItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Status { get; set; } = "Draft";
    public string Priority { get; set; } = "Medium";
    public string Assignee { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    public int Comments { get; set; }
    public int Attachments { get; set; }
    public string LinkedIdea { get; set; } = string.Empty;
    public string Campaign { get; set; } = string.Empty;
    public string OverviewJson { get; set; } = "{}";
    public string AudienceJson { get; set; } = "{}";
    public string CoreMessageJson { get; set; } = "{}";
    public string EmotionalDirectionJson { get; set; } = "{}";
    public string FrameworkJson { get; set; } = "{}";
    public string HookJson { get; set; } = "{}";
    public string NarrativeFlowJson { get; set; } = "[]";
    public string BrandVoiceJson { get; set; } = "{}";
    public string VisualNotesJson { get; set; } = "{}";
    public string CtaJson { get; set; } = "{}";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
