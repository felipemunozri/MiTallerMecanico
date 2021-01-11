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
    public partial class ModificarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarCliente.Text.Equals(""))
            {
                Response.Write("<script>alert('Debe ingresar un valor de Rut!')</script>");
                limpiarCampos();
            }
            else
            {
                NEGCliente negCliente = new NEGCliente();

                Cliente cliente = new Cliente();
                cliente = negCliente.NEGBuscarClientePorRut(txtBuscarCliente.Text);

                if (cliente.NomCliente != null)
                {
                    txtRutCliente.Text = cliente.RutCliente;
                    txtNomCliente.Text = cliente.NomCliente;
                    txtApeCliente.Text = cliente.ApeCliente;
                    txtDirecCliente.Text = cliente.DirecCliente;
                    txtTelCliente.Text = cliente.TelCliente.ToString();
                    txtMailCliente.Text = cliente.MailCliente;
                }
                else
                {
                    Response.Write("<script>alert('No existe un Cliente para el valor de Rut ingresado!')</script>");
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

        protected void btnModificarCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            cliente.RutCliente = txtRutCliente.Text;
            cliente.NomCliente = txtNomCliente.Text;
            cliente.ApeCliente = txtApeCliente.Text;
            cliente.DirecCliente = txtDirecCliente.Text;
            cliente.TelCliente = int.Parse(txtTelCliente.Text);
            cliente.MailCliente = txtMailCliente.Text;

            NEGCliente negCliente = new NEGCliente();

            if (negCliente.NEGModificarCliente(cliente))
            {
                Response.Write("<script>alert('Cliente modificado correctamente!')</script>");
            }
            else
            {
                Response.Write("<script>alert('No se pudo modificar el cliente!')</script>");
            }
        }

        private void limpiarCampos()
        {
            txtRutCliente.Text = "";
            txtNomCliente.Text = "";
            txtApeCliente.Text = "";
            txtDirecCliente.Text = "";
            txtTelCliente.Text = "";
            txtMailCliente.Text = "";
        }
    }
}