namespace ContentApi.Modules.Content.Models;

public class SoundsItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Status { get; set; } = "Draft";
    public string Priority { get; set; } = "Medium";
    public string Assignee { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    public int Comments { get; set; }
    public int Attachments { get; set; }
    public string DetailsJson { get; set; } = "{}";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
