using Microsoft.AspNetCore.Components;
using MudBlazor;
using OnTask.Data.Repositories;
using OnTask.Data.Services;
using OnTask.Data.Services.Models.DTO;
using OnTask.Shared.Components;

namespace OnTask.Pages;

public partial class Index
{
    [Inject] private IProjectRepository ProjectRepository { get; set; }
    [Inject] private IDialogService DialogService { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }
    
    private AddProjectModal Modal { get; set; }
    
    private Dictionary<Guid, ProjectDto> Projects { get; set; }

    protected override void OnInitialized()
    {
        var projectService = new ProjectService(ProjectRepository);
        
        var projectResponse = projectService.GetAllProjects();
        Projects = projectResponse.Projects;
    }

    private void OpenDialog()
    {
        var options = new DialogOptions {CloseOnEscapeKey = true};
        DialogService.Show<AddProjectModal>("Add Project", options);
    }

    private void OpenProject(Guid projectId)
    {
        NavigationManager.NavigateTo($"/project/{projectId}");
    }
}