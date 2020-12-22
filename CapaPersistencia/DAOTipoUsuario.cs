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
    public class DAOTipoUsuario
    {
        public bool registrarTipoUsuario(TipoUsuario tipoUsuario)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_registrar_tipo_usuario", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@cargo", tipoUsuario.Cargo));

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

        //public bool modificarTipoUsuario(TipoUsuario tipoUsuario)
        //{
        //    ConexionBD conectaBD = new ConexionBD();

        //    try
        //    {
        //        conectaBD.abrirConexion();

        //        SqlCommand cmd = new SqlCommand("sp_modificar_tipo_usuario", conectaBD.Conexion);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add(new SqlParameter("@idTipoUsuario", tipoUsuario.IdTipoUsuario));
        //        cmd.Parameters.Add(new SqlParameter("@cargo", tipoUsuario.Cargo));

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

        //public bool eliminarTipoUsuario(TipoUsuario tipoUsuario)
        //{
        //    ConexionBD conectaBD = new ConexionBD();

        //    try
        //    {
        //        string queryDelete = "DELETE tipo_usuario WHERE idTipoUsuario = " + tipoUsuario.IdTipoUsuario;

        //        //string queryDelete = "EXEC sp_eliminar_tipo_usuario = " + tipoUsuario.IdTipoUsuario;

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

        public List<TipoUsuario> listarTodosLosTiposUsuario()
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM tipo_usuario";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaTiposUsuario = new DataTable();

                sqlAdaptador.Fill(tablaTiposUsuario);

                conectaBD.cerrarConexion();

                if (tablaTiposUsuario.Rows.Count > 0)
                {
                    List<TipoUsuario> listaTiposUsuario = new List<TipoUsuario>();

                    for (int i = 0; i < tablaTiposUsuario.Rows.Count; i++)
                    {
                        TipoUsuario tipoUsuario = new TipoUsuario();

                        tipoUsuario.IdTipoUsuario = int.Parse(tablaTiposUsuario.Rows[i]["idTipoUsuario"].ToString());
                        tipoUsuario.Cargo = tablaTiposUsuario.Rows[i]["cargo"].ToString();

                        listaTiposUsuario.Add(tipoUsuario);
                    }

                    return listaTiposUsuario;
                }
                else
                {
                    return new List<TipoUsuario>();
                }
            }
            catch (Exception)
            {
                return new List<TipoUsuario>();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public DataTable tablaTodosLosTiposUsuario()
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM tipo_usuario";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaTiposUsuario = new DataTable();

                sqlAdaptador.Fill(tablaTiposUsuario);

                conectaBD.cerrarConexion();

                return tablaTiposUsuario;
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

        public DataTable tablaTiposUsuarioFiltrados(string campo, string filtro)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM tipo_usuario " +
                    "WHERE " + campo + " LIKE '%" + filtro + "%'";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaTiposUsuario = new DataTable();

                sqlAdaptador.Fill(tablaTiposUsuario);

                conectaBD.cerrarConexion();

                return tablaTiposUsuario;
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

        public TipoUsuario buscarTipoUsuarioPorId(int idTipoUsuario)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM tipo_usuario WHERE idTipoUsuario = " + idTipoUsuario;
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaTiposUsuario = new DataTable();

                sqlAdaptador.Fill(tablaTiposUsuario);

                conectaBD.cerrarConexion();

                if (tablaTiposUsuario.Rows.Count > 0)
                {
                    TipoUsuario tipoUsuario = new TipoUsuario();

                    for (int i = 0; i < tablaTiposUsuario.Rows.Count; i++)
                    {
                        tipoUsuario.IdTipoUsuario = int.Parse(tablaTiposUsuario.Rows[i]["idTipoUsuario"].ToString());
                        tipoUsuario.Cargo = tablaTiposUsuario.Rows[i]["cargo"].ToString();
                    }

                    return tipoUsuario;
                }
                else
                {
                    return new TipoUsuario();
                }
            }
            catch (Exception)
            {
                return new TipoUsuario();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }
    }
}
