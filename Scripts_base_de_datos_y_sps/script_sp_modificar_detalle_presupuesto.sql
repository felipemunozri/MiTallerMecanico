USE TALLER_MECANICO

-- Procedimiento Almacenado para modificar detalle de presupusto en tabla detalle_presupuesto
GO
CREATE PROCEDURE sp_modificar_detalle_presupuesto @fk_folioEncabezado INT, 
                                                  @fk_idServicio      INT, 
                                                  @fk_idRepuesto      INT, 
                                                  @cantidadServicio   INT, 
                                                  @cantidadRepuesto   INT, 
                                                  @subTotal           DECIMAL(18, 2)
AS
	BEGIN
        SET NOCOUNT OFF
        IF NOT EXISTS
        (
            SELECT *
            FROM encabezado_presupuesto
            WHERE folioEncabezado = @fk_folioEncabezado
        )
            BEGIN
                PRINT 'Error: el folioEncabezado ingresado no existe en la tabla encabezado_presupuesto'
        END
            ELSE
            BEGIN
				-- primero se borra el detalle del presupuesto
				DELETE detalle_presupuesto
				WHERE fk_folioEncabezado = @fk_folioEncabezado
				-- ahora se vuelve a insertar
                -- si no existe el idServicio pasado al sp lo cambiará a NULL antes de insertar
                IF NOT EXISTS
                (
                    SELECT *
                    FROM servicio
                    WHERE idServicio = @fk_idServicio
                )
                    BEGIN
                        SET @fk_idServicio = NULL
                        SET @cantidadServicio = 0

                        INSERT INTO detalle_presupuesto
                        (fk_folioEncabezado, 
                         fk_idServicio, 
                         fk_idRepuesto, 
                         cantidadServicio, 
                         cantidadRepuesto, 
                         subTotal
                        )
                        VALUES
                        (@fk_folioEncabezado, 
                         @fk_idServicio, 
                         @fk_idRepuesto, 
                         @cantidadServicio, 
                         @cantidadRepuesto, 
                         @subTotal
                        )
                END
                -- si no existe el idRepuesto pasado al sp lo cambiará a NULL antes de insertar
                IF NOT EXISTS
                (
                    SELECT *
                    FROM repuesto
                    WHERE idRepuesto = @fk_idRepuesto
                )
                    BEGIN
                        SET @fk_idRepuesto = NULL
                        SET @cantidadRepuesto = 0

                        INSERT INTO detalle_presupuesto
                        (fk_folioEncabezado, 
                         fk_idServicio, 
                         fk_idRepuesto, 
                         cantidadServicio, 
                         cantidadRepuesto, 
                         subTotal
                        )
                        VALUES
                        (@fk_folioEncabezado, 
                         @fk_idServicio, 
                         @fk_idRepuesto, 
                         @cantidadServicio, 
                         @cantidadRepuesto, 
                         @subTotal
                        )
                END
                PRINT 'Confirmación: Presupuesto modificado correctamente.'
        END
    END