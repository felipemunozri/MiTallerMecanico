USE TALLER_MECANICO

-- creacion de vista para consultar datos de clientes
GO
CREATE VIEW vw_clientes
AS
     SELECT rutCliente, 
            nombreCliente,
            apellidoCliente, 
            direccionCliente, 
            telefonoCliente,
            correoCliente
     FROM cliente