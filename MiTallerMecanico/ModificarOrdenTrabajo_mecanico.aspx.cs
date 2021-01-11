using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiTallerMecanico
{
    public partial class ModificarOrdenMecanico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarVehiculo.Text.Equals(""))
            {
                Response.Write("<script>alert('Debe ingresar la Patente del vehículo!')</script>");
                limpiarCampos();
            }
            else
            {
                NEGOrdenTrabajo negOrdenTrabajo = new NEGOrdenTrabajo();

                OrdenTrabajo ordenTrabajo = new OrdenTrabajo();
                ordenTrabajo = negOrdenTrabajo.NEGBuscarOrdenTrabajoPorPatenteYEstado(txtBuscarVehiculo.Text);

                if (ordenTrabajo.Cliente != null)
                {
                    txtIdOrden.Text = ordenTrabajo.FolioOrden.ToString();
                    txtPatente.Text = ordenTrabajo.Vehiculo.Patente;
                    txtMarca.Text = ordenTrabajo.Vehiculo.Marca;
                    txtModelo.Text = ordenTrabajo.Vehiculo.Modelo;
                    dpEstado.SelectedValue = ordenTrabajo.Estado;

                    dpEstado.ForeColor = Color.FromArgb(0, 0, 139);

                    SetFocus(dpEstado);
                }
                else
                {
                    Response.Write("<script>alert('No existen ordenes pendientes para la Patente de vehículo ingresada!')</script>");
                    limpiarCampos();
                }
            }
        }

        protected void btnModificarOrdenTrabajo_Click(object sender, EventArgs e)
        {
            NEGOrdenTrabajo negOrdenTrabajo = new NEGOrdenTrabajo();

            OrdenTrabajo ordenTrabajo = new OrdenTrabajo();
            ordenTrabajo = negOrdenTrabajo.NEGBuscarOrdenTrabajoPorFolio(int.Parse(txtIdOrden.Text));

            ordenTrabajo.Estado = dpEstado.SelectedValue;
            
            if (negOrdenTrabajo.NEGModificarOrdenTrabajo(ordenTrabajo))
            {
                Response.Write("<script>alert('Orden de Trabajo modificada correctamente!')</script>");
            }
            else
            {
                Response.Write("<script>alert('No se pudo modificar la Orden de Trabajo!')</script>");
            }
        }

        private void limpiarCampos()
        {
            txtPatente.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            dpEstado.SelectedValue = "";
        }
    }
}