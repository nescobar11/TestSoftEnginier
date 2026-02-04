using Microsoft.EntityFrameworkCore;
using TeamTask.Application.Interfaces;
using TeamTask.Domain.Entities;
using TeamTask.Infrastructure.Data;

namespace TeamTask.Infrastructure.Repositories;

public class DeveloperRepository : IDeveloperRepository
{
    private readonly AppDbContext _db;
    public DeveloperRepository(AppDbContext db) => _db = db;

    public async Task<List<Developer>> GetActiveDevelopersWithTasksAsync()
        => await _db.Developers.Where(d => d.Active).Include(d => d.Tasks).ToListAsync();

    public async Task<List<Developer>> GetAllAsync()
        => await _db.Developers.ToListAsync();

    public async Task AddAsync(Developer developer)
    {
        _db.Developers.Add(developer);
        await _db.SaveChangesAsync();
    }
}
