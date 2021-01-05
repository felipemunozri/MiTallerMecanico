﻿<%@ Page Title="Consultar Presupuesto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarPresupuesto.aspx.cs" Inherits="MiTallerMecanico.ConsultarPresupuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Consultar Presupuesto</h1>
        <br />

        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="lblFiltro" runat="server" Text="Filtrar por:"></asp:Label>
                <asp:TextBox ID="txtFiltro" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblCampo" runat="server" Text="Campo:"></asp:Label>
                <asp:DropDownList ID="dpCampo" CssClass="form-control" runat="server">
                    <asp:ListItem Value="folioEncabezado" Text="ID de Presupuesto" />
                    <asp:ListItem Value="rutCliente" Text="Rut Cliente" />
                    <asp:ListItem Value="patente" Text="Patente" />
                    <asp:ListItem Value="fecha" Text="Fecha" />
                    <asp:ListItem Value="iva" Text="IVA" />
                    <asp:ListItem Value="total" Text="Total" />
                </asp:DropDownList>
            </div>
            <div class="col-md-4">
                 <asp:Button ID="btnFiltrar" CssClass="btn btn-block btn-primary mt-4" OnClick="btnFiltrar_Click" runat="server" Text="Filtrar" />
            </div>
        </div>
        <br />

        <hr />

        <div class="table-responsive">
            <asp:GridView ID="gvResultado" AutoGenerateColumns="false" CssClass="table table-sm table-secondary" EmptyDataText="No se han encontrado registros!" runat="server">
            <Columns>
                <asp:BoundField DataField="folioEncabezado" HeaderText="ID presupuesto" SortExpression="folioEncabezado" />
                <asp:BoundField DataField="rutCliente" HeaderText="Rut del cliente" SortExpression="rutCliente" />
                <asp:BoundField DataField="patente" HeaderText="Patente" SortExpression="patente" />
                <asp:BoundField DataField="fecha" HeaderText="Fecha de creación" SortExpression="fecha" />
                <asp:BoundField DataField="iva" HeaderText="IVA" SortExpression="iva" />
                <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" />
            </Columns>
            </asp:GridView>
        </div>
        <br />

    </div>
</asp:Content>
