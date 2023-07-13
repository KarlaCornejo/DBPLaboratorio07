<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AplicacionWebParaDBP.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewData["Title"] - MiPrimeraAPI</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-9ndCyUaIbzAi2FUVXJi0CjmCapSmO7SnpJef0486qhLnuZ2cdeRhO02iuK6FUUVM" crossorigin="anonymous" />
    <link rel="stylesheet" href="site.css" asp-append-version="true" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <script src="site.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</head>
<body>
    <form id="miFormulario" runat="server">
        <!-- Contenido del formulario -->

        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <header>
            <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
                <div class="container-fluid">
                    <a class="navbar-brand" href="WebForm1.aspx">MiPrimeraAPI</a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                        <ul class="navbar-nav flex-grow-1">
                            <li class="nav-item">
                                <a class="nav-link text-dark" href="WebForm1.aspx">Home</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link text-dark" href="Privacy.aspx">Privacy</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        </header>

        <div class="container">
            <h2>Registro de Alumno</h2>
            <div>
                <label for="nombre">Nombre:</label>
                <asp:TextBox ID="nombre" runat="server" CssClass="form-control" placeholder="Ingrese su nombre"></asp:TextBox>
            </div>
            <div>
                <label for="apellidos">Apellidos:</label>
                <asp:TextBox ID="apellidos" runat="server" CssClass="form-control" placeholder="Ingrese sus apellidos"></asp:TextBox>
            </div>
            <div>
                <label for="sexo">Sexo:</label><br />
                <asp:RadioButtonList ID="sexo" runat="server">
                    <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                    <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div>
                <label for="correo">Correo:</label>
                <asp:TextBox ID="correo" runat="server" CssClass="form-control" placeholder="Ingrese su correo"></asp:TextBox>
            </div>
            <div>
                <label for="direccion">Dirección:</label>
                <asp:TextBox ID="direccion" runat="server" CssClass="form-control" placeholder="Ingrese su dirección"></asp:TextBox>
            </div>
            <div>
                <label>Ciudad:</label>
                <asp:DropDownList ID="ciudadDropdown" runat="server"></asp:DropDownList>
            </div>
            <div>
                <label for="descripcion">Descripción:</label>
                <asp:TextBox ID="descripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="ButtonEnviar" runat="server" Text="Enviar" OnClick="ButtonEnviar_Click" CssClass="btn btn-success btn-lg" />
                <button type="button" class="btn btn-default button_primary_propio" onclick="limpiarCampos()">Limpiar</button>
            </div>
        </div>

    <span id="serverSuccessMessage" runat="server" visible="false" class="text-success"></span>
     <div class="container">
    <div id="resultContainer" runat="server" visible="false">
        <h3>Valores recibidos:</h3>
        <p><strong>Nombre:</strong> <span id="lblNombre" runat="server"></span></p>
        <p><strong>Apellidos:</strong> <span id="lblApellidos" runat="server"></span></p>
        <p><strong>Sexo:</strong> <span id="lblSexo" runat="server"></span></p>
        <p><strong>Correo:</strong> <span id="lblCorreo" runat="server"></span></p>
        <p><strong>Dirección:</strong> <span id="lblDireccion" runat="server"></span></p>
        <p><strong>Ciudad:</strong> <span id="lblCiudad" runat="server"></span></p>
        <p><strong>Descripción:</strong> <span id="lblDescripcion" runat="server"></span></p>
    </div>
    </div>
        <div id="myModal" class="modal fade" role="dialog">
        
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="icon-box">
                            <i class="material-icons">
                                <span class="material-symbols-outlined">
                                    done
                                </span>
                            </i>
                        </div>
                        <button type="button" class="close btn btn-danger" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <!-- Mensaje se inserta dinámicamente aquí -->
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>

        <footer class="border-top footer text-muted">
            <div class="container">
                &copy; 2023 - MiPrimeraAPI - <a href="Privacy.aspx">Privacy</a>
            </div>
        </footer>
    </form>
</body>
</html>
