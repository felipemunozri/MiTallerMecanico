USE TALLER_MECANICO

-- Procedimiento Almacenado para modificar encabezado de presupusto en tabla encabezado_presupuesto
GO
CREATE PROCEDURE sp_modificar_encabezado_presupuesto @folioEncabezado INT, 
                                                     @rutCliente      VARCHAR(10), 
                                                     @patente         VARCHAR(6), 
                                                     @fecha           DATE, 
                                                     @iva             DECIMAL(18, 2), 
                                                     @total           DECIMAL(18, 2)
AS
    BEGIN
        UPDATE encabezado_presupuesto
          SET 
              rutCliente = @rutCliente, 
              patente = @patente, 
              fecha = @fecha, 
              iva = @iva, 
              total = @total
        WHERE folioEncabezado = @folioEncabezado
        PRINT 'Confirmación: Presupuesto modificado correctamente.'
    END