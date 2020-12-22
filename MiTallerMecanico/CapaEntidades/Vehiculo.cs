using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Vehiculo
    {
        private string patente;
        private Cliente cliente;
        private string tipoVehiculo;
        private string marca;
        private string modelo;
        private int ano;
        private double kilometraje;

        public Vehiculo()
        {

        }

        public Vehiculo(string patente, Cliente cliente, string tipo, string marca, string modelo, int ano, double kilometraje)
        {
            this.Patente = patente;
            this.Cliente = cliente;
            this.TipoVehiculo = tipo;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Ano = ano;
            this.Kilometraje = kilometraje;
        }

        public string Patente { get => patente; set => patente = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public string TipoVehiculo { get => tipoVehiculo; set => tipoVehiculo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int Ano { get => ano; set => ano = value; }
        public double Kilometraje { get => kilometraje; set => kilometraje = value; }
    }
}
