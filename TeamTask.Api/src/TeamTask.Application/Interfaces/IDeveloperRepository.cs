using System.Collections.Generic;
using System.Threading.Tasks;
using TeamTask.Domain.Entities;

namespace TeamTask.Application.Interfaces;

public interface IDeveloperRepository
{
    Task<List<Developer>> GetActiveDevelopersWithTasksAsync();
    Task<List<Developer>> GetAllAsync();
    Task AddAsync(Developer developer);
}
