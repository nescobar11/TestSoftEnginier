using System.Collections.Generic;
using System.Threading.Tasks;
using TeamTask.Domain.Entities;

namespace TeamTask.Application.Interfaces;

public interface IProjectRepository
{
    Task<List<Project>> GetAllWithTasksAsync();
    Task<List<Project>> GetAllAsync();
    Task AddAsync(Project project);
}
