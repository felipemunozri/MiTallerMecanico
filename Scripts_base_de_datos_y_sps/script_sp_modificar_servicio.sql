USE TALLER_MECANICO

-- Procedimiento Almacenado para modificar servicio en tabla servicio
GO
CREATE PROCEDURE sp_modificar_servicio @idServicio     INT, 
                                       @nombreServicio VARCHAR(200),
									   @valorServicio DECIMAL(18, 2)
AS
    BEGIN
        SET NOCOUNT OFF
        -- Comprobación de pre-existencia de id servicio en tabla servicio
        IF EXISTS
        (
            SELECT *
            FROM servicio
            WHERE idServicio = @idServicio
        )
            BEGIN
                UPDATE servicio
                  SET 
                      nombreServicio = @nombreServicio,
					  valorServicio = @valorServicio
                WHERE idServicio = @idServicio
                PRINT 'Confirmación: Servicio modificado correctamente.'
        END
            ELSE
            BEGIN
                PRINT 'Error: El Servicio ingresado no existe en la tabla.'
        END
    END