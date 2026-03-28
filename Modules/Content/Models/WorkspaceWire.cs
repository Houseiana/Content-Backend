namespace ContentApi.Modules.Content.Models;

public class WorkspaceWire
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public WorkspaceProject Project { get; set; } = null!;
    public string FromNodeId { get; set; } = string.Empty;
    public string ToNodeId { get; set; } = string.Empty;
}
