<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="MiTallerMecanico.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container w-100 h-100 py-4 px-5 shadow-lg mb-5 rounded">    
        <h1 class="display-4 mt-4 mb-5">¡Bienvenido <asp:Label ID="lblNombreUsuario" runat="server" Text=""></asp:Label>!</h1>
        <br />

        <h3>
            -Ordenes de Trabajo pendientes:
            <asp:Label ID="lblOrdenesPendientes" class="badge btn-main badge-pill float-right" runat="server" Text="0"></asp:Label>
        </h3>
        <br />

        <h3>
            -Ordenes de Trabajo finalizadas:
            <asp:Label ID="lblOrdenesTerminadas" class="badge btn-main badge-pill float-right" runat="server" Text="0"></asp:Label>
        </h3>
        <br />

        
    </div>

</asp:Content>
