using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiTallerMecanico
{
    public partial class ConsultarTipoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NEGTipoUsuario negTipoUsuario = new NEGTipoUsuario();

            gvResultado.DataSource = negTipoUsuario.NEGTablaTodosLosTiposUsuario();
            gvResultado.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            string campo = dpCampo.SelectedValue.ToString();

            NEGTipoUsuario negTipoUsuario = new NEGTipoUsuario();

            gvResultado.DataSource = negTipoUsuario.NEGTablaTiposUsuarioFiltrados(campo, filtro);
            gvResultado.DataBind();
        }
    }
}