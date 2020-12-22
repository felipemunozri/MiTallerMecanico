USE TALLER_MECANICO

-- Procedimiento Almacenado para eliminar encabezado y detalle presupuesto 
-- en las tablas encabezado_presupuesto y detalle_presupuesto
GO
CREATE PROCEDURE sp_eliminar_encabezado_y_detalle_presupuesto @folioEncabezado INT
AS
    BEGIN
        SET NOCOUNT OFF
        BEGIN
            -- primero se borra el detalle y luego el encabezado
            DELETE detalle_presupuesto
            WHERE fk_folioEncabezado = @folioEncabezado;

            DELETE encabezado_presupuesto
            WHERE folioEncabezado = @folioEncabezado

            PRINT 'Confirmación: Presupuesto eliminado correctamente.'
        END
    END