using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using NTask.Data.Repositories;
using NTask.Data.Services;
using NTask.Data.Services.Models.Communication.Projects;

namespace NTask.Shared.Components;

public partial class AddProjectModal
{
    private AddProjectFormModel _formModel = new AddProjectFormModel();
    
    [Inject] private IProjectRepository ProjectRepository { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    [CascadingParameter] private MudDialogInstance MudDialog { get; set; }
    
    void Cancel()
    {
        MudDialog.Cancel();
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
