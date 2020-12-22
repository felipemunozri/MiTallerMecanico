﻿<%@ Page Title="Registrar Vehiculo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarVehiculo.aspx.cs" Inherits="MiTallerMecanico.RegistrarVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Registrar Vehículo</h1>
        <br />

        <div class="row">
            <div class="col col-md-6">
                <asp:Label ID="lblRutCliente" runat="server" Text="Rut Dueño:"></asp:Label>
                <asp:TextBox ID="txtRutCliente" CssClass="form-control" required runat="server"></asp:TextBox><br />

                <asp:Label ID="lblPatente" runat="server" Text="Patente:"></asp:Label>
                <asp:TextBox ID="txtPatente" CssClass="form-control" runat="server"></asp:TextBox><br />

                <asp:Label ID="lblMarca" runat="server" Text="Marca:"></asp:Label>
                <asp:TextBox ID="txtMarca" CssClass="form-control" runat="server"></asp:TextBox><br />

                <asp:Label ID="lblModelo" runat="server" Text="Modelo:"></asp:Label>
                <asp:TextBox ID="txtModelo" CssClass="form-control" runat="server"></asp:TextBox><br />
            </div>
            <div class="col col-md-6">
                <asp:Label ID="lblTipoVehiculo" runat="server" Text="Tipo de Vehículo:"></asp:Label>
                <asp:TextBox ID="txtTipoVehiculo" CssClass="form-control" required runat="server"></asp:TextBox><br />

                <asp:Label ID="lblAno" runat="server" Text="Año:"></asp:Label>
                <asp:TextBox ID="txtAno" CssClass="form-control" runat="server"></asp:TextBox><br />
                
                <asp:Label ID="lblKilometraje" runat="server" Text="Kilometraje:"></asp:Label>
                <asp:TextBox ID="txtKilometraje" CssClass="form-control" runat="server"></asp:TextBox><br />
            </div>
        </div>

        <asp:Button ID="btnRegistrarVehiculo" CssClass="btn btn-lg btn-block btn-primary mb-3" OnClick="btnRegistrarVehiculo_Click" runat="server" Text="Registrar" />

    </div>
</asp:Content>