namespace ContentApi.Modules.Content.Models;

public class Idea
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Status { get; set; } = "Draft";
    public string Priority { get; set; } = "Medium";
    public string Assignee { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    public int Comments { get; set; }
    public int Attachments { get; set; }
    public string MainIdea { get; set; } = string.Empty;
    public string SubIdea { get; set; } = string.Empty;
    public List<string> Resources { get; set; } = new();
    public List<string> Researches { get; set; } = new();
    public List<string> Bases { get; set; } = new();
    public string Value { get; set; } = string.Empty;
    public string ValueImportance { get; set; } = string.Empty;
    public List<string> TrendsBased { get; set; } = new();
    public List<string> SameNiche { get; set; } = new();
    public List<string> DifferentNiche { get; set; } = new();
    public string DescriptionPointsJson { get; set; } = "[]";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
