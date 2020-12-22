USE TALLER_MECANICO

-- Procedimiento Almacenado para crear usuario en tabla usuario
GO
CREATE PROCEDURE sp_registrar_usuario @fk_idTipoUsuario INT, 
                                      @nombreUsuario    VARCHAR(50), 
                                      @passUsuario      VARCHAR(50)
AS
    BEGIN
        SET NOCOUNT ON
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
			    -- Comprobación de pre-existencia de tipo usuario en tabla tipoUsuario
                IF NOT EXISTS
                (
                    SELECT idTipoUsuario
                    FROM tipoUsuario
                    WHERE idTipoUsuario = @fk_idTipoUsuario
                )
                    BEGIN
                        PRINT 'Error: El tipo de usuario ingresado no existe.'
                END
                    ELSE
                    BEGIN
                        SET @fk_idTipoUsuario =
                        (
                            SELECT idTipoUsuario
                            FROM tipoUsuario
                            WHERE idTipoUsuario = @fk_idTipoUsuario
                        )
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
    END