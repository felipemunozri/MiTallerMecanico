USE TALLER_MECANICO

-- Procedimiento Almacenado para crear cliente en tabla cliente
GO
CREATE PROCEDURE sp_registrar_cliente @rutCliente       VARCHAR(10), 
                                      @nombreCliente    VARCHAR(35), 
                                      @apellidoCliente  VARCHAR(35), 
                                      @direccionCliente VARCHAR(100), 
                                      @telefonoCliente  INT, 
                                      @correoCliente    VARCHAR(50)
AS
    BEGIN
        SET NOCOUNT OFF
        -- Comprobación de pre-existencia de rut cliente en tabla cliente
        IF EXISTS
        (
            SELECT *
            FROM cliente
            WHERE rutCliente = @rutCliente
        )
            BEGIN
                PRINT 'Error: El rut de cliente ingresado ya existe en la tabla.'
        END
            ELSE
            BEGIN
                INSERT INTO cliente
                (rutCliente, 
                 nombreCliente, 
                 apellidoCliente, 
                 direccionCliente, 
                 telefonoCliente, 
                 correoCliente
                )
                VALUES
                (@rutCliente, 
                 @nombreCliente, 
                 @apellidoCliente, 
                 @direccionCliente, 
                 @telefonoCliente, 
                 @correoCliente
                )
                PRINT 'Confirmación: Cliente creado correctamente.'
        END
    END