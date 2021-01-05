USE TALLER_MECANICO

-- Procedimiento Almacenado para crear servicio en tabla servicio
GO
CREATE PROCEDURE sp_registrar_servicio @nombreServicio VARCHAR(200), 
                                       @valorServicio  DECIMAL(18, 2)
AS
    BEGIN
        SET NOCOUNT OFF
        -- Comprobación de pre-existencia de servicio en tabla servicio
        IF EXISTS
        (
            SELECT *
            FROM servicio
            WHERE nombreServicio = @nombreServicio
        )
            BEGIN
                PRINT 'Error: El servicio ingresado ya existe en la tabla.'
        END
            ELSE
            BEGIN
                INSERT INTO servicio
                (nombreServicio, 
                 valorServicio
                )
                VALUES
                (@nombreServicio, 
                 @valorServicio
                )
                PRINT 'Confirmación: Servicio creado correctamente.'
        END
    END