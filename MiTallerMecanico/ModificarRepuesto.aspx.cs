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
    public partial class ModificarRepuesto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarRepuesto.Text.Equals(""))
            {
                Response.Write("<script>alert('Debe ingresar un valor de ID!')</script>");
                limpiarCampos();
            }
            else
            {
                NEGRepuesto negRepuesto = new NEGRepuesto();

                Repuesto repuesto = new Repuesto();
                repuesto = negRepuesto.NEGBuscarRepuestoPorId(int.Parse(txtBuscarRepuesto.Text));

                if (repuesto.NomRepuesto != null)
                {
                    txtNombreRepuesto.Text = repuesto.NomRepuesto;
                }
                else
                {
                    Response.Write("<script>alert('No existe un Repuesto para el valor de ID ingresado!')</script>");
                    limpiarCampos();
                }
            }
        }

        protected void btnModificarRepuesto_Click(object sender, EventArgs e)
        {
            Repuesto repuesto = new Repuesto();

            NEGRepuesto negRepuesto = new NEGRepuesto();

            repuesto.IdRepuesto = int.Parse(txtBuscarRepuesto.Text);
            repuesto.NomRepuesto = txtNombreRepuesto.Text;

            if (negRepuesto.NEGModificarRepuesto(repuesto))
            {
                Response.Write("<script>alert('Repuesto modificado correctamente!')</script>");
            }
            else
            {
                Response.Write("<script>alert('No se pudo modificar el Repuesto!')</script>");
            }
        }

        private void limpiarCampos()
        {
            txtNombreRepuesto.Text = "";
        }
    }
}