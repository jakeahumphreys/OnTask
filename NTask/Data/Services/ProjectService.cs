using NTask.Data.Models;
using NTask.Data.Repositories;
using NTask.Data.Services.Models;
using NTask.Errors;

namespace NTask.Data.Services;

public class ProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public CreateProjectResponse CreateProject(CreateProjectRequest request)
    {
        if (string.IsNullOrEmpty(request.Name))
            return new CreateProjectResponse().WithError<CreateProjectResponse>(ErrorBecause.MissingRequiredValue("Description"));

        var projectRecord = new ProjectRecord
        {
            ProjectId = Guid.NewGuid(),
            Name = request.Name,
            IsArchived = false
        };

        _projectRepository.Create(projectRecord);

        return new CreateProjectResponse();
    }
}