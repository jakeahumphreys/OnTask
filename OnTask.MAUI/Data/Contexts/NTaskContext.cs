using Microsoft.EntityFrameworkCore;
using OnTask.MAUI.Data.Models;

namespace OnTask.MAUI.Data.Contexts;

public sealed class NTaskContext : DbContext
{
    public DbSet<ProjectRecord> Projects { get; set; }
    public DbSet<TaskRecord> Tasks { get; set; }
    public DbSet<ActivityRecord> Activities { get; set; }
    
    public string DbPath { get; }
    
    public NTaskContext()
    {
        var localApplicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        DbPath = Path.Join(localApplicationDataPath, "OnTask.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={DbPath}");
}