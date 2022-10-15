using OnTask.MAUI.Data.Services.Models.DTO;

namespace OnTask.MAUI.Data.Services.Models.Communication.Projects;

public class GetProjectByIdResponse : ResponseBase
{
    public ProjectDto Project { get; set; }
}