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

        public bool filtarMenuNavegacionSegunTipoUsuario()
        {
            int idTipoUsuario = ((Usuario)Session["usuarioConectado"]).TipoUsuario.IdTipoUsuario;

            if (idTipoUsuario == 1) 
            { 
                return true;
            }
            else
            { 
                return false;
            }
        }
    }
}