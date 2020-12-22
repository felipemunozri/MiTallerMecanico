using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiTallerMecanico
{
    public partial class ConsultarOrdenTrabajo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NEGOrdenTrabajo negOrdenTrabajo = new NEGOrdenTrabajo();

            gvResultado.DataSource = negOrdenTrabajo.NEGTablaTodasLasOrdenesDeTrabajo();
            gvResultado.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            string campo = dpCampo.SelectedValue.ToString();

            NEGOrdenTrabajo negOrdenTrabajo = new NEGOrdenTrabajo();

            gvResultado.DataSource = negOrdenTrabajo.NEGTablaOrdenesDeTrabajoFiltradas(campo, filtro);
            gvResultado.DataBind();
        }
    }
}