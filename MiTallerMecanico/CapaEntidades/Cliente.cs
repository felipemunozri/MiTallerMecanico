using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Cliente
    {
        private string rutCliente;
        private string nomCliente;
        private string apeCliente;
        private string direcCliente;
        private int telCliente;
        private string mailCliente;

        public Cliente()
        {

        }

        public Cliente(string rut, string nom, string ape, string direc, int tel, string mail)
        {
            this.RutCliente = rut;
            this.NomCliente = nom;
            this.ApeCliente = ape;
            this.DirecCliente = direc;
            this.TelCliente = tel;
            this.MailCliente = mail;
        }

        public string RutCliente { get => rutCliente; set => rutCliente = value; }
        public string NomCliente { get => nomCliente; set => nomCliente = value; }
        public string ApeCliente { get => apeCliente; set => apeCliente = value; }
        public string DirecCliente { get => direcCliente; set => direcCliente = value; }
        public int TelCliente { get => telCliente; set => telCliente = value; }
        public string MailCliente { get => mailCliente; set => mailCliente = value; }
    }
}
