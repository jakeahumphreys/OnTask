using Microsoft.EntityFrameworkCore;
using NTask.Data.Models;

namespace NTask.Data.Contexts;

public sealed class NTaskContext : DbContext
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectTask> Tasks { get; set; }
    public DbSet<Activity> Activities { get; set; }
    
    public string DbPath { get; }
    
    public NTaskContext()
    {
        var localApplicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        DbPath = Path.Join(localApplicationDataPath, "NTask.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={DbPath}");
}