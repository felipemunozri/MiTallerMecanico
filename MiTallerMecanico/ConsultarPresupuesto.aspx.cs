using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiTallerMecanico
{
    public partial class ConsultarPresupuesto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NEGEncabezadoPresupuesto negEncPresupuesto = new NEGEncabezadoPresupuesto();

            gvResultado.DataSource = negEncPresupuesto.NEGTablaTodosEncPresupuesto();
            gvResultado.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            string campo = dpCampo.SelectedValue.ToString();

            NEGEncabezadoPresupuesto negEncPresupuesto = new NEGEncabezadoPresupuesto();

            gvResultado.DataSource = negEncPresupuesto.NEGTablaEncPresupuestoFiltrados(campo, filtro);
            gvResultado.DataBind();
        }
    }
}