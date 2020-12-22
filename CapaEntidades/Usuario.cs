using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Usuario
    {
        private int idUsuario;
        private TipoUsuario tipoUsuario;
        private string nomUsuario;
        private string passUsuario;

        public Usuario()
        {

        }

        public Usuario(string nomUsuario, string passUsuario)
        {
            this.NomUsuario = nomUsuario;
            this.PassUsuario = passUsuario;
        }

        public Usuario(TipoUsuario tipoUsuario, string nomUsuario, string passUsuario)
        {
            this.TipoUsuario = tipoUsuario;
            this.NomUsuario = nomUsuario;
            this.PassUsuario = passUsuario;
        }

        public Usuario(int idUsuario, TipoUsuario tipoUsuario, string nomUsuario, string passUsuario)
        {
            this.IdUsuario = idUsuario;
            this.TipoUsuario = tipoUsuario;
            this.NomUsuario = nomUsuario;
            this.PassUsuario = passUsuario;
        }

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public TipoUsuario TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
        public string NomUsuario { get => nomUsuario; set => nomUsuario = value; }
        public string PassUsuario { get => passUsuario; set => passUsuario = value; }
    }
}
