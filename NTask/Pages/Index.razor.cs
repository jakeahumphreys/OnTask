using Microsoft.AspNetCore.Components;
using NTask.Data.Repositories;

namespace NTask.Pages;

public partial class Index
{
    [Inject] private IProjectRepository _projectRepository { get; set; }
    
    private int ProjectCount { get; set; }
    
    protected override void OnInitialized()
    {
        //TODO remove
        //Right now this is a hacky test and will be removed ASAP
        //shouldn't be directly using the repo for this.
        var projects = _projectRepository.GetAll();
        ProjectCount = projects.Count;
    }
}