using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class DetallePresupuesto
    {
        private int folioDetalle;
        private EncabezadoPresupuesto encabezadoPresupuesto;
        private Servicio servicio;
        private Repuesto repuesto;
        private int cantServicio;
        private int cantRepuesto;
        private double subTotal;
        private double iva;
        private double total;

        public DetallePresupuesto()
        {

        }

        public DetallePresupuesto(EncabezadoPresupuesto encabezadoPresupuesto, Servicio servicio, Repuesto repuesto, int cantServicio, int cantRepuesto, double subTotal, double iva, double total)
        {
            this.EncabezadoPresupuesto = encabezadoPresupuesto;
            this.Servicio = servicio;
            this.Repuesto = repuesto;
            this.CantServicio = cantServicio;
            this.CantRepuesto = cantRepuesto;
            this.SubTotal = subTotal;
            this.Iva = iva;
            this.Total = total;
        }

        public int FolioDetalle { get => folioDetalle; set => folioDetalle = value; }
        public EncabezadoPresupuesto EncabezadoPresupuesto { get => encabezadoPresupuesto; set => encabezadoPresupuesto = value; }
        public Servicio Servicio { get => servicio; set => servicio = value; }
        public Repuesto Repuesto { get => repuesto; set => repuesto = value; }
        public int CantServicio { get => cantServicio; set => cantServicio = value; }
        public int CantRepuesto { get => cantRepuesto; set => cantRepuesto = value; }
        public double SubTotal { get => subTotal; set => subTotal = value; }
        public double Iva { get => iva; set => iva = value; }
        public double Total { get => total; set => total = value; } 
    }
}
