USE TALLER_MECANICO

-- Procedimiento Almacenado para crear vehiculo en tabla vehiculo
GO
ALTER PROCEDURE sp_registrar_vehiculo @patente       VARCHAR(6), 
                                       @fk_rutCliente VARCHAR(10), 
                                       @tipoVehiculo  VARCHAR(50), 
                                       @marca         VARCHAR(50), 
                                       @modelo        VARCHAR(50), 
                                       @ano           INT, 
                                       @kilometraje   DECIMAL(18, 2)
AS
    BEGIN
        SET NOCOUNT OFF
        -- Comprobaci�n de pre-existencia de vehiculo en tabla vehiculo
        IF EXISTS
        (
            SELECT *
            FROM vehiculo
            WHERE patente = @patente
        )
            BEGIN
                PRINT 'Error: El vehiculo ingresado ya existe en la tabla.'
        END
            ELSE
            BEGIN
                INSERT INTO vehiculo
                (patente, 
                 fk_rutCliente, 
                 tipoVehiculo, 
                 marca, 
                 modelo, 
                 ano, 
                 kilometraje
                )
                VALUES
                (@patente, 
                 @fk_rutCliente, 
                 @tipoVehiculo, 
                 @marca, 
                 @modelo, 
                 @ano, 
                 @kilometraje
                )
                PRINT 'Confirmaci�n: Vehiculo creado correctamente.'
        END
    END