using Microsoft.AspNetCore.Components;
using NTask.Data.Repositories;
using NTask.Data.Services;
using NTask.Data.Services.Models.DTO;
using NTask.Shared.Components;

namespace NTask.Pages;

public partial class Index
{
    [Inject] private IProjectRepository ProjectRepository { get; set; }
    
    private AddProjectModal Modal { get; set; }
    
    private int ProjectCount { get; set; }
    private Dictionary<Guid, ProjectDto> Projects { get; set; }

    protected override void OnInitialized()
    {
        var projectService = new ProjectService(ProjectRepository);
        
        var projectResponse = projectService.GetAllProjects();
        Projects = projectResponse.Projects;
    }
}