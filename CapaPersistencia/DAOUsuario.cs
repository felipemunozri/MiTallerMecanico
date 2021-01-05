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
    public class DAOUsuario
    {
        public bool registrarUsuario(Usuario usuario)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_registrar_usuario", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@fk_idTipoUsuario", usuario.TipoUsuario.IdTipoUsuario));
                cmd.Parameters.Add(new SqlParameter("@nombreUsuario", usuario.NomUsuario));
                cmd.Parameters.Add(new SqlParameter("@passUsuario", usuario.PassUsuario));

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

        public bool modificarUsuario(Usuario usuario)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_modificar_usuario", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@idUsuario", usuario.IdUsuario));
                cmd.Parameters.Add(new SqlParameter("@fk_idTipoUsuario", usuario.TipoUsuario.IdTipoUsuario));
                cmd.Parameters.Add(new SqlParameter("@nombreUsuario", usuario.NomUsuario));
                cmd.Parameters.Add(new SqlParameter("@passUsuario", usuario.PassUsuario));

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

        //public bool eliminarUsuario(Usuario usuario)
        //{
        //    ConexionBD conectaBD = new ConexionBD();

        //    try
        //    {
        //        string queryDelete = "DELETE usuario WHERE idUsuario = " + usuario.IdUsuario;

        //        //string queryDelete = "EXEC sp_eliminar_usuario = " + usuario.IdUsuario;

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

        public List<Usuario> listarTodosLosUsuarios()
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM vw_usuarios";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaUsuarios = new DataTable();

                sqlAdaptador.Fill(tablaUsuarios);

                conectaBD.cerrarConexion();

                if (tablaUsuarios.Rows.Count > 0)
                {
                    List<Usuario> listaUsuarios = new List<Usuario>();

                    for (int i = 0; i < tablaUsuarios.Rows.Count; i++)
                    {
                        Usuario usuario = new Usuario();

                        usuario.IdUsuario = int.Parse(tablaUsuarios.Rows[i]["idUsuario"].ToString());
                        usuario.NomUsuario = tablaUsuarios.Rows[i]["nombreUsuario"].ToString();
                        usuario.PassUsuario = tablaUsuarios.Rows[i]["passUsuario"].ToString();

                        DAOTipoUsuario daoTipoUsuario = new DAOTipoUsuario();
                        usuario.TipoUsuario = daoTipoUsuario.buscarTipoUsuarioPorId(int.Parse(tablaUsuarios.Rows[i]["fk_idTipoUsuario"].ToString()));

                        listaUsuarios.Add(usuario);
                    }

                    return listaUsuarios;
                }
                else
                {
                    return new List<Usuario>();
                }
            }
            catch (Exception)
            {
                return new List<Usuario>();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public DataTable tablaTodosLosUsuarios()
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM vw_usuarios";

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaUsuarios = new DataTable();

                sqlAdaptador.Fill(tablaUsuarios);

                conectaBD.cerrarConexion();

                return tablaUsuarios;
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

        public DataTable tablaUsuariosFiltrados(string campo, string filtro)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM vw_usuarios " +
                    "WHERE " + campo + " LIKE '%" + filtro + "%'";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaUsuarios = new DataTable();

                sqlAdaptador.Fill(tablaUsuarios);

                conectaBD.cerrarConexion();

                return tablaUsuarios;
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

        public Usuario buscarUsuarioPorId(int idUsuario)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM vw_usuarios WHERE idUsuario = " + idUsuario;
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaUsuarios = new DataTable();

                sqlAdaptador.Fill(tablaUsuarios);

                conectaBD.cerrarConexion();

                if (tablaUsuarios.Rows.Count > 0)
                {
                    Usuario usuario = new Usuario();

                    for (int i = 0; i < tablaUsuarios.Rows.Count; i++)
                    {
                        usuario.IdUsuario = int.Parse(tablaUsuarios.Rows[i]["idUsuario"].ToString());
                        usuario.NomUsuario = tablaUsuarios.Rows[i]["nombreUsuario"].ToString();
                        usuario.PassUsuario = tablaUsuarios.Rows[i]["passUsuario"].ToString();

                        DAOTipoUsuario daoTipoUsuario = new DAOTipoUsuario();
                        usuario.TipoUsuario = daoTipoUsuario.buscarTipoUsuarioPorId(int.Parse(tablaUsuarios.Rows[i]["fk_idTipoUsuario"].ToString()));
                    }

                    return usuario;
                }
                else
                {
                    return new Usuario();
                }
            }
            catch (Exception)
            {
                return new Usuario();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public bool validarUsuario(Usuario usuario, out Usuario usuarioValido)
        {
            bool flag = false;

            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM vw_usuarios WHERE " +
                    "nombreUsuario = '" + usuario.NomUsuario + "' AND " +
                    "passUsuario  = '" + usuario.PassUsuario + "'";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaUsuarios = new DataTable();

                sqlAdaptador.Fill(tablaUsuarios);

                conectaBD.cerrarConexion();

                if (tablaUsuarios.Rows.Count > 0)
                {
                    usuarioValido = new Usuario();

                    for (int i = 0; i < tablaUsuarios.Rows.Count; i++)
                    {
                        usuarioValido.IdUsuario = int.Parse(tablaUsuarios.Rows[i]["idUsuario"].ToString());
                        usuarioValido.NomUsuario = tablaUsuarios.Rows[i]["nombreUsuario"].ToString();
                        usuarioValido.PassUsuario = tablaUsuarios.Rows[i]["passUsuario"].ToString();

                        DAOTipoUsuario daoTipoUsuario = new DAOTipoUsuario();
                        usuarioValido.TipoUsuario = daoTipoUsuario.buscarTipoUsuarioPorId(int.Parse(tablaUsuarios.Rows[i]["fk_idTipoUsuario"].ToString()));
                    }

                    flag = true;
                    return flag;
                }
                else
                {
                    usuarioValido = new Usuario();
                    return flag;
                }
            }
            catch (Exception)
            {
                usuarioValido = new Usuario();
                return flag;
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }
    }
}
