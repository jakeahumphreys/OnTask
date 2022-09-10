using System.ComponentModel.DataAnnotations;
using NTask.Data.Enums;

namespace NTask.Data.Models;

public sealed class ActivityRecord
{
    [Key]
    public Guid ActivityId { get; set; }
    public ActivityType Type { get; set; }
    public string Contents { get; set; }
    
    public Guid TaskId { get; set; }
    public TaskRecord TaskRecord { get; set; }
}