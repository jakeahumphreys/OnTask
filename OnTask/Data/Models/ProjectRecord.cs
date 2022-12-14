using System.ComponentModel.DataAnnotations;

namespace OnTask.Data.Models;

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
    public DateTime Created { get; set; }
    
    public List<TaskRecord> Tasks { get; set; }
    
    public bool IsArchived { get; set; }
}