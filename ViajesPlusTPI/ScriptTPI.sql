--CREATE DATABASE ViajesTPI;

USE ViajesTPI;

--CREATE TABLE Usuario
--(
--UserName VARCHAR(50) PRIMARY KEY NOT NULL,
--Contrasenia VARCHAR(50) NOT NULL,
--NombreUsuario VARCHAR(50) NOT NULL,
--ApellidoUsuario VARCHAR(50) NOT NULL,
--EsCliente BIT NOT NULL
--);

--CREATE TABLE Ciudad
--(
--NombreCiudad VARCHAR(50) PRIMARY KEY NOT NULL
--);

--CREATE TABLE Parada
--(
--NombreParada VARCHAR(50) NOT NULL,
--Latitud FLOAT NOT NULL,
--Longitud FLOAT NOT NULL,
--FK_NombreCiudad VARCHAR(50) NOT NULL,
--PRIMARY KEY (NombreParada, FK_NombreCiudad),
--FOREIGN KEY (FK_NombreCiudad) REFERENCES Ciudad(NombreCiudad)
--);

--CREATE TABLE Itinerario
--(
--IDItinerario INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
--HorarioPartidaItinerario TIME NOT NULL,
--HorarioLlegadaItinerario TIME NOT NULL,
--CantidadParadas INT NOT NULL,
--DistKmItinerario FLOAT NOT NULL
--);

--CREATE TABLE OrdenParadaItinerario
--(
--FK_IDItinerario INT NOT NULL,
--FK_NombreParada VARCHAR(50) NOT NULL,
--FK_NombreCiudad VARCHAR(50) NOT NULL,
--OrdenParada INT NOT NULL,
--PRIMARY KEY (FK_IDItinerario, FK_NombreParada, FK_NombreCiudad),
--FOREIGN KEY (FK_IDItinerario) REFERENCES Itinerario(IDItinerario),
--FOREIGN KEY (FK_NombreParada, FK_NombreCiudad) REFERENCES Parada(NombreParada, FK_NombreCiudad)
--);

--CREATE TABLE Categoria
--(
--NombreCategoria VARCHAR(50) PRIMARY KEY NOT NULL
--);

--CREATE TABLE UnidadTransporte
--(
--IDTransporte INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
--EsDosPisos BIT NOT NULL,
--CantidadDeAsientos INT NOT NULL,
--FK_NombreCategoria VARCHAR(50) NOT NULL,
--FOREIGN KEY (FK_NombreCategoria) REFERENCES Categoria(NombreCategoria)
--);

--CREATE TABLE Calidad
--(
--IDCalidad INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
--EsAtencionEjecutiva BIT NOT NULL,
--FK_NombreCategoria VARCHAR(50) NOT NULL,
--FOREIGN KEY (FK_NombreCategoria) REFERENCES Categoria(NombreCategoria)
--);

--CREATE TABLE Costo
--(
--TipoCosto VARCHAR(50) PRIMARY KEY NOT NULL,
--UnidadDeMedida VARCHAR(50) NOT NULL,
--PrecioUnitario FLOAT NOT NULL
--);

----120: Formato de fecha estandar ISO 8601 (aaaa/mm/dd)
----108: Formato de hora (hh:mi:ss)
--CREATE TABLE Servicio
--(
--IDServicio INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
--FechaPartidaServicio DATE NOT NULL,
--FechaLlegadaServicio DATE NOT NULL,
--HoraPartidaServicio TIME NOT NULL,
--HoraLlegadaServicio TIME NOT NULL,
--AsientosDisponibles INT,
--HayDisponibilidad BIT,
--TiempoDeViaje AS (
--DATEDIFF(HOUR,
--CONVERT(DATETIME2, CONVERT(VARCHAR, FechaPartidaServicio, 120) + ' ' + CONVERT(VARCHAR, HoraPartidaServicio, 108)),
--CONVERT(DATETIME2, CONVERT(VARCHAR, FechaLlegadaServicio, 120) + ' ' + CONVERT(VARCHAR, HoraLlegadaServicio, 108)))),
--FK_IDCalidad INT NOT NULL,
--FK_IDItinerario INT,
--FK_IDTransporte INT,
--FOREIGN KEY (FK_IDCalidad) REFERENCES Calidad(IDCalidad),
--FOREIGN KEY (FK_IDItinerario) REFERENCES Itinerario(IDItinerario),
--FOREIGN KEY (FK_IDTransporte) REFERENCES UnidadTransporte(IDTransporte)
--);

--CREATE TABLE DemandaServicio
--(
--FK_TipoCosto VARCHAR(50) NOT NULL,
--FK_IDServicio INT NOT NULL,
--PRIMARY KEY (FK_TipoCosto, FK_IDServicio),
--FOREIGN KEY (FK_TipoCosto) REFERENCES Costo(TipoCosto),
--FOREIGN KEY (FK_IDServicio) REFERENCES Servicio(IDServicio)
--);

--CREATE TABLE Pasaje
--(
--IDPasaje INT IDENTITY (1,1) NOT NULL,
--FK_IDServicio INT NOT NULL,
--NombreParadaSubida VARCHAR(50) NOT NULL,
--NombreParadaBajada VARCHAR(50) NOT NULL,
--EstaAbonado BIT NOT NULL,
--DistKmPasaje FLOAT NOT NULL,
--CostoPasaje FLOAT,
--FK_UserName VARCHAR(50) NOT NULL,
--PRIMARY KEY (IDPasaje, FK_IDServicio),
--FOREIGN KEY (FK_UserName) REFERENCES Usuario(UserName),
--FOREIGN KEY (FK_IDServicio) REFERENCES Servicio(IDServicio)
--);

--CREATE TRIGGER ActualizarAsientosDisponibles
--ON Servicio
--AFTER INSERT
--AS
--BEGIN
--    UPDATE Servicio
--    SET [AsientosDisponibles] = UnidadTransporte.[CantidadDeAsientos]
--    FROM Servicio
--    JOIN UnidadTransporte ON Servicio.[FK_IDTransporte] = UnidadTransporte.[IDTransporte]
--    INNER JOIN inserted ON Servicio.[IDServicio] = inserted.[IDServicio];
--END;

--CREATE TRIGGER DescuentoAsientoPasaje
--ON Pasaje
--AFTER INSERT
--AS
--BEGIN
--    UPDATE Servicio
--    SET AsientosDisponibles = Servicio.AsientosDisponibles - 1,
--        HayDisponibilidad = CASE WHEN (Servicio.AsientosDisponibles - 1) > 0 THEN 1 ELSE 0 END
--    FROM Servicio
--    INNER JOIN inserted ON Servicio.IDServicio = inserted.FK_IDServicio;
--END;

--CREATE TRIGGER SumarAsientoPasaje
--ON Pasaje
--AFTER DELETE
--AS
--BEGIN
--    UPDATE Servicio
--    SET AsientosDisponibles = Servicio.AsientosDisponibles + 1,
--        HayDisponibilidad = CASE WHEN (Servicio.AsientosDisponibles + 1) > 0 THEN 1 ELSE 0 END
--    FROM Servicio
--    INNER JOIN deleted ON Servicio.IDServicio = deleted.FK_IDServicio;
--END;

--CREATE TRIGGER ActualizarCostoPasaje
--ON Pasaje
--AFTER INSERT
--AS
--BEGIN
--    UPDATE Pasaje
--    SET CostoPasaje = (
--        SELECT (
--            CEILING((DistKmPasaje * 1) / 12) * (
--                SELECT PrecioUnitario
--                FROM Costo
--                WHERE TipoCosto = 'Nafta'
--            ) + Servicio.[TiempoDeViaje] * (
--                SELECT PrecioUnitario
--                FROM Costo
--                WHERE TipoCosto = 'Chofer'
--            ) + Servicio.[TiempoDeViaje] * (
--                CASE
--                    WHEN EXISTS (
--                        SELECT FK_TipoCosto
--                        FROM DemandaServicio
--                        WHERE FK_TipoCosto = 'Auxiliar' AND FK_IDServicio = Servicio.IDServicio
--                    ) THEN (
--                        SELECT PrecioUnitario
--                        FROM Costo
--                        WHERE TipoCosto = 'Auxiliar'
--                    )
--                    ELSE 0
--                END
--            )) * 2 / (
--                SELECT [CantidadDeAsientos]
--                FROM UnidadTransporte
--                WHERE Servicio.[FK_IDTransporte] = UnidadTransporte.[IDTransporte]
--            ) + (
--                CASE
--                    WHEN Itinerario.[CantidadParadas] > 2 THEN -1000
--                    ELSE 0
--                END
--            ) + (
--                CASE
--                    WHEN Calidad.[EsAtencionEjecutiva] = 0 AND Calidad.[FK_NombreCategoria] = 'Comun' THEN 0
--                    WHEN Calidad.[EsAtencionEjecutiva] = 0 AND Calidad.[FK_NombreCategoria] = 'SemiCama' THEN 500
--                    WHEN Calidad.[EsAtencionEjecutiva] = 0 AND Calidad.[FK_NombreCategoria] = 'CocheCama' THEN 1000
--                    WHEN Calidad.[EsAtencionEjecutiva] = 1 AND Calidad.[FK_NombreCategoria] = 'Comun' THEN 1000
--                    WHEN Calidad.[EsAtencionEjecutiva] = 1 AND Calidad.[FK_NombreCategoria] = 'SemiCama' THEN 1500
--                    WHEN Calidad.[EsAtencionEjecutiva] = 1 AND Calidad.[FK_NombreCategoria] = 'CocheCama' THEN 2000
--                    ELSE 0
--                END
--            )
--        FROM inserted
--        INNER JOIN Servicio ON inserted.FK_IDServicio = Servicio.IDServicio
--        INNER JOIN Calidad ON Calidad.IDCalidad = Servicio.FK_IDCalidad
--		INNER JOIN Itinerario ON Itinerario.IDItinerario = Servicio.[FK_IDItinerario]
--		WHERE inserted.IDPasaje = Pasaje.IDPasaje
--    )
--    FROM Pasaje
--    INNER JOIN inserted ON Pasaje.IDPasaje = inserted.IDPasaje;
--END;

--CREATE TRIGGER InsteadOfDeleteParada
--ON Parada
--INSTEAD OF DELETE
--AS
--BEGIN
--    DELETE FROM OrdenParadaItinerario
--    WHERE FK_NombreParada IN (SELECT NombreParada FROM deleted);
--    DELETE FROM Parada
--    WHERE NombreParada IN (SELECT NombreParada FROM deleted);
--END;

--CREATE TRIGGER InsteadOfDeleteItinerario
--ON Itinerario
--INSTEAD OF DELETE
--AS
--BEGIN
--    DELETE FROM OrdenParadaItinerario
--    WHERE FK_IDItinerario IN (SELECT IDItinerario FROM deleted);
--    UPDATE Servicio
--    SET FK_IDItinerario = NULL
--    WHERE FK_IDItinerario IN (SELECT IDItinerario FROM deleted);
--    DELETE FROM Itinerario
--    WHERE IDItinerario IN (SELECT IDItinerario FROM deleted);
--END;

--CREATE TRIGGER InsteadOfDeleteServicio
--ON Servicio
--INSTEAD OF DELETE
--AS
--BEGIN
--    DELETE FROM Pasaje
--    WHERE FK_IDServicio IN (SELECT IDServicio FROM deleted);
--    DELETE FROM DemandaServicio
--    WHERE FK_IDServicio IN (SELECT IDServicio FROM deleted);
--    DELETE FROM Servicio
--    WHERE IDServicio IN (SELECT IDServicio FROM deleted);
--END;

--CREATE TRIGGER InsteadOfDeleteUnidadTransporte
--ON UnidadTransporte
--INSTEAD OF DELETE
--AS
--BEGIN
--    UPDATE Servicio
--    SET FK_IDTransporte = NULL
--    WHERE FK_IDTransporte IN (SELECT IDTransporte FROM deleted);
--    DELETE FROM UnidadTransporte
--    WHERE IDTransporte IN (SELECT IDTransporte FROM deleted);
--END;

--CREATE PROCEDURE EliminarPasajesNoAbonados
--AS
--BEGIN
--    DELETE FROM Pasaje
--    WHERE FK_IDServicio IN (
--        SELECT IDServicio
--        FROM Servicio
--        WHERE GETDATE() >= DATEADD(MINUTE, -30, CAST(FechaPartidaServicio AS DATETIME) + CAST(HoraPartidaServicio AS DATETIME))
--    )
--    AND EstaAbonado = 0;
--END;

--EXEC EliminarPasajesNoAbonados;

--INSERT INTO Usuario (UserName, Contrasenia, NombreUsuario, ApellidoUsuario, EsCliente)
--VALUES
--('admin', 'admin', 'Lucas', 'Alvarez', 0),
--('usuario', 'usuario', 'Lucas', 'Alvarez', 1);

--INSERT INTO Ciudad (NombreCiudad)
--VALUES ('Bariloche'),
--('Buenos Aires'),
--('Clorinda'),
--('Corrientes'),
--('La Plata'),
--('La Rioja'),
--('Mar del Plata'),
--('Resistencia'),
--('Rosario'),
--('Salta');

--INSERT INTO Parada (NombreParada, Latitud, Longitud, FK_NombreCiudad)
--VALUES ('ParadaBariloche', -41.1041909445765, -71.16943359375, 'Bariloche'),
--('ParadaBuenos Aires', -34.6252978589571, -58.4458923339844, 'Buenos Aires'),
--('ParadaClorinda', -25.2980959836474, -57.7317810058594, 'Clorinda'),
--('ParadaCorrientes', -27.4814714374653, -58.831787109375, 'Corrientes'),
--('ParadaLa Plata', -34.9366078062388, -57.9597473144531, 'La Plata'),
--('ParadaLa Rioja', -29.410890376109, -66.77490234375, 'La Rioja'),
--('ParadaMar del Plata', -37.9961626797281, -57.579345703125, 'Mar del Plata'),
--('ParadaResistencia', -27.4631949866051, -58.9883422851563, 'Resistencia'),
--('ParadaRosario', -32.9372338139709, -60.7063293457031, 'Rosario'),
--('ParadaSalta', -24.7867345419889, -65.390625, 'Salta');

--INSERT INTO Categoria (NombreCategoria)
--VALUES
--('Comun'),
--('SemiCama'),
--('CocheCama');

--INSERT INTO Calidad (EsAtencionEjecutiva, FK_NombreCategoria)
--VALUES
--(0, 'Comun'),
--(0, 'SemiCama'),
--(0, 'CocheCama'),
--(1, 'Comun'),
--(1, 'SemiCama'),
--(1, 'CocheCama');

--INSERT INTO Costo (TipoCosto, UnidadDeMedida, PrecioUnitario)
--VALUES
--('Nafta', 'Litro', 1000),
--('Chofer', 'Hora', 1000),
--('Auxiliar', 'Hora', 800);

--INSERT INTO Pasaje (FK_IDServicio, NombreParadaSubida, NombreParadaBajada, EstaAbonado, DistKmPasaje, FK_UserName)
--VALUES (1, 'ParadaFontana', 'ParadaCorrientes', 1, 0, 'usuario');

--INSERT INTO UnidadTransporte (EsDosPisos, CantidadDeAsientos, FK_NombreCategoria)
--VALUES
--(0, 5, 'Comun'),
--(0, 5, 'SemiCama'),
--(0, 5, 'CocheCama'),
--(1, 5, 'Comun'),
--(1, 5, 'SemiCama'),
--(1, 5, 'CocheCama');

--INSERT INTO Itinerario (HorarioPartidaItinerario, HorarioLlegadaItinerario, CantidadParadas, DistKmItinerario)
--VALUES ('12:00:00', '18:00:00', 4, 0),
--('12:00:00', '18:00:00', 4, 0),
--('12:00:00', '18:00:00', 4, 0),
--('12:00:00', '18:00:00', 4, 0),
--('12:00:00', '18:00:00', 10, 0);

--INSERT INTO OrdenParadaItinerario (FK_IDItinerario, FK_NombreParada, FK_NombreCiudad, OrdenParada)
--VALUES 
--(1, 'ParadaBuenos Aires', 'Buenos Aires', 4),
--(1, 'ParadaClorinda', 'Clorinda', 1),
--(1, 'ParadaCorrientes', 'Corrientes', 3),
--(1, 'ParadaResistencia', 'Resistencia', 2),
--(2, 'ParadaBariloche', 'Bariloche', 1),
--(2, 'ParadaBuenos Aires', 'Buenos Aires', 3),
--(2, 'ParadaLa Rioja', 'La Rioja', 2),
--(2, 'ParadaMar del Plata', 'Mar del Plata', 4),
--(3, 'ParadaClorinda', 'Clorinda', 2),
--(3, 'ParadaCorrientes', 'Corrientes', 4),
--(3, 'ParadaResistencia', 'Resistencia', 3),
--(3, 'ParadaSalta', 'Salta', 1),
--(4, 'ParadaBuenos Aires', 'Buenos Aires', 2),
--(4, 'ParadaLa Rioja', 'La Rioja', 3),
--(4, 'ParadaMar del Plata', 'Mar del Plata', 1),
--(4, 'ParadaSalta', 'Salta', 4),
--(5, 'ParadaBariloche', 'Bariloche', 1),
--(5, 'ParadaBuenos Aires', 'Buenos Aires', 5),
--(5, 'ParadaClorinda', 'Clorinda', 9),
--(5, 'ParadaCorrientes', 'Corrientes', 7),
--(5, 'ParadaLa Plata', 'La Plata', 4),
--(5, 'ParadaLa Rioja', 'La Rioja', 2),
--(5, 'ParadaMar del Plata', 'Mar del Plata', 3),
--(5, 'ParadaResistencia', 'Resistencia', 8),
--(5, 'ParadaRosario', 'Rosario', 6),
--(5, 'ParadaSalta', 'Salta', 10);

--INSERT INTO Servicio (FechaPartidaServicio, FechaLlegadaServicio, HoraPartidaServicio, HoraLlegadaServicio, HayDisponibilidad, FK_IDCalidad, FK_IDItinerario, FK_IDTransporte)
--VALUES ('2023-12-10', '2023-12-12', '12:00:00', '18:00:00', 1, 1, 1, 1),
--('2023-12-10', '2023-12-12', '12:00:00', '18:00:00', 1, 2, 1, 2),
--('2023-12-10', '2023-12-12', '12:00:00', '18:00:00', 1, 2, 2, 2),
--('2023-12-10', '2023-12-12', '12:00:00', '18:00:00', 1, 3, 2, 3),
--('2023-12-10', '2023-12-12', '12:00:00', '18:00:00', 1, 3, 3, 3),
--('2023-12-10', '2023-12-12', '12:00:00', '18:00:00', 1, 4, 3, 4),
--('2023-12-10', '2023-12-12', '12:00:00', '18:00:00', 1, 4, 4, 4),
--('2023-12-10', '2023-12-12', '12:00:00', '18:00:00', 1, 5, 4, 5),
--('2023-12-10', '2023-12-20', '12:00:00', '18:00:00', 1, 5, 5, 5),
--('2023-12-10', '2023-12-20', '12:00:00', '18:00:00', 1, 6, 5, 6);

--INSERT INTO DemandaServicio (FK_TipoCosto, FK_IDServicio)
--VALUES
--('Nafta', 1),
--('Chofer', 1),
--('Auxiliar', 1),
--('Nafta', 2),
--('Chofer', 2),
--('Auxiliar', 2),
--('Nafta', 3),
--('Chofer', 3),
--('Auxiliar', 3),
--('Nafta', 4),
--('Chofer', 4),
--('Auxiliar', 4),
--('Nafta', 5),
--('Chofer', 5),
--('Auxiliar', 5),
--('Nafta', 6),
--('Chofer', 6),
--('Auxiliar', 6),
--('Nafta', 7),
--('Chofer', 7),
--('Auxiliar', 7),
--('Nafta', 8),
--('Chofer', 8),
--('Auxiliar', 8),
--('Nafta', 9),
--('Chofer', 9),
--('Auxiliar', 9),
--('Nafta', 10),
--('Chofer', 10),
--('Auxiliar', 10);

SELECT * FROM Pasaje;

SELECT * FROM Servicio;

SELECT * FROM Usuario;

SELECT * FROM Parada;

SELECT * FROM OrdenParadaItinerario;

SELECT * FROM Ciudad;

SELECT * FROM Itinerario;

SELECT * FROM UnidadTransporte;

SELECT * FROM Calidad;

SELECT * FROM DemandaServicio;

SELECT * FROM Costo;

SELECT * FROM Categoria;

--DELETE FROM Pasaje
--WHERE IDPasaje = 0;

--DELETE FROM Itinerario
--WHERE IDItinerario = 0;

--DELETE FROM Servicio
--WHERE IDServicio = 0;

--DELETE FROM Calidad
--WHERE IDCalidad = 0;

--DELETE FROM UnidadTransporte
--WHERE IDTransporte = 0;

--DELETE FROM Ciudad
--WHERE NombreCiudad = '';

--DELETE FROM Parada
--WHERE NombreParada = '';

--DELETE FROM Usuario;

--DELETE FROM Ciudad;

--DELETE FROM Parada;

--DELETE FROM Calidad;
--DBCC CHECKIDENT('Calidad', RESEED, 0);

--DELETE FROM Categoria;

--DELETE FROM Costo;

--DELETE FROM Itinerario;
--DBCC CHECKIDENT('Itinerario', RESEED, 0);

--DELETE FROM OrdenParadaItinerario;

--DELETE FROM UnidadTransporte;
--DBCC CHECKIDENT('UnidadTransporte', RESEED, 0);

--DELETE FROM Servicio;
--DBCC CHECKIDENT('Servicio', RESEED, 0);

--DELETE FROM DemandaServicio;

--DELETE FROM Pasaje;
--DBCC CHECKIDENT('Pasaje', RESEED, 0);

SELECT Parada.[NombreParada], Parada.[Latitud], Parada.[Longitud], OrdenParadaItinerario.[OrdenParada]
FROM Parada
INNER JOIN OrdenParadaItinerario
ON Parada.[NombreParada] = OrdenParadaItinerario.[FK_NombreParada]
WHERE OrdenParadaItinerario.[FK_IDItinerario] = 1
ORDER BY OrdenParadaItinerario.[OrdenParada];

SELECT COUNT(*) Contador
FROM OrdenParadaItinerario
WHERE FK_IDItinerario = 1;

--COALESCE muestra 0 si no hay coincidencias.
SELECT Itinerario.[IDItinerario], COALESCE(COUNT(Pasaje.[IDPasaje]), 0) Pasajes
FROM Itinerario
LEFT JOIN Servicio
ON Itinerario.[IDItinerario] = Servicio.[FK_IDItinerario]
LEFT JOIN Pasaje
ON Pasaje.[FK_IDServicio] = Servicio.[IDServicio]
GROUP BY Itinerario.[IDItinerario]
ORDER BY Pasajes DESC;

SELECT Servicio.[IDServicio], Servicio.[FechaPartidaServicio], COALESCE(COUNT(Pasaje.[IDPasaje]), 0) Pasajes
FROM Servicio
LEFT JOIN Pasaje
ON Pasaje.[FK_IDServicio] = Servicio.[IDServicio]
GROUP BY Servicio.[IDServicio], Servicio.[FechaPartidaServicio]
ORDER BY Pasajes DESC;

SELECT Categoria.[NombreCategoria], COALESCE(COUNT(Pasaje.[IDPasaje]), 0) Pasajes
FROM Categoria
LEFT JOIN UnidadTransporte
ON Categoria.[NombreCategoria] = UnidadTRansporte.[FK_NombreCategoria]
LEFT JOIN Servicio
ON UnidadTransporte.[IDTransporte] = Servicio.[FK_IDTransporte]
LEFT JOIN Pasaje
ON Pasaje.[FK_IDServicio] = Servicio.[IDServicio]
GROUP BY Categoria.[NombreCategoria]
ORDER BY Pasajes DESC;

SELECT
Pasaje.[IDPasaje] ID,
Pasaje.[NombreParadaSubida] Inicio,
Pasaje.[NombreParadaBajada] Fin,
Pasaje.[EstaAbonado],
Pasaje.[DistKmPasaje] DistKm,
Pasaje.[CostoPasaje] Costo,
Servicio.[IDServicio],
Servicio.[FechaPartidaServicio] FechaPartida,
Servicio.[FechaLlegadaServicio] FechaLlegada,
Servicio.[HoraPartidaServicio] HoraPartida,
Servicio.[HoraLlegadaServicio] HoraLlegada,
Servicio.[TiempoDeViaje],
Calidad.[EsAtencionEjecutiva],
Categoria.[NombreCategoria] Categoria
FROM Pasaje
INNER JOIN Servicio
ON Servicio.[IDServicio] = Pasaje.[FK_IDServicio]
INNER JOIN Calidad
ON Calidad.[IDCalidad] = Servicio.[FK_IDCalidad]
INNER JOIN Categoria
ON Categoria.[NombreCategoria] = Calidad.[FK_NombreCategoria]
WHERE Pasaje.[FK_UserName] = 'usuario';

SELECT
Servicio.[HoraLlegadaServicio],
Servicio.[HoraPartidaServicio],
Servicio.[TiempoDeViaje],
CASE WHEN Calidad.[EsAtencionEjecutiva] = 0 THEN 'Comun'
ELSE 'Ejecutiva' END Atencion,
Categoria.[NombreCategoria]
FROM Servicio
INNER JOIN Calidad
ON Servicio.[FK_IDCalidad] = Calidad.[IDCalidad]
INNER JOIN Categoria
ON Categoria.[NombreCategoria] = Calidad.[FK_NombreCategoria]
WHERE Servicio.[IDServicio] = 1;

SELECT IDServicio FROM Servicio WHERE FK_IDItinerario = 1 AND HayDisponibilidad = 1;

SELECT I.[IDItinerario]
FROM Itinerario I
INNER JOIN OrdenParadaItinerario O ON O.[FK_IDItinerario] = I.[IDItinerario]
INNER JOIN Parada P ON P.[NombreParada] = O.[FK_NombreParada]
WHERE O.[OrdenParada] = (
SELECT MAX(OrdenParadaItinerario.[OrdenParada])
FROM OrdenParadaItinerario
WHERE OrdenParadaItinerario.[FK_IDItinerario] = I.[IDItinerario]
) AND P.[FK_NombreCiudad] = 'Fontana';

SELECT Itinerario.[IDItinerario], COALESCE(COUNT(Pasaje.[IDPasaje]), 0) Pasajes,
CAST ( 100 * COALESCE(COUNT(Pasaje.[IDPasaje]), 0) / (SELECT COUNT(*) FROM Pasaje) AS NUMERIC (5, 2) ) Porcentaje
FROM Itinerario
LEFT JOIN Servicio
ON Itinerario.[IDItinerario] = Servicio.[FK_IDItinerario]
LEFT JOIN Pasaje
ON Pasaje.[FK_IDServicio] = Servicio.[IDServicio]
GROUP BY Itinerario.[IDItinerario]
ORDER BY Pasajes DESC;

DELETE FROM Pasaje
WHERE FK_IDServicio IN (
SELECT Servicio.[IDServicio]
FROM Itinerario
INNER JOIN Servicio
ON Servicio.[FK_IDItinerario] = Itinerario.[IDItinerario]
WHERE Itinerario.[IDItinerario] = 3
);

SELECT
Itinerario.[IDItinerario],
Servicio.[IDServicio],
Servicio.[FechaPartidaServicio] FechaPartida,
Servicio.[FechaLlegadaServicio] FechaLlegada,
Servicio.[HoraPartidaServicio] HoraPartida,
Servicio.[HoraLlegadaServicio] HoraLlegada,
Servicio.[TiempoDeViaje],
CASE
WHEN Calidad.[EsAtencionEjecutiva] = 1 THEN 'Ejecutiva'
WHEN Calidad.[EsAtencionEjecutiva] = 0 THEN 'Comun'
ELSE ''
END Atencion,
Categoria.[NombreCategoria] Categoria,
COALESCE(COUNT(Pasaje.[IDPasaje]), 0) Pasajes
FROM Itinerario
FULL JOIN Servicio
ON Servicio.[FK_IDItinerario] = Itinerario.[IDItinerario]
LEFT JOIN Calidad
ON Calidad.[IDCalidad] = Servicio.[FK_IDCalidad]
LEFT JOIN Categoria
ON Categoria.[NombreCategoria] = Calidad.[FK_NombreCategoria]
LEFT JOIN Pasaje
ON Pasaje.[FK_IDServicio] = Servicio.[IDServicio]
GROUP BY
Itinerario.[IDItinerario],
Servicio.[IDServicio],
Servicio.[FechaPartidaServicio],
Servicio.[FechaLlegadaServicio],
Servicio.[HoraPartidaServicio],
Servicio.[HoraLlegadaServicio],
Servicio.[TiempoDeViaje],
CASE
WHEN Calidad.[EsAtencionEjecutiva] = 1 THEN 'Ejecutiva'
WHEN Calidad.[EsAtencionEjecutiva] = 0 THEN 'Comun'
ELSE ''
END,
Categoria.[NombreCategoria]
ORDER BY Itinerario.[IDItinerario];

SELECT P.[FK_NombreCiudad]
FROM Parada P
INNER JOIN OrdenParadaItinerario O
ON P.[NombreParada] = O.[FK_NombreParada]
WHERE O.[OrdenParada] = (
SELECT MAX(OrdenParadaItinerario.[OrdenParada])
FROM Itinerario
INNER JOIN OrdenParadaItinerario
ON OrdenParadaItinerario.[FK_IDItinerario] = Itinerario.[IDItinerario]
GROUP BY IDItinerario
HAVING IDItinerario = 5) AND O.[FK_IDItinerario] = 5;

SELECT P.[FK_NombreCiudad]
FROM Parada P
INNER JOIN OrdenParadaItinerario O
ON P.[NombreParada] = O.[FK_NombreParada]
WHERE O.[OrdenParada] = (
SELECT MIN(OrdenParadaItinerario.[OrdenParada])
FROM Itinerario
INNER JOIN OrdenParadaItinerario
ON OrdenParadaItinerario.[FK_IDItinerario] = Itinerario.[IDItinerario]
WHERE IDItinerario = 5) AND O.[FK_IDItinerario] = 5;

SELECT
Itinerario.[IDItinerario],
Itinerario.[CantidadParadas],
Itinerario.[DistKmItinerario] DistKm,
(
SELECT P.[FK_NombreCiudad]
FROM Parada P
INNER JOIN OrdenParadaItinerario O
ON P.[NombreParada] = O.[FK_NombreParada]
WHERE O.[OrdenParada] = (
SELECT MIN(OrdenParadaItinerario.[OrdenParada])
FROM OrdenParadaItinerario
WHERE OrdenParadaItinerario.[FK_IDItinerario] = Itinerario.[IDItinerario]) AND O.[FK_IDItinerario] = Itinerario.[IDItinerario]
) Origen,
(
SELECT P.[FK_NombreCiudad]
FROM Parada P
INNER JOIN OrdenParadaItinerario O
ON P.[NombreParada] = O.[FK_NombreParada]
WHERE O.[OrdenParada] = (
SELECT MAX(OrdenParadaItinerario.[OrdenParada])
FROM OrdenParadaItinerario
WHERE OrdenParadaItinerario.[FK_IDItinerario] = Itinerario.[IDItinerario]) AND O.[FK_IDItinerario] = Itinerario.[IDItinerario]
) Destino,
Servicio.[IDServicio],
Servicio.[FechaPartidaServicio] FechaPartida,
Servicio.[FechaLlegadaServicio] FechaLlegada,
Servicio.[HoraPartidaServicio] HoraPartida,
Servicio.[HoraLlegadaServicio] HoraLlegada,
Servicio.[TiempoDeViaje],
CASE
WHEN Calidad.[EsAtencionEjecutiva] = 1 THEN 'Ejecutiva'
WHEN Calidad.[EsAtencionEjecutiva] = 0 THEN 'Comun'
ELSE ''
END Atencion,
Categoria.[NombreCategoria] Categoria,
COALESCE(COUNT(Pasaje.[IDPasaje]), 0) Pasajes
FROM Itinerario
FULL JOIN Servicio
ON Servicio.[FK_IDItinerario] = Itinerario.[IDItinerario]
LEFT JOIN Calidad
ON Calidad.[IDCalidad] = Servicio.[FK_IDCalidad]
LEFT JOIN Categoria
ON Categoria.[NombreCategoria] = Calidad.[FK_NombreCategoria]
LEFT JOIN Pasaje
ON Pasaje.[FK_IDServicio] = Servicio.[IDServicio]
GROUP BY
Itinerario.[IDItinerario],
Itinerario.[CantidadParadas],
Itinerario.[DistKmItinerario],
Servicio.[IDServicio],
Servicio.[FechaPartidaServicio],
Servicio.[FechaLlegadaServicio],
Servicio.[HoraPartidaServicio],
Servicio.[HoraLlegadaServicio],
Servicio.[TiempoDeViaje],
CASE
WHEN Calidad.[EsAtencionEjecutiva] = 1 THEN 'Ejecutiva'
WHEN Calidad.[EsAtencionEjecutiva] = 0 THEN 'Comun'
ELSE ''
END,
Categoria.[NombreCategoria]
ORDER BY Itinerario.[IDItinerario];

SELECT COALESCE(COUNT(NombreCiudad), 0) Cantidad FROM Ciudad WHERE NombreCiudad = '';

SELECT Servicio.[FechaPartidaServicio], COALESCE(COUNT(Pasaje.[IDPasaje]), 0) Pasajes
FROM Servicio
LEFT JOIN Pasaje
ON Pasaje.[FK_IDServicio] = Servicio.[IDServicio]
GROUP BY Servicio.[FechaPartidaServicio]
ORDER BY Pasajes DESC;