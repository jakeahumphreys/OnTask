namespace NTask.Data.Services.Models.DTO;

public sealed class ProjectDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsArchived { get; set; }
}