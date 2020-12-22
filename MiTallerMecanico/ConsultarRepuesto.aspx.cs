using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiTallerMecanico
{
    public partial class ConsultarRepuesto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NEGRepuesto negRepuesto = new NEGRepuesto();

            gvResultado.DataSource = negRepuesto.NEGTablaTodosLosRepuestos();
            gvResultado.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            string campo = dpCampo.SelectedValue.ToString();

            NEGRepuesto negRepuesto = new NEGRepuesto();

            gvResultado.DataSource = negRepuesto.NEGTablaRepuestosFiltrados(campo, filtro);
            gvResultado.DataBind();
        }
    }
}