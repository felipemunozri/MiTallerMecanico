USE TALLER_MECANICO

-- Procedimiento Almacenado para eliminar orden trabajo y su detalle 
-- en las tablas orden_trabajo y detalle_orden
GO
CREATE PROCEDURE sp_eliminar_orden_trabajo_y_detalle @folioOrden INT
AS
    BEGIN
        SET NOCOUNT OFF
        BEGIN
            -- primero se borra el detalle y luego la orden
            DELETE detalle_orden
            WHERE fk_folioOrden = @folioOrden;

            DELETE orden_trabajo
            WHERE folioOrden = @folioOrden

            PRINT 'Confirmación: Oden de Trabajo eliminada correctamente.'
        END
    END