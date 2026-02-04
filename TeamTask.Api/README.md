# TeamTask API Solution (.NET 8) – Lista para Angular

## Estructura
- **Domain**: Entidades de dominio y enums.
- **Application**: DTOs, interfaces y servicios de aplicación (métricas).
- **Infrastructure**: EF Core (InMemory), DbContext y repositorios.
- **Api**: Minimal API (.NET 8), Swagger, CORS para Angular.

## Ejecutar localmente
```bash
cd src/TeamTask.Api
# Restaurar deps y levantar API
dotnet restore
dotnet run
# Navega a /swagger para probar
```

## Endpoints clave
- `GET /api/tasks` — Listar tareas
- `POST /api/tasks` — Crear tarea
- `GET /api/developers` — Listar devs
- `POST /api/developers` — Crear dev
- `GET /api/projects` — Listar proyectos
- `POST /api/projects` — Crear proyecto
- `GET /api/metrics/workload` — Carga por desarrollador (activos)
- `GET /api/metrics/project-status` — Resumen por proyecto
- `GET /api/metrics/due-soon` — Próximas a vencer

## CORS
Permitido `http://localhost:4200` para Angular. Ajusta en `Program.cs` en producción.

## Docker
Desde la **raíz** del repo (donde está esta README):
```bash
docker build -f src/TeamTask.Api/Dockerfile -t teamtask-api .
docker run -p 8080:8080 teamtask-api
```
Luego prueba: `http://localhost:8080/swagger`

## Notas
- Base de datos **InMemory** para desarrollo. Cambia a SQL Server o PostgreSQL editando `Program.cs` y agregando el provider.
- Código limpio y minimalista, ideal para ser consumido por un frontend **Angular**.
