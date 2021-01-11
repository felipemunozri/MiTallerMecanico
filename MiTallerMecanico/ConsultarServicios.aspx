<%@ Page Title="Consultar Servicios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarServicios.aspx.cs" Inherits="MiTallerMecanico.ConusltarServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Consultar Servicio</h1>
        <br />

        <div class="row">
            <div class="col-md-4 pb-3">
                <asp:Label ID="lblFiltro" runat="server" Text="Filtrar por:"></asp:Label>
                <asp:TextBox ID="txtFiltro" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4 pb-3">
                <asp:Label ID="lblCampo" runat="server" Text="Campo:"></asp:Label>
                <asp:DropDownList ID="dpCampo" CssClass="form-control" runat="server">
                    <asp:ListItem Value="idServicio" Text="ID de Servicio" />
                    <asp:ListItem Value="nombreServicio" Text="Nombre de servicio" />
                    <asp:ListItem Value="valorServicio" Text="Valor de servicio" />
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
                <asp:BoundField DataField="idServicio" HeaderText="ID del servicio" SortExpression="idServicio" />
                <asp:BoundField DataField="nombreServicio" HeaderText="Nombre del servicio" SortExpression="nombreServicio" />
                <asp:BoundField DataField="valorServicio" HeaderText="Valor del servicio" SortExpression="valorServicio" />
            </Columns>
            </asp:GridView>
        </div>
        <br />

        <asp:Button ID="btnExportar" CssClass="btn btn-lg btn-block btn-success mt-4" OnClick="btnExportar_Click" runat="server" Text="Exportar a Excel" />

    </div>
</asp:Content>
