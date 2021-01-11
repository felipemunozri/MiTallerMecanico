<%@ Page Title="Modificar Repuesto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarRepuesto.aspx.cs" Inherits="MiTallerMecanico.ModificarRepuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Modificar Repuesto</h1>
        <br />

        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lblBuscarRepuesto" runat="server" Text="Buscar Repuesto por ID:"></asp:Label>
                <asp:TextBox ID="txtBuscarRepuesto" TextMode="Number"  min="1" max="2147483647" CssClass="form-control" required runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnBuscar" formnovalidate CssClass="btn btn-block btn-main mt-4" OnClick="btnBuscar_Click" runat="server" Text="Buscar" />
            </div>
        </div>
        <br />

        <hr />
        <br />

        <div class="row">
            <div class="col col-md-12">
                <asp:Label ID="lblNombreRepuesto" runat="server" Text="Nombre repuesto:"></asp:Label>
                <asp:TextBox ID="txtNombreRepuesto" CssClass="form-control" required runat="server" MaxLength="100"></asp:TextBox><br />
            </div>
        </div>

        <asp:Button ID="btnModificarRepuesto" CssClass="btn btn-lg btn-block btn-main mb-3" OnClick="btnModificarRepuesto_Click" runat="server" Text="Modificar" />

    </div>
</asp:Content>
