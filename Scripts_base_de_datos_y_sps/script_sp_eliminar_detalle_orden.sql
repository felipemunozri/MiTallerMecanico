USE TALLER_MECANICO

-- Procedimiento Almacenado para eliminar el detalle de una orden de trabajo en la tabla detalle_orden
GO
CREATE PROCEDURE sp_eliminar_detalle_orden @fk_folioOrden INT
AS
    BEGIN
        SET NOCOUNT OFF
        BEGIN
            DELETE detalle_orden
            WHERE fk_folioOrden = @fk_folioOrden

            PRINT 'Confirmación: Oden de Trabajo eliminada correctamente.'
        END
    END