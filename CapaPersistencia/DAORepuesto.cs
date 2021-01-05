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
    public class DAORepuesto
    {
        public bool registrarRepuesto(Repuesto repuesto)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_registrar_repuesto", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@nombreRepuesto", repuesto.NomRepuesto));

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

        public bool modificarRepuesto(Repuesto repuesto)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_modificar_repuesto", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@idRepuesto", repuesto.IdRepuesto));
                cmd.Parameters.Add(new SqlParameter("@nombreRepuesto", repuesto.NomRepuesto));

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

        //public bool eliminarRepuesto(Repuesto repuesto)
        //{
        //    ConexionBD conectaBD = new ConexionBD();

        //    try
        //    {
        //        string queryDelete = "DELETE repuesto WHERE idRepuesto = " + repuesto.IdRepuesto;

        //        //string queryDelete = "EXEC sp_eliminar_repuesto = " + repuesto.IdRepuesto;

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

        public List<Repuesto> listarTodosLosRepuestos()
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM vw_repuestos";

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaRepuestos = new DataTable();

                sqlAdaptador.Fill(tablaRepuestos);

                conectaBD.cerrarConexion();

                if (tablaRepuestos.Rows.Count > 0)
                {
                    List<Repuesto> listaRepuestos = new List<Repuesto>();

                    for (int i = 0; i < tablaRepuestos.Rows.Count; i++)
                    {
                        Repuesto repuesto = new Repuesto();

                        repuesto.IdRepuesto = int.Parse(tablaRepuestos.Rows[i]["idRepuesto"].ToString());
                        repuesto.NomRepuesto = tablaRepuestos.Rows[i]["nombreRepuesto"].ToString();

                        listaRepuestos.Add(repuesto);
                    }

                    return listaRepuestos;
                }
                else
                {
                    return new List<Repuesto>();
                }
            }
            catch (Exception)
            {
                return new List<Repuesto>();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public DataTable tablaTodosLosRepuestos()
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM vw_repuestos";

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaRepuestos = new DataTable();

                sqlAdaptador.Fill(tablaRepuestos);

                conectaBD.cerrarConexion();

                return tablaRepuestos;
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

        public DataTable tablaRepuestosFiltrados(string campo, string filtro)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM vw_repuestos " +
                    "WHERE " + campo + " LIKE '%" + filtro + "%'";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaRepuestos = new DataTable();

                sqlAdaptador.Fill(tablaRepuestos);

                conectaBD.cerrarConexion();

                return tablaRepuestos;
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
        public Repuesto buscarRepuestoPorId(int idRepuesto)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM vw_repuestos WHERE idRepuesto = " + idRepuesto;
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaRepuestos = new DataTable();

                sqlAdaptador.Fill(tablaRepuestos);

                conectaBD.cerrarConexion();

                if (tablaRepuestos.Rows.Count > 0)
                {
                    Repuesto repuesto = new Repuesto();

                    for (int i = 0; i < tablaRepuestos.Rows.Count; i++)
                    {
                        repuesto.IdRepuesto = int.Parse(tablaRepuestos.Rows[i]["idRepuesto"].ToString());
                        repuesto.NomRepuesto = tablaRepuestos.Rows[i]["nombreRepuesto"].ToString();
                    }

                    return repuesto;
                }
                else
                {
                    return new Repuesto();
                }
            }
            catch (Exception)
            {
                return new Repuesto();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public Repuesto buscarRepuestoPorNombre(string nomRepuesto)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM vw_repuestos " +
                    "WHERE nombreRepuesto LIKE '%" + nomRepuesto + "%'";

                SqlDataAdapter sqlAdpater = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaRepuestos = new DataTable();

                conectaBD.abrirConexion();

                sqlAdpater.Fill(tablaRepuestos);

                conectaBD.cerrarConexion();

                if (tablaRepuestos.Rows.Count > 0)
                {
                    Repuesto repuesto = new Repuesto();

                    for (int i = 0; i < tablaRepuestos.Rows.Count; i++)
                    {
                        repuesto.IdRepuesto = int.Parse(tablaRepuestos.Rows[i]["idRepuesto"].ToString());
                        repuesto.NomRepuesto = tablaRepuestos.Rows[i]["nombreRepuesto"].ToString();
                    }

                    return repuesto;
                }
                else
                {
                    return new Repuesto();
                }
            }
            catch (Exception)
            {
                return new Repuesto();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }
    }
}
