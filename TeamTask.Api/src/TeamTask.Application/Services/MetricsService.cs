using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using TeamTask.Application.Interfaces;
using TeamTask.Application.DTOs;
using TeamTask.Domain.Enums;

// Alias para evitar conflicto con System.Threading.Tasks.TaskStatus
using DomainTaskStatus = TeamTask.Domain.Enums.TaskStatus0;

namespace TeamTask.Application.Services;

public class MetricsService : IMetricsService
{
    private readonly IDeveloperRepository _devRepo;
    private readonly IProjectRepository _projRepo;
    private readonly ITaskRepository _taskRepo;

    public MetricsService(IDeveloperRepository devRepo, IProjectRepository projRepo, ITaskRepository taskRepo)
    {
        _devRepo = devRepo; _projRepo = projRepo; _taskRepo = taskRepo;
    }

    public async Task<List<WorkloadSummaryDto>> WorkloadSummaryAsync()
    {
        var devs = await _devRepo.GetActiveDevelopersWithTasksAsync();
        return devs.Select(d => new WorkloadSummaryDto(
            d.Id, d.Name,
            d.Tasks.Count,
            d.Tasks.Count(t => t.Status == DomainTaskStatus.InProgress)
        )).ToList();
    }

    public async Task<List<ProjectStatusDto>> ProjectStatusSummaryAsync()
    {
        var projects = await _projRepo.GetAllWithTasksAsync();
        return projects.Select(p => new ProjectStatusDto(
            p.Id, p.Name,
            p.Tasks.Count(t => t.Status == DomainTaskStatus.Todo),
            p.Tasks.Count(t => t.Status == DomainTaskStatus.InProgress),
            p.Tasks.Count(t => t.Status == DomainTaskStatus.Done)
        )).ToList();
    }

    public async Task<List<DueSoonDto>> DueSoonAsync()
    {
        var threshold = DateTime.UtcNow.AddDays(3);
        var tasks = await _taskRepo.GetDueSoonAsync(threshold);
        return tasks.Select(t => new DueSoonDto(
            t.Id, t.Title, t.DueDate,
            t.Developer?.Name ?? string.Empty,
            t.Project?.Name ?? string.Empty
        )).ToList();
    }
}
