namespace OnTask.Data.Services.Models.Communication.Projects;

public class CreateProjectRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
}

public class CreateProjectResponse : ResponseBase
{
}