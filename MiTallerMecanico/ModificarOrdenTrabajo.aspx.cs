using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiTallerMecanico
{
    public partial class ModificarOrdenTrabajo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NEGUsuario negUsuario = new NEGUsuario();
                DataTable tablaUsuarios = negUsuario.NEGTablaTodosLosUsuarios();

                dpNomUsuario.DataSource = tablaUsuarios;
                dpNomUsuario.DataTextField = "nombreUsuario";
                dpNomUsuario.DataValueField = "idUsuario";
                dpNomUsuario.DataBind();

                NEGServicio negServicio = new NEGServicio();
                DataTable tablaServicios = negServicio.NEGTablaTodosLosServicios();

                dpSelecServicio.DataSource = tablaServicios;
                dpSelecServicio.DataTextField = "nombreServicio";
                dpSelecServicio.DataValueField = "idServicio";
                dpSelecServicio.DataBind();

                NEGRepuesto negRepuesto = new NEGRepuesto();
                DataTable tablaRepuestos = negRepuesto.NEGTablaTodosLosRepuestos();

                dpSelecRepuesto.DataSource = tablaRepuestos;
                dpSelecRepuesto.DataTextField = "nombreRepuesto";
                dpSelecRepuesto.DataValueField = "idRepuesto";
                dpSelecRepuesto.DataBind();

                DataTable tablaSeleccion = new DataTable();

                tablaSeleccion.Columns.Add("Codigo");
                tablaSeleccion.Columns.Add("Servicio o Repuesto");
                tablaSeleccion.Columns.Add("Valor unitario");
                tablaSeleccion.Columns.Add("Cantidad");
                tablaSeleccion.Columns.Add("Subtotal");
                Session["dtSeleccion"] = tablaSeleccion;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarOrdenTrabajo.Text.Equals(""))
            {
                Response.Write("<script>alert('Debe ingresar un valor de ID!')</script>");
                limpiarCampos();
            }
            else
            {
                NEGOrdenTrabajo negOrdenTrabajo = new NEGOrdenTrabajo();

                OrdenTrabajo ordenTrabajo = new OrdenTrabajo();
                ordenTrabajo = negOrdenTrabajo.NEGBuscarOrdenTrabajoPorFolio(int.Parse(txtBuscarOrdenTrabajo.Text));

                if (ordenTrabajo.Cliente != null)
                {
                    NEGUsuario negUsuario = new NEGUsuario();
                    Usuario usuario = new Usuario();
                    usuario = negUsuario.NEGBuscarUsuarioPorId(ordenTrabajo.Encargado.IdUsuario);

                    dpNomUsuario.SelectedValue = usuario.IdUsuario.ToString();
                    txtFecha.Text = ordenTrabajo.Fecha.ToString("yyyy-MM-dd");
                    txtFechaEntrega.Text = ordenTrabajo.FechaEntrega.ToString("yyyy-MM-dd");
                    dpPrioridad.SelectedValue = ordenTrabajo.Prioridad;
                    txtObservaciones.Text = ordenTrabajo.Observaciones;
                    dpEstado.SelectedValue = ordenTrabajo.Estado;

                    txtPatente.Text = ordenTrabajo.Vehiculo.Patente;
                    txtMarca.Text = ordenTrabajo.Vehiculo.Marca;
                    txtModelo.Text = ordenTrabajo.Vehiculo.Modelo;
                    txtTipoVehiculo.Text = ordenTrabajo.Vehiculo.TipoVehiculo;
                    txtAno.Text = ordenTrabajo.Vehiculo.Ano.ToString();
                    txtKilometraje.Text = ordenTrabajo.Vehiculo.Kilometraje.ToString();

                    txtRutCliente.Text = ordenTrabajo.Cliente.RutCliente;
                    txtNomCliente.Text = ordenTrabajo.Cliente.NomCliente;
                    txtApeCliente.Text = ordenTrabajo.Cliente.ApeCliente;
                    txtDirecCliente.Text = ordenTrabajo.Cliente.DirecCliente;
                    txtTelCliente.Text = ordenTrabajo.Cliente.TelCliente.ToString();
                    txtMailCliente.Text = ordenTrabajo.Cliente.MailCliente;

                    txtMontoIVA.Text = ordenTrabajo.Iva.ToString("N2");
                    txtMontoTotal.Text = ordenTrabajo.Total.ToString("N2");

                    NEGDetalleOrden negDetalleOrden = new NEGDetalleOrden();

                    Session["dtSeleccion"] = negDetalleOrden.NEGTablaServiciosYRepuestosEnDetOrdenPorFolioOrdenTrabajo(int.Parse(txtBuscarOrdenTrabajo.Text));

                    gvSeleccion.DataSource = (DataTable)Session["dtSeleccion"];
                    gvSeleccion.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('No existe un documento para el valor de ID ingresado!')</script>");
                    limpiarCampos();
                }
            }
        }

        protected void txtPatente_TextChanged(object sender, EventArgs e)
        {
            Vehiculo vehiculo = new Vehiculo();

            NEGVehiculo negVehiculo = new NEGVehiculo();

            vehiculo = negVehiculo.NEGBuscarVehiculoPorPatente(txtPatente.Text);

            if (vehiculo.Cliente != null)
            {
                txtRutCliente.Text = vehiculo.Cliente.RutCliente;
                SetFocus(txtFecha);
            }
            else
            {
                txtRutCliente.Text = "";
                SetFocus(txtRutCliente);
            }
        }

        protected void btnAgregaServicio_Click(object sender, EventArgs e)
        {
            if (txtCantServicios.Text.Equals("") || txtValorServicio.Text.Equals(""))
            {
                Response.Write("<script>alert('Ingrese una cantidad y un valor!')</script>");
                SetFocus(txtCantServicios);
            }
            else
            {
                int idServicio = int.Parse(dpSelecServicio.SelectedValue);
                string nomServicio = dpSelecServicio.SelectedItem.Text;
                int cantServicio = int.Parse(txtCantServicios.Text);
                int valorServicio = int.Parse(txtValorServicio.Text);

                int subTotal = cantServicio * valorServicio;

                ((DataTable)Session["dtSeleccion"]).Rows.Add(idServicio, nomServicio, valorServicio, cantServicio, subTotal);

                gvSeleccion.DataSource = (DataTable)Session["dtSeleccion"];
                gvSeleccion.DataBind();

                double montoIVA = double.Parse(txtMontoIVA.Text) / 0.19;
                montoIVA = montoIVA + subTotal;

                txtMontoIVA.Text = (montoIVA * 0.19).ToString();
                txtMontoTotal.Text = (montoIVA + double.Parse(txtMontoIVA.Text)).ToString();

                SetFocus(gvSeleccion);
            }
        }

        protected void btnAgregaRepuesto_Click(object sender, EventArgs e)
        {
            if (txtCantRepuestos.Text.Equals("") || txtValorRepuesto.Text.Equals(""))
            {
                Response.Write("<script>alert('Ingrese una cantidad y un valor!')</script>");
                SetFocus(txtCantRepuestos);
            }
            else
            {
                int idRepuesto = int.Parse(dpSelecRepuesto.SelectedValue);
                string nomRepuesto = dpSelecRepuesto.SelectedItem.Text;
                int cantRepuesto = int.Parse(txtCantRepuestos.Text);
                int valorRepuesto = int.Parse(txtValorRepuesto.Text);

                int subTotal = cantRepuesto * valorRepuesto;

                ((DataTable)Session["dtSeleccion"]).Rows.Add(idRepuesto, nomRepuesto, valorRepuesto, cantRepuesto, subTotal);

                gvSeleccion.DataSource = (DataTable)Session["dtSeleccion"];
                gvSeleccion.DataBind();

                double montoIVA = double.Parse(txtMontoIVA.Text) / 0.19;
                montoIVA = montoIVA + subTotal;

                txtMontoIVA.Text = (montoIVA * 0.19).ToString();
                txtMontoTotal.Text = (montoIVA + double.Parse(txtMontoIVA.Text)).ToString();

                SetFocus(gvSeleccion);
            }
        }

        protected void gvSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow filaSeleccionada = gvSeleccion.SelectedRow;

            string subTotal = filaSeleccionada.Cells[5].Text;

            double montoIVA = double.Parse(txtMontoIVA.Text) / 0.19;
            montoIVA = montoIVA - int.Parse(subTotal);

            txtMontoIVA.Text = (montoIVA * 0.19).ToString();
            txtMontoTotal.Text = (montoIVA + double.Parse(txtMontoIVA.Text)).ToString();

            int fila = filaSeleccionada.RowIndex;
            ((DataTable)Session["dtSeleccion"]).Rows.RemoveAt(fila);

            gvSeleccion.DataSource = (DataTable)Session["dtSeleccion"];
            gvSeleccion.DataBind();

            SetFocus(gvSeleccion);
        }

        protected void btnModificarOrdenTrabajo_Click(object sender, EventArgs e)
        {
            bool flagRegistroOrden = false;
            bool flagRegistroDetalleOrden = false;
            int idOrdenInsertada = 0;

            //CODIGO PARA MODIFICAR LA ORDEN DE TRABAJO
            OrdenTrabajo ordenTrabajo = new OrdenTrabajo();

            NEGUsuario negUsuario = new NEGUsuario();
            NEGCliente negCliente = new NEGCliente();
            NEGVehiculo negVehiculo = new NEGVehiculo();

            ordenTrabajo.Encargado = negUsuario.NEGBuscarUsuarioPorId(int.Parse(dpNomUsuario.SelectedValue));
            ordenTrabajo.Cliente = negCliente.NEGBuscarClientePorRut(txtRutCliente.Text);
            ordenTrabajo.Vehiculo = negVehiculo.NEGBuscarVehiculoPorPatente(txtPatente.Text.ToUpper());
            ordenTrabajo.Fecha = DateTime.Parse(txtFecha.Text);
            ordenTrabajo.FechaEntrega = DateTime.Parse(txtFechaEntrega.Text);
            ordenTrabajo.Prioridad = dpPrioridad.SelectedValue; //podria venir de una tabla en bd??
            ordenTrabajo.Observaciones = txtObservaciones.Text;
            ordenTrabajo.Estado = dpEstado.SelectedValue; //podria ser txtbox o el estado podria venir de una tabla en bd??

            NEGOrdenTrabajo negOrdenTrabajo = new NEGOrdenTrabajo();
            flagRegistroOrden = negOrdenTrabajo.NEGModificarOrdenTrabajo(ordenTrabajo);

            //CODIGO PARA MODIFICAR EL DETALLE DE LA ORDEN DE TRABAJO

            if (gvSeleccion.Rows.Count != 0)
            {
                for (int i = 0; i < gvSeleccion.Rows.Count; i++)
                {
                    DetalleOrden detalleOrden = new DetalleOrden();

                    NEGServicio negServicio = new NEGServicio();
                    NEGRepuesto negRepuesto = new NEGRepuesto();

                    detalleOrden.OrdenTrabajo = negOrdenTrabajo.NEGBuscarOrdenTrabajoPorFolio(idOrdenInsertada);
                    detalleOrden.Servicio = negServicio.NEGBuscarServicioPorId(int.Parse(gvSeleccion.Rows[i].Cells[1].Text));
                    detalleOrden.Repuesto = negRepuesto.NEGBuscarRepuestoPorId(int.Parse(gvSeleccion.Rows[i].Cells[1].Text));
                    detalleOrden.CantServicio = int.Parse(gvSeleccion.Rows[i].Cells[4].Text);
                    detalleOrden.CantRepuesto = int.Parse(gvSeleccion.Rows[i].Cells[4].Text);
                    detalleOrden.SubTotal = int.Parse(gvSeleccion.Rows[i].Cells[5].Text);

                    NEGDetalleOrden negDetalleOrden = new NEGDetalleOrden();
                    flagRegistroDetalleOrden = negDetalleOrden.NEGModificarDetOrden(detalleOrden);
                }
            }
            else
            {
                Response.Write("<script>alert('Debe ingresar al menos un servicio o repuesto antes de registar una orden de trabajo!')</script>");
            }


            if (flagRegistroOrden == true && flagRegistroDetalleOrden == true)
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
            //FALTA IMPLEMENTAR!!!
        }
    }
}