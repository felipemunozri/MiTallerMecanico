USE TALLER_MECANICO

-- Procedimiento Almacenado para eliminar una orden trabajo en la tabla orden_trabajo
GO
CREATE PROCEDURE sp_eliminar_orden_trabajo @folioOrden INT
AS
    BEGIN
        SET NOCOUNT OFF
        BEGIN
            DELETE orden_trabajo
            WHERE folioOrden = @folioOrden;

            PRINT 'Confirmación: Oden de Trabajo eliminada correctamente.'
        END
    END