using OnTask.MAUI.Data.Models;
using OnTask.MAUI.Data.Services.Models.DTO;

namespace OnTask.MAUI.Data.Mappers;

public static class ProjectMapper
{
    public static ProjectDto MapToDto(ProjectRecord projectRecord)
    {
        return new ProjectDto
        {
            Id = projectRecord.ProjectId,
            Name = projectRecord.Name,
            Description = projectRecord.Description,
            Created = projectRecord.Created,
            Tasks = projectRecord.Tasks.ConvertAll(TaskMapper.FromRecordToDto),
            IsArchived = projectRecord.IsArchived
        };
    }
}