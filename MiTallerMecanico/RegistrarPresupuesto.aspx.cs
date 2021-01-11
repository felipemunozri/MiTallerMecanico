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
    public partial class RegistrarPresupuesto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                txtRutCliente.Text = "";
                limpiarCamposCliente();
                SetFocus(txtMarca);
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
            else
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

        protected void btnRegistrarPresupuesto_Click(object sender, EventArgs e)
        {
            bool flagRegistroEncPresupuesto = false;
            bool flagRegistroDetPresupuesto = false;
            int idPresupuestoInsertado = 0;

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

            //CODIGO PARA REGISTRAR EL ENCABEZADO DEL PRESUPUESTO
            EncabezadoPresupuesto encPresupuesto = new EncabezadoPresupuesto();

            encPresupuesto.Cliente = negCliente.NEGBuscarClientePorRut(txtRutCliente.Text);
            encPresupuesto.Vehiculo = negVehiculo.NEGBuscarVehiculoPorPatente(txtPatente.Text.ToUpper());
            encPresupuesto.Fecha = DateTime.Parse(txtFecha.Text);
            encPresupuesto.Observaciones = txtObservaciones.Text;
            encPresupuesto.Estado = dpEstado.SelectedValue; //podria ser txtbox o el estado podria venir de una tabla en bd??
            encPresupuesto.Iva = double.Parse(txtMontoIVA.Text);
            encPresupuesto.Total = double.Parse(txtMontoTotal.Text);

            NEGEncabezadoPresupuesto negEncPresupuesto = new NEGEncabezadoPresupuesto();
            flagRegistroEncPresupuesto = negEncPresupuesto.NEGRegistrarEncPresupuesto(encPresupuesto, out idPresupuestoInsertado);

            //CODIGO PARA INSERTAR EL DETALLE DE PRESUPUESTO

            if (gvSeleccion.Rows.Count != 0)
            {
                for (int i = 0; i < gvSeleccion.Rows.Count; i++)
                {
                    DetallePresupuesto detPresupuesto = new DetallePresupuesto();

                    NEGServicio negServicio = new NEGServicio();
                    NEGRepuesto negRepuesto = new NEGRepuesto();

                    detPresupuesto.EncabezadoPresupuesto = negEncPresupuesto.NEGBuscarEncPresupuestoPorFolio(idPresupuestoInsertado);
                    detPresupuesto.Servicio = negServicio.NEGBuscarServicioPorId(int.Parse(gvSeleccion.Rows[i].Cells[1].Text));
                    detPresupuesto.Repuesto = negRepuesto.NEGBuscarRepuestoPorId(int.Parse(gvSeleccion.Rows[i].Cells[1].Text));
                    detPresupuesto.CantServicio = int.Parse(gvSeleccion.Rows[i].Cells[4].Text);
                    detPresupuesto.CantRepuesto = int.Parse(gvSeleccion.Rows[i].Cells[4].Text);
                    detPresupuesto.SubTotal = int.Parse(gvSeleccion.Rows[i].Cells[5].Text);

                    NEGDetallePresupuesto negDetpresupuesto = new NEGDetallePresupuesto();
                    flagRegistroDetPresupuesto = negDetpresupuesto.NEGRegistrarDetPresupuesto(detPresupuesto);
                }
            }
            else
            {
                Response.Write("<script>alert('Debe ingresar al menos un servicio o repuesto antes de registar una orden de trabajo!')</script>");
            }


            if (flagRegistroEncPresupuesto == true && flagRegistroDetPresupuesto == true)
            {
                Response.Write("<script>alert('Presupuesto registrado correctamente!')</script>");
            }
            else
            {
                Response.Write("<script>alert('No se pudo registrar el Presupuesto!')</script>");
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