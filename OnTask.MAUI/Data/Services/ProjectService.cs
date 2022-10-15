using OnTask.Data.Repositories;
using OnTask.MAUI.Data.Mappers;
using OnTask.MAUI.Data.Models;
using OnTask.MAUI.Data.Services.Models.Communication.Projects;
using OnTask.MAUI.Errors;

namespace OnTask.MAUI.Data.Services;

public class ProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public GetAllProjectsResponse GetAllProjects()
    {
        var projectDictionary = _projectRepository.GetAll().ToDictionary(x => x.ProjectId, ProjectMapper.MapToDto);
        return new GetAllProjectsResponse
        {
            Projects = projectDictionary
        };
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

        if (string.IsNullOrEmpty(request.Description))
            return new CreateProjectResponse().WithError<CreateProjectResponse>(ErrorBecause.MissingRequiredValue("Description"));

        var projectRecord = new ProjectRecord
        {
            ProjectId = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Created = DateTime.Now,
            IsArchived = false
        };

        _projectRepository.Create(projectRecord);

        return new CreateProjectResponse();
    }
}