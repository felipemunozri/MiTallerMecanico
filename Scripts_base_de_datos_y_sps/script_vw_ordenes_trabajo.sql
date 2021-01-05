USE TALLER_MECANICO

-- creacion de vista para consultar ordenes de trabajo
GO
CREATE VIEW vw_ordenes_trabajo
AS
     SELECT folioOrden, 
            fk_idUsuario, 
            fk_rutCliente, 
            fk_patente, 
            fecha, 
            fechaEntrega, 
            prioridad, 
            observaciones, 
            estado, 
            iva, 
            total
     FROM orden_trabajo