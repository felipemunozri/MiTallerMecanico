<%@ Page Title="Registrar Presupuesto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarPresupuesto.aspx.cs" Inherits="MiTallerMecanico.RegistrarPresupuesto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Registrar Presupuesto</h1>
        <br />

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

        <asp:Button ID="btnRegistrarPresupuesto" CssClass="btn btn-lg btn-block btn-main mb-3" OnClick="btnRegistrarPresupuesto_Click" runat="server" Text="Registrar" /><br />

        <button type="button" class="btn btn-lg btn-block btn-success mb-3" onclick="printPDF()">Exportar a PDF</button><br />

        <%--<a href="RegistrarPresupuesto.aspx" role="button" class="btn btn-lg btn-block btn-danger mb-3">Limpiar formulario</a>--%>
    </div>

    <script>
        function printPDF() {
            var doc = new jsPDF();

            //var patente = document.getElementById("MainContent_txtPatente").value;
            //var rutCliente = document.getElementById("MainContent_txtRutCliente").value;
            //var fecha = document.getElementById("MainContent_txtFecha").value;

            //alert(patente);

            //var tablaDetalle = $(".table-responsive").html();

            //doc.text(10, 20, patente);
            //doc.text(10, 30, rutCliente);
            //doc.text(10, 40, fecha);
            //doc.fromHTML(tablaDetalle)

            var pagina = $(".container").html();
            doc.fromHTML(pagina)

            doc.save("a4.pdf");
        }
    </script>
</asp:Content>
