USE TALLER_MECANICO

GO
CREATE PROCEDURE sp_ver_cliente_por_rut @rutCliente VARCHAR(10)
AS
    BEGIN
        SELECT rutCliente, 
               nombreCliente, 
               apellidoCliente, 
               direccionCliente, 
               telefonoCliente, 
               correoCliente
        FROM cliente
        WHERE rutCliente = @rutCliente
    END