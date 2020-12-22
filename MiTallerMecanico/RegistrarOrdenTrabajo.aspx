<%@ Page Title="Registrar Orden de Trabajo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarOrdenTrabajo.aspx.cs" Inherits="MiTallerMecanico.RegistrarOrdenTrabajo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Registrar Orden de Trabajo</h1>
        <br />

        <h4>Información de la Orden de Trabajo:</h4>
        <br />

        <div class="row">
            <div class="col col-md-6">
                <asp:Label ID="lblNomUsuario" runat="server" Text="Usuario:"></asp:Label>
                <asp:DropDownList ID="dpNomUsuario" CssClass="form-control" runat="server"></asp:DropDownList><br />
                <%-- En vez de un dropdown podria ser un txtbox readonly con el nombre de ususario en la session --%>

                <asp:Label ID="lblPatente" runat="server" Text="Patente vehículo:"></asp:Label>
                <asp:TextBox ID="txtPatente" AutoPostBack="true" OnTextChanged="txtPatente_TextChanged" CssClass="form-control" required runat="server" MaxLength="6"></asp:TextBox><br />

                 <asp:Label ID="lblRutCliente" runat="server" Text="Rut cliente:"></asp:Label>
                <asp:TextBox ID="txtRutCliente" CssClass="form-control" required runat="server"></asp:TextBox><br />

                <asp:Label ID="lblFecha" runat="server" Text="Fecha:"></asp:Label>
                <asp:TextBox ID="txtFecha" CssClass="form-control" TextMode="Date" required runat="server"></asp:TextBox><br />
            </div>
            <div class="col col-md-6 mb-auto">
                <asp:Label ID="lblFechaEntrega" runat="server" Text="Fecha entrega:"></asp:Label>
                <asp:TextBox ID="txtFechaEntrega" CssClass="form-control" TextMode="Date" required runat="server"></asp:TextBox><br />

                <asp:Label ID="lblPrioridad" runat="server" Text="Prioridad:"></asp:Label>
                <asp:DropDownList ID="dpPrioridad" CssClass="form-control" required runat="server">
                    <asp:ListItem Value="ALTA" Text="Alta"></asp:ListItem>
                    <asp:ListItem Value="MEDIA" Text="Media"></asp:ListItem>
                    <asp:ListItem Value="BAJA" Text="Baja"></asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:"></asp:Label>
                <asp:TextBox ID="txtObservaciones" CssClass="form-control" TextMode="MultiLine" runat="server" MaxLength="200"></asp:TextBox><br />

                <asp:Label ID="lblEstado" runat="server" Text="Estado:"></asp:Label>
                <asp:DropDownList ID="dpEstado" CssClass="form-control" required runat="server">
                    <asp:ListItem Value="Ingresado" Text="Vehículo Ingresado" Selected></asp:ListItem>
                    <asp:ListItem Value="En reparacion" Text="Vehículo en Reparacion"></asp:ListItem>
                    <asp:ListItem Value="Listo" Text="Vehículo listo para Retiro"></asp:ListItem>
                </asp:DropDownList><br />
            </div>
        </div>

        <hr />


        <h4>Añadir Servicios:</h4>
        <br />

        <div class="row">
            <div class="col-md-3 mb-4">
                <asp:Label ID="lblSelecServicio" runat="server" Text="Buscar por nombre:"></asp:Label>
                <asp:DropDownList ID="dpSelecServicio" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <%-- no se esta ocupando --%>
            <div class="col-md-3 mb-4">
                <asp:Label ID="lblCantServicios" runat="server" Text="Cantidad:"></asp:Label>
                <asp:TextBox ID="txtCantServicios" CssClass="form-control" TextMode="Number" min="1" runat="server"></asp:TextBox>
            </div>
            <%-- no se esta ocupando --%>
            <div class="col-md-3">
                <asp:Label ID="lblValorServicio" runat="server" Text="Valor unitario:"></asp:Label>
                <asp:TextBox ID="txtValorServicio" placeholder="$" CssClass="form-control" TextMode="Number" min="0" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnAgregaServicio" CssClass="btn btn-block btn-primary mt-4" OnClick="btnAgregaServicio_Click" runat="server" Text="Añadir" />
            </div>
        </div>
        <br />
        <hr />

        <h4>Añadir Repuestos:</h4>
        <br />

        <div class="row">
            <div class="col-md-3 mb-4">
                <asp:Label ID="lblSelecRepuesto" runat="server" Text="Buscar por nombre:"></asp:Label>
                <asp:DropDownList ID="dpSelecRepuesto" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <%-- no se esta ocupando --%>
            <div class="col-md-3 mb-4">
                <asp:Label ID="lblCantRepuestos" runat="server" Text="Cantidad:"></asp:Label>
                <asp:TextBox ID="txtCantRepuestos" CssClass="form-control" TextMode="Number" min="1" runat="server"></asp:TextBox>
            </div>
            <%-- no se esta ocupando --%>
            <div class="col-md-3">
                <asp:Label ID="lblValorRepuesto" runat="server" Text="Valor unitario:"></asp:Label>
                <asp:TextBox ID="txtValorRepuesto" placeholder="$" CssClass="form-control" TextMode="Number" min="0" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnAgregaRepuesto" CssClass="btn btn-block btn-primary  mt-4" OnClick="btnAgregaRepuesto_Click" runat="server" Text="Añadir" />
            </div>
        </div>
        <br />
        <hr />

        <h4>Detalle de Servicios y Repuestos:</h4>
        <br />

        <div class="table-responsive">
            <asp:GridView ID="gvSeleccion" CssClass="table table-sm table-secondary" OnSelectedIndexChanged="gvSeleccion_SelectedIndexChanged" EmptyDataText="No hay más registros!" runat="server">
                <Columns>
                    <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-sm btn-danger d-flex m-auto" ShowSelectButton="true" SelectText="Borrar" />
                </Columns>
            </asp:GridView>
        </div>
        <br />

<%--    no se estan ocupando pero creo que deberian! 
        <asp:Label ID="lblMontoIVA" runat="server" Text="Monto IVA:"></asp:Label>
        <asp:TextBox ID="txtMontoIVA" Text="0" required ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox><br />

        <asp:Label ID="lblMontoTotal" runat="server" Text="Monto Total:"></asp:Label>
        <asp:TextBox ID="txtMontoTotal" Text="0" required ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox><br />
    --%>
        <asp:Button ID="btnRegistrarOrdenTrabajo" CssClass="btn btn-lg btn-block btn-primary mb-3" OnClick="btnRegistrarOrdenTrabajo_Click" runat="server" Text="Registrar" />

    </div>   
</asp:Content>
