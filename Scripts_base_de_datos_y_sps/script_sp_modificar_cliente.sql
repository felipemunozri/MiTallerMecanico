USE TALLER_MECANICO

-- Procedimiento Almacenado para modificar cliente en tabla cliente
GO
CREATE PROCEDURE sp_modificar_cliente @rutCliente       VARCHAR(10), 
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
                UPDATE cliente
                  SET 
                      nombreCliente = @nombreCliente,
					  apellidoCliente = @apellidoCliente,
					  direccionCliente = @direccionCliente,
					  telefonoCliente = @telefonoCliente,
					  correoCliente = @correoCliente 
                WHERE rutCliente = @rutCliente
                PRINT 'Confirmación: Cliente modificado correctamente.'
        END
            ELSE
            BEGIN
                PRINT 'Error: El rut de cliente ingresado no existe en la tabla.'
        END
    END