using Microsoft.AspNetCore.Components;
using NTask.Data.Repositories;
using NTask.Data.Services;

namespace NTask.Pages;

public partial class Index
{
    [Inject] private IProjectRepository _projectRepository { get; set; }
    
    protected override void OnInitialized()
    {
        
    }
}