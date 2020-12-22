<%@ Page Title="Registrar Repuesto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarRepuesto.aspx.cs" Inherits="MiTallerMecanico.RegistrarRepuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Registrar Repuesto</h1>
        <br />

        <div class="row">
            <div class="col col-md-12">
                <asp:Label ID="lblNombreRepuesto" runat="server" Text="Nombre repuesto:"></asp:Label>
                <asp:TextBox ID="txtNombreRepuesto" CssClass="form-control" required runat="server"></asp:TextBox><br />
            </div>
        </div>

        <asp:Button ID="btnRegistrarRepuesto" CssClass="btn btn-lg btn-block btn-primary mb-3" OnClick="btnRegistrarRepuesto_Click" runat="server" Text="Registrar" />

    </div>
</asp:Content>
