using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiTallerMecanico
{
    public partial class ConusltarServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NEGServicio negServicio = new NEGServicio();

            gvResultado.DataSource = negServicio.NEGTablaTodosLosServicios();
            gvResultado.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            string campo = dpCampo.SelectedValue.ToString();

            NEGServicio negServicio = new NEGServicio();

            gvResultado.DataSource = negServicio.NEGTablaServiciosFiltrados(campo, filtro);
            gvResultado.DataBind();
        }
    }
}