using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamTask.Domain.Entities;

namespace TeamTask.Application.Interfaces;

public interface ITaskRepository
{
    Task<List<TaskItem>> GetAllAsync();
    Task<List<TaskItem>> GetDueSoonAsync(DateTime thresholdUtc);
    Task AddAsync(TaskItem task);
}
