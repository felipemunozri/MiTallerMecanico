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
    public class DAOVehiculo
    {
        public bool registrarVehiculo(Vehiculo vehiculo)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_registrar_vehiculo", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@patente", vehiculo.Patente));
                cmd.Parameters.Add(new SqlParameter("@fk_rutCliente", vehiculo.Cliente.RutCliente));
                cmd.Parameters.Add(new SqlParameter("@tipoVehiculo", vehiculo.TipoVehiculo));
                cmd.Parameters.Add(new SqlParameter("@marca", vehiculo.Marca));
                cmd.Parameters.Add(new SqlParameter("@modelo", vehiculo.Modelo));
                cmd.Parameters.Add(new SqlParameter("@ano", vehiculo.Ano));
                cmd.Parameters.Add(new SqlParameter("@kilometraje", vehiculo.Kilometraje));

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

        public bool modificarVehiculo(Vehiculo vehiculo)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                conectaBD.abrirConexion();

                SqlCommand cmd = new SqlCommand("sp_modificar_vehiculo", conectaBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@patente", vehiculo.Patente));
                cmd.Parameters.Add(new SqlParameter("@fk_rutCliente", vehiculo.Cliente.RutCliente));
                cmd.Parameters.Add(new SqlParameter("@tipoVehiculo", vehiculo.TipoVehiculo));
                cmd.Parameters.Add(new SqlParameter("@marca", vehiculo.Marca));
                cmd.Parameters.Add(new SqlParameter("@modelo", vehiculo.Modelo));
                cmd.Parameters.Add(new SqlParameter("@ano", vehiculo.Ano));
                cmd.Parameters.Add(new SqlParameter("@kilometraje", vehiculo.Kilometraje));

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

        public List<Vehiculo> listarTodosLosVehiculos()
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM vw_vehiculos";

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaVehiculos = new DataTable();

                sqlAdaptador.Fill(tablaVehiculos);

                conectaBD.cerrarConexion();

                if (tablaVehiculos.Rows.Count > 0)
                {
                    List<Vehiculo> listaVehiculos = new List<Vehiculo>();

                    for (int i = 0; i < tablaVehiculos.Rows.Count; i++)
                    {
                        Vehiculo vehiculo = new Vehiculo();

                        vehiculo.Patente = tablaVehiculos.Rows[i]["patente"].ToString();
                        vehiculo.TipoVehiculo = tablaVehiculos.Rows[i]["tipoVehiculo"].ToString();
                        vehiculo.Marca = tablaVehiculos.Rows[i]["marca"].ToString();
                        vehiculo.Modelo = tablaVehiculos.Rows[i]["modelo"].ToString();
                        vehiculo.Ano = int.Parse(tablaVehiculos.Rows[i]["ano"].ToString());
                        vehiculo.Kilometraje = double.Parse(tablaVehiculos.Rows[i]["kilometraje"].ToString());

                        DAOCliente daoCliente = new DAOCliente();
                        vehiculo.Cliente = daoCliente.buscarClientePorRut(tablaVehiculos.Rows[i]["fk_rutCliente"].ToString());

                        listaVehiculos.Add(vehiculo);
                    }

                    return listaVehiculos;
                }
                else
                {
                    return new List<Vehiculo>();
                }

            }
            catch (Exception)
            {
                return new List<Vehiculo>();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public DataTable tablaTodosLosVehiculos()
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM vw_vehiculos";

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaVehiculos = new DataTable();

                sqlAdaptador.Fill(tablaVehiculos);

                conectaBD.cerrarConexion();

                return tablaVehiculos;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return new DataTable();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public DataTable tablaVehiculosFiltrados(string campo, string filtro)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM vw_vehiculos " +
                    "WHERE " + campo + " LIKE '%" + filtro + "%'";
                
                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaVehiculos = new DataTable();

                sqlAdaptador.Fill(tablaVehiculos);

                conectaBD.cerrarConexion();

                return tablaVehiculos;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return new DataTable();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }

        public Vehiculo buscarVehiculoPorPatente(string patente)
        {
            ConexionBD conectaBD = new ConexionBD();

            try
            {
                string querySelect = "SELECT * FROM vw_vehiculos WHERE patente = '" + patente + "'";
                //cambiar por sp

                conectaBD.abrirConexion();

                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(querySelect, conectaBD.Conexion);

                DataTable tablaVehiculos = new DataTable();

                sqlAdaptador.Fill(tablaVehiculos);

                conectaBD.cerrarConexion();

                if (tablaVehiculos.Rows.Count > 0)
                {
                    Vehiculo vehiculo = new Vehiculo();

                    for (int i = 0; i < tablaVehiculos.Rows.Count; i++)
                    {
                        vehiculo.Patente = tablaVehiculos.Rows[i]["patente"].ToString();
                        vehiculo.TipoVehiculo = tablaVehiculos.Rows[i]["tipoVehiculo"].ToString();
                        vehiculo.Marca = tablaVehiculos.Rows[i]["marca"].ToString();
                        vehiculo.Modelo = tablaVehiculos.Rows[i]["modelo"].ToString();
                        vehiculo.Ano = int.Parse(tablaVehiculos.Rows[i]["ano"].ToString());
                        vehiculo.Kilometraje = double.Parse(tablaVehiculos.Rows[i]["kilometraje"].ToString());

                        DAOCliente daoCliente = new DAOCliente();
                        vehiculo.Cliente = daoCliente.buscarClientePorRut(tablaVehiculos.Rows[i]["fk_rutCliente"].ToString());
                    }

                    return vehiculo;
                }
                else
                {
                    return new Vehiculo();
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return new Vehiculo();
            }
            finally
            {
                conectaBD.cerrarConexion();
            }
        }
    }
}
