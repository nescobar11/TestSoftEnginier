using TeamTask.Domain.Entities;
using TeamTask.Domain.Enums;

namespace TeamTask.Infrastructure.Data;

public static class AppDbSeed
{
    public static async Task SeedAsync(AppDbContext db)
    {
        if (db.Developers.Any()) return;

        var alice = new Developer { Name = "Alice", Active = true };
        var bob = new Developer { Name = "Bob", Active = true };
        var carol = new Developer { Name = "Carol", Active = false };
        db.Developers.AddRange(alice, bob, carol);

        var phoenix = new Project { Name = "Phoenix" };
        var orion = new Project { Name = "Orion" };
        db.Projects.AddRange(phoenix, orion);
        await db.SaveChangesAsync();

        db.Tasks.AddRange(
            new TaskItem { Title = "Auth API", Status = TaskStatus0.InProgress, DueDate = DateTime.UtcNow.AddDays(2), DeveloperId = alice.Id, ProjectId = phoenix.Id },
            new TaskItem { Title = "Landing Page", Status = TaskStatus0.Todo, DueDate = DateTime.UtcNow.AddDays(5), DeveloperId = bob.Id, ProjectId = phoenix.Id },
            new TaskItem { Title = "ETL Job", Status = TaskStatus0.Todo, DueDate = DateTime.UtcNow.AddDays(1), DeveloperId = bob.Id, ProjectId = orion.Id }
        );
        await db.SaveChangesAsync();
    }
}
