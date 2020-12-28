USE TALLER_MECANICO

-- Procedimiento Almacenado para crear encabezado presupuesto en la tabla encabezado_presupuesto
GO
CREATE PROCEDURE sp_registrar_encabezado_presupuesto @rutCliente VARCHAR(10), 
                                                     @patente    VARCHAR(6), 
                                                     @fecha         DATE, 
                                                     @iva           DECIMAL(18, 4), 
                                                     @total         DECIMAL(18, 4), 
                                                     @new_identity  INT OUTPUT -- aqui se guarda el id del registro que se va a insertar
AS
    BEGIN
        SET NOCOUNT OFF
        BEGIN
            INSERT INTO encabezado_presupuesto
            (rutCliente, 
             patente, 
             fecha, 
             iva, 
             total
            )
            VALUES
            (@rutCliente, 
             @patente, 
             @fecha, 
             @iva, 
             @total
            )
            SET @new_identity = SCOPE_IDENTITY()
            PRINT 'Confirmación: Preupuesto creado correctamente.'
        END
    END