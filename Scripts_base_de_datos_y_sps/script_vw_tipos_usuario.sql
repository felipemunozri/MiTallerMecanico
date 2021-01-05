USE TALLER_MECANICO

-- creacion de vista para consultar tipos de usuario
GO
CREATE VIEW vw_tipos_usuario
AS
     SELECT idTipoUsuario, 
            cargo
     FROM tipo_usuario