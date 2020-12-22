<%@ Page Title="Eliminar Orden de Trabajo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarOrdenTrabajo.aspx.cs" Inherits="MiTallerMecanico.EliminarOrdenTrabajo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Eliminar Orden de Trabajo</h1>
        <br />

        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblFolioOrden" runat="server" Text="ID de Orden de Trabajo:"></asp:Label>
                <asp:TextBox ID="txtFolioOrden" TextMode="Number"  min="1" CssClass="form-control" required runat="server"></asp:TextBox>
            </div>
            <div class="col-md-12">
                 <asp:Button ID="btnEliminar" CssClass="btn btn-lg btn-block btn-danger mt-4" OnClick="btnEliminar_Click" runat="server" Text="Eliminar" />
            </div>
        </div>
        <br />

    </div>
</asp:Content>
