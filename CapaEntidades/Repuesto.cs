using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Repuesto
    {
        private int idRepuesto;
        private string nomRepuesto;

        public Repuesto()
        {

        }

        public Repuesto(string nomRepuesto)
        {
            this.NomRepuesto = nomRepuesto;
        }

        public int IdRepuesto { get => idRepuesto; set => idRepuesto = value; }
        public string NomRepuesto { get => nomRepuesto; set => nomRepuesto = value; }
    }
}
