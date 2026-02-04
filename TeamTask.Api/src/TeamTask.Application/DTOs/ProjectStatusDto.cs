namespace TeamTask.Application.DTOs;

public record ProjectStatusDto(int ProjectId, string Project, int Todo, int InProgress, int Done);
