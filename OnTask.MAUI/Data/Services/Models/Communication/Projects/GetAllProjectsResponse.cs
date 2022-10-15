using OnTask.MAUI.Data.Services.Models.DTO;

namespace OnTask.MAUI.Data.Services.Models.Communication.Projects;

public class GetAllProjectsResponse : ResponseBase
{
    public Dictionary<Guid, ProjectDto> Projects { get; set; }
}