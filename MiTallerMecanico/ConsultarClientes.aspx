﻿<%@ Page Title="Consultar Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarClientes.aspx.cs" Inherits="MiTallerMecanico.ConsultarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Consultar Clientes</h1>
        <br />

        <div class="row">
            <div class="col-md-4 pb-3">
                <asp:Label ID="lblFiltro" runat="server" Text="Filtrar por:"></asp:Label>
                <asp:TextBox ID="txtFiltro" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4 pb-3">
                <asp:Label ID="lblCampo" runat="server" Text="Campo:"></asp:Label>
                <asp:DropDownList ID="dpCampo" CssClass="form-control" runat="server">
                    <asp:ListItem Value="rutCliente" Text="Rut Cliente" />
                    <asp:ListItem Value="nombreCliente" Text="Nombre" />
                    <asp:ListItem Value="apellidoCliente" Text="Apellido" />
                    <asp:ListItem Value="direccionCliente" Text="Dirección" />
                    <asp:ListItem Value="telefonoCliente" Text="Teléfono" />
                    <asp:ListItem Value="correoCliente" Text="Mail" />
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
                <asp:BoundField  DataField="rutCliente" HeaderText="Rut cliente" SortExpression="rutCliente"/>
                <asp:BoundField  DataField="nombreCliente" HeaderText="Nombre cliente" SortExpression="nombreCliente"/>
                <asp:BoundField  DataField="apellidoCliente" HeaderText="Apellido cliente" SortExpression="apellidoCliente"/>
                <asp:BoundField  DataField="direccionCliente" HeaderText="Dirección cliente" SortExpression="direccionCliente"/>
                <asp:BoundField  DataField="telefonoCliente" HeaderText="Teléfono cliente" SortExpression="telefonoCliente"/>
                <asp:BoundField  DataField="correoCliente" HeaderText="Correo cliente" SortExpression="correoCliente"/>

            </Columns>
            </asp:GridView>
        </div>  
        <br />
        <% 
            if (filtarBotonExcel())
            {
            %>
                <asp:Button ID="btnExportar" CssClass="btn btn-lg btn-block btn-success mt-4" OnClick="btnExportar_Click" runat="server" Text="Exportar a Excel" />
        <%
            }
            else
            {
            %>
                <a href="Login.aspx" class="btn btn-lg btn-block btn-main mb-3" role="button">Volver</a>
        <%
            }
            %>
</div>
</asp:Content>
