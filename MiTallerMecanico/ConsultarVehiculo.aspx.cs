using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiTallerMecanico
{
    public partial class ConsultarVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NEGVehiculo negVehiculo = new NEGVehiculo();

            gvResultado.DataSource = negVehiculo.NEGTablaTodosLosVehiculos();
            gvResultado.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            string campo = dpCampo.SelectedValue.ToString();

            NEGVehiculo negVehiculo = new NEGVehiculo();

            gvResultado.DataSource = negVehiculo.NEGTablaVehiculosFiltrados(campo, filtro);
            gvResultado.DataBind();
        }
    }
}