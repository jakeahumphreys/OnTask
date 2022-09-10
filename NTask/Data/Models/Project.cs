using System.ComponentModel.DataAnnotations;

namespace NTask.Data.Models;

public class Project
{
    [Key]
    public Guid ProjectId { get; set; }
    public string Name { get; set; }
    
    public List<ProjectTask> Tasks { get; set; }
    
    public bool IsArchived { get; set; }
}