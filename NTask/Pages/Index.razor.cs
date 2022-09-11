using Microsoft.AspNetCore.Components;
using NTask.Data.Repositories;
using NTask.Data.Services;

namespace NTask.Pages;

public partial class Index
{
    [Inject] private IProjectRepository ProjectRepository { get; set; }
    
    private int ProjectCount { get; set; }
    
    protected override void OnInitialized()
    {
        var projectService = new ProjectService(ProjectRepository);
        
        var projectResponse = projectService.GetAllProjects();
        ProjectCount = projectResponse.Projects.Count;
    }
}