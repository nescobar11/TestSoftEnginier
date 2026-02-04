using System.Collections.Generic;
using System.Threading.Tasks;
using TeamTask.Application.DTOs;

namespace TeamTask.Application.Interfaces;

public interface IMetricsService
{
    Task<List<WorkloadSummaryDto>> WorkloadSummaryAsync();
    Task<List<ProjectStatusDto>> ProjectStatusSummaryAsync();
    Task<List<DueSoonDto>> DueSoonAsync();
}
