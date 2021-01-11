using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiTallerMecanico
{
    public partial class ConusltarmiVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarOrden.Text.Equals("") || txtBuscarVehiculo.Text.Equals(""))
            {
                Response.Write("<script>alert('Debe ingresar el ID de Orden de Trabajo y la Patente de su vehículo!')</script>");
                limpiarCampos();
            }
            else
            {
                int folioOrden = int.Parse(txtBuscarOrden.Text);
                string patente = txtBuscarVehiculo.Text;

                OrdenTrabajo ordenTrabajo = new OrdenTrabajo();
                NEGOrdenTrabajo negOrdenTrabajo = new NEGOrdenTrabajo();

                ordenTrabajo = negOrdenTrabajo.NEGBuscarOrdenTrabajoPorFolioYPatente(folioOrden, patente);

                if (ordenTrabajo.Vehiculo != null)
                {
                    txtIdOrden.Text = ordenTrabajo.FolioOrden.ToString();
                    txtRutCliente.Text = ordenTrabajo.Cliente.RutCliente;
                    txtPatente.Text = ordenTrabajo.Vehiculo.Patente;
                    txtValorOrden.Text = "$" +  ordenTrabajo.Total.ToString();
                    txtEstado.Text = ordenTrabajo.Estado;

                    txtEstado.ForeColor = Color.White;
                    txtEstado.BackColor = Color.FromArgb(40, 167, 69);
                    SetFocus(txtEstado);
                }
                else
                {
                    Response.Write("<script>alert('ID Orden de Trabajo o Patente incorrectos!')</script>");
                    limpiarCampos();
                }
            }
        }

        private void limpiarCampos()
        {
            txtIdOrden.Text = "";
            txtRutCliente.Text = "";
            txtPatente.Text = "";
            txtEstado.Text = "";
            txtEstado.BackColor = Color.Empty;
        }
    }
}