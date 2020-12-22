<%@ Page Title="Registrar Servico" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarServicio.aspx.cs" Inherits="MiTallerMecanico.RegistrarServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Registrar Servicio</h1>
        <br />

        <div class="row">
            <div class="col col-md-12">
                <asp:Label ID="lblNombreServicio" runat="server" Text="Nombre servicio:"></asp:Label>
                <asp:TextBox ID="txtNombreServicio" CssClass="form-control" required runat="server"></asp:TextBox><br />
            </div>
        </div>

        <asp:Button ID="btnRegistrarServicio" CssClass="btn btn-lg btn-block btn-primary mb-3" OnClick="btnRegistrarServicio_Click" runat="server" Text="Registrar" />

    </div>
</asp:Content>
