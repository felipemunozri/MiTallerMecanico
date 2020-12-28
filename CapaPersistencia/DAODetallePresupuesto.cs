using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPersistencia
{
    public class DAODetallePresupuesto
    {
        public bool registrarDetPresupuesto(DetallePresupuesto detPresupuesto)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_registrar_detalle_presupuesto", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@fk_folioEncabezado", detPresupuesto.EncabezadoPresupuesto.FolioEncabezado));
                cmd.Parameters.Add(new SqlParameter("@fk_idServicio", detPresupuesto.Servicio.IdServicio));
                cmd.Parameters.Add(new SqlParameter("@fk_idRepuesto", detPresupuesto.Repuesto.IdRepuesto));
                cmd.Parameters.Add(new SqlParameter("@cantidadServicio", detPresupuesto.CantServicio));
                cmd.Parameters.Add(new SqlParameter("@cantidadRepuesto", detPresupuesto.CantRepuesto));
                cmd.Parameters.Add(new SqlParameter("@subTotal", detPresupuesto.SubTotal));

                int aux = cmd.ExecuteNonQuery();

                conectaBD.cerrarConexion();

                if (aux > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return false;
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public bool modificarDetPresupuesto(DetallePresupuesto detPresupuesto)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_modificar_detalle_presupuesto", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@folioDetalle", detPresupuesto.FolioDetalle));
                cmd.Parameters.Add(new SqlParameter("@fk_folioEncabezado", detPresupuesto.EncabezadoPresupuesto.FolioEncabezado));
                cmd.Parameters.Add(new SqlParameter("@fk_idServicio", detPresupuesto.Servicio.IdServicio));
                cmd.Parameters.Add(new SqlParameter("@fk_idRepuesto", detPresupuesto.Repuesto.IdRepuesto));
                cmd.Parameters.Add(new SqlParameter("@cantidadServicio", detPresupuesto.CantServicio));
                cmd.Parameters.Add(new SqlParameter("@cantidadRepuesto", detPresupuesto.CantRepuesto));
                cmd.Parameters.Add(new SqlParameter("@subTotal", detPresupuesto.SubTotal));

                int aux = cmd.ExecuteNonQuery();

                conectaBD.cerrarConexion();

                if (aux > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return false;
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public bool eliminarDetPresupuesto(DetallePresupuesto detPresupuesto)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string queryDelete = "DELETE FROM detalle_presupuesto WHERE folioDetalle = " + detPresupuesto.FolioDetalle;
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(queryDelete, conectaBD.Conexion);

                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand(queryDelete, conectaBD.Conexion);

                int aux = cmd.ExecuteNonQuery();

                conectaBD.cerrarConexion();

                if (aux > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return false;
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public List<DetallePresupuesto> listarTodosLosDetPresupuesto()
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM detalle_presupuesto";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaDetPresupuesto = new DataTable();

                sqlAdaptador.Fill(tablaDetPresupuesto);

                conectaBD.cerrarConexion();

                if (tablaDetPresupuesto.Rows.Count > 0)
                {
                    List<DetallePresupuesto> listaDetPresupuesto = new List<DetallePresupuesto>();

                    for (int i = 0; i < tablaDetPresupuesto.Rows.Count; i++)
                    {
                        DetallePresupuesto detPresupuesto = new DetallePresupuesto();

                        detPresupuesto.FolioDetalle = int.Parse(tablaDetPresupuesto.Rows[i]["folioDetalle"].ToString());
                        detPresupuesto.CantServicio = int.Parse(tablaDetPresupuesto.Rows[i]["cantidadServicio"].ToString());
                        detPresupuesto.CantRepuesto = int.Parse(tablaDetPresupuesto.Rows[i]["cantidadRepuesto"].ToString());

                        DAOEncabezadoPresupuesto daoEncPresupuesto = new DAOEncabezadoPresupuesto();
                        detPresupuesto.EncabezadoPresupuesto = daoEncPresupuesto.buscarEncPresupuestoPorFolio(int.Parse(tablaDetPresupuesto.Rows[i]["fk_folioEncabezado"].ToString()));

                        DAOServicio daoServicio = new DAOServicio();
                        detPresupuesto.Servicio = daoServicio.buscarServicioPorId(int.Parse(tablaDetPresupuesto.Rows[i]["fk_idServicio"].ToString()));

                        DAORepuesto daoRepuesto = new DAORepuesto();
                        detPresupuesto.Repuesto = daoRepuesto.buscarRepuestoPorId(int.Parse(tablaDetPresupuesto.Rows[i]["fk_idRepuesto"].ToString()));

                        listaDetPresupuesto.Add(detPresupuesto);
                    }

                    return listaDetPresupuesto;
                }
                else
                {
                    return new List<DetallePresupuesto>();
                }
            }
            catch (Exception)
            {
                return new List<DetallePresupuesto>();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public DetallePresupuesto buscarDetPresupuestoPorFolioDetalle(int folioDetalle)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM detalle_presupuesto WHERE folioDetalle = " + folioDetalle;
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaDetPresupuesto = new DataTable();

                sqlAdaptador.Fill(tablaDetPresupuesto);

                conectaBD.cerrarConexion();

                if (tablaDetPresupuesto.Rows.Count > 0)
                {
                    DetallePresupuesto detPresupuesto = new DetallePresupuesto();

                    for (int i = 0; i < tablaDetPresupuesto.Rows.Count; i++)
                    {
                        detPresupuesto.FolioDetalle = int.Parse(tablaDetPresupuesto.Rows[i]["folioDetalle"].ToString());
                        detPresupuesto.CantServicio = int.Parse(tablaDetPresupuesto.Rows[i]["cantidadServicio"].ToString());
                        detPresupuesto.CantRepuesto = int.Parse(tablaDetPresupuesto.Rows[i]["cantidadRepuesto"].ToString());

                        DAOEncabezadoPresupuesto daoEncPresupuesto = new DAOEncabezadoPresupuesto();
                        detPresupuesto.EncabezadoPresupuesto = daoEncPresupuesto.buscarEncPresupuestoPorFolio(int.Parse(tablaDetPresupuesto.Rows[i]["fk_folioEncabezado"].ToString()));

                        DAOServicio daoServicio = new DAOServicio();
                        detPresupuesto.Servicio = daoServicio.buscarServicioPorId(int.Parse(tablaDetPresupuesto.Rows[i]["fk_idServicio"].ToString()));

                        DAORepuesto daoRepuesto = new DAORepuesto();
                        detPresupuesto.Repuesto = daoRepuesto.buscarRepuestoPorId(int.Parse(tablaDetPresupuesto.Rows[i]["fk_idRepuesto"].ToString()));
                    }

                    return detPresupuesto;
                }
                else
                {
                    return new DetallePresupuesto();
                }
            }
            catch (Exception)
            {
                return new DetallePresupuesto();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public DataTable tablaServiciosYRepuestosEnDetPresupuestoPorFolioEncabezado(int folioEncabezado)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT fk_idServicio AS 'Codigo', nombreServicio AS " +
                    "'Servicio o Repuesto', CAST((subtotal / cantidadServicio) AS INT) AS " +
                    "'Valor unitario', cantidadServicio AS 'Cantidad', CAST(subTotal AS INT) " +
                    "AS Subtotal FROM detalle_presupuesto AS dt INNER JOIN servicio AS ser ON " +
                    "dt.fk_idServicio = ser.idServicio WHERE fk_folioEncabezado = " + folioEncabezado + " UNION SELECT fk_idRepuesto AS " +
                    "'Codigo', nombreRepuesto AS 'Servicio o Repuesto', CAST((subtotal / cantidadRepuesto) AS INT) " +
                    "AS 'Valor unitario', cantidadRepuesto AS 'Cantidad', CAST(subTotal AS INT) AS Subtotal FROM " +
                    "detalle_presupuesto AS dt INNER JOIN repuesto AS rep ON dt.fk_idRepuesto = rep.idRepuesto " +
                    "WHERE fk_folioEncabezado = " + folioEncabezado;
                //cambiar por sp

                SqlDataAdapter sqlAdpater = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaDetOrden = new DataTable();

                conectaBD.abrirConexion();

                sqlAdpater.Fill(tablaDetOrden);

                conectaBD.cerrarConexion();

                return tablaDetOrden;
            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }
    }
}
