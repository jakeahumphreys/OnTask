using OnTask.Data.Enums;

namespace OnTask.Data.Services.Models.DTO;

public class ActivityDto
{
    public Guid ActivityId { get; set; }
    public ActivityType Type { get; set; }
    public string Contents { get; set; }
}