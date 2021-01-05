USE TALLER_MECANICO

-- creacion de vista para consultar servicios
GO
CREATE VIEW vw_servicios
AS
     SELECT idServicio, 
            nombreServicio,
			valorServicio
     FROM servicio