USE TALLER_MECANICO

-- Procedimiento Almacenado para crear usuario en tabla usuario
GO
CREATE PROCEDURE sp_registrar_usuario @fk_idTipoUsuario INT, 
                                      @nombreUsuario    VARCHAR(50), 
                                      @passUsuario      VARCHAR(50)
AS
    BEGIN
        SET NOCOUNT OFF
        -- Comprobación de pre-existencia de usuario en tabla usuario
        IF EXISTS
        (
            SELECT *
            FROM usuario
            WHERE fk_idTipoUsuario = @fk_idTipoUsuario
                  AND nombreUsuario = @nombreUsuario
                  AND passUsuario = @passUsuario
        )
            BEGIN
                PRINT 'Error: El usuario ingresado ya existe en la tabla.'
        END
            ELSE
            BEGIN
                INSERT INTO usuario
                (fk_idTipoUsuario, 
                 nombreUsuario, 
                 passUsuario
                )
                VALUES
                (@fk_idTipoUsuario, 
                 @nombreUsuario, 
                 @passUsuario
                )
                PRINT 'Confirmación: Usuario creado correctamente.'
        END
    END