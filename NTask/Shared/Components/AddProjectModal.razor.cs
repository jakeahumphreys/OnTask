using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using NTask.Data.Repositories;
using NTask.Data.Services;
using NTask.Data.Services.Models.Communication.Projects;
using NTask.Data.Services.Models.DTO;

namespace NTask.Shared.Components;

public partial class AddProjectModal
{
    private string _modalClass = "";
    private string _modalDisplay = "";
    private bool _showBackdrop = false;

    private AddProjectFormModel _formModel = new AddProjectFormModel();
    
    [Inject] private IProjectRepository ProjectRepository { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    public void Show()
    {
        _modalDisplay = "block;";
        _modalClass = "Show";
        _showBackdrop = true;
        StateHasChanged();
    }
    
    public void Hide()
    {
        _modalDisplay = "none;";
        _modalClass = "";
        _showBackdrop = false;
        StateHasChanged();
    }

    void FormSubmit()
    {
        var projectService = new ProjectService(ProjectRepository);

        projectService.CreateProject(new CreateProjectRequest
        {
            Name = _formModel.Name,
            Description = _formModel.Description,
        });
        
        StateHasChanged();
        NavigationManager.NavigateTo("/", true);
    }
}

public class AddProjectFormModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
}
