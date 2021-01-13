<%@ Page Title="Consultar Ordenes de Trabajo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarOrdenesTrabajo.aspx.cs" Inherits="MiTallerMecanico.ConsultarOrdenTrabajo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Consultar Ordenes de Trabajo</h1>
        <br />

        <div class="row">
            <div class="col-md-4 pb-3">
                <asp:Label ID="lblFiltro" runat="server" Text="Filtrar por:"></asp:Label>
                <asp:TextBox ID="txtFiltro" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4 pb-3">
                <asp:Label ID="lblCampo" runat="server" Text="Campo:"></asp:Label>
                <asp:DropDownList ID="dpCampo" CssClass="form-control" runat="server">
                    <asp:ListItem Value="folioOrden" Text="ID Orden de Trabajo" />
                    <asp:ListItem Value="nombreUsuario" Text="Mecánico" />
                    <asp:ListItem Value="fk_rutCliente" Text="Rut Cliente" />
                    <asp:ListItem Value="fk_patente" Text="Patente" />
                    <asp:ListItem Value="fecha" Text="Fecha Creación" />
                    <asp:ListItem Value="fechaEntrega" Text="Fecha de Entrega" />
                    <asp:ListItem Value="prioridad" Text="Prioridad" />
                    <asp:ListItem Value="observaciones" Text="Observaciones" />
                    <asp:ListItem Value="estado" Text="Estado" />
                    <asp:ListItem Value="iva" Text="IVA" />
                    <asp:ListItem Value="total" Text="Total" />
                </asp:DropDownList>
            </div>
            <div class="col-md-4 pb-3">
                 <asp:Button ID="btnFiltrar" CssClass="btn btn-block btn-main mt-4" OnClick="btnFiltrar_Click" runat="server" Text="Filtrar" />
            </div>
        </div>
        <br />

        <hr />

        <div class="table-responsive">
            <asp:GridView ID="gvResultado" AutoGenerateColumns="false" CssClass="table table-sm table-secondary" EmptyDataText="No se han encontrado registros!" runat="server">
            <Columns>
                <asp:BoundField DataField="folioOrden" HeaderText="ID Orden de Trabajo" SortExpression="folioOrden" />
                <asp:BoundField DataField="nombreUsuario" HeaderText="Mecánico" SortExpression="fk_idUsuario" />
                <asp:BoundField DataField="fk_rutCliente" HeaderText="Rut del cliente" SortExpression="fk_rutCliente" />
                <asp:BoundField DataField="fk_patente" HeaderText="Patente" SortExpression="fk_patente" />
                <asp:BoundField DataField="fecha" HeaderText="Fecha de creación" SortExpression="fecha" />
                <asp:BoundField DataField="fechaEntrega" HeaderText="Fecha de entrega" SortExpression="fechaEntrega" />
                <asp:BoundField DataField="prioridad" HeaderText="Prioridad" SortExpression="prioridad" />
                <asp:BoundField DataField="observaciones" HeaderText="Observaciones" SortExpression="observaciones" />
                <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado" />
                <asp:BoundField DataField="iva" HeaderText="IVA" SortExpression="iva" />
                <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" />
            </Columns>
            </asp:GridView>
        </div>
        <br />

        <asp:Button ID="btnExportar" CssClass="btn btn-lg btn-block btn-success mt-4" OnClick="btnExportar_Click" runat="server" Text="Exportar a Excel" />

    </div>
</asp:Content>
