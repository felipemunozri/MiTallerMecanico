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
    public partial class RegistrarOrdenTrabajo : System.Web.UI.Page
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

        protected void txtPatente_TextChanged(object sender, EventArgs e)
        {
            Vehiculo vehiculo = new Vehiculo();

            NEGVehiculo negVehiculo = new NEGVehiculo();

            vehiculo = negVehiculo.NEGBuscarVehiculoPorPatente(txtPatente.Text);

            if (vehiculo.Cliente != null)
            {
                txtMarca.Text = vehiculo.Marca;
                txtModelo.Text = vehiculo.Modelo;
                txtTipoVehiculo.Text = vehiculo.TipoVehiculo;
                txtAno.Text = vehiculo.Ano.ToString();
                txtKilometraje.Text = vehiculo.Kilometraje.ToString();

                txtRutCliente.Text = vehiculo.Cliente.RutCliente;
                txtNomCliente.Text = vehiculo.Cliente.NomCliente;
                txtApeCliente.Text = vehiculo.Cliente.ApeCliente;
                txtDirecCliente.Text = vehiculo.Cliente.DirecCliente;
                txtTelCliente.Text = vehiculo.Cliente.TelCliente.ToString();
                txtMailCliente.Text = vehiculo.Cliente.MailCliente;

                SetFocus(dpSelecServicio);
            }
            else
            {
                limpiarCamposVehiculo();
                SetFocus(txtMarca);
            }
        }

        protected void txtRutCliente_TextChanged(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            NEGCliente negCliente = new NEGCliente();

            cliente = negCliente.NEGBuscarClientePorRut(txtRutCliente.Text);

            if (cliente.NomCliente != null)
            {
                txtNomCliente.Text = cliente.NomCliente;
                txtApeCliente.Text = cliente.ApeCliente;
                txtDirecCliente.Text = cliente.DirecCliente;
                txtTelCliente.Text = cliente.TelCliente.ToString();
                txtMailCliente.Text = cliente.MailCliente;

                SetFocus(dpSelecServicio);
            }
            else
            {
                limpiarCamposCliente();
                SetFocus(txtNomCliente);
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

        protected void btnRegistrarOrdenTrabajo_Click(object sender, EventArgs e)
        {
            bool flagRegistroOrden = false;
            bool flagRegistroDetalleOrden = false;
            int idOrdenInsertada = 0;

            //CODIGO PARA REGISTRAR CLIENTE
            Cliente cliente = new Cliente();

            cliente.RutCliente = txtRutCliente.Text;
            cliente.NomCliente = txtNomCliente.Text;
            cliente.ApeCliente = txtApeCliente.Text;
            cliente.DirecCliente = txtDirecCliente.Text;
            cliente.TelCliente = int.Parse(txtTelCliente.Text);
            cliente.MailCliente = txtMailCliente.Text;

            NEGCliente negCliente = new NEGCliente();

            if (negCliente.NEGBuscarClientePorRut(txtRutCliente.Text).NomCliente == null)
            {
                negCliente.NEGRegistarCliente(cliente);
            }        

            //CODIGO PARA REGISTRAR VEHICULO
            Vehiculo vehiculo = new Vehiculo();

            vehiculo.Patente = txtPatente.Text.ToUpper();
            vehiculo.Cliente = negCliente.NEGBuscarClientePorRut(txtRutCliente.Text);
            vehiculo.TipoVehiculo = txtTipoVehiculo.Text.ToUpper();
            vehiculo.Marca = txtMarca.Text.ToUpper();
            vehiculo.Modelo = txtModelo.Text.ToUpper();
            vehiculo.Ano = int.Parse(txtAno.Text);
            vehiculo.Kilometraje = double.Parse(txtKilometraje.Text);

            NEGVehiculo negVehiculo = new NEGVehiculo();

            if (negVehiculo.NEGBuscarVehiculoPorPatente(txtPatente.Text).Patente == null)
            {
                negVehiculo.NEGRegistrarVehiculo(vehiculo);
            }

            //CODIGO PARA REGISTRAR ORDEN DE TRABAJO
            OrdenTrabajo ordenTrabajo = new OrdenTrabajo();

            NEGUsuario negUsuario = new NEGUsuario();

            ordenTrabajo.Encargado = negUsuario.NEGBuscarUsuarioPorId(int.Parse(dpNomUsuario.SelectedValue));
            ordenTrabajo.Cliente = negCliente.NEGBuscarClientePorRut(txtRutCliente.Text);
            ordenTrabajo.Vehiculo = negVehiculo.NEGBuscarVehiculoPorPatente(txtPatente.Text.ToUpper());
            ordenTrabajo.Fecha = DateTime.Parse(txtFecha.Text);
            ordenTrabajo.FechaEntrega = DateTime.Parse(txtFechaEntrega.Text);
            ordenTrabajo.Prioridad = dpPrioridad.SelectedValue; //podria venir de una tabla en bd??
            ordenTrabajo.Observaciones = txtObservaciones.Text;
            ordenTrabajo.Estado = dpEstado.SelectedValue; //podria ser txtbox o el estado podria venir de una tabla en bd??
            ordenTrabajo.Iva = double.Parse(txtMontoIVA.Text);
            ordenTrabajo.Total = double.Parse(txtMontoTotal.Text);

            NEGOrdenTrabajo negOrdenTrabajo = new NEGOrdenTrabajo();
            flagRegistroOrden = negOrdenTrabajo.NEGRegistrarOrdenTrabajo(ordenTrabajo, out idOrdenInsertada);

            //CODIGO PARA INSERTAR EL DETALLE DE LA ORDEN DE TRABAJO

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
                    flagRegistroDetalleOrden = negDetalleOrden.NEGRegistrarDetOrden(detalleOrden);
                }
            }
            else
            {
                Response.Write("<script>alert('Debe ingresar al menos un servicio o repuesto antes de registar una orden de trabajo!')</script>");
            }


            if (flagRegistroOrden == true && flagRegistroDetalleOrden == true)
            {
                Response.Write("<script>alert('Orden de Trabajo registrada correctamente!')</script>");
            }
            else
            {
                Response.Write("<script>alert('No se pudo registrar la Orden de Trabajo!')</script>");
            }
        }

        private void limpiarCamposVehiculo()
        {
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtTipoVehiculo.Text = "";
            txtAno.Text = "";
            txtKilometraje.Text = "";
        }

        private void limpiarCamposCliente()
        {
            txtNomCliente.Text = "";
            txtApeCliente.Text = "";
            txtDirecCliente.Text = "";
            txtTelCliente.Text = "";
            txtMailCliente.Text = "";
        }
    }
}