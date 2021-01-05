<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MiTallerMecanico.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login</title>

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
        <a class="navbar-brand" href="#"><span class="texto-logo shadow-lg">Mi Taller Mecánico</span></a>
    </nav>

    <div class="container w-100 py-4 px-5 shadow-lg my-5 rounded">
        <h1 class="text-center display-4 my-4">¡Bienvenido a Mi Taller Mecánico!</h1>
        <br />

        <form id="form1" runat="server">

            <div class="row">
                <div class="col-md-6 p-3 shadow-sm rounded">
                    <h4>Si eres Cliente:</h4>
                    <br />

                    <div class="row h-75">
                        <div class="col align-self-center">
                            <h5 class="text-center">Consulta el estado de tu Vehículo ingresando aquí</h5>
                            <br />

                            <div>
                                <a href="ConusltarMiVehiculo.aspx" class="btn btn-lg btn-block w-75 mx-auto btn-success mb-3" role="button">Consultar</a>
                            </div>
                            
                        </div>
                    </div>

                </div>
                <div class="col-md-6 py-3 px-5 shadow-sm rounded">
                    <h4>Si eres Usuario:</h4>
                    <br />

                    <h5 class="text-center">Inicia Sesión</h5>
                    <br />

                    <div class="w-100 my-auto mx-auto">
                        <asp:Label ID="lblNomUsuario" runat="server" Text="Usuario:"></asp:Label>
                        <asp:TextBox ID="txtNomUsuario" class="form-control" required runat="server"></asp:TextBox><br />

                        <asp:Label ID="lblPassUsuario" runat="server" Text="Contraseña:"></asp:Label>
                        <asp:TextBox ID="txtPassUsuario" class="form-control" required TextMode="Password" runat="server" MaxLength="8"></asp:TextBox><br />

                        <asp:Button ID="btnIngresar" class="btn btn-lg btn-primary btn-block mb-3" OnClick="btnIngresar_Click" runat="server" Text="Ingresar" />
                    </div>
                </div>
            </div>

            <div class="container body-content">
                <hr />
                <footer class="text-center pt-3">
                    <p>&copy; <%: DateTime.Now.Year %> - Mi Taller Mecánico</p>
                </footer>
            </div>

        </form>
    </div>

    <%--SCRIPTS BOOTSTRAP 4.5.3--%>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js" integrity="sha384-w1Q4orYjBQndcko6MimVbzY0tgp4pWB4lZ7lr30WKz0vr/aWKhXdBNmNb5D92v7s" crossorigin="anonymous"></script>
</body>
</html>
