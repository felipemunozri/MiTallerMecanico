<%@ Page Title="Modificar Orden de Trabajo - Mecánico" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarOrdenTrabajo_mecanico.aspx.cs" Inherits="MiTallerMecanico.ModificarOrdenMecanico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Modificar Orden de Trabajo</h1>
        <br />

        <h3>-Ingrese ID de la Orden de trabajo y Patente del vehículo:</h3>
        <br />

        <div class="row">
            <div class="col-md-4 pb-3">
                <asp:Label ID="lblBuscarOrden" runat="server" Text="ID Orden de Trabajo:"></asp:Label>
                <asp:TextBox ID="txtBuscarOrden" TextMode="Number" min="1" CssClass="form-control" required runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4 pb-3">
                <asp:Label ID="lblBuscarVehiculo" runat="server" Text="Patente:"></asp:Label>
                <asp:TextBox ID="txtBuscarVehiculo" CssClass="form-control" required runat="server" MaxLength="6"></asp:TextBox>
            </div>
            <div class="col-md-4 pb-3">
                <asp:Button ID="btnBuscar" formnovalidate CssClass="btn btn-block btn-main mt-4" OnClick="btnBuscar_Click" runat="server" Text="Buscar" />
            </div>
        </div>
        <br />

        <hr />
        <br />

        <h3>-Información Orden de Trabajo:</h3>
        <br />

        <div class="row">
            <div class="col col-md-12">
                <asp:Label ID="lblIdOrden" runat="server" Text="ID Orden de Trabajo:"></asp:Label>
                <asp:TextBox ID="txtIdOrden" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox><br />

                <asp:Label ID="lblPatente" runat="server" Text="Patente Vehículo:"></asp:Label>
                <asp:TextBox ID="txtPatente" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox><br />

                <asp:Label ID="lblMarca" runat="server" Text="Marca:"></asp:Label>
                <asp:TextBox ID="txtMarca" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox><br />

                <asp:Label ID="lblModelo" runat="server" Text="Modelo:"></asp:Label>
                <asp:TextBox ID="txtModelo" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox><br />

                <asp:Label ID="lblEstado" runat="server" Text="Estado:"></asp:Label>
                <asp:DropDownList ID="dpEstado" CssClass="form-control" required runat="server">
                    <asp:ListItem Text="- - Seleccionar" Value="" Selected="True"/>
                    <asp:ListItem Value="Ingresado" Text="Vehículo Ingresado"></asp:ListItem>
                    <asp:ListItem Value="En reparacion" Text="Vehículo en Reparacion"></asp:ListItem>
                    <asp:ListItem Value="Listo para retiro" Text="Vehículo listo para Retiro"></asp:ListItem>
                    <asp:ListItem Value="Entregado" Text="Vehículo Entregado"></asp:ListItem>
                </asp:DropDownList><br />
            </div>
        </div>

        <asp:Button ID="btnModificarOrdenTrabajo" CssClass="btn btn-lg btn-block btn-main mb-3" OnClick="btnModificarOrdenTrabajo_Click" runat="server" Text="Modificar" /><br />

        <%--<a href="ModificarOrdenTrabajo.aspx" role="button" class="btn btn-lg btn-block btn-danger mb-3">Limpiar formulario</a><br />   --%>     

    </div>  
</asp:Content>
