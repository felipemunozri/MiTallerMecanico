USE TALLER_MECANICO

-- Procedimiento Almacenado para crear repuesto en tabla repuesto
GO
CREATE PROCEDURE sp_registrar_repuesto @nombreRepuesto VARCHAR(100)
AS
    BEGIN
        SET NOCOUNT OFF
        -- Comprobaci�n de pre-existencia de repuesto en tabla repuesto
        IF EXISTS
        (
            SELECT *
            FROM repuesto
            WHERE nombreRepuesto = @nombreRepuesto
        )
            BEGIN
                PRINT 'Error: El repuesto ingresado ya existe en la tabla.'
        END
            ELSE
            BEGIN
                INSERT INTO servicio(nombreServicio)
            VALUES(@nombreRepuesto)
                PRINT 'Confirmaci�n: Repuesto creado correctamente.'
        END
    END