using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiTallerMecanico
{
    public partial class EliminarPresupuesto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            NEGEncabezadoPresupuesto negEncPresupuesto = new NEGEncabezadoPresupuesto();
            NEGDetallePresupuesto negDetPresupuesto = new NEGDetallePresupuesto();

            EncabezadoPresupuesto encPresupuesto = new EncabezadoPresupuesto();

            encPresupuesto = negEncPresupuesto.NEGBuscarEncPresupuestoPorFolio(int.Parse(txtfolioPrepuesto.Text));

            if (encPresupuesto.RutCliente != null)
            {
                if (negDetPresupuesto.NEGEliminarDetPresupuesto(encPresupuesto))
                {
                    if (negEncPresupuesto.NEGEliminarEncPresupuesto(encPresupuesto))
                    {
                        Response.Write("<script>alert('Presupuesto eliminado correctamente!')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('No se pudo eliminar el Presupuesto!')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('No existe un Presupuesto asociado al ID ingresado!')</script>");
            }
        }
    }
}