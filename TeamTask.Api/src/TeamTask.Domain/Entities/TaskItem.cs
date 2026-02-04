using System;
using TeamTask.Domain.Enums;

namespace TeamTask.Domain.Entities;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public TaskStatus0 Status { get; set; } = TaskStatus0.Todo;
    public DateTime DueDate { get; set; } = DateTime.UtcNow.AddDays(7);

    public int DeveloperId { get; set; }
    public Developer? Developer { get; set; }

    public int ProjectId { get; set; }
    public Project? Project { get; set; }
}
