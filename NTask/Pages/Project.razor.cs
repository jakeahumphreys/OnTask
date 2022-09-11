using Microsoft.AspNetCore.Components;
using NTask.Data.Repositories;
using NTask.Data.Services;
using NTask.Data.Services.Models.DTO;

namespace NTask.Pages;

public partial class Project
{
    private ProjectDto _project;

    [Parameter]
    public string Id { get; set; }
    
    [Inject] private IProjectRepository ProjectRepository { get; set; }

    protected override void OnInitialized()
    {
        var parsedId = Guid.Parse(Id);
        var projectService = new ProjectService(ProjectRepository);
        _project = projectService.GetProjectById(parsedId).Project;
    }
}