<%@ Page Title="Consultar Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarUsuario.aspx.cs" Inherits="MiTallerMecanico.ConsultarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Consultar Usuario</h1>
        <br />

        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="lblFiltro" runat="server" Text="Filtrar por:"></asp:Label>
                <asp:TextBox ID="txtFiltro" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblCampo" runat="server" Text="Campo:"></asp:Label>
                <asp:DropDownList ID="dpCampo" CssClass="form-control" runat="server">
                    <asp:ListItem Value="idUsuario" Text="ID de Usuario" />
                    <asp:ListItem Value="fk_idTipoUsuario" Text="Tipo de Usuario" />
                    <asp:ListItem Value="nombreUsuario" Text="Nombre" />
                    <asp:ListItem Value="passUsuario" Text="Contraseña" />
                </asp:DropDownList>
            </div>
            <div class="col-md-4">
                 <asp:Button ID="btnFiltrar" CssClass="btn btn-block btn-primary mt-4" OnClick="btnFiltrar_Click" runat="server" Text="Filtrar" />
            </div>
        </div>
        <br />

        <hr />

        <div class="table-responsive">
            <asp:GridView ID="gvResultado" AutoGenerateColumns="true" CssClass="table table-sm table-secondary" EmptyDataText="No se han encontrado registros!" runat="server">
            
            </asp:GridView>
        </div>
        <br />

    </div>
</asp:Content>
