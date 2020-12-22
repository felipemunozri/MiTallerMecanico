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
    public partial class RegistrarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            cliente.RutCliente = txtRutCliente.Text;
            cliente.NomCliente = txtNomCliente.Text;
            cliente.ApeCliente = txtApeCliente.Text;
            cliente.DirecCliente = txtDirecCliente.Text;
            cliente.TelCliente = int.Parse(txtTelCliente.Text);
            cliente.MailCliente = txtMailCliente.Text;

            NEGCliente negCliente = new NEGCliente();

            if (negCliente.NEGRegistarCliente(cliente))
            {
                Response.Write("<script>alert('Cliente registrado correctamente!')</script>");
            }
            else
            {
                Response.Write("<script>alert('No se pudo registrar el cliente!')</script>");
            }
        }
    }
}