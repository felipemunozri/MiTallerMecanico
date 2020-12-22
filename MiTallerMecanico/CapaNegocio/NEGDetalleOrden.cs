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
    public class NEGDetalleOrden
    {
        public bool NEGRegistrarDetOrden(DetalleOrden detOrden)
        {
            DAODetalleOrden daoDetOrden = new DAODetalleOrden();
            return daoDetOrden.registrarDetOrden(detOrden);
        }

        public bool NEGModificarDetOrden(DetalleOrden detOrden)
        {
            DAODetalleOrden daoDetOrden = new DAODetalleOrden();
            return daoDetOrden.modificarDetOrden(detOrden);
        }

        public bool NEGEliminarDetOrden(DetalleOrden detOrden)
        {
            DAODetalleOrden daoDetOrden = new DAODetalleOrden();
            return daoDetOrden.eliminarDetOrden(detOrden);
        }

        public List<DetalleOrden> NEGListarTodosLosDetOrden()
        {
            DAODetalleOrden daoDetOrden = new DAODetalleOrden();
            return daoDetOrden.listarTodosLosDetOrden();
        }

        public DetalleOrden NEGBuscarDetOrdenPorFolioOrdenTrabajo(int folioOrden)
        {
            DAODetalleOrden daoDetOrden = new DAODetalleOrden();
            return daoDetOrden.buscarDetOrdenPorFolioOrdenTrabajo(folioOrden);
        }

        public DataTable NEGTablaServiciosYRepuestosEnDetOrdenPorFolioOrdenTrabajo(int folioOrden)
        {
            DAODetalleOrden daoDetOrden = new DAODetalleOrden();
            return daoDetOrden.tablaServiciosYRepuestosEnDetOrdenPorFolioOrdenTrabajo(folioOrden);
        }
    }
}
