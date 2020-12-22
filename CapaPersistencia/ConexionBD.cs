using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPersistencia
{
    public class ConexionBD
    {
        private string cadenaConexion = @"";
        private SqlConnection conexion = null;

        public ConexionBD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["CadenaBDTallerMecanico"].ConnectionString;
            conexion = new SqlConnection(cadenaConexion);
        }

        public SqlConnection Conexion { get => conexion; } // Borramos el set a proposito

        public void abrirConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                }
            }
            catch (Exception)
            {

            }
        }

        public void cerrarConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
