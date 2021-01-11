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
    public partial class ModificarPresupuesto : System.Web.UI.Page
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarPresupuesto.Text.Equals(""))
            {
                Response.Write("<script>alert('Debe ingresar un valor de ID!')</script>");
                limpiarCampos();
            }
            else
            {
                NEGEncabezadoPresupuesto negEncPresupuesto = new NEGEncabezadoPresupuesto();

                EncabezadoPresupuesto encPresupuesto = new EncabezadoPresupuesto();
                encPresupuesto = negEncPresupuesto.NEGBuscarEncPresupuestoPorFolio(int.Parse(txtBuscarPresupuesto.Text));

                if (encPresupuesto.Cliente != null)
                {
                    txtFecha.Text = encPresupuesto.Fecha.ToString("yyyy-MM-dd");
                    txtObservaciones.Text = encPresupuesto.Observaciones;
                    dpEstado.SelectedValue = encPresupuesto.Estado;
                    txtMontoIVA.Text = encPresupuesto.Iva.ToString("N2");
                    txtMontoTotal.Text = encPresupuesto.Total.ToString("N2");

                    txtPatente.Text = encPresupuesto.Vehiculo.Patente;
                    txtMarca.Text = encPresupuesto.Vehiculo.Marca;
                    txtModelo.Text = encPresupuesto.Vehiculo.Modelo;
                    txtTipoVehiculo.Text = encPresupuesto.Vehiculo.TipoVehiculo;
                    txtAno.Text = encPresupuesto.Vehiculo.Ano.ToString();
                    txtKilometraje.Text = encPresupuesto.Vehiculo.Kilometraje.ToString();

                    txtRutCliente.Text = encPresupuesto.Cliente.RutCliente;
                    txtNomCliente.Text = encPresupuesto.Cliente.NomCliente;
                    txtApeCliente.Text = encPresupuesto.Cliente.ApeCliente;
                    txtDirecCliente.Text = encPresupuesto.Cliente.DirecCliente;
                    txtTelCliente.Text = encPresupuesto.Cliente.TelCliente.ToString();
                    txtMailCliente.Text = encPresupuesto.Cliente.MailCliente;

                    NEGDetallePresupuesto negDetPresupuesto = new NEGDetallePresupuesto();

                    Session["dtSeleccion"] = negDetPresupuesto.NEGTablaServiciosYRepuestosEnDetPresupuestoPorFolioEncabezado(int.Parse(txtBuscarPresupuesto.Text));

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

        protected void txtRutCliente_TextChanged(object sender, EventArgs e)
        {
            Validacion valida = new Validacion();

            if (!valida.validarRut(txtRutCliente.Text))
            {
                Response.Write("<script>alert('Vuelva a ingresar el rut!')</script>");
                txtRutCliente.Text = "";
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

        protected void btnModificarPresupuesto_Click(object sender, EventArgs e)
        {
            bool flagRegistroEncPresupuesto = false;
            bool flagRegistroDetPresupuesto = false;
            int idOrdenInsertada = 0;

            //CODIGO PARA MODIFICAR EL ENCABEZADO DEL PRESUPUESTO
            EncabezadoPresupuesto encPresupuesto = new EncabezadoPresupuesto();

            NEGCliente negCliente = new NEGCliente();
            NEGVehiculo negVehiculo = new NEGVehiculo();

            encPresupuesto.FolioEncabezado = int.Parse(txtBuscarPresupuesto.Text);
            encPresupuesto.Cliente = negCliente.NEGBuscarClientePorRut(txtRutCliente.Text);
            encPresupuesto.Vehiculo = negVehiculo.NEGBuscarVehiculoPorPatente(txtPatente.Text.ToUpper());
            encPresupuesto.Fecha = DateTime.Parse(txtFecha.Text);
            encPresupuesto.Observaciones = txtObservaciones.Text;
            encPresupuesto.Estado = dpEstado.SelectedValue; //podria ser txtbox o el estado podria venir de una tabla en bd??
            encPresupuesto.Iva = double.Parse(txtMontoIVA.Text);
            encPresupuesto.Total = double.Parse(txtMontoTotal.Text);

            NEGEncabezadoPresupuesto negEncPresupuesto = new NEGEncabezadoPresupuesto();
            flagRegistroEncPresupuesto = negEncPresupuesto.NEGModificarEncPresupuesto(encPresupuesto);

            NEGDetallePresupuesto negDetpresupuesto = new NEGDetallePresupuesto();
            negDetpresupuesto.NEGEliminarDetPresupuesto(encPresupuesto);
            //CODIGO PARA MODIFICAR EL DETALLE DEL PRESUPUESTO 

            if (gvSeleccion.Rows.Count != 0)
            {
                for (int i = 0; i < gvSeleccion.Rows.Count; i++)
                {
                    DetallePresupuesto detPresupuesto = new DetallePresupuesto();

                    NEGServicio negServicio = new NEGServicio();
                    NEGRepuesto negRepuesto = new NEGRepuesto();

                    detPresupuesto.EncabezadoPresupuesto = negEncPresupuesto.NEGBuscarEncPresupuestoPorFolio(int.Parse(txtBuscarPresupuesto.Text));
                    detPresupuesto.Servicio = negServicio.NEGBuscarServicioPorId(int.Parse(gvSeleccion.Rows[i].Cells[1].Text));
                    detPresupuesto.Repuesto = negRepuesto.NEGBuscarRepuestoPorId(int.Parse(gvSeleccion.Rows[i].Cells[1].Text));
                    detPresupuesto.CantServicio = int.Parse(gvSeleccion.Rows[i].Cells[4].Text);
                    detPresupuesto.CantRepuesto = int.Parse(gvSeleccion.Rows[i].Cells[4].Text);
                    detPresupuesto.SubTotal = int.Parse(gvSeleccion.Rows[i].Cells[5].Text);

                    flagRegistroDetPresupuesto = negDetpresupuesto.NEGRegistrarDetPresupuesto(detPresupuesto);
                }
            }
            else
            {
                Response.Write("<script>alert('Debe ingresar al menos un servicio o repuesto antes de registar una orden de trabajo!')</script>");
            }

            //if (dpEstado.SelectedValue.Equals("Aprobado"))
            //{
            //    //CODIGO PARA REGISTRAR ORDEN DE TRABAJO

            //    OrdenTrabajo ordenTrabajo = new OrdenTrabajo();

            //    ordenTrabajo.Encargado = (Usuario)Session["usuarioConectado"];
            //    ordenTrabajo.Cliente = negCliente.NEGBuscarClientePorRut(txtRutCliente.Text);
            //    ordenTrabajo.Vehiculo = negVehiculo.NEGBuscarVehiculoPorPatente(txtPatente.Text.ToUpper());
            //    ordenTrabajo.Fecha = DateTime.Parse(txtFecha.Text);
            //    ordenTrabajo.FechaEntrega = DateTime.Parse(txtFecha.Text);
            //    ordenTrabajo.Prioridad = ""; //podria venir de una tabla en bd??
            //    ordenTrabajo.Observaciones = txtObservaciones.Text;
            //    ordenTrabajo.Estado = dpEstado.SelectedValue; //podria ser txtbox o el estado podria venir de una tabla en bd??
            //    ordenTrabajo.Iva = double.Parse(txtMontoIVA.Text);
            //    ordenTrabajo.Total = double.Parse(txtMontoTotal.Text);

            //    NEGOrdenTrabajo negOrdenTrabajo = new NEGOrdenTrabajo();
            //    negOrdenTrabajo.NEGRegistrarOrdenTrabajo(ordenTrabajo, out idOrdenInsertada);

            //    //CODIGO PARA INSERTAR EL DETALLE DE LA ORDEN DE TRABAJO

            //    if (gvSeleccion.Rows.Count != 0)
            //    {
            //        for (int i = 0; i < gvSeleccion.Rows.Count; i++)
            //        {
            //            DetalleOrden detalleOrden = new DetalleOrden();

            //            NEGServicio negServicio = new NEGServicio();
            //            NEGRepuesto negRepuesto = new NEGRepuesto();

            //            detalleOrden.OrdenTrabajo = negOrdenTrabajo.NEGBuscarOrdenTrabajoPorFolio(idOrdenInsertada);
            //            detalleOrden.Servicio = negServicio.NEGBuscarServicioPorId(int.Parse(gvSeleccion.Rows[i].Cells[1].Text));
            //            detalleOrden.Repuesto = negRepuesto.NEGBuscarRepuestoPorId(int.Parse(gvSeleccion.Rows[i].Cells[1].Text));
            //            detalleOrden.CantServicio = int.Parse(gvSeleccion.Rows[i].Cells[4].Text);
            //            detalleOrden.CantRepuesto = int.Parse(gvSeleccion.Rows[i].Cells[4].Text);
            //            detalleOrden.SubTotal = int.Parse(gvSeleccion.Rows[i].Cells[5].Text);

            //            NEGDetalleOrden negDetalleOrden = new NEGDetalleOrden();
            //        }
            //    }
            //}

            if (flagRegistroEncPresupuesto == true && flagRegistroDetPresupuesto == true)
            {
                Response.Write("<script>alert('Presupuesto modificado correctamente!')</script>");
            }
            //else if (dpEstado.SelectedValue.Equals("Aprobado"))
            //{
                //Response.Write("<script>alert('Presupuesto modificado y Orden de Trabajo creada! ID de Orden = " + idOrdenInsertada +) </script>");
            //}
            else
            {
                Response.Write("<script>alert('No se pudo modificar el Presupuesto!')</script>");
            }
        }

        private void limpiarCampos()
        {
            dpEstado.SelectedValue = "";
            txtFecha.Text = "";
            txtObservaciones.Text = "";
            txtPatente.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtTipoVehiculo.Text = "";
            txtAno.Text = "";
            txtKilometraje.Text = "";
            txtRutCliente.Text = "";
            txtNomCliente.Text = "";
            txtApeCliente.Text = "";
            txtDirecCliente.Text = "";
            txtTelCliente.Text = "";
            txtMailCliente.Text = "";

            if (gvSeleccion.Rows.Count != 0)
            {
                for (int i = 0; i < gvSeleccion.Rows.Count; i++)
                {
                    ((DataTable)Session["dtSeleccion"]).Rows.RemoveAt(i);

                    gvSeleccion.DataSource = (DataTable)Session["dtSeleccion"];
                    gvSeleccion.DataBind();
                }
            }

            txtMontoIVA.Text = "0";
            txtMontoTotal.Text = "0";
        }
    }
}