CREATE DATABASE [TALLER_MECANICO]

USE [TALLER_MECANICO]

CREATE TABLE [dbo].[cliente](
	[rutCliente] [varchar](10) PRIMARY KEY NOT NULL,
	[nombreCliente] [varchar](35) NULL,
	[apellidoCliente] [varchar](35) NULL,
	[direccionCliente] [varchar](100) NULL,
	[telefonoCliente] [int] NULL,
	[correoCliente] [varchar](50) NULL
)

CREATE TABLE [dbo].[detalle_orden](
	[folioDetalleOrden] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[fk_folioOrden] [int] NULL,
	[fk_idServicio] [int] NULL,
	[fk_idRepuesto] [int] NULL,
	[cantidadServicio] [int] NULL,
	[cantidadRepuesto] [int] NULL,
	[subTotal] [decimal](18, 2) NULL
)

CREATE TABLE [dbo].[detalle_presupuesto](
	[folioDetalle] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[fk_folioEncabezado] [int] NULL,
	[fk_idServicio] [int] NULL,
	[fk_idRepuesto] [int] NULL,
	[cantidadServicio] [int] NULL,
	[cantidadRepuesto] [int] NULL,
	[subTotal] [decimal](18, 2) NULL
)

CREATE TABLE [dbo].[encabezado_presupuesto](
	[folioEncabezado] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[fk_rutCliente] [varchar](10) NULL,
	[fk_patente] [varchar](6) NULL,
	[fecha] [date] NULL,
	[observaciones] [varchar](200) NULL,
	[estado] [varchar](20) NULL,
	[iva] [decimal](18, 2) NULL,
	[total] [decimal](18, 2) NULL
)

CREATE TABLE [dbo].[orden_trabajo](
	[folioOrden] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[fk_idUsuario] [int] NULL,
	[fk_rutCliente] [varchar](10) NULL,
	[fk_patente] [varchar](6) NULL,
	[fecha] [date] NULL,
	[fechaEntrega] [date] NULL,
	[prioridad] [varchar](50) NULL,
	[observaciones] [varchar](200) NULL,
	[estado] [varchar](20) NULL,
	[iva] [decimal](18, 2) NULL,
	[total] [decimal](18, 2) NULL
)

CREATE TABLE [dbo].[repuesto](
	[idRepuesto] [int] PRIMARY KEY IDENTITY(10000,1) NOT NULL,
	[nombreRepuesto] [varchar](100) NULL,
)

CREATE TABLE [dbo].[servicio](
	[idServicio] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[nombreServicio] [varchar](200) NULL,
	[valorServicio] [decimal](18, 2) NULL
)

CREATE TABLE [dbo].[tipo_usuario](
	[idTipoUsuario] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[cargo] [varchar](50) NULL
)

CREATE TABLE [dbo].[usuario](
	[idUsuario] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[fk_idTipoUsuario] [int] NULL,
	[nombreUsuario] [varchar](50) NULL,
	[passUsuario] [varchar](50) NULL
)

CREATE TABLE [dbo].[vehiculo](
	[patente] [varchar](6) PRIMARY KEY NOT NULL,
	[fk_rutCliente] [varchar](10) NULL,
	[tipoVehiculo] [varchar](50) NULL,
	[marca] [varchar](50) NULL,
	[modelo] [varchar](50) NULL,
	[ano] [int] NULL,
	[kilometraje] [decimal](18, 2) NULL
)

ALTER TABLE [dbo].[detalle_orden]  WITH CHECK ADD FOREIGN KEY([fk_folioOrden])
REFERENCES [dbo].[orden_trabajo] ([folioOrden])
GO
ALTER TABLE [dbo].[detalle_orden]  WITH CHECK ADD FOREIGN KEY([fk_idServicio])
REFERENCES [dbo].[servicio] ([idServicio])
GO
ALTER TABLE [dbo].[detalle_orden]  WITH CHECK ADD FOREIGN KEY([fk_idRepuesto])
REFERENCES [dbo].[repuesto] ([idRepuesto])
GO
ALTER TABLE [dbo].[detalle_presupuesto]  WITH CHECK ADD FOREIGN KEY([fk_folioEncabezado])
REFERENCES [dbo].[encabezado_presupuesto] ([folioEncabezado])
GO
ALTER TABLE [dbo].[detalle_presupuesto]  WITH CHECK ADD FOREIGN KEY([fk_idservicio])
REFERENCES [dbo].[servicio] ([idServicio])
GO
ALTER TABLE [dbo].[detalle_presupuesto]  WITH CHECK ADD FOREIGN KEY([fk_idRepuesto])
REFERENCES [dbo].[repuesto] ([idRepuesto])
GO
ALTER TABLE [dbo].[encabezado_presupuesto]  WITH CHECK ADD FOREIGN KEY([fk_rutCliente])
REFERENCES [dbo].[cliente] ([rutCliente])
GO
ALTER TABLE [dbo].[encabezado_presupuesto]  WITH CHECK ADD FOREIGN KEY([fk_patente])
REFERENCES [dbo].[vehiculo] ([patente])
GO
ALTER TABLE [dbo].[orden_trabajo]  WITH CHECK ADD FOREIGN KEY([fk_idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[orden_trabajo]  WITH CHECK ADD FOREIGN KEY([fk_rutCliente])
REFERENCES [dbo].[cliente] ([rutCliente])
GO
ALTER TABLE [dbo].[orden_trabajo]  WITH CHECK ADD FOREIGN KEY([fk_patente])
REFERENCES [dbo].[vehiculo] ([patente])
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD FOREIGN KEY([fk_idTipoUsuario])
REFERENCES [dbo].[tipo_usuario] ([idTipoUsuario])
GO
ALTER TABLE [dbo].[vehiculo]  WITH CHECK ADD FOREIGN KEY([fk_rutCliente])
REFERENCES [dbo].[cliente] ([rutCliente])
GO
ALTER TABLE [dbo].[usuario] ADD UNIQUE ([nombreUsuario])
GO
ALTER TABLE [dbo].[usuario] ADD UNIQUE ([passUsuario])
GO
ALTER TABLE [dbo].[servicio] ADD UNIQUE ([nombreServicio])
GO
ALTER TABLE [dbo].[repuesto] ADD UNIQUE ([nombreRepuesto])

/***************** INGRESO DE DATOS *****************/

INSERT tipo_usuario VALUES ('ADMINISTRADOR')
INSERT tipo_usuario VALUES ('MECANICO')

INSERT usuario VALUES (1, 'FELIPE', '123')
INSERT usuario VALUES (1, 'ROBERTO', '456')
INSERT usuario VALUES (1, 'NICOLAS', '789')
INSERT usuario VALUES (2, 'JUAN', '741') --mecanico

INSERT servicio VALUES ('Mantención por Kilometraje', 15000)
INSERT servicio VALUES ('Ajuste de Motor', 60000)
INSERT servicio VALUES ('Reparación Diferenciales', 45000)
INSERT servicio VALUES ('Cambio de Aceite', 8000)
INSERT servicio VALUES ('Electricidad', 15000)
INSERT servicio VALUES ('Reparación Caja Mecánica', 35000)
INSERT servicio VALUES ('Reparación Caja Automática', 70000)
INSERT servicio VALUES ('Frenos - Cambio de Pastillas', 12000)
INSERT servicio VALUES ('Frenos - Embalatado', 15000)
INSERT servicio VALUES ('Frenos - Rectificado de Disco', 12000)
INSERT servicio VALUES ('Scanner', 12000)
INSERT servicio VALUES ('Pintura', 35000)
INSERT servicio VALUES ('Tren Delantero', 35000)
INSERT servicio VALUES ('Alineamiento', 10000)
INSERT servicio VALUES ('Embrague - Cambio de Kit', 35000)
INSERT servicio VALUES ('Embrague - Disco Prensa', 18000)
INSERT servicio VALUES ('Embrague - Rodamientos', 10000)

INSERT repuesto VALUES ('Neumático')
INSERT repuesto VALUES ('Batería')
INSERT repuesto VALUES ('Lubricante')
INSERT repuesto VALUES ('Crucetas de Cardan')
INSERT repuesto VALUES ('Soporte Cardan')
INSERT repuesto VALUES ('Rodamiento de Empuje')
INSERT repuesto VALUES ('Cilindro de Embrague')
INSERT repuesto VALUES ('Disco de Embrague')
INSERT repuesto VALUES ('Piola de Embrague')
INSERT repuesto VALUES ('Bomba de Embrague')
INSERT repuesto VALUES ('Horquilla de Embrague')
INSERT repuesto VALUES ('Punta de Homocinetica')
INSERT repuesto VALUES ('Rodamiento Caja de Cambio')
INSERT repuesto VALUES ('Piola Selector de Cambios')
INSERT repuesto VALUES ('Kit de Embrague')
INSERT repuesto VALUES ('Piola de Velocímetro')
INSERT repuesto VALUES ('Anillos de Motor')
INSERT repuesto VALUES ('Guia de Valvula')
INSERT repuesto VALUES ('Empaquetadura Tapa de Valvulas')
INSERT repuesto VALUES ('Empaquetadora de Culata')
INSERT repuesto VALUES ('Empaquetadura de Carter')
INSERT repuesto VALUES ('Empaquetadura Multiple de Admisión')
INSERT repuesto VALUES ('Empaquetadura de Escape')
INSERT repuesto VALUES ('Juego Empaquetadura Motor')
INSERT repuesto VALUES ('Pistones')
INSERT repuesto VALUES ('Metales Axiales')
INSERT repuesto VALUES ('Reten Eje de Levas')
INSERT repuesto VALUES ('Soporte Motor')
INSERT repuesto VALUES ('Reten de Cigueñal')
INSERT repuesto VALUES ('Retenes de Valvula')
INSERT repuesto VALUES ('Valculas de Motor')
INSERT repuesto VALUES ('Metales de Biela')
INSERT repuesto VALUES ('Metales de Bancada')
INSERT repuesto VALUES ('Taque')
INSERT repuesto VALUES ('Empaquetadura Salida de Escape')
INSERT repuesto VALUES ('Turbo')
INSERT repuesto VALUES ('Cigueñal')
INSERT repuesto VALUES ('Eje de Leva')
INSERT repuesto VALUES ('Culata')
INSERT repuesto VALUES ('Biela de Motor')
INSERT repuesto VALUES ('Cadena Bomba Inyectora')
INSERT repuesto VALUES ('Chaveta Cigueñal')
INSERT repuesto VALUES ('Eje Balancín')
INSERT repuesto VALUES ('Pistones')
INSERT repuesto VALUES ('Metales Axiales')
INSERT repuesto VALUES ('Reten Eje de Levas')
INSERT repuesto VALUES ('Soporte Motor')
INSERT repuesto VALUES ('Reten de Cigueñal')
INSERT repuesto VALUES ('Retenes de Valvula')
INSERT repuesto VALUES ('Valculas de Motor')
INSERT repuesto VALUES ('Metales de Biela')
INSERT repuesto VALUES ('Metales de Bancada')
INSERT repuesto VALUES ('Juego Bujes de Biela')
INSERT repuesto VALUES ('Juego Camisa Motor')
INSERT repuesto VALUES ('Juego de Metales Compensador')
INSERT repuesto VALUES ('Juego Torre Eje de Leva')
INSERT repuesto VALUES ('Pasador Piston')
INSERT repuesto VALUES ('Perno Biela')
INSERT repuesto VALUES ('Perno Culata')
INSERT repuesto VALUES ('Platillo Resorte de Valvulas')
INSERT repuesto VALUES ('Resorte de Valvula')
INSERT repuesto VALUES ('Seguro Valvula de Motor')
INSERT repuesto VALUES ('Tornillo Balancin')
INSERT repuesto VALUES ('Balancin')
INSERT repuesto VALUES ('Perno Polea Cigueñal')
INSERT repuesto VALUES ('Piñon Bomba de Aceite')
INSERT repuesto VALUES ('Tapa Aceite')
INSERT repuesto VALUES ('Pastillas de Freno Trasero')
INSERT repuesto VALUES ('Pastillas de Freno Delantero')
INSERT repuesto VALUES ('Balatas Traseras')
INSERT repuesto VALUES ('Bomba de Freno')
INSERT repuesto VALUES ('Tambores de Freno Trasero')
INSERT repuesto VALUES ('Disco de Freno Trasero')
INSERT repuesto VALUES ('Disco de Freno Delantero')

INSERT cliente VALUES ('17248124-8', 'Felipe', 'Munoz', 'Avenida Nosellama 123', 994042289, 'felipemunoz@gmail.com')

INSERT vehiculo VALUES ('PX1234', '17248124-8', 'AUTO', 'TOYOTA', 'TERCEL', 2004, 2500)


SELECT * FROM tipo_usuario

SELECT * FROM usuario

SELECT * FROM orden_trabajo

SELECT * FROM detalle_orden

SELECT * FROM encabezado_presupuesto

SELECT * FROM detalle_presupuesto

SELECT * FROM servicio	

SELECT * FROM repuesto

SELECT * FROM cliente

SELECT * FROM vehiculo


--DELETE FROM orden_trabajo

--DBCC CHECKIDENT ('detalle_presupuesto', RESEED, 0);
--GO
