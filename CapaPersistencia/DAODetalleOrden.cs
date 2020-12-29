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
    public class DAODetalleOrden
    {
        public bool registrarDetOrden(DetalleOrden detOrden)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_registrar_detalle_orden", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add(new SqlParameter("@fk_folioOrden", detOrden.OrdenTrabajo.FolioOrden));
                cmd.Parameters.Add(new SqlParameter("@fk_idServicio", detOrden.Servicio.IdServicio));
                cmd.Parameters.Add(new SqlParameter("@fk_idRepuesto", detOrden.Repuesto.IdRepuesto));
                cmd.Parameters.Add(new SqlParameter("@cantidadServicio", detOrden.CantServicio));
                cmd.Parameters.Add(new SqlParameter("@cantidadRepuesto", detOrden.CantRepuesto));
                cmd.Parameters.Add(new SqlParameter("@subTotal", detOrden.SubTotal));

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

        //public bool modificarDetOrden(DetalleOrden detOrden)
        //{
        //    ConexionBD conectaBD = new ConexionBD();

        //    try
        //    {
        //        conectaBD.abrirConexion();

        //        SqlCommand cmd = new SqlCommand("sp_modificar_detalle_orden", conectaBD.Conexion);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add(new SqlParameter("@fk_folioOrden", detOrden.OrdenTrabajo.FolioOrden));
        //        cmd.Parameters.Add(new SqlParameter("@fk_idServicio", detOrden.Servicio.IdServicio));
        //        cmd.Parameters.Add(new SqlParameter("@fk_idRepuesto", detOrden.Repuesto.IdRepuesto));
        //        cmd.Parameters.Add(new SqlParameter("@cantidadServicio", detOrden.CantServicio));
        //        cmd.Parameters.Add(new SqlParameter("@cantidadRepuesto", detOrden.CantRepuesto));
        //        cmd.Parameters.Add(new SqlParameter("@subTotal", detOrden.SubTotal));

        //        int aux = cmd.ExecuteNonQuery();

        //        conectaBD.cerrarConexion();

        //        if (aux > 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        string err = ex.Message;
        //        return false;
        //    }
        //    finally
        //    {
        //        conectaBD.cerrarConexion();
        //    }
        //}

        public bool eliminarDetOrden(OrdenTrabajo ordenTrabajo)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_eliminar_detalle_orden", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@fk_folioOrden", ordenTrabajo.FolioOrden));

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

        public List<DetalleOrden> listarTodosLosDetOrden()
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM detalle_orden";
                //cambiar por sp o vista

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaDetOrden = new DataTable();

                sqlAdaptador.Fill(tablaDetOrden);

                conectaBD.cerrarConexion();

                if (tablaDetOrden.Rows.Count > 0)
                {
                    List<DetalleOrden> listaDetOrden = new List<DetalleOrden>();

                    for (int i = 0; i < tablaDetOrden.Rows.Count; i++)
                    {
                        DetalleOrden detOrden = new DetalleOrden();

                        detOrden.FolioDetalleOrden = int.Parse(tablaDetOrden.Rows[i]["folioDetalleOrden"].ToString());
                        detOrden.CantServicio = int.Parse(tablaDetOrden.Rows[i]["cantidadServicio"].ToString());
                        detOrden.CantRepuesto = int.Parse(tablaDetOrden.Rows[i]["cantidadRepuesto"].ToString());

                        DAOOrdenTrabajo daoOrdenTrabajo = new DAOOrdenTrabajo();
                        detOrden.OrdenTrabajo = daoOrdenTrabajo.buscarOrdenTrabajoPorFolio(int.Parse(tablaDetOrden.Rows[i]["fk_folioOrden"].ToString()));

                        DAOServicio daoServicio = new DAOServicio();
                        detOrden.Servicio = daoServicio.buscarServicioPorId(int.Parse(tablaDetOrden.Rows[i]["fk_idServicio"].ToString()));

                        DAORepuesto daoRepuesto = new DAORepuesto();
                        detOrden.Repuesto = daoRepuesto.buscarRepuestoPorId(int.Parse(tablaDetOrden.Rows[i]["fk_idRepuesto"].ToString()));

                        listaDetOrden.Add(detOrden);
                    }

                    return listaDetOrden;
                }
                else
                {
                    return new List<DetalleOrden>();
                }

            }
            catch (Exception)
            {
                return new List<DetalleOrden>();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public DetalleOrden buscarDetOrdenPorFolioOrdenTrabajo(int folioOrden)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM detalle_orden WHERE fk_folioOrden = " + folioOrden;
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaDetOrden = new DataTable();

                sqlAdaptador.Fill(tablaDetOrden);

                conectaBD.cerrarConexion();

                if (tablaDetOrden.Rows.Count > 0)
                {
                    DetalleOrden detOrden = new DetalleOrden();

                    for (int i = 0; i < tablaDetOrden.Rows.Count; i++)
                    {
                        detOrden.FolioDetalleOrden = int.Parse(tablaDetOrden.Rows[i]["folioDetalleOrden"].ToString());
                        detOrden.CantServicio = int.Parse(tablaDetOrden.Rows[i]["cantidadServicio"].ToString());
                        detOrden.CantRepuesto = int.Parse(tablaDetOrden.Rows[i]["cantidadRepuesto"].ToString());

                        DAOOrdenTrabajo daoOrdenTrabajo = new DAOOrdenTrabajo();
                        detOrden.OrdenTrabajo = daoOrdenTrabajo.buscarOrdenTrabajoPorFolio(int.Parse(tablaDetOrden.Rows[i]["fk_folioOrden"].ToString()));

                        DAOServicio daoServicio = new DAOServicio();
                        detOrden.Servicio = daoServicio.buscarServicioPorId(int.Parse(tablaDetOrden.Rows[i]["fk_idServicio"].ToString()));

                        DAORepuesto daoRepuesto = new DAORepuesto();
                        detOrden.Repuesto = daoRepuesto.buscarRepuestoPorId(int.Parse(tablaDetOrden.Rows[i]["fk_idRepuesto"].ToString()));
                    }

                    return detOrden;
                }
                else
                {
                    return new DetalleOrden();
                }
            }
            catch (Exception)
            {
                return new DetalleOrden();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public DataTable tablaServiciosYRepuestosEnDetOrdenPorFolioOrdenTrabajo(int folioOrden)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT fk_idServicio AS 'Codigo', nombreServicio AS " +
                    "'Servicio o Repuesto', CAST((subtotal / cantidadServicio) AS INT) AS " +
                    "'Valor unitario', cantidadServicio AS 'Cantidad', CAST(subTotal AS INT) " +
                    "AS Subtotal FROM detalle_orden AS dt INNER JOIN servicio AS ser ON " +
                    "dt.fk_idServicio = ser.idServicio WHERE fk_folioOrden = " + folioOrden + " UNION SELECT fk_idRepuesto AS " +
                    "'Codigo', nombreRepuesto AS 'Servicio o Repuesto', CAST((subtotal / cantidadRepuesto) AS INT) " +
                    "AS 'Valor unitario', cantidadRepuesto AS 'Cantidad', CAST(subTotal AS INT) AS Subtotal FROM " +
                    "detalle_orden AS dt INNER JOIN repuesto AS rep ON dt.fk_idRepuesto = rep.idRepuesto " +
                    "WHERE fk_folioOrden = " + folioOrden;
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
