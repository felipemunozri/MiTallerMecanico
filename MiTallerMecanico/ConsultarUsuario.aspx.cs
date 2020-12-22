using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiTallerMecanico
{
    public partial class ConsultarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NEGUsuario negUsuario = new NEGUsuario();

            gvResultado.DataSource = negUsuario.NEGTablaTodosLosUsuarios();
            gvResultado.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            string campo = dpCampo.SelectedValue.ToString();

            NEGUsuario negUsuario = new NEGUsuario();

            gvResultado.DataSource = negUsuario.NEGTablaUsuariosFiltrados(campo, filtro);
            gvResultado.DataBind();
        }
    }
}