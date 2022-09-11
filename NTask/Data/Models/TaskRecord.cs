using System.ComponentModel.DataAnnotations;
using TaskStatus = NTask.Data.Enums.TaskStatus;

namespace NTask.Data.Models;

public class TaskRecord
{
    public TaskRecord()
    {
        ActivityRecords = new List<ActivityRecord>();
    }
    
    [Key]
    public Guid TaskId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public TaskStatus Status { get; set; }
    
    public List<ActivityRecord> ActivityRecords { get; set; }
}