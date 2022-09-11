using NTask.Data.Services.Models.DTO;

namespace NTask.Data.Services.Models.Communication;

public class GetProjectByIdResponse : ResponseBase
{
    public ProjectDto Project { get; set; }
}