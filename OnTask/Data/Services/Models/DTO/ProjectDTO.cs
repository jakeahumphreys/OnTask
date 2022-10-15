namespace OnTask.Data.Services.Models.DTO;

public sealed class ProjectDto
{
    public ProjectDto()
    {
        Tasks = new List<TaskDto>();
    }
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public List<TaskDto> Tasks { get; set; }
    public bool IsArchived { get; set; }
}