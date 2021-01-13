<%@ Page Title="Modificar Presupuesto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarPresupuesto.aspx.cs" Inherits="MiTallerMecanico.ModificarPresupuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Modificar Presupuesto</h1>
        <br />

        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lblBuscarPresupuesto" runat="server" Text="Buscar Presupuesto por ID:"></asp:Label>
                <asp:TextBox ID="txtBuscarPresupuesto" TextMode="Number"  min="1" max="2147483647" CssClass="form-control" required runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnBuscar" formnovalidate CssClass="btn btn-block btn-main mt-4" OnClick="btnBuscar_Click" runat="server" Text="Buscar" />
            </div>
        </div>
        <br />

        <hr />

        <h4>
            -Información del Presupuesto:
            <button type="button" class="btn btn-sm btn-more float-right" data-toggle="collapse" data-target="#divInfo" aria-expanded="true" aria-controls="collapseOne">
                +
            </button>
        </h4>
        <br />

        <div class="row collapse show" id="divInfo">
            <div class="col col-md-6">
                <asp:Label ID="lblFecha" runat="server" Text="Fecha:"></asp:Label>
                <asp:TextBox ID="txtFecha" CssClass="form-control" TextMode="Date" required runat="server"></asp:TextBox><br />

                <asp:Label ID="lblEstado" runat="server" Text="Estado:"></asp:Label>
                <asp:DropDownList ID="dpEstado" CssClass="form-control" required runat="server">
                    <asp:ListItem Text="- - Seleccionar" Value="" Selected="True"/>
                    <asp:ListItem Value="Pendiente" Text="Pendiente"></asp:ListItem>
                    <asp:ListItem Value="Aprobado" Text="Aprobado"></asp:ListItem>
                </asp:DropDownList><br />
            </div>
            <div class="col col-md-6 mb-auto">
                <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:"></asp:Label>
                <asp:TextBox ID="txtObservaciones" CssClass="form-control" TextMode="MultiLine" runat="server" MaxLength="200"></asp:TextBox><br />
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
                <asp:TextBox ID="txtPatente" AutoPostBack="true"  required CssClass="form-control" runat="server" MaxLength="6"></asp:TextBox><br />

                <asp:Label ID="lblMarca" runat="server" Text="Marca:"></asp:Label>
                <asp:TextBox ID="txtMarca" CssClass="form-control" required runat="server" MaxLength="50"></asp:TextBox><br />

                <asp:Label ID="lblModelo" runat="server" Text="Modelo:"></asp:Label>
                <asp:TextBox ID="txtModelo" CssClass="form-control" required runat="server" MaxLength="50"></asp:TextBox><br />
            </div>
            <div class="col col-md-6">
                <asp:Label ID="lblTipoVehiculo" runat="server" Text="Tipo de Vehículo:"></asp:Label>
                <asp:TextBox ID="txtTipoVehiculo" CssClass="form-control" required runat="server" MaxLength="50"></asp:TextBox><br />

                <asp:Label ID="lblAno" runat="server" Text="Año:"></asp:Label>
                <asp:TextBox ID="txtAno" TextMode="Number" min="1000" max="9999" required CssClass="form-control" runat="server"></asp:TextBox><br />
                
                <asp:Label ID="lblKilometraje" runat="server" Text="Kilometraje:"></asp:Label>
                <asp:TextBox ID="txtKilometraje" CssClass="form-control" required TextMode="Number" min="0" step=".1" max="99999999.99" runat="server"></asp:TextBox><br />
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
                <asp:TextBox ID="txtMailCliente" CssClass="form-control" TextMode="Email" required runat="server" MaxLength="50"></asp:TextBox><br />
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
                <asp:Button ID="btnAgregaRepuesto" CssClass="btn btn-block btn-main mt-4" OnClick="btnAgregaRepuesto_Click" runat="server" Text="Añadir" />
            </div>
        </div>

        <hr />

        <h4>-Detalle Presupuesto:</h4>
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

        <asp:Button ID="btnModificarPresupuesto" CssClass="btn btn-lg btn-block btn-main mb-3" OnClick="btnModificarPresupuesto_Click" runat="server" Text="Modificar" /><br />

        <button type="button" class="btn btn-lg btn-block btn-success mb-3" onclick="printPDF2()">Exportar a PDF</button><br />

        <%--<a href="ModificarPresupuesto.aspx" role="button" class="btn btn-lg btn-block btn-danger mb-3">Limpiar formulario</a>--%>

    </div> 
    
    <script>
        function printPDF2() {
            var doc = new jsPDF('p', 'mm', [210, 297]);


            var fecha = document.getElementById("MainContent_txtFecha").value;

            //vehiculo
            var patente = document.getElementById("MainContent_txtPatente").value;
            var marca = document.getElementById("MainContent_txtMarca").value;
            var modelo = document.getElementById("MainContent_txtModelo").value;
            var tipo = document.getElementById("MainContent_txtTipoVehiculo").value;
            var kilometraje = document.getElementById("MainContent_txtKilometraje").value;
            var año = document.getElementById("MainContent_txtAno").value;

            //cliente
            var rutCliente = document.getElementById("MainContent_txtRutCliente").value;
            var nomcliente = document.getElementById("MainContent_txtNomCliente").value + " " + document.getElementById("MainContent_txtApeCliente").value;
            var direccion = document.getElementById("MainContent_txtDirecCliente").value;
            var telefono = document.getElementById("MainContent_txtTelCliente").value;
            var mail = document.getElementById("MainContent_txtMailCliente").value;

            //valores
            var montoIva = document.getElementById("MainContent_txtMontoIVA").value;
            var montoTotal = document.getElementById("MainContent_txtMontoTotal").value;

            doc.setTextColor(255, 255, 255);
            doc.setDrawColor(0);
            doc.setFillColor(72, 61, 139);
            doc.rect(0.7, 8, 210, 16, "F");
            doc.setFont("helvetica", "bold");
            doc.setFontSize(22);
            doc.text(70, 20, '-PRESUPUESTO-');
            doc.setFont("courier", "normal");
            doc.setLineWidth(0.5);

            doc.setTextColor(255, 255, 255);
            doc.setFillColor(72, 61, 139);
            doc.rect(5, 30, 195, 10, "FD");

            doc.setFontSize(12);
            doc.setFont("helvetica", "bold");
            doc.text(110, 36, 'Datos del cliente:');
            doc.setTextColor(0);
            doc.setFontSize(10);
            doc.rect(5, 40, 95, 30);

            //Logo
            var img = new Image()
            img.src = 'images/Logo-Taller5.png'
            doc.addImage(img, 'png', 176, 45, 20, 20)


            doc.text(10, 45, 'Taller mecanico Navarrete e hijo');
            doc.text(10, 50, 'Direccion: Camino Padre hurtado #4563');
            doc.text(10, 55, 'Telefono: +56963254563');
            doc.text(10, 60, 'Email: contacto@navarreteehijo.cl');

            doc.rect(100, 40, 100, 30);


            doc.text(110, 45, 'Nombre:');
            doc.text(130, 45, nomcliente);
            doc.text(110, 50, 'Rut:');
            doc.text(130, 50, rutCliente);
            doc.text(110, 55, 'Direccion:');
            doc.text(130, 55, direccion);
            doc.text(110, 60, 'Telefono:');
            doc.text(130, 60, telefono);
            doc.text(110, 65, 'Email:');
            doc.text(130, 65, mail);

            doc.setDrawColor(0);
            doc.setFillColor(72, 61, 139);
            doc.rect(5, 75, 195, 10, "FD");
            doc.setTextColor(255, 255, 255);

            doc.setFontSize(12);
            doc.text(10, 82, 'Fecha Presupuesto:');
            doc.text(52, 82, fecha);

            doc.text(145, 82, 'válido: 15 días');
            doc.setDrawColor(0);
            doc.setFillColor(72, 61, 139);
            doc.rect(5, 90, 195, 10, "FD");
            doc.text(10, 97, 'Datos Automovil:');

            doc.rect(5, 100, 195, 20);
            doc.setTextColor(0);
            doc.setFontSize(10);
            doc.text(10, 108, 'Patente:');
            doc.text(28, 108, patente);
            doc.text(10, 113, 'Marca:');
            doc.text(28, 113, marca);
            doc.text(10, 118, 'Modelo:');
            doc.text(28, 118, modelo);

            doc.text(110, 108, 'Tipo Vehiculo:');
            doc.text(135, 108, tipo);
            doc.text(110, 113, 'Kilometraje:');
            doc.text(135, 113, kilometraje);
            doc.text(110, 118, 'Año:');
            doc.text(135, 118, año);


            doc.rect(100, 250, 100, 30);
            doc.line(20, 268, 80, 268);
            doc.text(42, 272, 'Firma cliente');


            doc.rect(5, 250, 95, 30);
            doc.setFontSize(10);
            doc.text(110, 260, 'Monto iva :');
            doc.text(138, 260, montoIva);
            doc.text(110, 266, 'Monto total :');
            doc.text(138, 266, montoTotal);

            doc.setFontSize(11);

            doc.text(75, 295, '© 2021 - Mi Taller Mecánico');


            //tabla
            doc.autoTable({
                html: '#MainContent_gvSeleccion',
                startY: 130,
                tableWidth: 195,
                margin: { left: 5 },
                theme: 'grid',
                tableLineColor: [0, 0, 0],
                tableLineWidth: 0.5,
                styles: {
                    fontStyle: 'bold',
                    lineColor: [0, 0, 0],
                    lineWidth: 0.5,
                },
            });


            doc.save("a4.pdf");
        }
    </script>
</asp:Content>
