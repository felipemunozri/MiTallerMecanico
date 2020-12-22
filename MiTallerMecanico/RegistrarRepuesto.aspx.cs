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
    public partial class RegistrarRepuesto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarRepuesto_Click(object sender, EventArgs e)
        {
            Repuesto repuesto = new Repuesto();

            NEGRepuesto negRepuesto = new NEGRepuesto();

            repuesto.NomRepuesto = txtNombreRepuesto.Text;

            if (negRepuesto.NEGRegistarRepuesto(repuesto))
            {
                Response.Write("<script>alert('Repuesto registrado correctamente!')</script>");
            }
            else
            {
                Response.Write("<script>alert('No se pudo registrar el Repuesto!')</script>");
            }
        }
    }
}