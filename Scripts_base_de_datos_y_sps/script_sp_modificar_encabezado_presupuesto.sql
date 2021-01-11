USE TALLER_MECANICO

-- Procedimiento Almacenado para modificar encabezado de presupusto en tabla encabezado_presupuesto
GO
CREATE PROCEDURE sp_modificar_encabezado_presupuesto @folioEncabezado INT, 
                                                     @fk_rutCliente      VARCHAR(10), 
                                                     @fk_patente         VARCHAR(6), 
                                                     @fecha           DATE, 
													 @observaciones		VARCHAR(200),
													 @estado		VARCHAR(50),
                                                     @iva             DECIMAL(18, 2), 
                                                     @total           DECIMAL(18, 2)
AS
    BEGIN
        UPDATE encabezado_presupuesto
          SET 
              fk_rutCliente = @fk_rutCliente, 
              fk_patente = @fk_patente, 
              fecha = @fecha, 
			  observaciones = @observaciones,
			  estado = @estado,
              iva = @iva, 
              total = @total
        WHERE folioEncabezado = @folioEncabezado
        PRINT 'Confirmación: Presupuesto modificado correctamente.'
    END