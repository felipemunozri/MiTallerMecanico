USE TALLER_MECANICO

-- Procedimiento Almacenado para modificar orden de trabajo en tabla orden_trabajo
GO
CREATE PROCEDURE sp_modificar_orden_trabajo @folioOrden    INT, 
                                            @fk_idUsuario  INT, 
                                            @fk_rutCliente VARCHAR(10), 
                                            @fk_patente    VARCHAR(6), 
                                            @fecha         DATE, 
                                            @fechaEntrega  DATE, 
                                            @prioridad     VARCHAR(50), 
                                            @observaciones VARCHAR(200), 
                                            @estado        VARCHAR(20), 
                                            @iva           DECIMAL(18, 4), 
                                            @total         DECIMAL(18, 4)
AS
    BEGIN
        UPDATE orden_trabajo
          SET 
              fk_idUsuario = @fk_idUsuario, 
              fk_rutCliente = @fk_rutCliente, 
              fk_patente = @fk_patente, 
              fecha = @fecha, 
              fechaEntrega = @fechaEntrega, 
              prioridad = @prioridad, 
              observaciones = @observaciones, 
              estado = @estado, 
              iva = @iva, 
              total = @total
        WHERE folioOrden = @folioOrden
        PRINT 'Confirmación: Orden de Trabajo modificada correctamente.'
    END