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
    public class NEGServicio
    {
        public bool NEGRegistarServicio(Servicio servicio)
        {
            DAOServicio daoServicio = new DAOServicio();
            return daoServicio.registrarServicio(servicio);
        }

        public bool NEGModificarServicio(Servicio servicio)
        {
            DAOServicio daoServicio = new DAOServicio();
            return daoServicio.modificarServicio(servicio);
        }

        public List<Servicio> NEGListarTodosLosServicios()
        {
            DAOServicio daoServicio = new DAOServicio();
            return daoServicio.listarTodosLosServicios();
        }

        public DataTable NEGTablaTodosLosServicios()
        {
            DAOServicio daoServicio = new DAOServicio();
            return daoServicio.tablaTodosLosServicios();
        }

        public DataTable NEGTablaServiciosFiltrados(string campo, string filtro)
        {
            DAOServicio daoServicio = new DAOServicio();
            return daoServicio.tablaServiciosFiltrados(campo, filtro);
        }

        public Servicio NEGBuscarServicioPorId(int idServicio)
        {
            DAOServicio daoServicio = new DAOServicio();
            return daoServicio.buscarServicioPorId(idServicio);
        }
    }
}
