USE TALLER_MECANICO

-- Procedimiento Almacenado para modificar usuario en tabla usuario
GO
CREATE PROCEDURE sp_modificar_usuario @idUsuario        INT, 
                                      @fk_idTipoUsuario INT, 
                                      @nombreUsuario    VARCHAR(50), 
                                      @passUsuario      VARCHAR(50)
AS
    BEGIN
        SET NOCOUNT OFF
        -- Comprobación de pre-existencia de id usuario en tabla usuario
        IF EXISTS
        (
            SELECT *
            FROM usuario
            WHERE idUsuario = @idUsuario
        )
            BEGIN
                UPDATE usuario
                  SET 
                      fk_idTipoUsuario = @fk_idTipoUsuario, 
                      nombreUsuario = @nombreUsuario, 
                      passUsuario = @passUsuario
                WHERE idUsuario = @idUsuario
                PRINT 'Confirmación: Usuario modificado correctamente.'
        END
            ELSE
            BEGIN
                PRINT 'Error: Usuario ingresado no existe en la tabla.'
        END
    END