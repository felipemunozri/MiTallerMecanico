﻿using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiTallerMecanico
{
    public partial class ConsultarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NEGCliente negCliente = new NEGCliente();

            gvResultado.DataSource = negCliente.NEGTablaTodosLosClientes();
            gvResultado.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            string campo = dpCampo.SelectedValue.ToString();

            NEGCliente negCliente = new NEGCliente();

            gvResultado.DataSource = negCliente.NEGTablaClientesFiltrados(campo, filtro);
            gvResultado.DataBind();
        }
    }
}