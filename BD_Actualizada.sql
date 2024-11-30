-- Creaci�n de la base de datos
CREATE DATABASE VetConnectDB;
GO
USE VetConnectDB;
GO

-- Creaci�n de las tablas de Usuarios, Veterinarios, Mascotas y Citas
CREATE TABLE Usuarios (
    IDUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(MAX) NOT NULL,
    NombreMascota NVARCHAR(MAX) NOT NULL,
    Edad INT NOT NULL,
    CorreoElectronico NVARCHAR(MAX) NOT NULL
);

CREATE TABLE Veterinarios (
    IDVeterinario INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(MAX) NOT NULL,
    Especialidad NVARCHAR(MAX) NOT NULL
);

CREATE TABLE Mascotas (
    IdMascota INT IDENTITY(1,1) PRIMARY KEY,
    Propietario NVARCHAR(MAX) NOT NULL,
    Nombre NVARCHAR(MAX) NOT NULL,
    Edad INT NOT NULL,
    Especie NVARCHAR(MAX) NOT NULL,
    IDUsuario INT NOT NULL,
    FOREIGN KEY (IDUsuario) REFERENCES Usuarios(IDUsuario) ON DELETE CASCADE
);

CREATE TABLE Citas (
    IdCita INT IDENTITY(1,1) PRIMARY KEY,
    IDMascota INT NOT NULL,
    IDVeterinario INT NOT NULL,
    IDUsuario INT NOT NULL,
    FOREIGN KEY (IDMascota) REFERENCES Mascotas(IdMascota) ON DELETE CASCADE,
    FOREIGN KEY (IDVeterinario) REFERENCES Veterinarios(IDVeterinario) ON DELETE NO ACTION,
    FOREIGN KEY (IDUsuario) REFERENCES Usuarios(IDUsuario) ON DELETE NO ACTION
);

-- Crear �ndices para las tablas existentes
CREATE INDEX IX_Citas_IDMascota ON Citas(IDMascota);
CREATE INDEX IX_Citas_IDUsuario ON Citas(IDUsuario);
CREATE INDEX IX_Citas_IDVeterinario ON Citas(IDVeterinario);
CREATE INDEX IX_Mascotas_IDUsuario ON Mascotas(IDUsuario);

-- Creaci�n de la tabla ServiciosVeterinarios
CREATE TABLE ServiciosVeterinarios (
    IDServicio INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(MAX) NOT NULL,
    Descripcion NVARCHAR(MAX) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL
);

-- Creaci�n de la tabla HistorialCitas
CREATE TABLE HistorialCitas (
    IDHistorialCitas INT IDENTITY(1,1) PRIMARY KEY,
    IDCita INT NOT NULL,
    IDServicioVeterinario INT NOT NULL,
    IDUsuario INT NOT NULL,
    FechaRealizacion DATETIME2 NOT NULL,
    FOREIGN KEY (IDCita) REFERENCES Citas(IdCita) ON DELETE CASCADE,
    FOREIGN KEY (IDServicioVeterinario) REFERENCES ServiciosVeterinarios(IDServicio) ON DELETE CASCADE,
    FOREIGN KEY (IDUsuario) REFERENCES Usuarios(IDUsuario) ON DELETE CASCADE
);

-- Crear �ndices para las nuevas tablas
CREATE INDEX IX_HistorialCitas_IDCita ON HistorialCitas(IDCita);
CREATE INDEX IX_HistorialCitas_IDServicioVeterinario ON HistorialCitas(IDServicioVeterinario);
CREATE INDEX IX_HistorialCitas_IDUsuario ON HistorialCitas(IDUsuario);

-- Insertar datos en la tabla Usuarios
INSERT INTO Usuarios (Nombre, NombreMascota, Edad, CorreoElectronico)
VALUES
    ('Juan P�rez', 'Rex', 30, 'juan.perez@example.com'),
    ('Ana L�pez', 'Mia', 25, 'ana.lopez@example.com'),
    ('Carlos G�mez', 'Toby', 28, 'carlos.gomez@example.com');

-- Insertar datos en la tabla Veterinarios
INSERT INTO Veterinarios (Nombre, Especialidad)
VALUES 
('Dr. Sandra Morales', 'Cirug�a'),
('Dr. Pedro Mart�nez', 'Dermatolog�a'),
('Dr. Laura Hern�ndez', 'Medicina Interna');

-- Insertar datos en la tabla Mascotas
INSERT INTO Mascotas (Propietario, Nombre, Edad, Especie, IDUsuario)
VALUES 
('Juan P�rez', 'Max', 5, 'Perro', 1),
('Ana Garc�a', 'Luna', 3, 'Gato', 2),
('Carlos L�pez', 'Rocky', 7, 'Perro', 3);

-- Insertar datos en la tabla Citas
INSERT INTO Citas (IDMascota, IDVeterinario, IDUsuario)
VALUES 
(1, 1, 1), -- Max con Dr. Sandra Morales
(2, 2, 2), -- Luna con Dr. Pedro Mart�nez
(3, 3, 3); -- Rocky con Dr. Laura Hern�ndez

-- Insertar datos en la tabla ServiciosVeterinarios
INSERT INTO ServiciosVeterinarios (Nombre, Descripcion, Precio)
VALUES 
('Consulta general', 'Consulta m�dica general para mascotas.', 500.00),
('Cirug�a de urgencia', 'Cirug�a veterinaria de emergencia.', 2500.00),
('Vacunaci�n', 'Vacunaci�n contra diversas enfermedades.', 300.00);

-- Insertar datos en la tabla HistorialCitas
INSERT INTO HistorialCitas (IDCita, IDServicioVeterinario, IDUsuario, FechaRealizacion)
VALUES
(1, 1, 1, '2024-11-28T10:00:00'),
(2, 3, 2, '2024-11-28T11:30:00'),
(3, 2, 3, '2024-11-28T12:15:00');

-- Verificar que los datos se insertaron correctamente
SELECT * FROM Usuarios;
SELECT * FROM Veterinarios;
SELECT * FROM Mascotas;
SELECT * FROM Citas;
SELECT * FROM ServiciosVeterinarios;
SELECT * FROM HistorialCitas;
