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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            NEGOrdenTrabajo negOrdenTrabajo = new NEGOrdenTrabajo();

            OrdenTrabajo ordenTrabajo = new OrdenTrabajo();

            ordenTrabajo = negOrdenTrabajo.NEGBuscarOrdenTrabajoPorFolio(int.Parse(txtFolioOrden.Text));

            if (ordenTrabajo.Cliente != null)
            {
                if (negOrdenTrabajo.NEGEliminarOrdenTrabajo(ordenTrabajo))
                {
                    Response.Write("<script>alert('Orden de Trabajo eliminada correctamente!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('No se pudo eliminar la Orden de Trabajo!')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('No existe una Orden de Trabajo asociada al ID ingresado!')</script>");
            }
        }
    }
}