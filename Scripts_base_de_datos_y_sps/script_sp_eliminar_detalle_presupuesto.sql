USE TALLER_MECANICO

-- Procedimiento Almacenado para eliminar detalle presupuesto 
-- en la tabla detalle_presupuesto
GO
CREATE PROCEDURE sp_eliminar_detalle_presupuesto @fk_folioEncabezado INT
AS
    BEGIN
        SET NOCOUNT OFF
        BEGIN
            DELETE detalle_presupuesto
            WHERE fk_folioEncabezado = @fk_folioEncabezado;

            PRINT 'Confirmación: Presupuesto eliminado correctamente.'
        END
    END