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
        private Cliente cliente;
        private Vehiculo vehiculo;
        private string observaciones;
        private string estado;
        private double iva;
        private double total;

        public EncabezadoPresupuesto()
        {

        }

        // esta sobrecarga se ocupa para listar los encabezados ya que usa el id de documento
        public EncabezadoPresupuesto(int folioEncabezado, DateTime fecha, Cliente cliente, Vehiculo vehiculo, string observaciones, string estado, double iva, double total)
        {
            this.FolioEncabezado = folioEncabezado;
            this.Fecha = fecha;
            this.Cliente = cliente;
            this.Vehiculo = vehiculo;
            this.Observaciones = observaciones;
            this.Estado = estado;
            this.Iva = iva;
            this.Total = total;
        }

        // esta sobrecarga se ocupa para crear un encabezado, ya que no utiliza el id de documento (se crea en BD)
        public EncabezadoPresupuesto(DateTime fecha, Cliente cliente, Vehiculo vehiculo, string observaciones, string estado, double iva, double total)
        {
            this.Fecha = fecha;
            this.Cliente = cliente;
            this.Vehiculo = vehiculo;
            this.Observaciones = observaciones;
            this.Estado = estado;
            this.Iva = iva;
            this.Total = total;
        }

        public int FolioEncabezado { get => folioEncabezado; set => folioEncabezado = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Vehiculo Vehiculo { get => vehiculo; set => vehiculo = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public string Estado { get => estado; set => estado = value; }
        public double Iva { get => iva; set => iva = value; }
        public double Total { get => total; set => total = value; }

    }
}
