using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiTallerMecanico
{
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NEGTipoUsuario negTipoUsuario = new NEGTipoUsuario();
                DataTable tablaTipoUsuarios = negTipoUsuario.NEGTablaTodosLosTiposUsuario();

                dpTipoUsuario.DataSource = tablaTipoUsuarios;
                dpTipoUsuario.DataTextField = "cargo";
                dpTipoUsuario.DataValueField = "idTipoUsuario";
                dpTipoUsuario.DataBind();
            }
        }

        protected void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            NEGTipoUsuario negTipoUsuario = new NEGTipoUsuario();

            usuario.TipoUsuario = negTipoUsuario.NEGBuscarTipoUsuarioPorId(int.Parse(dpTipoUsuario.SelectedValue));
            usuario.NomUsuario = txtNomUsuario.Text.ToUpper();
            usuario.PassUsuario = txtPassUsuario.Text;

            NEGUsuario negUsuario = new NEGUsuario();

            if (negUsuario.NEGRegistrarUsuario(usuario))
            {
                Response.Write("<script>alert('Usuario registrado correctamente!')</script>");
            }
            else
            {
                Response.Write("<script>alert('No se pudo registrar el usuario!')</script>");
            }
        }
    }
}