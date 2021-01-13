<%@ Page Title="Consultar Vehículos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarVehiculos.aspx.cs" Inherits="MiTallerMecanico.ConsultarVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Consultar Vehículos</h1>
        <br />

        <div class="row">
            <div class="col-md-4 pb-3">
                <asp:Label ID="lblFiltro" runat="server" Text="Filtrar por:"></asp:Label>
                <asp:TextBox ID="txtFiltro" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4 pb-3">
                <asp:Label ID="lblCampo" runat="server" Text="Campo:"></asp:Label>
                <asp:DropDownList ID="dpCampo" CssClass="form-control" runat="server">
                    <asp:ListItem Value="patente" Text="Patente" />
                    <asp:ListItem Value="fk_rutCliente" Text="Rut Cliente" />
                    <asp:ListItem Value="tipoVehiculo" Text="Tipo de Vehículo" />
                    <asp:ListItem Value="marca" Text="Marca" />
                    <asp:ListItem Value="modelo" Text="Modelo" />
                    <asp:ListItem Value="ano" Text="Año" />
                    <asp:ListItem Value="kilometraje" Text="Kilometraje" />
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
                <asp:BoundField DataField="patente" HeaderText="Patente" SortExpression="patente" />
                <asp:BoundField DataField="fk_rutCliente" HeaderText="Rut del cliente" SortExpression="fk_rutCliente" />
                <asp:BoundField DataField="tipoVehiculo" HeaderText="Tipo de vehículo" SortExpression="tipoVehiculo" />
                <asp:BoundField DataField="marca" HeaderText="Marca" SortExpression="marca" />
                <asp:BoundField DataField="modelo" HeaderText="Modelo" SortExpression="modelo" />
                <asp:BoundField DataField="ano" HeaderText="Año" SortExpression="ano"/>
                <asp:BoundField DataField="kilometraje" HeaderText="Kilometraje" SortExpression="kilometraje" />
            </Columns>
            </asp:GridView>
        </div>
        <br />

        <asp:Button ID="btnExportar" CssClass="btn btn-lg btn-block btn-success mt-4" OnClick="btnExportar_Click" runat="server" Text="Exportar a Excel" />

    </div>
</asp:Content>
