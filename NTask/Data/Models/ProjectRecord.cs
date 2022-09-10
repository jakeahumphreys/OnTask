using System.ComponentModel.DataAnnotations;

namespace NTask.Data.Models;

public class ProjectRecord
{
    [Key]
    public Guid ProjectId { get; set; }
    public string Name { get; set; }
    
    public List<TaskRecord> Tasks { get; set; }
    
    public bool IsArchived { get; set; }
}