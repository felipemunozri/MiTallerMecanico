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
    public class DAOCliente
    {
        public bool registrarCliente(Cliente cliente)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_registrar_cliente", conectaBD.Conexion);  
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@rutCliente", cliente.RutCliente));
                cmd.Parameters.Add(new SqlParameter("@nombreCliente", cliente.NomCliente));
                cmd.Parameters.Add(new SqlParameter("@apellidoCliente", cliente.ApeCliente));
                cmd.Parameters.Add(new SqlParameter("@direccioncliente", cliente.DirecCliente));
                cmd.Parameters.Add(new SqlParameter("@telefonoCliente", cliente.TelCliente));
                cmd.Parameters.Add(new SqlParameter("@correoCliente", cliente.MailCliente));

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

        public bool modificarCliente(Cliente cliente)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_modificar_cliente", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@rutCliente", cliente.RutCliente));
                cmd.Parameters.Add(new SqlParameter("@nombreCliente", cliente.NomCliente));
                cmd.Parameters.Add(new SqlParameter("@apellidoCliente", cliente.ApeCliente));
                cmd.Parameters.Add(new SqlParameter("@direccioncliente", cliente.DirecCliente));
                cmd.Parameters.Add(new SqlParameter("@telefonoCliente", cliente.TelCliente));
                cmd.Parameters.Add(new SqlParameter("@correoCliente", cliente.MailCliente));

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

        public List<Cliente> listarTodosLosClientes()
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM vw_clientes";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaClientes = new DataTable();

                sqlAdaptador.Fill(tablaClientes);

                conectaBD.cerrarConexion();

                if (tablaClientes.Rows.Count > 0)
                {
                    List<Cliente> listaClientes = new List<Cliente>();

                    for (int i = 0; i < tablaClientes.Rows.Count; i++)
                    {
                        Cliente cliente = new Cliente();

                        cliente.RutCliente = tablaClientes.Rows[i]["rutCliente"].ToString();
                        cliente.NomCliente = tablaClientes.Rows[i]["nombreCliente"].ToString();
                        cliente.ApeCliente = tablaClientes.Rows[i]["apellidoCliente"].ToString();
                        cliente.DirecCliente = tablaClientes.Rows[i]["direccionCliente"].ToString();
                        cliente.TelCliente = int.Parse(tablaClientes.Rows[i]["telefonoCliente"].ToString());
                        cliente.MailCliente = tablaClientes.Rows[i]["correoCliente"].ToString();

                        listaClientes.Add(cliente);
                    }

                    return listaClientes;
                }
                else
                {
                    return new List<Cliente>();
                }
            }
            catch (Exception)
            {
                return new List<Cliente>();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public DataTable tablaTodosLosClientes()
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM vw_clientes";

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaClientes = new DataTable();

                sqlAdaptador.Fill(tablaClientes);

                conectaBD.cerrarConexion();

                return tablaClientes;
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

        public DataTable tablaClientesFiltrados(string campo, string filtro)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM vw_clientes " +
                    "WHERE " + campo + " LIKE '%" + filtro + "%'";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaClientes = new DataTable();

                sqlAdaptador.Fill(tablaClientes);

                conectaBD.cerrarConexion();

                return tablaClientes;
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

        public Cliente buscarClientePorRut(string rutCliente)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_ver_cliente_por_rut", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@rutCliente", rutCliente));

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
                sqlAdaptador.SelectCommand = cmd;

                DataTable tablaClientes = new DataTable();
                sqlAdaptador.Fill(tablaClientes);

                conectaBD.cerrarConexion();

                if (tablaClientes.Rows.Count > 0)
                {
                    Cliente cliente = new Cliente();

                    for (int i = 0; i < tablaClientes.Rows.Count; i++)
                    {
                        cliente.RutCliente = tablaClientes.Rows[i]["rutCliente"].ToString();
                        cliente.NomCliente = tablaClientes.Rows[i]["nombreCliente"].ToString();
                        cliente.ApeCliente = tablaClientes.Rows[i]["apellidoCliente"].ToString();
                        cliente.DirecCliente = tablaClientes.Rows[i]["direccionCliente"].ToString();
                        cliente.TelCliente = int.Parse(tablaClientes.Rows[i]["telefonoCliente"].ToString());
                        cliente.MailCliente = tablaClientes.Rows[i]["correoCliente"].ToString();
                    }

                    return cliente;
                }
                else
                {
                    return new Cliente();
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return new Cliente();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }
    }
}
