USE TALLER_MECANICO

-- Procedimiento Almacenado para crear detalle de una orden trabajo en la tabla detalle_orden
GO
CREATE PROCEDURE sp_registrar_detalle_orden @fk_folioOrden INT, 
                                            @fk_idServicio INT, 
                                            @fk_idRepuesto INT,
											@cantidadServicio INT,
											@cantidadRepuesto INT,
											@subTotal         DECIMAL(18, 2)
AS
    BEGIN
        SET NOCOUNT OFF
        IF NOT EXISTS
        (
            SELECT *
            FROM orden_trabajo
            WHERE folioOrden = @fk_folioOrden
        )
            BEGIN
                PRINT 'Error: el folioOrden ingresado no existe en la tabla orden_trabajo'
        END
            ELSE
            BEGIN
                -- si no existe el idServicio pasado al sp lo cambiar� a NULL antes de insertar
                IF NOT EXISTS
                (
                    SELECT *
                    FROM servicio
                    WHERE idServicio = @fk_idServicio
                )
                    BEGIN
                        SET @fk_idServicio = NULL
						SET @cantidadServicio = 0

                        INSERT INTO detalle_orden
                        (fk_folioOrden, 
                         fk_idServicio, 
                         fk_idRepuesto,
						 cantidadServicio,
						 cantidadRepuesto,
						 subTotal
                        )
                        VALUES
                        (@fk_folioOrden, 
                         @fk_idServicio, 
                         @fk_idRepuesto,
						 @cantidadServicio,
						 @cantidadRepuesto,
						 @subTotal
                        )
                END
                -- si no existe el idRepuesto pasado al sp lo cambiar� a NULL antes de insertar
                IF NOT EXISTS
                (
                    SELECT *
                    FROM repuesto
                    WHERE idRepuesto = @fk_idRepuesto
                )
                    BEGIN
                        SET @fk_idRepuesto = NULL
						SET @cantidadRepuesto = 0

                        INSERT INTO detalle_orden
                        (fk_folioOrden, 
                         fk_idServicio, 
                         fk_idRepuesto,
						 cantidadServicio,
						 cantidadRepuesto,
						 subTotal
                        )
                        VALUES
                        (@fk_folioOrden, 
                         @fk_idServicio, 
                         @fk_idRepuesto,
						 @cantidadServicio,
						 @cantidadRepuesto,
						 @subTotal
                        )
                END
                PRINT 'Confirmaci�n: Orden de Trabajo registrada correctamente.'
        END
    END