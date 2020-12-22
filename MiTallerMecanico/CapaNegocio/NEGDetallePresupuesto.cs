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
    public class NEGDetallePresupuesto
    {
        public bool NEGRegistrarDetPresupuesto(DetallePresupuesto detPresupuesto)
        {
            DAODetallePresupuesto daoDetPresupuesto = new DAODetallePresupuesto();
            return daoDetPresupuesto.registrarDetPresupuesto(detPresupuesto);
        }

        public bool NEGModificarDetPresupuesto(DetallePresupuesto detPresupuesto)
        {
            DAODetallePresupuesto daoDetPresupuesto = new DAODetallePresupuesto();
            return daoDetPresupuesto.modificarDetPresupuesto(detPresupuesto);
        }

        public bool NEGEliminarDetPresupuesto(DetallePresupuesto detPresupuesto)
        {
            DAODetallePresupuesto daoDetPresupuesto = new DAODetallePresupuesto();
            return daoDetPresupuesto.eliminarDetPresupuesto(detPresupuesto);
        }

        public List<DetallePresupuesto> NEGListarTodosLosDetPresupuesto()
        {
            DAODetallePresupuesto daoDetPresupuesto = new DAODetallePresupuesto();
            return daoDetPresupuesto.listarTodosLosDetPresupuesto();
        }

        public DetallePresupuesto NEGBuscarDetPresupuestoPorFolioDetalle(int folioDetalle)
        {
            DAODetallePresupuesto daoDetPresupuesto = new DAODetallePresupuesto();
            return daoDetPresupuesto.buscarDetPresupuestoPorFolioDetalle(folioDetalle);
        }

        public DataTable NEGTablaServiciosYRepuestosEnDetPresupuestoPorFolioEncabezado(int folioEncabezado)
        {
            DAODetallePresupuesto daoDetPresupuesto = new DAODetallePresupuesto();
            return daoDetPresupuesto.tablaServiciosYRepuestosEnDetPresupuestoPorFolioEncabezado(folioEncabezado);
        }
    }
}
