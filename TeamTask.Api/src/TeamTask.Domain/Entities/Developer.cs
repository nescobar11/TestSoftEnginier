using System.Collections.Generic;
using TeamTask.Domain.Entities;

namespace TeamTask.Domain.Entities;

public class Developer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Active { get; set; } = true;
    public List<TaskItem> Tasks { get; set; } = new();
}
