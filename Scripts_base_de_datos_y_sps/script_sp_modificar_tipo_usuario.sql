USE TALLER_MECANICO

-- Procedimiento Almacenado para modificar tipo de usuario en tabla tipoUsuario
GO
CREATE PROCEDURE sp_modificar_tipo_usuario @idTipoUsuario INT, 
                                           @cargo         VARCHAR(50)
AS
    BEGIN
        SET NOCOUNT OFF
        -- Comprobación de pre-existencia de id tipo de usuario en tabla tipoUsuario
        IF EXISTS
        (
            SELECT *
            FROM tipoUsuario
            WHERE idTipoUsuario = idTipoUsuario
        )
            BEGIN
                UPDATE tipoUsuario
                  SET 
                      cargo = @cargo
                WHERE idTipoUsuario = idTipoUsuario
                PRINT 'Confirmación: Tipo de Usuario modificado correctamente.'
        END
            ELSE
            BEGIN
                PRINT 'Error: El Tipo de Usuario ingresado no existe en la tabla.'
        END
    END