using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EncabezadoPresupuesto
    {
        private int folioEncabezado;
        private DateTime fecha;
        private string rutCliente;
        private string patente;
        private double iva;
        private double total;

        public EncabezadoPresupuesto()
        {

        }

        // esta sobrecarga se ocupa para listar los encabezados ya que usa el id de documento
        public EncabezadoPresupuesto(int folioEncabezado, DateTime fecha, string rutCliente, string patente, double iva, double total)
        {
            this.FolioEncabezado = folioEncabezado;
            this.Fecha = fecha;
            this.RutCliente = rutCliente;
            this.Patente = patente;
            this.Iva = iva;
            this.Total = total;
        }

        // esta sobrecarga se ocupa para crear un encabezado, ya que no utiliza el id de documento (se crea en BD)
        public EncabezadoPresupuesto(DateTime fecha, string rutCliente, string patente, double iva, double total)
        {
            this.Fecha = fecha;
            this.RutCliente = rutCliente;
            this.Patente = patente;
            this.Iva = iva;
            this.Total = total;
        }

        public int FolioEncabezado { get => folioEncabezado; set => folioEncabezado = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string RutCliente { get => rutCliente; set => rutCliente = value; }
        public string Patente { get => patente; set => patente = value; }
        public double Iva { get => iva; set => iva = value; }
        public double Total { get => total; set => total = value; }
    }
}
