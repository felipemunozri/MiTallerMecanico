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
    public class NEGCliente
    {
        public bool NEGRegistarCliente(Cliente cliente)
        {
            DAOCliente daoCliente = new DAOCliente();
            return daoCliente.registrarCliente(cliente);
        }

        public bool NEGModificarCliente(Cliente cliente)
        {
            DAOCliente daoCliente = new DAOCliente();
            return daoCliente.modificarCliente(cliente);
        }

        public List<Cliente> NEGListarTodosLosClientes()
        {
            DAOCliente daoCliente = new DAOCliente();
            return daoCliente.listarTodosLosClientes();
        }

        public DataTable NEGTablaTodosLosClientes()
        {
            DAOCliente daoCliente = new DAOCliente();
            return daoCliente.tablaTodosLosClientes();
        }

        public DataTable NEGTablaClientesFiltrados(string campo, string filtro)
        {
            DAOCliente daoCliente = new DAOCliente();
            return daoCliente.tablaClientesFiltrados(campo, filtro);
        }

        public Cliente NEGBuscarClientePorRut(string rut)
        {
            DAOCliente daoCliente = new DAOCliente();
            return daoCliente.buscarClientePorRut(rut);
        }
    }
}
