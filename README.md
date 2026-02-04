# TeamTask Dashboard SPA

SPA desarrollada en Angular que consume una API REST en .NET 8.0 para gestión de proyectos y tareas.

## Tecnologías
- Angular 17
- TypeScript
- SCSS
- HTML5 

## Funcionalidades
- Dashboard con métricas de carga, estado de proyectos y riesgo de retraso.
- Visualización de tareas por proyecto con filtros y paginación.

## Estructura
- core/: servicios, modelos
- pages/: vistas principales

## Ejecución
```bash
npm install
ng serve

# Team Task Backend
Este proyecto es una API REST desarrollada en .NET 8 para la gestión de tareas, proyectos y desarrolladores.
Implementa una arquitectura limpia y escalable utilizando Entity Framework Core, SQL Server y principios REST.

La API permite:

*Administrar proyectos, desarrolladores y tareas.
*Consultar estado por proyecto y carga de trabajo por desarrollador.
*Detectar riesgos de retraso en tareas mediante análisis de fechas históricas.
*Crear y actualizar tareas con validaciones de negocio.

## Tecnologías
.net core 8.0
sql server 20.2
## Ejecución
dotnet restore
dotnet run
