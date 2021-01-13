<%@ Page Title="Registrar Tipo Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarTipoUsuario.aspx.cs" Inherits="MiTallerMecanico.RegistrarTipoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Registrar Tipo Usuario</h1>
        <br />

        <div class="row">
            <div class="col col-md-12">
                <asp:Label ID="lblCargo" runat="server" Text="Cargo usuario:"></asp:Label>
                <asp:TextBox ID="txtCargo" CssClass="form-control" required runat="server" MaxLength="50"></asp:TextBox><br />
            </div>
        </div>

        <asp:Button ID="btnRegistrarTipoUsuario" CssClass="btn btn-lg btn-block btn-main mb-3" OnClick="btnRegistrarTipoUsuario_Click" runat="server" Text="Registrar" />

    </div>
</asp:Content>
