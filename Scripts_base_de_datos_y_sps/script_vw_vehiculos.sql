USE TALLER_MECANICO

-- creacion de vista para consultar vehiculos
GO
CREATE VIEW vw_vehiculos
AS
     SELECT patente, 
            fk_rutCliente, 
            tipoVehiculo, 
            marca, 
            modelo, 
            ano, 
            kilometraje
     FROM vehiculo