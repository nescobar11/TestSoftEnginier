using Microsoft.EntityFrameworkCore;
using TeamTask.Application.Interfaces;
using TeamTask.Domain.Entities;
using TeamTask.Infrastructure.Data;
using TeamTask.Domain.Enums;

namespace TeamTask.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _db;
    public TaskRepository(AppDbContext db) => _db = db;

    public async Task<List<TaskItem>> GetAllAsync()
        => await _db.Tasks.Include(t => t.Developer).Include(t => t.Project).ToListAsync();

    public async Task<List<TaskItem>> GetDueSoonAsync(DateTime thresholdUtc)
        => await _db.Tasks.Include(t => t.Developer).Include(t => t.Project)
                          .Where(t => t.DueDate <= thresholdUtc && t.Status != TaskStatus0.Done)
                          .ToListAsync();

    public async Task AddAsync(TaskItem task)
    {
        _db.Tasks.Add(task);
        await _db.SaveChangesAsync();
    }
}
