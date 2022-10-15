using OnTask.MAUI.Data.Enums;

namespace OnTask.MAUI.Data.Services.Models.DTO;

public class ActivityDto
{
    public Guid ActivityId { get; set; }
    public ActivityType Type { get; set; }
    public string Contents { get; set; }
}