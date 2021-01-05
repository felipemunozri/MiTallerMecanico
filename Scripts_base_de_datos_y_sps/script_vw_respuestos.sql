USE TALLER_MECANICO

-- creacion de vista para consultar repuestos
GO
CREATE VIEW vw_repuestos
AS
     SELECT idRepuesto, 
            nombreRepuesto
     FROM repuesto