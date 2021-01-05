using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Servicio
    {
        private int idServicio;
        private string nomServicio;
        private double valorServicio;

        public Servicio()
        {

        }

        public Servicio(string nomServicio)
        {
            this.NomServicio = nomServicio;
        }

        public Servicio(string nomServicio, double valorServicio)
        {
            this.NomServicio = nomServicio;
            this.ValorServicio = valorServicio;
        }

        public int IdServicio { get => idServicio; set => idServicio = value; }
        public string NomServicio { get => nomServicio; set => nomServicio = value; }
        public double ValorServicio { get => valorServicio; set => valorServicio = value; }
    }
}
