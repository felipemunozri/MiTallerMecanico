using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class DetalleOrden
    {
        private int folioDetalleOrden;
        private OrdenTrabajo ordenTrabajo;
        private Servicio servicio;
        private Repuesto repuesto;
        private int cantServicio;
        private int cantRepuesto;
        private double subTotal;

        public DetalleOrden()
        {

        }

        public DetalleOrden(OrdenTrabajo ordenTrabajo, Servicio servicio, Repuesto respuesto, int cantServicio, int cantRepuesto, double subTotal)
        {
            this.OrdenTrabajo = ordenTrabajo;
            this.Servicio = servicio;
            this.Repuesto = Repuesto;
            this.CantServicio = cantServicio;
            this.CantRepuesto = cantRepuesto;
            this.SubTotal = subTotal;
        }

        public int FolioDetalleOrden { get => folioDetalleOrden; set => folioDetalleOrden = value; }
        public OrdenTrabajo OrdenTrabajo { get => ordenTrabajo; set => ordenTrabajo = value; }
        public Servicio Servicio { get => servicio; set => servicio = value; }
        public Repuesto Repuesto { get => repuesto; set => repuesto = value; }
        public int CantServicio { get => cantServicio; set => cantServicio = value; }
        public int CantRepuesto { get => cantRepuesto; set => cantRepuesto = value; }
        public double SubTotal { get => subTotal; set => subTotal = value; }
    }
}
