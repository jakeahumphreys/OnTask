using NTask.Data.Contexts;
using NTask.Data.Models;

namespace NTask.Data.Repositories;

public interface IProjectRepository
{
    List<ProjectRecord> GetAll();

    ProjectRecord GetById(Guid projectId);
    void Create(ProjectRecord projectRecord);
    void Update(ProjectRecord projectRecord);
    void Delete(ProjectRecord projectRecord);
}

public class ProjectRepository : IProjectRepository
{
    private readonly NTaskContext _context;

    public ProjectRepository()
    {
        _context = new NTaskContext();
    }

    public List<ProjectRecord> GetAll()
    {
        return _context.Projects.ToList();
    }

    public ProjectRecord GetById(Guid projectId)
    {
        return _context.Projects.SingleOrDefault(x => x.ProjectId == projectId);
    }

    public void Create(ProjectRecord projectRecord)
    {
        _context.Projects.Add(projectRecord);
        _context.SaveChanges();
    }

    public void Update(ProjectRecord projectRecord)
    {
        _context.Projects.Update(projectRecord);
        _context.SaveChanges();
    }

    public void Delete(ProjectRecord projectRecord)
    {
        _context.Projects.Remove(projectRecord);
        _context.SaveChanges();
    }
}