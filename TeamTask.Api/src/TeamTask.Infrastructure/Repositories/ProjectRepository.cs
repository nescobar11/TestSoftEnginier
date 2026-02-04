using Microsoft.EntityFrameworkCore;
using TeamTask.Application.Interfaces;
using TeamTask.Domain.Entities;
using TeamTask.Infrastructure.Data;

namespace TeamTask.Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _db;
    public ProjectRepository(AppDbContext db) => _db = db;

    public async Task<List<Project>> GetAllWithTasksAsync()
        => await _db.Projects.Include(p => p.Tasks).ToListAsync();

    public async Task<List<Project>> GetAllAsync()
        => await _db.Projects.ToListAsync();

    public async Task AddAsync(Project project)
    {
        _db.Projects.Add(project);
        await _db.SaveChangesAsync();
    }
}
