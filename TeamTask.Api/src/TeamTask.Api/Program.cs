using Microsoft.EntityFrameworkCore;
using TeamTask.Infrastructure.Data;
using TeamTask.Infrastructure.Repositories;
using TeamTask.Application.Interfaces;
using TeamTask.Application.Services;
using TeamTask.Domain.Entities;
using TeamTask.Application.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Swagger + Endpoints
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS para Angular
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("ng-client", p => p.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
});

// EF Core InMemory
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TeamTaskDB"));

// DI Repos y Servicios
builder.Services.AddScoped<IDeveloperRepository, DeveloperRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddScoped<IMetricsService, MetricsService>();

var app = builder.Build();

app.UseCors("ng-client");
app.UseSwagger();
app.UseSwaggerUI();

// Seed de datos en arranque
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await AppDbSeed.SeedAsync(db);
}

// Endpoints raíz
app.MapGet("/", () => Results.Ok(new { name = "Team Task API", version = "v1" }));

// Developers
app.MapGet("/api/developers", async (IDeveloperRepository repo) => Results.Ok(await repo.GetAllAsync()));
app.MapPost("/api/developers", async (IDeveloperRepository repo, Developer dev) => { await repo.AddAsync(dev); return Results.Created($"/api/developers/{dev.Id}", dev); });

// Projects
app.MapGet("/api/projects", async (IProjectRepository repo) => Results.Ok(await repo.GetAllAsync()));
app.MapPost("/api/projects", async (IProjectRepository repo, Project pr) => { await repo.AddAsync(pr); return Results.Created($"/api/projects/{pr.Id}", pr); });

// Tasks
app.MapGet("/api/tasks", async (ITaskRepository repo) => Results.Ok(await repo.GetAllAsync()));
app.MapPost("/api/tasks", async (ITaskRepository repo, CreateTaskDto dto) =>
{
    var task = new TaskItem { Title = dto.Title, DueDate = dto.DueDate, DeveloperId = dto.DeveloperId, ProjectId = dto.ProjectId };
    await repo.AddAsync(task);
    return Results.Created($"/api/tasks/{task.Id}", task);
});

// Metrics
app.MapGet("/api/metrics/workload", async (IMetricsService svc) => Results.Ok(await svc.WorkloadSummaryAsync()));
app.MapGet("/api/metrics/project-status", async (IMetricsService svc) => Results.Ok(await svc.ProjectStatusSummaryAsync()));
app.MapGet("/api/metrics/due-soon", async (IMetricsService svc) => Results.Ok(await svc.DueSoonAsync()));

app.Run();
