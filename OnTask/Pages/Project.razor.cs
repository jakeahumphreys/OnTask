using Microsoft.AspNetCore.Components;
using OnTask.Data.Repositories;
using OnTask.Data.Services;
using OnTask.Data.Services.Models.DTO;

namespace OnTask.Pages;

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