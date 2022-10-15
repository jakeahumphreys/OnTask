using Microsoft.EntityFrameworkCore;
using OnTask.Data.Contexts;
using OnTask.Data.Models;

namespace OnTask.Data.Repositories;

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
        return _context.Projects
            .Include(x => x.Tasks)
            .ThenInclude(y => y.ActivityRecords)
            .ToList();
    }

    public ProjectRecord GetById(Guid projectId)
    {
        return _context.Projects
            .Include(x => x.Tasks)
            .ThenInclude(y => y.ActivityRecords)
            .SingleOrDefault(x => x.ProjectId == projectId);
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