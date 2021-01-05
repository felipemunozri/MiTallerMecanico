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
    public partial class RegistrarServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarServicio_Click(object sender, EventArgs e)
        {
            Servicio servicio = new Servicio();

            NEGServicio negServicio = new NEGServicio();

            servicio.NomServicio = txtNombreServicio.Text;
            servicio.ValorServicio = double.Parse(txtValorServicio.Text);

            if (negServicio.NEGRegistarServicio(servicio))
            {
                Response.Write("<script>alert('Servicio registrado correctamente!')</script>");
            }
            else
            {
                Response.Write("<script>alert('No se pudo registrar el Servicio!')</script>");
            }
        }
    }
}