using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class OrdenTrabajo
    {
        private int folioOrden;
        private Usuario encargado;
        private Cliente cliente;
        private Vehiculo vehiculo;
        private DateTime fecha;
        private DateTime fechaEntrega;
        private string prioridad;
        private string observaciones;
        private string estado;
        private double iva;
        private double total;

        public OrdenTrabajo()
        {

        }

        // esta sobrecarga se ocupa para listar las ordenes ya que usa el id de documento
        public OrdenTrabajo(int folioOrden, Usuario encargado, Vehiculo vehiculo, Cliente cliente, DateTime fecha, DateTime fechaEntrega, string prioridad, string observaciones, string estado, double iva, double subTotal)
        {
            this.FolioOrden = folioOrden;
            this.Encargado = encargado;
            this.Vehiculo = vehiculo;
            this.Fecha = fecha;
            this.FechaEntrega = fechaEntrega;
            this.Prioridad = prioridad;
            this.Observaciones = observaciones;
            this.Estado = estado;
        }

        // esta sobrecarga se ocupa para crear una orden, ya que no utiliza el id de documento (se crea en BD)
        public OrdenTrabajo(Usuario encargado, Vehiculo vehiculo, Cliente cliente, DateTime fecha, DateTime fechaEntrega, string prioridad, string observaciones, string estado, double iva, double subTotal)
        {
            this.Encargado = encargado;
            this.Vehiculo = vehiculo;
            this.Cliente = cliente;
            this.Fecha = fecha;
            this.FechaEntrega = fechaEntrega;
            this.Prioridad = prioridad;
            this.Observaciones = observaciones;
            this.Estado = estado;
        }

        public int FolioOrden { get => folioOrden; set => folioOrden = value; }
        public Usuario Encargado { get => encargado; set => encargado = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Vehiculo Vehiculo { get => vehiculo; set => vehiculo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime FechaEntrega { get => fechaEntrega; set => fechaEntrega = value; }
        public string Prioridad { get => prioridad; set => prioridad = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public string Estado { get => estado; set => estado = value; }
        public double Iva { get => iva; set => iva = value; }
        public double Total { get => total; set => total = value; }
    }
}
