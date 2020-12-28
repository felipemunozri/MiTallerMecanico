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
    public partial class ModificarUsuario : System.Web.UI.Page
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarUsuario.Text.Equals(""))
            {
                Response.Write("<script>alert('Debe ingresar un valor de ID!')</script>");
                limpiarCampos();
            }
            else
            {
                NEGUsuario negUsuario = new NEGUsuario();

                Usuario usuario = new Usuario();
                usuario = negUsuario.NEGBuscarUsuarioPorId(int.Parse(txtBuscarUsuario.Text));

                if (usuario.NomUsuario != null)
                {
                    dpTipoUsuario.SelectedValue = usuario.TipoUsuario.IdTipoUsuario.ToString();
                    txtNomUsuario.Text = usuario.NomUsuario;
                    txtPassUsuario.Text = usuario.PassUsuario;
                }
                else
                {
                    Response.Write("<script>alert('No existe un Usuario para el valor de ID ingresado!')</script>");
                    limpiarCampos();
                }
            }
        }

        protected void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
    
            NEGTipoUsuario negTipoUsuario = new NEGTipoUsuario();

            usuario.IdUsuario = int.Parse(txtBuscarUsuario.Text);
            usuario.TipoUsuario = negTipoUsuario.NEGBuscarTipoUsuarioPorId(int.Parse(dpTipoUsuario.SelectedValue));
            usuario.NomUsuario = txtNomUsuario.Text.ToUpper();
            usuario.PassUsuario = txtPassUsuario.Text.ToUpper();

            NEGUsuario negUsuario = new NEGUsuario();

            if (negUsuario.NEGModificarUsuario(usuario))
            {
                Response.Write("<script>alert('Usuario modificado correctamente!')</script>");
            }
            else
            {
                Response.Write("<script>alert('No se pudo modificar el Usuario!')</script>");
            }
        }

        private void limpiarCampos()
        {
            txtNomUsuario.Text = "";
            txtPassUsuario.Text = "";
        }
    }
}