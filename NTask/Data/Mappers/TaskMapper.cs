using NTask.Data.Models;
using NTask.Data.Services.Models.DTO;

namespace NTask.Data.Mappers;

public static class TaskMapper
{
    public static TaskDto FromRecordToDto(TaskRecord taskRecord)
    {
        return new TaskDto
        {
            Id = taskRecord.ProjectId,
            Name = taskRecord.Name,
            Description = taskRecord.Description,
            DueDate = taskRecord.DueDate,
            Activities = taskRecord.ActivityRecords.ConvertAll(ActivityMapper.FromRecordToDto),
            TaskStatus = taskRecord.Status
        };
    }
}