USE TALLER_MECANICO

-- Procedimiento Almacenado para crear tipo usuario en tabla tipo_usuario
GO
CREATE PROCEDURE sp_registrar_tipo_usuario @cargo VARCHAR(50)
AS
    BEGIN
        SET NOCOUNT OFF
        -- Comprobación de pre-existencia de tipo usuario en tabla tipoUsuario
        IF EXISTS
        (
            SELECT *
            FROM tipo_usuario
            WHERE cargo = @cargo
        )
            BEGIN
                PRINT 'Error: El cargo ingresado ya existe en la tabla.'
        END;
            ELSE
            BEGIN
                INSERT INTO tipo_usuario(cargo)
            VALUES(@cargo)
                PRINT 'Confirmación: Tipo de Usuario creado correctamente.'
        END
    END