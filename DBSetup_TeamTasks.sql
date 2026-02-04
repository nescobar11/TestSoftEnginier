/* =========================================================
   DBSetup_TeamTasks.sql
   Base de datos: TeamTasksDashboard
   Motor: SQL Server
   ========================================================= */

-- 1. Crear base de datos
IF DB_ID('TeamTaskDashboard') IS NULL
BEGIN
    CREATE DATABASE TeamTaskDashboard;
END
GO

USE TeamTaskDashboard;
GO

-- 2. Crear esquema
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'core')
BEGIN
    EXEC('CREATE SCHEMA core');
END
GO

/* =========================================================
   3. Tabla: Developers
   ========================================================= */
CREATE TABLE Developers (
    DeveloperId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);
GO

/* =========================================================
   4. Tabla: Projects
   ========================================================= */
CREATE TABLE Projects (
    ProjectId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    ClientName NVARCHAR(150) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NULL,
    Status NVARCHAR(20) NOT NULL
        CHECK (Status IN ('Planned', 'InProgress', 'Completed')),
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);
GO

/* =========================================================
   5. Tabla: Tasks
   ========================================================= */
CREATE TABLE Tasks (
    TaskId INT IDENTITY(1,1) PRIMARY KEY,
    ProjectId INT NOT NULL,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(500) NULL,
    AssigneeId INT NOT NULL,
    Status NVARCHAR(20) NOT NULL
        CHECK (Status IN ('ToDo', 'InProgress', 'Blocked', 'Completed')),
    Priority NVARCHAR(10) NOT NULL
        CHECK (Priority IN ('Low', 'Medium', 'High')),
    EstimatedComplexity INT NOT NULL
        CHECK (EstimatedComplexity BETWEEN 1 AND 5),
    DueDate DATE NOT NULL,
    CompletionDate DATE NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT FK_Tasks_Projects
        FOREIGN KEY (ProjectId) REFERENCES Projects(ProjectId),

    CONSTRAINT FK_Tasks_Developers
        FOREIGN KEY (AssigneeId) REFERENCES Developers(DeveloperId)
);
GO

/* =========================================================
   6. Datos de prueba
   ========================================================= */

-- Developers (5 activos)
INSERT INTO Developers (FirstName, LastName, Email)
VALUES
('Ana', 'Gómez', 'ana.gomez@teamtasks.com'),
('Luis', 'Martínez', 'luis.martinez@teamtasks.com'),
('Carlos', 'Pérez', 'carlos.perez@teamtasks.com'),
('María', 'Rodríguez', 'maria.rodriguez@teamtasks.com'),
('Sofía', 'López', 'sofia.lopez@teamtasks.com');

-- Projects (3 proyectos)
INSERT INTO Projects (Name, ClientName, StartDate, EndDate, Status)
VALUES
('Sistema de Gestión', 'Cliente A', '2024-01-01', NULL, 'InProgress'),
('Plataforma Web', 'Cliente B', '2024-02-01', NULL, 'Planned'),
('App Móvil', 'Cliente C', '2023-10-01', '2024-01-15', 'Completed');

-- Tasks (20 tareas)
INSERT INTO Tasks
(ProjectId, Title, Description, AssigneeId, Status, Priority, EstimatedComplexity, DueDate, CompletionDate)
VALUES
-- Proyecto 1
(1, 'Diseño BD', 'Modelo inicial de base de datos', 1, 'Completed', 'High', 4, '2024-01-15', '2024-01-10'),
(1, 'API Usuarios', 'CRUD de usuarios', 2, 'InProgress', 'High', 5, '2024-02-10', NULL),
(1, 'Autenticación', 'JWT y roles', 3, 'ToDo', 'High', 5, '2024-02-20', NULL),
(1, 'Pruebas Unitarias', 'Cobertura inicial', 4, 'ToDo', 'Medium', 3, '2024-03-01', NULL),
(1, 'Documentación', 'Swagger y README', 5, 'Blocked', 'Low', 2, '2024-03-05', NULL),

-- Proyecto 2
(2, 'Maquetación UI', 'Diseño en Figma', 1, 'InProgress', 'Medium', 3, '2024-02-15', NULL),
(2, 'Landing Page', 'HTML/CSS inicial', 2, 'ToDo', 'Low', 2, '2024-02-20', NULL),
(2, 'Integración API', 'Consumo de servicios', 3, 'ToDo', 'High', 4, '2024-03-01', NULL),
(2, 'Optimización', 'Performance frontend', 4, 'ToDo', 'Medium', 3, '2024-03-10', NULL),
(2, 'Deploy', 'Publicación en hosting', 5, 'ToDo', 'High', 4, '2024-03-15', NULL),

-- Proyecto 3
(3, 'Login móvil', 'Pantalla de login', 1, 'Completed', 'High', 3, '2023-11-01', '2023-10-28'),
(3, 'Consumo API', 'Servicios REST', 2, 'Completed', 'High', 4, '2023-11-15', '2023-11-10'),
(3, 'Notificaciones', 'Push notifications', 3, 'Completed', 'Medium', 3, '2023-12-01', '2023-11-25'),
(3, 'Testing', 'Pruebas funcionales', 4, 'Completed', 'Medium', 2, '2023-12-10', '2023-12-05'),
(3, 'Publicación Store', 'Subida a tiendas', 5, 'Completed', 'High', 5, '2024-01-10', '2024-01-05'),

-- Extras para llegar a 20
(1, 'Refactor código', 'Mejoras técnicas', 2, 'ToDo', 'Medium', 3, '2024-03-20', NULL),
(2, 'SEO básico', 'Optimización buscadores', 3, 'ToDo', 'Low', 2, '2024-03-25', NULL),
(3, 'Mantenimiento', 'Corrección bugs', 4, 'Completed', 'Low', 2, '2024-01-20', '2024-01-18'),
(1, 'Logs y monitoreo', 'Serilog + dashboards', 5, 'InProgress', 'Medium', 4, '2024-03-30', NULL),
(2, 'Accesibilidad', 'WCAG', 1, 'ToDo', 'Medium', 3, '2024-04-05', NULL);

GO
