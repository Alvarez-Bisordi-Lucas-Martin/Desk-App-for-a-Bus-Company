--CREATE DATABASE ViajesTPI;

USE ViajesTPI;

--CREATE TABLE Usuario
--(
--UserName VARCHAR(50) PRIMARY KEY NOT NULL,
--Contrasenia VARCHAR(50) NOT NULL,
--NombreUsuario VARCHAR(50),
--ApellidoUsuario VARCHAR(50)
--);

--CREATE TABLE Punto
--(
--IDPunto INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
--NombrePunto VARCHAR(50)
--);

--CREATE TABLE Itinerario
--(
--IDItinerario INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
--HorarioPartidaItinerario TIME,
--HorarioLlegadaItinerario TIME,
--HayDisponibilidadItinerario BIT,
--CantidadPuntosItinerario INT
--);

--CREATE TABLE PasajeCompleto
--(
--IDPasajeCompleto INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
--FK_IDItinerario INT,
--FOREIGN KEY (FK_IDItinerario) REFERENCES Itinerario(IDItinerario)
--);

--CREATE TABLE PasajeParcial
--(
--IDPasajeParcial INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
--CantidadPuntosPasajeParcial INT,
--FK_IDItinerario INT,
--FOREIGN KEY (FK_IDItinerario) REFERENCES Itinerario(IDItinerario)
--);

--CREATE TABLE PasajeParcialUsuario
--(
--FK_UserName VARCHAR(50) NOT NULL,
--FK_IDPasajeParcial INT NOT NULL,
--AbonoParcial BIT,
--PRIMARY KEY (FK_UserName, FK_IDPasajeParcial),
--FOREIGN KEY (FK_UserName) REFERENCES Usuario(UserName),
--FOREIGN KEY (FK_IDPasajeParcial) REFERENCES PasajeParcial(IDPasajeParcial)
--);

--CREATE TABLE PasajeCompletoUsuario
--(
--FK_UserName VARCHAR(50) NOT NULL,
--FK_IDPasajeCompleto INT NOT NULL,
--AbonoCompleto BIT,
--PRIMARY KEY (FK_UserName, FK_IDPasajeCompleto),
--FOREIGN KEY (FK_UserName) REFERENCES Usuario(UserName),
--FOREIGN KEY (FK_IDPasajeCompleto) REFERENCES PasajeCompleto(IDPasajeCompleto)
--);

--CREATE TABLE TramoParcial
--(
--FK_PasajeParcial INT NOT NULL,
--FK_IDPunto INT NOT NULL,
--OrdenParcial INT NOT NULL,
--PRIMARY KEY (FK_PasajeParcial, FK_IDPunto),
--FOREIGN KEY (FK_PasajeParcial) REFERENCES PasajeParcial(IDPasajeParcial),
--FOREIGN KEY (FK_IDPunto) REFERENCES Punto(IDPunto)
--);

--CREATE TABLE OrdenItinerario
--(
--FK_IDItinerario INT NOT NULL,
--FK_IDPunto INT NOT NULL,
--OrdenItinerario INT NOT NULL,
--PRIMARY KEY (FK_IDItinerario, FK_IDPunto),
--FOREIGN KEY (FK_IDItinerario) REFERENCES Itinerario(IDItinerario),
--FOREIGN KEY (FK_IDPunto) REFERENCES Punto(IDPunto)
--);

--CREATE TABLE Categoria
--(
--IDCategoria INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
--NombreCategoria VARCHAR(50) NOT NULL
--);

--CREATE TABLE UnidadTRansporte
--(
--IDTransporte INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
--CantidadPisos INT,
--FK_IDCategoria INT,
--FOREIGN KEY (FK_IDCategoria) REFERENCES Categoria(IDCategoria)
--);

--CREATE TABLE Calidad
--(
--IDCalidad INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
--AtencionComun BIT,
--FK_IDTransporte INT,
--FOREIGN KEY (FK_IDTransporte) REFERENCES UnidadTransporte(IDTransporte)
--);

--CREATE TABLE Servicio
--(
--IDServicio INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
--FechaPartidaServicio DATETIME2,
--FechaLlegadaServicio DATETIME2,
--FK_IDCalidad INT,
--FK_IDItinerario INT,
--FK_IDTransporte INT,
--FOREIGN KEY (FK_IDCalidad) REFERENCES Calidad(IDCalidad),
--FOREIGN KEY (FK_IDItinerario) REFERENCES Itinerario(IDItinerario),
--FOREIGN KEY (FK_IDTransporte) REFERENCES UnidadTransporte(IDTransporte)
--);

INSERT INTO Usuario (UserName, Contrasenia, NombreUsuario, ApellidoUsuario)
VALUES
('admin', 'admin', 'Lucas', 'Alvarez'),
('usuario', 'usuario', 'Gaona', 'German');

INSERT INTO Punto (NombrePunto)
VALUES
('Buenos Aires'),
('Córdoba'),
('Santa Fe'),
('Mendoza'),
('Tucumán'),
('Neuquén'),
('Salta'),
('Jujuy'),
('Entre Ríos'),
('San Juan');

INSERT INTO Itinerario (HorarioPartidaItinerario, HorarioLlegadaItinerario, HayDisponibilidadItinerario, CantidadPuntosItinerario)
VALUES
('10:00:00', '22:00:00', 1, 5),
('08:00:00', '20:00:00', 1, 5);

INSERT INTO PasajeCompleto (FK_IDItinerario)
VALUES
(1),
(2);

INSERT INTO PasajeParcial (CantidadPuntosPasajeParcial, FK_IDItinerario)
VALUES
(3, 1),
(3, 2);

INSERT INTO PasajeParcialUsuario (FK_UserName, FK_IDPasajeParcial, AbonoParcial)
VALUES
('usuario', 1, 0),
('usuario', 2, 0);

INSERT INTO PasajeCompletoUsuario (FK_UserName, FK_IDPasajeCompleto, AbonoCompleto)
VALUES
('usuario', 1, 0),
('usuario', 2, 0);

INSERT INTO TramoParcial (FK_PasajeParcial, FK_IDPunto, OrdenParcial)
VALUES
(1, 1, 1),
(1, 2, 2),
(1, 3, 3),
(2, 4, 1),
(2, 5, 2),
(2, 6, 3);

INSERT INTO OrdenItinerario (FK_IDItinerario, FK_IDPunto, OrdenItinerario)
VALUES
(1, 1, 1),
(1, 2, 2),
(1, 3, 3),
(1, 4, 4),
(1, 5, 5),
(2, 6, 1),
(2, 7, 2),
(2, 8, 3),
(2, 9, 4),
(2, 10, 5);

INSERT INTO Categoria (NombreCategoria)
VALUES
('Comun'),
('Semicama'),
('Cochecama');

INSERT INTO UnidadTransporte (CantidadPisos, FK_IDCategoria)
VALUES
(1, 1),
(1, 2),
(2, 3),
(2, 1);

INSERT INTO Calidad (AtencionComun, FK_IDTransporte)
VALUES
(1, 1),
(1, 2),
(0, 3),
(0, 4);

INSERT INTO Servicio (FechaPartidaServicio, FechaLlegadaServicio, FK_IDCalidad, FK_IDItinerario, FK_IDTransporte)
VALUES
('2023-11-01 10:00:00', '2023-11-01 22:00:00', 1, 1, 1),
('2023-11-02 08:00:00', '2023-11-02 20:00:00', 2, 2, 2);

SELECT *
FROM Usuario;

SELECT *
FROM Categoria;

SELECT *
FROM UnidadTransporte;

SELECT *
FROM Calidad;

SELECT *
FROM Itinerario;

SELECT *
FROM Punto;

SELECT *
FROM PasajeParcial;

SELECT *
FROM PasajeCompleto;

SELECT *
FROM PasajeParcialUsuario;

SELECT *
FROM PasajeCompletoUsuario;

SELECT *
FROM TramoParcial;

SELECT *
FROM OrdenItinerario;

SELECT *
FROM Servicio;

DELETE FROM Itinerario
WHERE IDItinerario = 0;

UPDATE Itinerario
SET
HorarioPartidaItinerario = '00:00:00',
HorarioLlegadaItinerario = '00:00:00',
HayDisponibilidadItinerario = 0,
CantidadPuntosItinerario = 0
WHERE IDItinerario = 0;

DELETE FROM OrdenItinerario
WHERE FK_IDItinerario = 0 AND FK_IDPunto = 0;

UPDATE OrdenItinerario
SET
OrdenItinerario = 0
WHERE FK_IDItinerario = 0 AND FK_IDPunto = 0;

DELETE FROM Servicio
WHERE IDServicio = 0;

UPDATE Servicio
SET
FechaPartidaServicio = '20230101 00:00:00',
FechaLlegadaServicio = '20230101 00:00:00',
FK_IDCalidad = 0,
FK_IDItinerario = 0,
FK_IDTransporte = 0
WHERE IDServicio = 0;