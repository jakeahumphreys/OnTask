using OnTask.Data.Services.Models.DTO;

namespace OnTask.Data.Services.Models.Communication.Projects;

public class GetProjectByIdResponse : ResponseBase
{
    public ProjectDto Project { get; set; }
}