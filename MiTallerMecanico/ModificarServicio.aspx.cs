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
    public partial class ModificarServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarServicio.Text.Equals(""))
            {
                Response.Write("<script>alert('Debe ingresar un valor de ID!')</script>");
                limpiarCampos();
            }
            else
            {
                NEGServicio negServicio = new NEGServicio();

                Servicio servicio = new Servicio();
                servicio = negServicio.NEGBuscarServicioPorId(int.Parse(txtBuscarServicio.Text));

                if (servicio.NomServicio != null)
                {
                    txtNombreServicio.Text = servicio.NomServicio;
                }
                else
                {
                    Response.Write("<script>alert('No existe un Servicio para el valor de ID ingresado!')</script>");
                    limpiarCampos();
                }
            }
        }

        protected void btnModificarServicio_Click(object sender, EventArgs e)
        {
            Servicio servicio = new Servicio();

            NEGServicio negServicio = new NEGServicio();

            servicio.IdServicio = int.Parse(txtBuscarServicio.Text);
            servicio.NomServicio = txtNombreServicio.Text;

            if (negServicio.NEGModificarServicio(servicio))
            {
                Response.Write("<script>alert('Servicio modificado correctamente!')</script>");
            }
            else
            {
                Response.Write("<script>alert('No se pudo modificar el Servicio!')</script>");
                limpiarCampos();
            }
        }

        private void limpiarCampos()
        {
            txtNombreServicio.Text = "";
        }
    }
}