using OnTask.Data.Models;
using OnTask.Data.Services.Models.DTO;

namespace OnTask.Data.Mappers;

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