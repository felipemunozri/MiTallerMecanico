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
    public class NEGOrdenTrabajo
    {
        public bool NEGRegistrarOrdenTrabajo(OrdenTrabajo ordenTrabajo, out int id)
        {
            DAOOrdenTrabajo daoOrdenTrabajo = new DAOOrdenTrabajo();
            return daoOrdenTrabajo.registrarOrdenTrabajo(ordenTrabajo, out id);
        }

        public bool NEGModificarOrdenTrabajo(OrdenTrabajo ordenTrabajo)
        {
            DAOOrdenTrabajo daoOrdenTrabajo = new DAOOrdenTrabajo();
            return daoOrdenTrabajo.modificarOrdenTrabajo(ordenTrabajo);
        }

        public bool NEGEliminarOrdenTrabajo(OrdenTrabajo ordenTrabajo)
        {
            DAOOrdenTrabajo daoOrdenTrabajo = new DAOOrdenTrabajo();
            return daoOrdenTrabajo.eliminarOrdenTrabajo(ordenTrabajo);
        }

        public List<OrdenTrabajo> NEGListarTodasLasOrdenesDeTrabajo()
        {
            DAOOrdenTrabajo daoOrdenTrabajo = new DAOOrdenTrabajo();
            return daoOrdenTrabajo.listarTodasLasOrdenesDeTrabajo();
        }

        public DataTable NEGTablaTodasLasOrdenesDeTrabajo()
        {
            DAOOrdenTrabajo daoOrdenTrabajo = new DAOOrdenTrabajo();
            return daoOrdenTrabajo.tablaTodasLasOrdenesDeTrabajo();
        }

        public DataTable NEGTablaOrdenesDeTrabajoFiltradas(string campo, string filtro)
        {
            DAOOrdenTrabajo daoOrdenTrabajo = new DAOOrdenTrabajo();
            return daoOrdenTrabajo.tablaOrdenesDeTrabajoFiltradas(campo, filtro);
        }

        public OrdenTrabajo NEGBuscarOrdenTrabajoPorFolio(int folioOrden)
        {
            DAOOrdenTrabajo daoOrdenTrabajo = new DAOOrdenTrabajo();
            return daoOrdenTrabajo.buscarOrdenTrabajoPorFolio(folioOrden);
        }

        public OrdenTrabajo NEGBuscarOrdenTrabajoPorFolioYPatente(int folioOrden, string patente)
        {
            DAOOrdenTrabajo daoOrdenTrabajo = new DAOOrdenTrabajo();
            return daoOrdenTrabajo.buscarOrdenTrabajoPorFolioYPatente(folioOrden, patente);
        }

        public OrdenTrabajo NEGBuscarOrdenTrabajoPorPatenteYEstado(string patente)
        {
            DAOOrdenTrabajo daoOrdenTrabajo = new DAOOrdenTrabajo();
            return daoOrdenTrabajo.buscarOrdenTrabajoPorPatenteYEstado(patente);
        }
    }
}
