<%@ Page Title="Modificar Servicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarServicio.aspx.cs" Inherits="MiTallerMecanico.ModificarServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Modificar Servicio</h1>
        <br />

        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lblBuscarServicio" runat="server" Text="Buscar Servicio por ID:"></asp:Label>
                <asp:TextBox ID="txtBuscarServicio" TextMode="Number"  min="1" max="99999999" CssClass="form-control" required runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnBuscar" formnovalidate CssClass="btn btn-block btn-primary mt-4" OnClick="btnBuscar_Click" runat="server" Text="Buscar" />
            </div>
        </div>
        <br />

        <hr />
        <br />

        <div class="row">
            <div class="col col-md-6">
                <asp:Label ID="lblNombreServicio" runat="server" Text="Nombre servicio:"></asp:Label>
                <asp:TextBox ID="txtNombreServicio" CssClass="form-control" required runat="server" MaxLength="200"></asp:TextBox><br />
            </div>
            <div class="col col-md-6">
                <asp:Label ID="lblValorServicio" runat="server" Text="Valor (sugerido) servicio:"></asp:Label>
                <asp:TextBox ID="txtValorServicio" TextMode="Number" min="0" max="99999999" CssClass="form-control" required runat="server"></asp:TextBox><br />
            </div>
        </div>

        <asp:Button ID="btnModificarServicio" CssClass="btn btn-lg btn-block btn-primary mb-3" OnClick="btnModificarServicio_Click" runat="server" Text="Modificar" />

    </div>
</asp:Content>
