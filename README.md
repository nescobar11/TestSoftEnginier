# TeamTask Dashboard SPA

SPA desarrollada en Angular que consume una API REST en .NET 8.0 para gestión de proyectos y tareas.

## Tecnologías
- Angular 17
- TypeScript
- SCSS
- HTML5
- .net 8.0
- sql server 20.2

## Funcionalidades
- Visualización de tareas por proyecto con filtros y paginación.
- Administrar proyectos, desarrolladores y tareas.
- Consultar estado por proyecto y carga de trabajo por desarrollador.
- Detectar riesgos de retraso en tareas mediante análisis de fechas históricas.

## Estructura
frontend
- core/: servicios, modelos
- pages/: vistas principales
backend
-controllers
-services
-data
-entities

## Ejecución
```bash
npm install
ng serve

backend
dotnet restore
dotnet build
dotnet run
