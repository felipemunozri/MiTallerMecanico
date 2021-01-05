USE TALLER_MECANICO

-- creacion de vista para consultar presupuestos
GO
CREATE VIEW vw_encabezados_presupuesto
AS
     SELECT folioEncabezado, 
            rutCliente, 
            patente, 
            fecha, 
            iva, 
            total
     FROM encabezado_presupuesto