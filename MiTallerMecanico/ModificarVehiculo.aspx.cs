using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiTallerMecanico
{
    public partial class ModificarVehiculo : System.Web.UI.Page
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
            }
        }

        protected void txtRutCliente_TextChanged(object sender, EventArgs e)
        {
            Validacion valida = new Validacion();

            if (!valida.validarRut(txtRutCliente.Text))
            {
                Response.Write("<script>alert('Vuelva a ingresar el rut!')</script>");
                txtRutCliente.Text = "";
            }
        }

        protected void btnModificarVehiculo_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = new Vehiculo();

            NEGCliente negCliente = new NEGCliente();

            vehiculo.Cliente = negCliente.NEGBuscarClientePorRut(txtRutCliente.Text);
            vehiculo.Patente = txtPatente.Text.ToUpper();
            vehiculo.Marca = txtMarca.Text;
            vehiculo.Modelo = txtModelo.Text;
            vehiculo.TipoVehiculo = txtTipoVehiculo.Text;
            vehiculo.Ano = int.Parse(txtAno.Text);
            vehiculo.Kilometraje = double.Parse(txtKilometraje.Text);

            NEGVehiculo negVehiculo = new NEGVehiculo();

            if (negVehiculo.NEGModificarVehiculo(vehiculo))
            {
                Response.Write("<script>alert('Vehículo modificado correctamente!')</script>");
            }
            else
            {
                Response.Write("<script>alert('No se pudo modificar el Vehículo!')</script>");
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