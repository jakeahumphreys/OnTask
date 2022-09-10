using NTask.Data.Contexts;
using NTask.Data.Models;

namespace NTask.Data.Repositories;

public interface IProjectRepository
{
    List<Project> GetAll();

    Project GetById(Guid projectId);
    void Create(Project project);
    void Update(Project project);
    void Delete(Project project);
}

public class ProjectRepository : IProjectRepository
{
    private readonly NTaskContext _context;

    public ProjectRepository()
    {
        _context = new NTaskContext();
    }

    public List<Project> GetAll()
    {
        return _context.Projects.ToList();
    }

    public Project GetById(Guid projectId)
    {
        return _context.Projects.SingleOrDefault(x => x.ProjectId == projectId);
    }

    public void Create(Project project)
    {
        _context.Projects.Add(project);
    }

    public void Update(Project project)
    {
        _context.Projects.Update(project);
    }

    public void Delete(Project project)
    {
        _context.Projects.Remove(project);
    }
}