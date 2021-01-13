USE TALLER_MECANICO

-- Procedimiento Almacenado para anular una orden trabajo en la tabla orden_trabajo
GO
CREATE PROCEDURE sp_anular_orden_trabajo @folioOrden INT
AS
    BEGIN
        SET NOCOUNT OFF
        BEGIN
            UPDATE orden_trabajo
			SET estado = 'Anulada'
            WHERE folioOrden = @folioOrden;

            PRINT 'Confirmación: Oden de Trabajo anulada correctamente.'
        END
    END