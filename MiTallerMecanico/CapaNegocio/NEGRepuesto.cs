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
    public class NEGRepuesto
    {
        public bool NEGRegistarRepuesto(Repuesto repuesto)
        {
            DAORepuesto daoRepuesto = new DAORepuesto();
            return daoRepuesto.registrarRepuesto(repuesto);
        }

        public bool NEGModificarRepuesto(Repuesto repuesto)
        {
            DAORepuesto daoRepuesto = new DAORepuesto();
            return daoRepuesto.modificarRepuesto(repuesto);
        }

        public List<Repuesto> NEGListarTodosLosRepuesto()
        {
            DAORepuesto daoRepuesto = new DAORepuesto();
            return daoRepuesto.listarTodosLosRepuestos();
        }

        public DataTable NEGTablaTodosLosRepuestos()
        {
            DAORepuesto daoRepuesto = new DAORepuesto();
            return daoRepuesto.tablaTodosLosRepuestos();
        }

        public DataTable NEGTablaRepuestosFiltrados(string campo, string filtro)
        {
            DAORepuesto daoRepuesto = new DAORepuesto();
            return daoRepuesto.tablaRepuestosFiltrados(campo, filtro);
        }

        public Repuesto NEGBuscarRepuestoPorId(int idRepuesto)
        {
            DAORepuesto daoRepuesto = new DAORepuesto();
            return daoRepuesto.buscarRepuestoPorId(idRepuesto);
        }

        public Repuesto NEGBuscarRepuestoPorNombre(string nomRepuesto)
        {
            DAORepuesto daoRepuesto = new DAORepuesto();
            return daoRepuesto.buscarRepuestoPorNombre(nomRepuesto);
        }
    }
}
