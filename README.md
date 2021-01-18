# MiTallerMecanico
Proyecto app web en asp.net C# para administración de un Taller Mecánico con conexión a base de datos MS SQL Server.

Permite la creación, consulta y modificación de:

-Presupuestos
-Órdenes de Trabajo
-Clientes
-Vehículos
-Servicios
-Repuestos
-Usuarios del sistema

Además, ofrece la posibilidad de exportar Presupuestos y Órdenes de Trabajo en formato PDF y exportar tablas de consultas en formato Excel.

Cuenta con dos perfiles de acceso, uno para usuario Administrador con acceso a todas las funciones del sistema, y otro para Mecánicos, con acceso limitado a consultas de Presupuestos y Órdenes de Trabajo, así como la actualización del estado de las Órdenes de Trabajo a medida que se realizan las reparaciones de los vehículos ("vehículo ingresado", "en reparación", "listo para retiro", "vehículo entregado").

La interfaz de inicio además cuenta con una sección para Clientes, quienes solamente ingresando su número de Orden de Trabajo (proporcionado por el administrador del taller) y la patente de su vehículo, pueden consultar el estado de avance en la reparación de su vehículo.
