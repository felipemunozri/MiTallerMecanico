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
    public class NEGEncabezadoPresupuesto
    {
        public bool NEGRegistrarEncPresupuesto(EncabezadoPresupuesto encPresupuesto, out int id)
        {
            DAOEncabezadoPresupuesto daoEncPresupuesto = new DAOEncabezadoPresupuesto();
            return daoEncPresupuesto.registrarEncPresupuesto(encPresupuesto, out id);
        }

        public bool NEGModificarEncPresupuesto(EncabezadoPresupuesto encPresupuesto)
        {
            DAOEncabezadoPresupuesto daoEncPresupuesto = new DAOEncabezadoPresupuesto();
            return daoEncPresupuesto.modificarEncPresupuesto(encPresupuesto);
        }

        public bool NEGEliminarEncPresupuesto(EncabezadoPresupuesto encPresupuesto)
        {
            DAOEncabezadoPresupuesto daoEncPresupuesto = new DAOEncabezadoPresupuesto();
            return daoEncPresupuesto.eliminarEncPresupuesto(encPresupuesto);
        }

        public List<EncabezadoPresupuesto> NEGListarTodosLosEncPresupuesto()
        {
            DAOEncabezadoPresupuesto daoEncPresupuesto = new DAOEncabezadoPresupuesto();
            return daoEncPresupuesto.listarTodosLosEncPresupuesto();
        }

        public DataTable NEGTablaTodosLosEncPresupuesto()
        {
            DAOEncabezadoPresupuesto daoEncPresupuesto = new DAOEncabezadoPresupuesto();
            return daoEncPresupuesto.tablaTodosLosEncPresupuesto();
        }

        public DataTable NEGTablaEncPresupuestoFiltrados(string campo, string filtro)
        {
            DAOEncabezadoPresupuesto daoEncPresupuesto = new DAOEncabezadoPresupuesto();
            return daoEncPresupuesto.tablaEncPresupuestoFiltrados(campo, filtro);
        }

        public EncabezadoPresupuesto NEGBuscarEncPresupuestoPorFolio(int folioEncabezado)
        {
            DAOEncabezadoPresupuesto daoEncPresupuesto = new DAOEncabezadoPresupuesto();
            return daoEncPresupuesto.buscarEncPresupuestoPorFolio(folioEncabezado);
        }
    }
}
