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
    public class NEGTipoUsuario
    {
        public bool NEGRegistarTipoUsuario(TipoUsuario cliente)
        {
            DAOTipoUsuario daoTipoUsuario = new DAOTipoUsuario();
            return daoTipoUsuario.registrarTipoUsuario(cliente);
        }

        public List<TipoUsuario> NEGListarTodosLosTiposUsuario()
        {
            DAOTipoUsuario daoTipoUsuario = new DAOTipoUsuario();
            return daoTipoUsuario.listarTodosLosTiposUsuario();
        }

        public DataTable NEGTablaTodosLosTiposUsuario()
        {
            DAOTipoUsuario daoTipoUsuario = new DAOTipoUsuario();
            return daoTipoUsuario.tablaTodosLosTiposUsuario();
        }

        public DataTable NEGTablaTiposUsuarioFiltrados(string campo, string filtro)
        {
            DAOTipoUsuario daoTipoUsuario = new DAOTipoUsuario();
            return daoTipoUsuario.tablaTiposUsuarioFiltrados(campo, filtro);
        }

        public TipoUsuario NEGBuscarTipoUsuarioPorId(int idTipoUsuario)
        {
            DAOTipoUsuario daoTipoUsuario = new DAOTipoUsuario();
            return daoTipoUsuario.buscarTipoUsuarioPorId(idTipoUsuario);
        }
    }
}
