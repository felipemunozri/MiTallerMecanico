using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPersistencia
{
    public class DAOOrdenTrabajo
    {
        public bool registrarOrdenTrabajo(OrdenTrabajo ordenTrabajo, out int id)
        {
            ConexionBD conectaBD = new ConexionBD();
            id = 0;

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_registrar_orden_trabajo", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@fk_idUsuario", ordenTrabajo.Encargado.IdUsuario));
                cmd.Parameters.Add(new SqlParameter("@fk_rutCliente", ordenTrabajo.Cliente.RutCliente));
                cmd.Parameters.Add(new SqlParameter("@fk_patente", ordenTrabajo.Vehiculo.Patente));
                cmd.Parameters.Add(new SqlParameter("@fecha", ordenTrabajo.Fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));
                cmd.Parameters.Add(new SqlParameter("@fechaEntrega", ordenTrabajo.FechaEntrega.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));
                cmd.Parameters.Add(new SqlParameter("@prioridad", ordenTrabajo.Prioridad));
                cmd.Parameters.Add(new SqlParameter("@observaciones", ordenTrabajo.Observaciones));
                cmd.Parameters.Add(new SqlParameter("@estado", ordenTrabajo.Estado));
                cmd.Parameters.Add("@new_identity", SqlDbType.Int).Direction = ParameterDirection.Output;

                int aux = cmd.ExecuteNonQuery();

                id = (int)(cmd.Parameters["@new_identity"].Value);

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

        public bool modificarOrdenTrabajo(OrdenTrabajo ordenTrabajo)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_modificar_orden_trabajo", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@idUsuario", ordenTrabajo.FolioOrden));
                cmd.Parameters.Add(new SqlParameter("@fk_idUsuario", ordenTrabajo.Encargado.IdUsuario));
                cmd.Parameters.Add(new SqlParameter("@fk_rutCliente", ordenTrabajo.Cliente.RutCliente));
                cmd.Parameters.Add(new SqlParameter("@fk_patente", ordenTrabajo.Vehiculo.Patente));
                cmd.Parameters.Add(new SqlParameter("@fecha", ordenTrabajo.Fecha));
                cmd.Parameters.Add(new SqlParameter("@prioridad", ordenTrabajo.FechaEntrega));
                cmd.Parameters.Add(new SqlParameter("@observaciones", ordenTrabajo.Observaciones));
                cmd.Parameters.Add(new SqlParameter("@estado", ordenTrabajo.Estado));
                cmd.Parameters.Add(new SqlParameter("@observaciones", ordenTrabajo.Observaciones));

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

        public bool eliminarOrdenTrabajo(OrdenTrabajo ordenTrabajo)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_eliminar_orden_trabajo_y_detalle", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@folioOrden", ordenTrabajo.FolioOrden));

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

        public List<OrdenTrabajo> listarTodasLasOrdenesDeTrabajo()
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM orden_trabajo";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaOrdenesTrabajo = new DataTable();

                sqlAdaptador.Fill(tablaOrdenesTrabajo);

                conectaBD.cerrarConexion();

                if (tablaOrdenesTrabajo.Rows.Count > 0)
                {
                    List<OrdenTrabajo> listaOrdenesTrabajo = new List<OrdenTrabajo>();

                    for (int i = 0; i < tablaOrdenesTrabajo.Rows.Count; i++)
                    {
                        OrdenTrabajo ordenTrabajo = new OrdenTrabajo();

                        ordenTrabajo.FolioOrden = int.Parse(tablaOrdenesTrabajo.Rows[i]["folioOrden"].ToString());
                        ordenTrabajo.Fecha = DateTime.Parse(tablaOrdenesTrabajo.Rows[i]["fecha"].ToString());
                        ordenTrabajo.FechaEntrega = DateTime.Parse(tablaOrdenesTrabajo.Rows[i]["fechaEntrega"].ToString());
                        ordenTrabajo.Prioridad = tablaOrdenesTrabajo.Rows[i]["prioridad"].ToString();
                        ordenTrabajo.Observaciones = tablaOrdenesTrabajo.Rows[i]["observaciones"].ToString();
                        ordenTrabajo.Estado = tablaOrdenesTrabajo.Rows[i]["estado"].ToString();

                        DAOUsuario daoUsuario = new DAOUsuario();
                        ordenTrabajo.Encargado = daoUsuario.buscarUsuarioPorId(int.Parse(tablaOrdenesTrabajo.Rows[i]["fk_idUsuario"].ToString()));

                        DAOVehiculo daoVehiculo = new DAOVehiculo();
                        ordenTrabajo.Vehiculo = daoVehiculo.buscarVehiculoPorPatente(tablaOrdenesTrabajo.Rows[i]["fk_patente"].ToString());

                        listaOrdenesTrabajo.Add(ordenTrabajo);
                    }

                    return listaOrdenesTrabajo;
                }
                else
                {
                    return new List<OrdenTrabajo>();
                }
            }
            catch (Exception)
            {
                return new List<OrdenTrabajo>();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public DataTable tablaTodasLasOrdenesDeTrabajo()
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM orden_trabajo";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaOrdenesTrabajo = new DataTable();

                sqlAdaptador.Fill(tablaOrdenesTrabajo);

                conectaBD.cerrarConexion();

                return tablaOrdenesTrabajo;
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

        public DataTable tablaOrdenesDeTrabajoFiltradas(string campo, string filtro)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM orden_trabajo " +
                    "WHERE " + campo + " LIKE '%" + filtro + "%'";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaOrdenesTrabajo = new DataTable();

                sqlAdaptador.Fill(tablaOrdenesTrabajo);

                conectaBD.cerrarConexion();

                return tablaOrdenesTrabajo;
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

        public OrdenTrabajo buscarOrdenTrabajoPorFolio(int folioOrden)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM orden_trabajo WHERE folioOrden = " + folioOrden;
                //cambiar por sp 

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaOrdenesTrabajo = new DataTable();

                sqlAdaptador.Fill(tablaOrdenesTrabajo);

                conectaBD.cerrarConexion();

                if (tablaOrdenesTrabajo.Rows.Count > 0)
                {
                    OrdenTrabajo ordenTrabajo = new OrdenTrabajo();

                    for (int i = 0; i < tablaOrdenesTrabajo.Rows.Count; i++)
                    {
                        ordenTrabajo.FolioOrden = int.Parse(tablaOrdenesTrabajo.Rows[i]["folioOrden"].ToString());
                        ordenTrabajo.Fecha = DateTime.Parse(tablaOrdenesTrabajo.Rows[i]["fecha"].ToString());
                        ordenTrabajo.FechaEntrega = DateTime.Parse(tablaOrdenesTrabajo.Rows[i]["fechaEntrega"].ToString());
                        ordenTrabajo.Prioridad = tablaOrdenesTrabajo.Rows[i]["prioridad"].ToString();
                        ordenTrabajo.Observaciones = tablaOrdenesTrabajo.Rows[i]["observaciones"].ToString();
                        ordenTrabajo.Estado = tablaOrdenesTrabajo.Rows[i]["estado"].ToString();

                        DAOUsuario daoUsuario = new DAOUsuario();
                        ordenTrabajo.Encargado = daoUsuario.buscarUsuarioPorId(int.Parse(tablaOrdenesTrabajo.Rows[i]["fk_idUsuario"].ToString()));

                        DAOCliente daoCliente = new DAOCliente();
                        ordenTrabajo.Cliente = daoCliente.buscarClientePorRut(tablaOrdenesTrabajo.Rows[i]["fk_rutCliente"].ToString());

                        DAOVehiculo daoVehiculo = new DAOVehiculo();
                        ordenTrabajo.Vehiculo = daoVehiculo.buscarVehiculoPorPatente(tablaOrdenesTrabajo.Rows[i]["fk_patente"].ToString());
                    }

                    return ordenTrabajo;
                }
                else
                {
                    return new OrdenTrabajo();
                }
            }
            catch (Exception)
            {
                return new OrdenTrabajo();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }
    }
}
