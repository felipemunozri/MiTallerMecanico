USE TALLER_MECANICO

-- Procedimiento Almacenado para crear orden trabajo en la tabla orden_trabajo
GO
CREATE PROCEDURE sp_registrar_orden_trabajo @fk_idUsuario  INT, 
                                           @fk_rutCliente VARCHAR(10), 
                                           @fk_patente    VARCHAR(6), 
                                           @fecha         DATE, 
                                           @fechaEntrega  DATE, 
                                           @prioridad     VARCHAR(50), 
                                           @observaciones VARCHAR(200), 
                                           @estado        VARCHAR(20), 
										   @iva           DECIMAL(18, 2), 
                                           @total         DECIMAL(18, 2), 
                                           @new_identity  INT OUTPUT -- aqui se guarda el id del registro que se va a insertar
AS
    BEGIN
        SET NOCOUNT OFF
        BEGIN
            INSERT INTO orden_trabajo
            (fk_idUsuario, 
             fk_rutCliente, 
             fk_patente, 
             fecha, 
             fechaEntrega, 
             prioridad, 
             observaciones, 
             estado,
			 iva,
			 total
            )
            VALUES
            (@fk_idUsuario, 
             @fk_rutCliente, 
             @fk_patente, 
             @fecha, 
             @fechaEntrega, 
             @prioridad, 
             @observaciones, 
             @estado,
			 @iva,
			 @total
            )
            SET @new_identity = SCOPE_IDENTITY()
            PRINT 'Confirmación: Orden de Trabajo creada correctamente.'
        END
    END