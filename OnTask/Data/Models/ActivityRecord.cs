using System.ComponentModel.DataAnnotations;
using OnTask.Data.Enums;

namespace OnTask.Data.Models;

public sealed class ActivityRecord
{
    [Key]
    public Guid ActivityId { get; set; }
    public ActivityType Type { get; set; }
    public string Contents { get; set; }
}