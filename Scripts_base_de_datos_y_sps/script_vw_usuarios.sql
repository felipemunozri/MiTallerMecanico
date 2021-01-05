USE TALLER_MECANICO

-- creacion de vista para consultar usuarios
GO
CREATE VIEW vw_usuarios
AS
     SELECT idUsuario, 
            fk_idTipoUsuario, 
            nombreUsuario, 
            passUsuario
     FROM usuario