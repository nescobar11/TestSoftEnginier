using System;

namespace TeamTask.Application.DTOs;

public record CreateTaskDto(string Title, DateTime DueDate, int DeveloperId, int ProjectId);
