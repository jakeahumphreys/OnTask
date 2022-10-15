using OnTask.MAUI.Data.Models;
using OnTask.MAUI.Data.Services.Models.DTO;

namespace OnTask.MAUI.Data.Mappers;

public static class TaskMapper
{
    public static TaskDto FromRecordToDto(TaskRecord taskRecord)
    {
        return new TaskDto
        {
            Id = taskRecord.TaskId,
            Name = taskRecord.Name,
            Description = taskRecord.Description,
            DueDate = taskRecord.DueDate,
            Activities = taskRecord.ActivityRecords.ConvertAll(ActivityMapper.FromRecordToDto),
            TaskStatus = taskRecord.Status
        };
    }
}