using NTask.Data.Services.Models.DTO;

namespace NTask.Data.Services.Models.Communication.Projects;

public class GetAllProjectsResponse : ResponseBase
{
    public Dictionary<Guid, ProjectDto> Projects { get; set; }
}