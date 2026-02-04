using System;
using TeamTask.Domain.Enums;

namespace TeamTask.Application.DTOs;

public record TaskDto(int Id, string Title, TaskStatus Status, DateTime DueDate, string Developer, string Project);
