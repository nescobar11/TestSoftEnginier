using Microsoft.EntityFrameworkCore;
using TeamTask.Domain.Entities;

namespace TeamTask.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Developer> Developers => Set<Developer>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}
