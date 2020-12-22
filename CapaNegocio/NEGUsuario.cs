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
    public class NEGUsuario
    {
        public bool NEGRegistrarUsuario(Usuario usuario)
        {
            DAOUsuario daoUsuario = new DAOUsuario();
            return daoUsuario.registrarUsuario(usuario);
        }

        public bool NEGModificarUsuario(Usuario usuario)
        {
            DAOUsuario daoUsuario = new DAOUsuario();
            return daoUsuario.modificarUsuario(usuario);
        }

        public List<Usuario> NEGListarTodosLosUsuarios()
        {
            DAOUsuario daoUsuario = new DAOUsuario();
            return daoUsuario.listarTodosLosUsuarios();
        }

        public DataTable NEGTablaTodosLosUsuarios()
        {
            DAOUsuario daoUsuario = new DAOUsuario();
            return daoUsuario.tablaTodosLosUsuarios();
        }

        public DataTable NEGTablaUsuariosFiltrados(string campo, string filtro)
        {
            DAOUsuario daoUsuario = new DAOUsuario();
            return daoUsuario.tablaUsuariosFiltrados(campo, filtro);
        }

        public Usuario NEGBuscarUsuarioPorId(int idUsuario)
        {
            DAOUsuario daoUsuario = new DAOUsuario();
            return daoUsuario.buscarUsuarioPorId(idUsuario);
        }
        public bool NEGValidarUsuario(Usuario usuario)
        {
            DAOUsuario daoUsuario = new DAOUsuario();
            return daoUsuario.validarUsuario(usuario);
        }
    }
}