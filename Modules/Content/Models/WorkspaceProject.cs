namespace ContentApi.Modules.Content.Models;

public class WorkspaceProject
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<WorkspaceNode> Nodes { get; set; } = new();
    public List<WorkspaceWire> Wires { get; set; } = new();
}
