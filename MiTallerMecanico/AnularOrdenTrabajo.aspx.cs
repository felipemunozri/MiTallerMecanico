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
    public partial class EliminarOrdenTrabajo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {
            Validacion val = new Validacion();

            NEGOrdenTrabajo negOrdenTrabajo = new NEGOrdenTrabajo();

            OrdenTrabajo ordenTrabajo = new OrdenTrabajo();

            ordenTrabajo = negOrdenTrabajo.NEGBuscarOrdenTrabajoPorFolio(int.Parse(val.validarEspacios(txtFolioOrden.Text)));

            if (ordenTrabajo.Cliente != null)
            {
                if (ordenTrabajo.Estado.Equals("Listo para retiro") || ordenTrabajo.Estado.Equals("Entregado") || ordenTrabajo.Estado.Equals("Anulada"))
                {
                    Response.Write("<script>alert('ERROR: La Orden de Trabajo referida ya fue completada o anulada previamente!')</script>");
                }
                else
                {
                    if (negOrdenTrabajo.NEGAnularOrdenTrabajo(ordenTrabajo))
                    {
                        Response.Write("<script>alert('Orden de Trabajo anulada correctamente!')</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('No existe una Orden de Trabajo asociada al ID ingresado!')</script>");
            }
        }
    }
}