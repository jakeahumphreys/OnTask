using TaskStatus = OnTask.Data.Enums.TaskStatus;

namespace OnTask.Data.Services.Models.DTO;

public class TaskDto
{
    public TaskDto()
    {
        Activities = new List<ActivityDto>();
    }
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? DueDate { get; set; }
    public TaskStatus TaskStatus { get; set; }
    public List<ActivityDto> Activities { get; set; }
}