USE TALLER_MECANICO

-- Procedimiento Almacenado para eliminar encabezado presupuesto 
-- en la tabla encabezado_presupuesto
GO
CREATE PROCEDURE sp_eliminar_encabezado_presupuesto @folioEncabezado INT
AS
    BEGIN
        SET NOCOUNT OFF
        BEGIN
            DELETE encabezado_presupuesto
            WHERE folioEncabezado = @folioEncabezado

            PRINT 'Confirmación: Presupuesto eliminado correctamente.'
        END
    END