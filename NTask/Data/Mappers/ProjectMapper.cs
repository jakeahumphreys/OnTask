using NTask.Data.Models;
using NTask.Data.Services.Models.DTO;

namespace NTask.Data.Mappers;

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
            IsArchived = projectRecord.IsArchived
        };
    }
}