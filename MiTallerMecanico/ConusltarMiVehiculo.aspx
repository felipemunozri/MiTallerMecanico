<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConusltarMiVehiculo.aspx.cs" Inherits="MiTallerMecanico.ConusltarmiVehiculo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Consultar Mi Vehículo</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <%--GOOGLE FONTS--%>
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Noto+Sans+JP&family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,500&display=swap" rel="stylesheet">

    <%--CSS BOOTSTRAP 4.5.3--%>
    <%-- <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">--%>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">

    <%-- CUSTOM CSS --%>
    <link href="Content/style.css" rel="stylesheet" />
</head>
<body>
    <nav class="navbar navbar-dark navbar-expand-xl shadow-lg p-3">
        <a class="navbar-brand" href="Login.aspx">
            <img class="mx-1 mb-2" src="images/Logo-Taller6.png" alt="logo Mi Taller Mecánico" width="25" />
            <span class="texto-logo shadow-lg">Mi Taller Mecánico</span>
        </a>
    </nav>

    <div class="container w-100 py-4 px-5 shadow-lg mb-5 rounded">
        <h1 class="display-4 mt-4 mb-5">·Consultar Mi Vehículo</h1>
        <br />

        <form id="form1" runat="server">

            <h3>-Ingrese el ID de su Orden de Trabajo y la Patente de su Vehículo:</h3>
            <br />

            <div class="row">
                <div class="col-md-4 pb-3">
                    <asp:Label ID="lblBuscarOrden" runat="server" Text="ID Orden de Trabajo:"></asp:Label>
                    <asp:TextBox ID="txtBuscarOrden" TextMode="Number" min="1" CssClass="form-control" required runat="server"></asp:TextBox>
                </div>
                <div class="col-md-4 pb-3">
                    <asp:Label ID="lblBuscarVehiculo" runat="server" Text="Patente:"></asp:Label>
                    <asp:TextBox ID="txtBuscarVehiculo" CssClass="form-control" required runat="server"></asp:TextBox>
                </div>
                <div class="col-md-4 pb-3">
                    <asp:Button ID="btnBuscar" formnovalidate CssClass="btn btn-block btn-main mt-4" OnClick="btnBuscar_Click" runat="server" Text="Buscar" />
                </div>
            </div>
            <br />

            <hr />
            <br />

            <h3>-Información de su Vehículo:</h3>
            <br />

            <div class="row">
                <div class="col col-md-12">
                    <asp:Label ID="lblIdOrden" runat="server" Text="ID Orden de Trabajo:"></asp:Label>
                    <asp:TextBox ID="txtIdOrden" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox><br />

                    <asp:Label ID="lblRutCliente" runat="server" Text="Rut Cliente:"></asp:Label>
                    <asp:TextBox ID="txtRutCliente" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox><br />

                    <asp:Label ID="lblPatente" runat="server" Text="Patente:"></asp:Label>
                    <asp:TextBox ID="txtPatente" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox><br />

                    <asp:Label ID="lblValorOrden" runat="server" Text="Valor Orden de Trabajo:"></asp:Label>
                    <asp:TextBox ID="txtValorOrden" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox><br />

                    <asp:Label ID="lblEstado" runat="server" Text="Estado de su Vehículo:"></asp:Label>
                    <asp:TextBox ID="txtEstado" Cssclass="form-control" ReadOnly="true" runat="server"></asp:TextBox><br />
                    <br />
                </div>
            </div>

            <div>
                <a href="Login.aspx" class="btn btn-lg btn-block btn-main mb-3" role="button">Volver</a>
            </div>

        </form>
    </div>

    <%--SCRIPTS BOOTSTRAP 4.5.3--%>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js" integrity="sha384-w1Q4orYjBQndcko6MimVbzY0tgp4pWB4lZ7lr30WKz0vr/aWKhXdBNmNb5D92v7s" crossorigin="anonymous"></script>
</body>
</html>
