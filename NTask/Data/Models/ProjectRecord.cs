using System.ComponentModel.DataAnnotations;

namespace NTask.Data.Models;

public class ProjectRecord
{
    public ProjectRecord()
    {
        Tasks = new List<TaskRecord>();
    }
    
    [Key]
    public Guid ProjectId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public List<TaskRecord> Tasks { get; set; }
    
    public bool IsArchived { get; set; }
}