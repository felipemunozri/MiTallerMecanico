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
    public class DAOServicio
    {
        public bool registrarServicio(Servicio servicio)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_registrar_servicio", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@nombreServicio", servicio.NomServicio));

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

        public bool modificarServicio(Servicio servicio)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_modificar_servicio", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@idServicio", servicio.IdServicio));
                cmd.Parameters.Add(new SqlParameter("@nombreServicio", servicio.NomServicio));

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

        //public bool eliminarServicio(Servicio servicio)
        //{
        //    ConexionBD conectaBD = new ConexionBD();

        //    try
        //    {
        //        string queryDelete = "DELETE servicio WHERE idServicio = " + servicio.IdServicio;

        //        //string queryDelete = "EXEC sp_eliminar_servicio = " + servicio.IdServicio;

        //        conectaBD.abrirConexion();

        //        SqlDataAdapter sqlAdaptador = new SqlDataAdapter(queryDelete, conectaBD.Conexion);

        //        conectaBD.abrirConexion();

        //        SqlCommand cmd = new SqlCommand(queryDelete, conectaBD.Conexion);

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

        public List<Servicio> listarTodosLosServicios()
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM servicio";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaServicios = new DataTable();

                sqlAdaptador.Fill(tablaServicios);

                conectaBD.cerrarConexion();

                if (tablaServicios.Rows.Count > 0)
                {
                    List<Servicio> listaServicios = new List<Servicio>();

                    for (int i = 0; i < tablaServicios.Rows.Count; i++)
                    {
                        Servicio servicio = new Servicio();

                        servicio.IdServicio = int.Parse(tablaServicios.Rows[i]["idServicio"].ToString());
                        servicio.NomServicio = tablaServicios.Rows[i]["nombreServicio"].ToString();

                        listaServicios.Add(servicio);
                    }

                    return listaServicios;
                }
                else
                {
                    return new List<Servicio>();
                }

            }
            catch (Exception)
            {
                return new List<Servicio>();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public DataTable tablaTodosLosServicios()
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM servicio";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaServicios = new DataTable();

                sqlAdaptador.Fill(tablaServicios);

                conectaBD.cerrarConexion();

                return tablaServicios;
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

        public DataTable tablaServiciosFiltrados(string campo, string filtro)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM servicio " +
                    "WHERE " + campo + " LIKE '%" + filtro + "%'";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaServicios = new DataTable();

                sqlAdaptador.Fill(tablaServicios);

                conectaBD.cerrarConexion();

                return tablaServicios;
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

        public Servicio buscarServicioPorId(int idServicio)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM servicio WHERE idServicio = " + idServicio;
                //reemplazar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaServicios = new DataTable();

                sqlAdaptador.Fill(tablaServicios);

                conectaBD.cerrarConexion();

                if (tablaServicios.Rows.Count > 0)
                {
                    Servicio servicio = new Servicio();

                    for (int i = 0; i < tablaServicios.Rows.Count; i++)
                    {
                        servicio.IdServicio = int.Parse(tablaServicios.Rows[i]["idServicio"].ToString());
                        servicio.NomServicio = tablaServicios.Rows[i]["nombreServicio"].ToString();
                    }

                    return servicio;
                }
                else
                {
                    return new Servicio();
                }
            }
            catch (Exception)
            {
                return new Servicio();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }
    }
}
