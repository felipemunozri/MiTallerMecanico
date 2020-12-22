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
    public class DAOEncabezadoPresupuesto
    {
        public bool registrarEncPresupuesto(EncabezadoPresupuesto encPresupuesto, out int id)
        {
            ConexionBD conectaBD = new ConexionBD();
            id = 0;

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_registrar_encabezado_presupuesto", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@fk_rutCliente", encPresupuesto.Cliente.RutCliente));
                cmd.Parameters.Add(new SqlParameter("@fk_patente", encPresupuesto.Vehiculo.Patente));
                cmd.Parameters.Add(new SqlParameter("@fecha", encPresupuesto.Fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));
                cmd.Parameters.Add(new SqlParameter("@iva", encPresupuesto.Iva));
                cmd.Parameters.Add(new SqlParameter("@total", encPresupuesto.Total));
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

        public bool modificarEncPresupuesto(EncabezadoPresupuesto encPresupuesto)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_modificar_encabezado_presupuesto", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@folioEncabezado", encPresupuesto.FolioEncabezado));
                cmd.Parameters.Add(new SqlParameter("@fk_rutCliente", encPresupuesto.Cliente.RutCliente));
                cmd.Parameters.Add(new SqlParameter("@fk_patente", encPresupuesto.Vehiculo.Patente));
                cmd.Parameters.Add(new SqlParameter("@fecha", encPresupuesto.Fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));
                cmd.Parameters.Add(new SqlParameter("@iva", encPresupuesto.Iva));
                cmd.Parameters.Add(new SqlParameter("@total", encPresupuesto.Total));

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

        public bool eliminarEncPresupuesto(EncabezadoPresupuesto encPresupuesto)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_eliminar_encabezado_y_detalle_presupuesto", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@folioEncabezado", encPresupuesto.FolioEncabezado));

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

        public List<EncabezadoPresupuesto> listarTodosLosEncPresupuesto()
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM encabezado_presupuesto";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaEncPresupuesto = new DataTable();

                sqlAdaptador.Fill(tablaEncPresupuesto);

                conectaBD.cerrarConexion();

                if (tablaEncPresupuesto.Rows.Count > 0)
                {
                    List<EncabezadoPresupuesto> listaEncPresupuesto = new List<EncabezadoPresupuesto>();

                    for (int i = 0; i < tablaEncPresupuesto.Rows.Count; i++)
                    {
                        EncabezadoPresupuesto encPresupuesto = new EncabezadoPresupuesto();

                        encPresupuesto.FolioEncabezado = int.Parse(tablaEncPresupuesto.Rows[i]["folioEncabezado"].ToString());
                        encPresupuesto.Fecha = DateTime.Parse(tablaEncPresupuesto.Rows[i]["fecha"].ToString());
                        encPresupuesto.Iva = double.Parse(tablaEncPresupuesto.Rows[i]["iva"].ToString());
                        encPresupuesto.Total = double.Parse(tablaEncPresupuesto.Rows[i]["total"].ToString());

                        DAOCliente daoCliente = new DAOCliente();
                        encPresupuesto.Cliente = daoCliente.buscarClientePorRut(tablaEncPresupuesto.Rows[i]["fk_rutCliente"].ToString());

                        DAOVehiculo daoVehiculo = new DAOVehiculo();
                        encPresupuesto.Vehiculo = daoVehiculo.buscarVehiculoPorPatente(tablaEncPresupuesto.Rows[i]["fk_rutCliente"].ToString());

                        listaEncPresupuesto.Add(encPresupuesto);
                    }

                    return listaEncPresupuesto;
                }
                else
                {
                    return new List<EncabezadoPresupuesto>();
                }
            }
            catch (Exception)
            {
                return new List<EncabezadoPresupuesto>();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public DataTable tablaTodosLosEncPresupuesto()
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM encabezado_presupuesto";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaEncPresupuesto = new DataTable();

                sqlAdaptador.Fill(tablaEncPresupuesto);

                conectaBD.cerrarConexion();

                return tablaEncPresupuesto;
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

        public DataTable tablaEncPresupuestoFiltrados(string campo, string filtro)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM encabezado_presupuesto " +
                    "WHERE " + campo + " LIKE '%" + filtro + "%'";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaEncPresupuesto = new DataTable();

                sqlAdaptador.Fill(tablaEncPresupuesto);

                conectaBD.cerrarConexion();

                return tablaEncPresupuesto;
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

        public EncabezadoPresupuesto buscarEncPresupuestoPorFolio(int folioEncabezado)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM encabezado_presupuesto WHERE folioEncabezado = " + folioEncabezado;
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaEncPresupuesto = new DataTable();

                sqlAdaptador.Fill(tablaEncPresupuesto);

                conectaBD.cerrarConexion();

                if (tablaEncPresupuesto.Rows.Count > 0)
                {
                    EncabezadoPresupuesto encPresupuesto = new EncabezadoPresupuesto();

                    for (int i = 0; i < tablaEncPresupuesto.Rows.Count; i++)
                    {
                        encPresupuesto.FolioEncabezado = int.Parse(tablaEncPresupuesto.Rows[i]["folioEncabezado"].ToString());
                        encPresupuesto.Fecha = DateTime.Parse(tablaEncPresupuesto.Rows[i]["fecha"].ToString());
                        encPresupuesto.Iva = double.Parse(tablaEncPresupuesto.Rows[i]["iva"].ToString());
                        encPresupuesto.Total = double.Parse(tablaEncPresupuesto.Rows[i]["total"].ToString());

                        DAOCliente daoCliente = new DAOCliente();
                        encPresupuesto.Cliente = daoCliente.buscarClientePorRut(tablaEncPresupuesto.Rows[i]["fk_rutCliente"].ToString());

                        DAOVehiculo daoVehiculo = new DAOVehiculo();
                        encPresupuesto.Vehiculo = daoVehiculo.buscarVehiculoPorPatente(tablaEncPresupuesto.Rows[i]["fk_patente"].ToString());
                    }

                    return encPresupuesto;
                }
                else
                {
                    return new EncabezadoPresupuesto();
                }
            }
            catch (Exception)
            {
                return new EncabezadoPresupuesto();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }
    }
}
