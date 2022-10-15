using OnTask.Data.Services.Models.DTO;

namespace OnTask.Data.Services.Models.Communication.Projects;

public class GetAllProjectsResponse : ResponseBase
{
    public Dictionary<Guid, ProjectDto> Projects { get; set; }
}