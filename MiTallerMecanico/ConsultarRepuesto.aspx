<%@ Page Title="Consultar Repuesto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarRepuesto.aspx.cs" Inherits="MiTallerMecanico.ConsultarRepuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Consultar Repuesto</h1>
        <br />

        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="lblFiltro" runat="server" Text="Filtrar por:"></asp:Label>
                <asp:TextBox ID="txtFiltro" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblCampo" runat="server" Text="Campo:"></asp:Label>
                <asp:DropDownList ID="dpCampo" CssClass="form-control" runat="server">
                    <asp:ListItem Value="idRepuesto" Text="ID de Repuesto" />
                    <asp:ListItem Value="nombreRepuesto" Text="Nombre de repuesto" />
                </asp:DropDownList>
            </div>
            <div class="col-md-4">
                 <asp:Button ID="btnFiltrar" CssClass="btn btn-block btn-primary mt-4" OnClick="btnFiltrar_Click" runat="server" Text="Filtrar" />
            </div>
        </div>
        <br />

        <hr />

        <div class="table-responsive">
            <asp:GridView ID="gvResultado" AutoGenerateColumns="false" CssClass="table table-sm table-secondary" EmptyDataText="No se han encontrado registros!" runat="server">
            <Columns>
                <asp:BoundField DataField="idRepuesto" HeaderText="ID del repuesto" SortExpression="idRepuesto" />
                <asp:BoundField DataField="nombreRepuesto" HeaderText="Nombre del repuesto" SortExpression="nombreRepuesto" />
            </Columns>
            </asp:GridView>
        </div>
        <br />

        <asp:Button ID="btnExportar" CssClass="btn btn-block btn-primary mt-4" OnClick="btnExportar_Click" runat="server" Text="Exportar a Excel" />

    </div>
</asp:Content>
