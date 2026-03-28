namespace ContentApi.Modules.Content.Models;

public class WorkspaceNode
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public WorkspaceProject Project { get; set; } = null!;
    public string Comp { get; set; } = string.Empty;
    public string ItemTitle { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public double X { get; set; }
    public double Y { get; set; }
}
