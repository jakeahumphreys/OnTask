using NTask.Data.Mappers;
using NTask.Data.Models;
using NTask.Data.Repositories;
using NTask.Data.Services.Models.Communication;
using NTask.Errors;

namespace NTask.Data.Services;

public class ProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public GetProjectByIdResponse GetProjectById(Guid id)
    {
        if (id == Guid.Empty)
            return new GetProjectByIdResponse().WithError<GetProjectByIdResponse>(ErrorBecause.MissingRequiredValue("Id"));

        var project = _projectRepository.GetById(id);

        if (project == null)
            return new GetProjectByIdResponse().WithError<GetProjectByIdResponse>(ErrorBecause.RecordByIdNotFound(id));

        return new GetProjectByIdResponse
        {
            Project = ProjectMapper.MapToDto(project)
        };
    }

    public CreateProjectResponse CreateProject(CreateProjectRequest request)
    {
        if (string.IsNullOrEmpty(request.Name))
            return new CreateProjectResponse().WithError<CreateProjectResponse>(ErrorBecause.MissingRequiredValue("Name"));

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