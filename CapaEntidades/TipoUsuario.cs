using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class TipoUsuario
    {
        private int idTipoUsuario;
        private string cargo;

        public TipoUsuario()
        {

        }

        public TipoUsuario(string cargo)
        {
            this.Cargo = cargo;
        }

        public int IdTipoUsuario { get => idTipoUsuario; set => idTipoUsuario = value; }
        public string Cargo { get => cargo; set => cargo = value; }
    }
}
