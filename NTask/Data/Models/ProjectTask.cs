namespace NTask.Data.Models;

public class ProjectTask
{
    public Guid TaskId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public TaskStatus Status { get; set; }
    
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
}