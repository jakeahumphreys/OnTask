using NTask.Data.Services.Models.DTO;

namespace NTask.Data.Services.Models.Communication.Projects;

public class GetProjectByIdResponse : ResponseBase
{
    public ProjectDto Project { get; set; }
}