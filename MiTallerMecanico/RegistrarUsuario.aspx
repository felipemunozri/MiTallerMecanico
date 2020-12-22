<%@ Page Title="Registrar Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="MiTallerMecanico.RegistrarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Registrar Usuario</h1>
        <br />

        <div class="row">
            <div class="col col-md-12">
                <asp:Label ID="lblTipoUsuario" runat="server" Text="Tipo usuario:"></asp:Label>
                <asp:DropDownList ID="dpTipoUsuario" CssClass="form-control" runat="server"></asp:DropDownList><br />

                <asp:Label ID="lblNomUsuario" runat="server" Text="Nombre usuario:"></asp:Label>
                <asp:TextBox ID="txtNomUsuario" CssClass="form-control" required runat="server"></asp:TextBox><br />

                <asp:Label ID="lblPassUsuario" runat="server" Text="Contraseña:"></asp:Label>
                <asp:TextBox ID="txtPassUsuario" TextMode="Password" CssClass="form-control" required runat="server"></asp:TextBox><br />
            </div>
        </div>

        <asp:Button ID="btnRegistrarUsuario" CssClass="btn btn-lg btn-block btn-primary mb-3" OnClick="btnRegistrarUsuario_Click" runat="server" Text="Registrar" />

    </div>
</asp:Content>
