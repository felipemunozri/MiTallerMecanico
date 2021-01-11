<%@ Page Title="Registrar Orden de Trabajo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarOrdenTrabajo.aspx.cs" Inherits="MiTallerMecanico.RegistrarOrdenTrabajo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Registrar Orden de Trabajo</h1>
        <br />

        <h4>
            -Información de la Orden de Trabajo:
            <button type="button" class="btn btn-sm btn-more float-right" formnovalidate data-toggle="collapse" data-target="#divInfo" aria-expanded="true" aria-controls="collapseOne">
                +
            </button>
        </h4>
        <br />

        <div class="row collapse show" id="divInfo">
            <div class="col col-md-6">
                <asp:Label ID="lblNomUsuario" runat="server" Text="Usuario:"></asp:Label>
                <asp:DropDownList ID="dpNomUsuario" AppendDataBoundItems="true" CssClass="form-control" required runat="server">
                       <Items>
                           <asp:ListItem Text="- - Seleccionar" Value="" Selected="True" />
                       </Items>
                </asp:DropDownList><br />

                <asp:Label ID="lblFecha" runat="server" Text="Fecha:"></asp:Label>
                <asp:TextBox ID="txtFecha" CssClass="form-control" TextMode="Date" required runat="server"></asp:TextBox><br />

                <asp:Label ID="lblFechaEntrega" runat="server" Text="Fecha entrega:"></asp:Label>
                <asp:TextBox ID="txtFechaEntrega" CssClass="form-control" TextMode="Date" required runat="server"></asp:TextBox><br />
            </div>
            <div class="col col-md-6 mb-auto">
                <asp:Label ID="lblPrioridad" runat="server" Text="Prioridad:"></asp:Label>
                <asp:DropDownList ID="dpPrioridad" CssClass="form-control" required runat="server">
                    <asp:ListItem Text="- - Seleccionar" Value="" Selected="True"/>
                    <asp:ListItem Value="ALTA" Text="Alta"></asp:ListItem>
                    <asp:ListItem Value="MEDIA" Text="Media"></asp:ListItem>
                    <asp:ListItem Value="BAJA" Text="Baja"></asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:"></asp:Label>
                <asp:TextBox ID="txtObservaciones" CssClass="form-control" TextMode="MultiLine" runat="server" MaxLength="200"></asp:TextBox><br />

                <asp:Label ID="lblEstado" runat="server" Text="Estado:"></asp:Label>
                <asp:DropDownList ID="dpEstado" CssClass="form-control" required runat="server">
                    <asp:ListItem Text="- - Seleccionar" Value="" Selected="True"/>
                    <asp:ListItem Value="Ingresado" Text="Vehículo Ingresado"></asp:ListItem>
                    <asp:ListItem Value="En reparacion" Text="Vehículo en Reparacion"></asp:ListItem>
                    <asp:ListItem Value="Listo para retiro" Text="Vehículo listo para Retiro"></asp:ListItem>
                    <asp:ListItem Value="Entregado" Text="Vehículo Entregado"></asp:ListItem>
                </asp:DropDownList><br />
            </div>
        </div>

        <hr />

        <h4>
            -Información del Vehículo:
            <button type="button" class="btn btn-sm btn-more float-right" formnovalidate data-toggle="collapse" data-target="#divVehiculo" aria-expanded="true" aria-controls="collapseOne">
                +
            </button>
        </h4>
        <br />

        <div class="row collapse show" id="divVehiculo">
            <div class="col col-md-6">
                <asp:Label ID="lblPatente" runat="server" Text="Patente:"></asp:Label>
                <asp:TextBox ID="txtPatente" AutoPostBack="true" OnTextChanged="txtPatente_TextChanged" required CssClass="form-control" runat="server" MaxLength="6"></asp:TextBox><br />

                <asp:Label ID="lblMarca" runat="server" Text="Marca:"></asp:Label>
                <asp:TextBox ID="txtMarca" CssClass="form-control" runat="server" required MaxLength="50"></asp:TextBox><br />

                <asp:Label ID="lblModelo" runat="server" Text="Modelo:"></asp:Label>
                <asp:TextBox ID="txtModelo" CssClass="form-control" runat="server" required MaxLength="50"></asp:TextBox><br />
            </div>
            <div class="col col-md-6">
                <asp:Label ID="lblTipoVehiculo" runat="server" Text="Tipo de Vehículo:"></asp:Label>
                <asp:TextBox ID="txtTipoVehiculo" CssClass="form-control" required runat="server" MaxLength="50"></asp:TextBox><br />

                <asp:Label ID="lblAno" runat="server" Text="Año:"></asp:Label>
                <asp:TextBox ID="txtAno" TextMode="Number" min="1000" max="9999" required CssClass="form-control" runat="server"></asp:TextBox><br />
                
                <asp:Label ID="lblKilometraje" runat="server" Text="Kilometraje:"></asp:Label>
                <asp:TextBox ID="txtKilometraje" TextMode="Number" min="0" step=".1" max="99999999.99" required CssClass="form-control" runat="server"></asp:TextBox><br />
            </div>
        </div>

        <hr />

        <h4>
            -Información del Cliente:
            <button type="button" class="btn btn-sm btn-more float-right" formnovalidate data-toggle="collapse" data-target="#divCliente" aria-expanded="true" aria-controls="collapseOne">
                +
            </button>
        </h4>
        <br />

        <div class="row collapse show" id="divCliente">
            <div class="col col-md-6">
                <asp:Label ID="lblRutCliente" runat="server" Text="Rut cliente:"></asp:Label>
                <asp:TextBox ID="txtRutCliente" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtRutCliente_TextChanged" required runat="server" MaxLength="10"></asp:TextBox><br />

                <asp:Label ID="lblNomCliente" runat="server" Text="Nombre cliente:"></asp:Label>
                <asp:TextBox ID="txtNomCliente" CssClass="form-control" required runat="server" MaxLength="35"></asp:TextBox><br />

                <asp:Label ID="lblApeCliente" runat="server" Text="Apellido cliente:"></asp:Label>
                <asp:TextBox ID="txtApeCliente" CssClass="form-control" required runat="server" MaxLength="35"></asp:TextBox><br />
            </div>
            <div class="col col-md-6">
                <asp:Label ID="lblDirecCliente" runat="server" Text="Dirección cliente:"></asp:Label>
                <asp:TextBox ID="txtDirecCliente" CssClass="form-control" required runat="server" MaxLength="100"></asp:TextBox><br />

                <asp:Label ID="lblTelCliente" runat="server" Text="Teléfono cliente:"></asp:Label>
                <asp:TextBox ID="txtTelCliente" CssClass="form-control" TextMode="Number" min="0" max="999999999" required runat="server"></asp:TextBox><br />

                <asp:Label ID="lblMailCliente" runat="server" Text="Mail cliente:"></asp:Label>
                <asp:TextBox ID="txtMailCliente" TextMode="Email" CssClass="form-control" required runat="server" MaxLength="50"></asp:TextBox><br />
            </div>
        </div>

        <hr />


        <h4>
            -Añadir Servicios:
            <button type="button" class="btn btn-sm btn-more float-right" formnovalidate data-toggle="collapse" data-target="#divServicios" aria-expanded="true" aria-controls="collapseOne">
                +
            </button>
        </h4>
        <br />

        <div class="row collapse show" id="divServicios">
            <div class="col-md-3 mb-4">
                <asp:Label ID="lblSelecServicio" runat="server" Text="Buscar por nombre:"></asp:Label>
                <asp:DropDownList ID="dpSelecServicio" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-3 mb-4">
                <asp:Label ID="lblCantServicios" runat="server" Text="Cantidad:"></asp:Label>
                <asp:TextBox ID="txtCantServicios" CssClass="form-control" TextMode="Number" min="1" max="999" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lblValorServicio" runat="server" Text="Valor unitario:"></asp:Label>
                <asp:TextBox ID="txtValorServicio" placeholder="$" CssClass="form-control" TextMode="Number" min="0" max="99999999" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnAgregaServicio" CssClass="btn btn-block btn-main mt-4" OnClick="btnAgregaServicio_Click" runat="server" Text="Añadir" />
            </div>
        </div>

        <hr />

        <h4>
            -Añadir Repuestos:
            <button type="button" class="btn btn-sm btn-more float-right" data-toggle="collapse" data-target="#divRepuestos" aria-expanded="true" aria-controls="collapseOne">
                +
            </button>
        </h4>
        <br />

        <div class="row collapse show" id="divRepuestos">
            <div class="col-md-3 mb-4">
                <asp:Label ID="lblSelecRepuesto" runat="server" Text="Buscar por nombre:"></asp:Label>
                <asp:DropDownList ID="dpSelecRepuesto" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-3 mb-4">
                <asp:Label ID="lblCantRepuestos" runat="server" Text="Cantidad:"></asp:Label>
                <asp:TextBox ID="txtCantRepuestos" CssClass="form-control" TextMode="Number" min="1" max="999" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lblValorRepuesto" runat="server" Text="Valor unitario:"></asp:Label>
                <asp:TextBox ID="txtValorRepuesto" placeholder="$" CssClass="form-control" TextMode="Number" min="0" max="99999999" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnAgregaRepuesto" CssClass="btn btn-block btn-main  mt-4" OnClick="btnAgregaRepuesto_Click" runat="server" Text="Añadir" />
            </div>
        </div>

        <hr />

        <h4>-Detalle Orden de Trabajo:</h4>
        <br />

        <div class="table-responsive">
            <asp:GridView ID="gvSeleccion" CssClass="table table-sm table-secondary" OnSelectedIndexChanged="gvSeleccion_SelectedIndexChanged" EmptyDataText="No hay más registros!" runat="server">
                <Columns>
                    <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-sm btn-danger d-flex m-auto" ShowSelectButton="true" SelectText="Borrar" />
                </Columns>
            </asp:GridView>
        </div>
        <br />

        <asp:Label ID="lblMontoIVA" runat="server" Text="Monto IVA:"></asp:Label>
        <asp:TextBox ID="txtMontoIVA" Text="0" required ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox><br />

        <asp:Label ID="lblMontoTotal" runat="server" Text="Monto Total:"></asp:Label>
        <asp:TextBox ID="txtMontoTotal" Text="0" required ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox><br />
        <hr />

        <asp:Button ID="btnRegistrarOrdenTrabajo" CssClass="btn btn-lg btn-block btn-main mb-3" OnClick="btnRegistrarOrdenTrabajo_Click" runat="server" Text="Registrar" /><br />

        <button type="button" class="btn btn-lg btn-block btn-success mb-3" onclick="printPDF()">Exportar a PDF</button><br />

        <%--<a href="RegistrarOrdenTrabajo.aspx" role="button" class="btn btn-lg btn-block btn-danger mb-3">Limpiar formulario</a>--%>

    </div>   

    <script>
        function printPDF() {
            var doc = new jsPDF("p", "mm", [297, 210]);

            var patente = document.getElementById("MainContent_txtPatente").value;
            var rutCliente = document.getElementById("MainContent_txtRutCliente").value;
            var fecha = document.getElementById("MainContent_txtFecha").value;



            doc.setLineWidth(0.5);
            doc.setFont("helvetica", "bold");
            doc.setFontSize(22);
            doc.text(70, 20, '-PRESUPUESTO-');
            doc.setFont("courier", "normal");
            doc.setLineWidth(0.5);
            doc.line(0, 25, 210, 25);
            doc.rect(5, 30, 195, 10);

            doc.setFontSize(12);
            doc.setFont("helvetica", "bold");
            doc.text(110, 36, 'Datos del cliente:');

            doc.setFontSize(10);
            doc.rect(5, 40, 95, 30);

            doc.text(10, 45, 'Taller mecanico Navarrete e hijo');
            doc.text(10, 50, 'direccion :Camino Padre hurtado #4563');
            doc.text(10, 55, 'Telefono:+56963254563');
            doc.text(10, 60, 'email :contacto@navarreteehijo.cl');

            doc.rect(100, 40, 100, 30);


            doc.text(110, 45, 'Nombre:');
            doc.text(130, 45, 'Aqui va el nombre');
            doc.text(110, 50, 'Rut:');
            doc.text(130, 50, rutCliente);
            doc.text(110, 55, 'Direccion:');
            doc.text(130, 55, 'Aqui va la direccion');
            doc.text(110, 60, 'Telefono:');
            doc.text(130, 60, 'Aqui va el telefono');
            doc.text(110, 65, 'email:');
            doc.text(130, 65, 'Aquiva el correo');

            doc.rect(5, 75, 195, 10);
            doc.setFontSize(12);
            doc.text(10, 82, 'Fecha Presupuesto:');
            doc.text(52, 82, fecha);

            doc.text(145, 82, 'válido: 15 días');


            // doc.fromHTML(tablaDetalle, 10, 110, {
            //   'width': 190
            //});

            var tablaDetalle = $("#MainContent_gvSeleccion").html();

            doc.fromHTML(tablaDetalle, 10, 110);
            //doc.fromHTML(tablaDetalle, 10, 110,{autoSize: true});





            doc.save("a4.pdf");
        }
    </script>
</asp:Content>
