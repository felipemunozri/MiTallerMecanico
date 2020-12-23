using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace MiTallerMecanico
{
    public partial class ConsultarMiVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarVehiculo.Text.Equals(""))
            {
                Response.Write("<script>alert('Debe ingresar un valor de Patente!')</script>");
                limpiarCampos();
            }
            else
            {
                NEGVehiculo negVehiculo = new NEGVehiculo();

                Vehiculo vehiculo = new Vehiculo();
                vehiculo = negVehiculo.NEGBuscarVehiculoPorPatente(txtBuscarVehiculo.Text);

                NEGOrdenTrabajo negOrdenTrabajo = new NEGOrdenTrabajo();

                OrdenTrabajo ordenTrabajo = new OrdenTrabajo();
                ordenTrabajo = negOrdenTrabajo.NEGBuscarOrdenTrabajoPorPatente(txtBuscarVehiculo.Text);

                if (vehiculo.Marca != null)
                {
                    txtRutCliente.Text = vehiculo.Cliente.RutCliente;
                    txtPatente.Text = vehiculo.Patente;
                    txtMarca.Text = vehiculo.Marca;
                    txtModelo.Text = vehiculo.Modelo;
                    txtTipoVehiculo.Text = vehiculo.TipoVehiculo;
                    txtAno.Text = vehiculo.Ano.ToString();
                    txtKilometraje.Text = vehiculo.Kilometraje.ToString("N2");
                }
                else
                {
                    Response.Write("<script>alert('No existe un Vehículo para el valor de Patente ingresado!')</script>");
                    limpiarCampos();
                }

                if (ordenTrabajo.Vehiculo != null)
                {
                    txtEstado.Text = ordenTrabajo.Estado;
                    txtEstado.BackColor = Color.FromArgb(127,255,0);
                    SetFocus(txtEstado);
                }
                else
                {
                    Response.Write("<script>alert('No existe una Orden de Trabajo asociada a la Patente de vehiculo ingresada!')</script>");
                    limpiarCampos();
                }

            }
        }

        private void limpiarCampos()
        {
            txtRutCliente.Text = "";
            txtPatente.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtTipoVehiculo.Text = "";
            txtAno.Text = "";
            txtKilometraje.Text = "";
        }
    }
}