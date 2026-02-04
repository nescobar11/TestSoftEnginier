namespace TeamTask.Application.DTOs;

public record WorkloadSummaryDto(int DeveloperId, string Developer, int TotalTasks, int TasksInProgress);
