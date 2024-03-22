USE ViajesTPI;

-- DROP TABLE Usuario
DROP TABLE IF EXISTS Usuario;

-- DROP TABLE Ciudad
DROP TABLE IF EXISTS Ciudad;

-- DROP TABLE Parada
DROP TABLE IF EXISTS Parada;

-- DROP TABLE Itinerario
DROP TABLE IF EXISTS Itinerario;

-- DROP TABLE OrdenParadaItinerario
DROP TABLE IF EXISTS OrdenParadaItinerario;

-- DROP TABLE Categoria
DROP TABLE IF EXISTS Categoria;

-- DROP TABLE UnidadTransporte
DROP TABLE IF EXISTS UnidadTransporte;

-- DROP TABLE Calidad
DROP TABLE IF EXISTS Calidad;

-- DROP TABLE Costo
DROP TABLE IF EXISTS Costo;

-- DROP TABLE Servicio
DROP TABLE IF EXISTS Servicio;

-- DROP TABLE DemandaServicio
DROP TABLE IF EXISTS DemandaServicio;

-- DROP TABLE Pasaje
DROP TABLE IF EXISTS Pasaje;

-- DROP PROCEDURE EliminarPasajesNoAbonados
DROP PROCEDURE IF EXISTS EliminarPasajesNoAbonados;

-- DROP TRIGGER ActualizarCostoPasaje
DROP TRIGGER IF EXISTS ActualizarCostoPasaje;

-- DROP TRIGGER SumarAsientoPasaje
DROP TRIGGER IF EXISTS SumarAsientoPasaje;

-- DROP TRIGGER DescuentoAsientoPasaje
DROP TRIGGER IF EXISTS DescuentoAsientoPasaje;

-- DROP TRIGGER ActualizarAsientosDisponibles
DROP TRIGGER IF EXISTS ActualizarAsientosDisponibles;