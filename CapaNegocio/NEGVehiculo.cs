using CapaEntidades;
using CapaPersistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NEGVehiculo
    {
        public bool NEGRegistrarVehiculo(Vehiculo vehiculo)
        {
            DAOVehiculo daoVehiculo = new DAOVehiculo();
            return daoVehiculo.registrarVehiculo(vehiculo);
        }

        public bool NEGModificarVehiculo(Vehiculo vehiculo)
        {
            DAOVehiculo daoVehiculo = new DAOVehiculo();
            return daoVehiculo.modificarVehiculo(vehiculo);
        }

        public List<Vehiculo> NEGListarTodosLosVehiculos()
        {
            DAOVehiculo daoVehiculo = new DAOVehiculo();
            return daoVehiculo.listarTodosLosVehiculos();
        }

        public DataTable NEGTablaTodosLosVehiculos()
        {
            DAOVehiculo daoVehiculo = new DAOVehiculo();
            return daoVehiculo.tablaTodosLosVehiculos();
        }

        public DataTable NEGTablaVehiculosFiltrados(string campo, string filtro)
        {
            DAOVehiculo daoVehiculo = new DAOVehiculo();
            return daoVehiculo.tablaVehiculosFiltrados(campo, filtro);
        }

        public Vehiculo NEGBuscarVehiculoPorPatente(string patente)
        {
            DAOVehiculo daoVehiculo = new DAOVehiculo();
            return daoVehiculo.buscarVehiculoPorPatente(patente);
        }
    }
}
