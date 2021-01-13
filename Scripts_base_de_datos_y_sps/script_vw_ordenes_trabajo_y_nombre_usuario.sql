USE TALLER_MECANICO

-- creacion de vista para consultar ordenes de trabajo y mostrar nombre de usuario
GO
CREATE VIEW vw_ordenes_trabajo_y_nombre_usuario
AS
     SELECT folioOrden, 
            nombreUsuario, 
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
          INNER JOIN usuario ON orden_trabajo.fk_idUsuario = usuario.idUsuario