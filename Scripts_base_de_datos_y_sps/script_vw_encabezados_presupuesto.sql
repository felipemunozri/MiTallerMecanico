USE TALLER_MECANICO

-- creacion de vista para consultar presupuestos
GO
CREATE VIEW vw_encabezados_presupuesto
AS
     SELECT folioEncabezado, 
            fk_rutCliente, 
            fk_patente, 
            fecha,
			observaciones,
			estado,
            iva, 
            total
     FROM encabezado_presupuesto