USE TALLER_MECANICO

-- Procedimiento Almacenado para modificar vehiculo en tabla vehiculo
GO
CREATE PROCEDURE sp_modificar_vehiculo @patente       VARCHAR(6), 
                                       @fk_rutCliente VARCHAR(10), 
                                       @tipoVehiculo  VARCHAR(50), 
                                       @marca         VARCHAR(50), 
                                       @modelo        VARCHAR(50), 
                                       @ano           INT, 
                                       @kilometraje   DECIMAL(18, 4)
AS
    BEGIN
        SET NOCOUNT OFF
        -- Comprobación de pre-existencia de patente vehiculo en tabla vehiculo
        IF EXISTS
        (
            SELECT *
            FROM vehiculo
            WHERE patente = @patente
        )
            BEGIN
                UPDATE vehiculo
                  SET 
                      fk_rutCliente = @fk_rutCliente, 
                      tipoVehiculo = @tipoVehiculo, 
                      marca = @marca, 
                      modelo = @modelo, 
                      ano = @ano, 
                      kilometraje = @kilometraje
                WHERE patente = @patente
                PRINT 'Confirmación: Vehiculo modificado correctamente.'
        END
            ELSE
            BEGIN
                PRINT 'Error: Vehiculo ingresado no existe en la tabla.'
        END
    END