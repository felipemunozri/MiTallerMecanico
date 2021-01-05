<%@ Page Title="Modificar Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="MiTallerMecanico.ModificarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Modificar Usuario</h1>
        <br />

        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lblBuscarUsuario" runat="server" Text="Buscar Usuario por ID:"></asp:Label>
                <asp:TextBox ID="txtBuscarUsuario" TextMode="Number"  min="1" max="99999999" CssClass="form-control" required runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnBuscar" formnovalidate CssClass="btn btn-block btn-primary mt-4" OnClick="btnBuscar_Click" runat="server" Text="Buscar" />
            </div>
        </div>
        <br />

        <hr />
        <br />

        <div class="row">
            <div class="col col-md-12">
                <asp:Label ID="lblTipoUsuario" runat="server" Text="Tipo usuario:"></asp:Label>
                <asp:DropDownList ID="dpTipoUsuario" CssClass="form-control" runat="server"></asp:DropDownList><br />

                <asp:Label ID="lblNomUsuario" runat="server" Text="Nombre usuario:"></asp:Label>
                <asp:TextBox ID="txtNomUsuario" CssClass="form-control" required runat="server"></asp:TextBox><br />

                <asp:Label ID="lblPassUsuario" runat="server" Text="Contraseña:"></asp:Label>
                <asp:TextBox ID="txtPassUsuario" TextMode="Password" CssClass="form-control" required runat="server" MaxLength="8"></asp:TextBox><br />
            </div>
        </div>

        <asp:Button ID="btnModificarUsuario" CssClass="btn btn-lg btn-block btn-primary mb-3" OnClick="btnModificarUsuario_Click" runat="server" Text="Modificar" />

    </div>
</asp:Content>
