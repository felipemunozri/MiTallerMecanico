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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string nomUsuario = txtNomUsuario.Text.ToUpper();
            string passUsuario = txtPassUsuario.Text;

            Usuario usuario = new Usuario(nomUsuario, passUsuario);

            NEGUsuario negUsuario = new NEGUsuario();

            if (negUsuario.NEGValidarUsuario(usuario))
            {
                usuario = negUsuario.NEGBuscarUsuarioPorId

                Session["usuarioConectado"] = usuario;

                Response.Redirect("Inicio.aspx");
            }
            else
            {
                Response.Write("<script>alert('Nombre de Usuario o Contraseña incorrectos!');</script>");
            }
        }
    }
}