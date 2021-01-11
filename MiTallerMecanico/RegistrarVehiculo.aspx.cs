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
    public partial class RegistrarVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void btnRegistrarVehiculo_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = new Vehiculo();

            NEGCliente negCliente = new NEGCliente();

            vehiculo.Patente = txtPatente.Text.ToUpper();
            vehiculo.Cliente = negCliente.NEGBuscarClientePorRut(txtRutCliente.Text);
            vehiculo.TipoVehiculo = txtTipoVehiculo.Text.ToUpper();
            vehiculo.Marca = txtMarca.Text.ToUpper();
            vehiculo.Modelo = txtModelo.Text.ToUpper();
            vehiculo.Ano = int.Parse(txtAno.Text);
            vehiculo.Kilometraje = double.Parse(txtKilometraje.Text);

            NEGVehiculo negVehiculo = new NEGVehiculo();

            if (negVehiculo.NEGRegistrarVehiculo(vehiculo))
            {
                Response.Write("<script>alert('Vehículo registrado correctamente!')</script>");
            }
            else
            {
                Response.Write("<script>alert('No se pudo registrar el Vehículo!')</script>");
            }
        }
    }
}