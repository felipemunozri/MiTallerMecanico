using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiTallerMecanico
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        public bool filtarMenuNavegacionSegunTipoUsuario(string nombreMenu)
        {
            int idTipoUsuario = ((Usuario)Session["usuarioConectado"]).TipoUsuario.IdTipoUsuario;

            if (nombreMenu == "menuAdmin")
            {
                if (idTipoUsuario == 3)
                    return false;
            }
            else if (nombreMenu == "menuMecanico")
            {
                if (idTipoUsuario == 1 || idTipoUsuario == 2)
                    return false;
            }
            return true;
        }
    }
}