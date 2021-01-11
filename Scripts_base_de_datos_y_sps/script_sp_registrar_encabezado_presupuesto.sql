USE TALLER_MECANICO

-- Procedimiento Almacenado para crear encabezado presupuesto en la tabla encabezado_presupuesto
GO
CREATE PROCEDURE sp_registrar_encabezado_presupuesto @fk_rutCliente VARCHAR(10), 
                                                     @fk_patente    VARCHAR(6), 
                                                     @fecha         DATE, 
													 @observaciones VARCHAR(200),
													 @estado	VARCHAR(20),
                                                     @iva           DECIMAL(18, 2), 
                                                     @total         DECIMAL(18, 2), 
                                                     @new_identity  INT OUTPUT -- aqui se guarda el id del registro que se va a insertar
AS
    BEGIN
        SET NOCOUNT OFF
        BEGIN
            INSERT INTO encabezado_presupuesto
            (fk_rutCliente, 
             fk_patente,
			 observaciones,
			 estado,
             fecha, 
             iva, 
             total
            )
            VALUES
            (@fk_rutCliente, 
             @fk_patente, 
			 @observaciones,
			 @estado,
             @fecha, 
             @iva, 
             @total
            )
            SET @new_identity = SCOPE_IDENTITY()
            PRINT 'Confirmación: Preupuesto creado correctamente.'
        END
    END