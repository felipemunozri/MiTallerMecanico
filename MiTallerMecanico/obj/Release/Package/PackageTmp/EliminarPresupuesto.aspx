<%@ Page Title="Eliminar Presupuesto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarPresupuesto.aspx.cs" Inherits="MiTallerMecanico.EliminarPresupuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Eliminar Presupuesto</h1>
        <br />

        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblfolioPrepuesto" runat="server" Text="ID de Presupuesto:"></asp:Label>
                <asp:TextBox ID="txtfolioPrepuesto" TextMode="Number"  min="1" max="2147483647" CssClass="form-control" required runat="server"></asp:TextBox>
            </div>
            <div class="col-md-12">
                 <asp:Button ID="btnEliminar" CssClass="btn btn-lg btn-block btn-danger mt-4" OnClick="btnEliminar_Click" runat="server" Text="Eliminar" />
            </div>
        </div>
        <br />

    </div>
</asp:Content>
