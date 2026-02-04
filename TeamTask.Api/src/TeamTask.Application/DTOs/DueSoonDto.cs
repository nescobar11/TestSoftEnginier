using System;

namespace TeamTask.Application.DTOs;

public record DueSoonDto(int TaskId, string Title, DateTime DueDate, string Developer, string Project);
