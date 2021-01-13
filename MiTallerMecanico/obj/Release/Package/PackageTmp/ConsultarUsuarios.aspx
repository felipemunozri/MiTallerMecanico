<%@ Page Title="Consultar Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarUsuarios.aspx.cs" Inherits="MiTallerMecanico.ConsultarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Consultar Usuarios</h1>
        <br />

        <div class="row">
            <div class="col-md-4 pb-3">
                <asp:Label ID="lblFiltro" runat="server" Text="Filtrar por:"></asp:Label>
                <asp:TextBox ID="txtFiltro" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4 pb-3">
                <asp:Label ID="lblCampo" runat="server" Text="Campo:"></asp:Label>
                <asp:DropDownList ID="dpCampo" CssClass="form-control" runat="server">
                    <asp:ListItem Value="idUsuario" Text="ID de Usuario" />
                    <asp:ListItem Value="fk_idTipoUsuario" Text="Tipo de Usuario" />
                    <asp:ListItem Value="nombreUsuario" Text="Nombre" />
                    <asp:ListItem Value="passUsuario" Text="Contraseña" />
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
                    <asp:BoundField DataField="idUsuario" HeaderText="ID Usuario" SortExpression="idUsuario" />
                    <asp:BoundField DataField="fk_idTipoUsuario" HeaderText="ID Tipo de Usuario" SortExpression="fk_idTipoUsuario" />
                    <asp:BoundField DataField="nombreUsuario" HeaderText="Nombre usuario" SortExpression="nombreUsuario" />
                    <asp:BoundField DataField="passUsuario" HeaderText="Contraseña" SortExpression="passUsuario" />
                </Columns>
            </asp:GridView>
        </div>
        <br />

        <asp:Button ID="btnExportar" CssClass="btn btn-lg btn-block btn-success mt-4" OnClick="btnExportar_Click" runat="server" Text="Exportar a Excel" />

    </div>
</asp:Content>
