using OnTask.Data.Models;
using OnTask.Data.Services.Models.DTO;

namespace OnTask.Data.Mappers;

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