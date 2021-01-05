﻿<%@ Page Title="Modificar Presupuesto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarPresupuesto.aspx.cs" Inherits="MiTallerMecanico.ModificarPresupuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Modificar Presupuesto</h1>
        <br />

        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lblBuscarPresupuesto" runat="server" Text="Buscar Presupuesto por ID:"></asp:Label>
                <asp:TextBox ID="txtBuscarPresupuesto" TextMode="Number"  min="1" max="99999999" CssClass="form-control" required runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnBuscar" formnovalidate CssClass="btn btn-block btn-primary mt-4" OnClick="btnBuscar_Click" runat="server" Text="Buscar" />
            </div>
        </div>
        <br />

        <hr />
        <br />

        <h4>Información de Presupuesto:</h4>
        <br />

        <div class="row">
            <div class="col col-md-12">
                <asp:Label ID="lblPatente" runat="server" Text="Patente vehículo:"></asp:Label>
                <asp:TextBox ID="txtPatente" AutoPostBack="true" OnTextChanged="txtPatente_TextChanged" CssClass="form-control" required runat="server" MaxLength="6"></asp:TextBox><br />

                 <asp:Label ID="lblRutCliente" runat="server" Text="Rut cliente:"></asp:Label>
                <asp:TextBox ID="txtRutCliente" CssClass="form-control" required runat="server" MaxLength="10"></asp:TextBox><br />

                <asp:Label ID="lblFecha" runat="server" Text="Fecha:"></asp:Label>
                <asp:TextBox ID="txtFecha" CssClass="form-control" TextMode="Date" required runat="server"></asp:TextBox><br />
            </div>
        </div>

        <hr />


        <h4>Añadir Servicios:</h4>
        <br />

        <div class="row">
            <div class="col-md-3 mb-4">
                <asp:Label ID="lblSelecServicio" runat="server" Text="Buscar por nombre:"></asp:Label>
                <asp:DropDownList ID="dpSelecServicio" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-3 mb-4">
                <asp:Label ID="lblCantServicios" runat="server" Text="Cantidad:"></asp:Label>
                <asp:TextBox ID="txtCantServicios" CssClass="form-control" TextMode="Number" min="1" max="999" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lblValorServicio" runat="server" Text="Valor unitario:"></asp:Label>
                <asp:TextBox ID="txtValorServicio" placeholder="$" CssClass="form-control" TextMode="Number" min="0" max="99999999" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnAgregaServicio" CssClass="btn btn-block btn-primary mt-4" OnClick="btnAgregaServicio_Click" runat="server" Text="Añadir" />
            </div>
        </div>
        <br />
        <hr />

        <h4>Añadir Repuestos:</h4>
        <br />

        <div class="row">
            <div class="col-md-3 mb-4">
                <asp:Label ID="lblSelecRepuesto" runat="server" Text="Buscar por nombre:"></asp:Label>
                <asp:DropDownList ID="dpSelecRepuesto" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-3 mb-4">
                <asp:Label ID="lblCantRepuestos" runat="server" Text="Cantidad:"></asp:Label>
                <asp:TextBox ID="txtCantRepuestos" CssClass="form-control" TextMode="Number" min="1" max="999" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lblValorRepuesto" runat="server" Text="Valor unitario:"></asp:Label>
                <asp:TextBox ID="txtValorRepuesto" placeholder="$" CssClass="form-control" TextMode="Number" min="0" max="99999999" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnAgregaRepuesto" CssClass="btn btn-block btn-primary  mt-4" OnClick="btnAgregaRepuesto_Click" runat="server" Text="Añadir" />
            </div>
        </div>
        <br />
        <hr />

        <h4>Detalle de Servicios y Repuestos:</h4>
        <br />

        <div class="table-responsive">
            <asp:GridView ID="gvSeleccion" CssClass="table table-sm table-secondary" OnSelectedIndexChanged="gvSeleccion_SelectedIndexChanged" EmptyDataText="No hay más registros!" runat="server">
                <Columns>
                    <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-sm btn-danger d-flex m-auto" ShowSelectButton="true" SelectText="Borrar" />
                </Columns>
            </asp:GridView>
        </div>
        <br />

        <asp:Label ID="lblMontoIVA" runat="server" Text="Monto IVA:"></asp:Label>
        <asp:TextBox ID="txtMontoIVA" Text="0" required ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox><br />

        <asp:Label ID="lblMontoTotal" runat="server" Text="Monto Total:"></asp:Label>
        <asp:TextBox ID="txtMontoTotal" Text="0" required ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox><br />
        <hr />

        <asp:Button ID="btnModificarPresupuesto" CssClass="btn btn-lg btn-block btn-primary mb-3" OnClick="btnModificarPresupuesto_Click" runat="server" Text="Modificar" /><br />

        <button type="button" class="btn btn-lg btn-block btn-success mb-3" onclick="window.print()">Imprimir</button><br />

        <%--<a href="ModificarPresupuesto.aspx" role="button" class="btn btn-lg btn-block btn-danger mb-3">Limpiar formulario</a>--%>

    </div>   
</asp:Content>
