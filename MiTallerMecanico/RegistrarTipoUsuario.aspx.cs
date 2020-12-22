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
    public partial class RegistrarTipoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarTipoUsuario_Click(object sender, EventArgs e)
        {
            TipoUsuario tipoUsuario = new TipoUsuario();

            tipoUsuario.Cargo = txtCargo.Text.ToUpper();

            NEGTipoUsuario negTipoUsuario = new NEGTipoUsuario();

            if (negTipoUsuario.NEGRegistarTipoUsuario(tipoUsuario))
            {
                Response.Write("<script>alert('Tipo de Usuario registrado correctamente!')</script>");
            }
            else
            {
                Response.Write("<script>alert('No se pudo registrar el Tipo de Usuario!')</script>");
            }
        }
    }
}