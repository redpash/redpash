<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="MAS_PMSU.Login" %>

<head runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>REDPASH - TNS</title>

    <!-- Bootstrap Core CSS -->
    <link href="~/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- MetisMenu CSS -->
    <link href="~/vendor/metisMenu/metisMenu.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="~/dist/css/sb-admin-2.css" rel="stylesheet">

    <!-- Morris Charts CSS -->
    <link href="~/vendor/morrisjs/morris.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="~/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <%--   <asp:ContentPlaceHolder ID="head" runat="server">
    </asp:ContentPlaceHolder>--%>
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>

    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading text-center panel-relative">
                        <h3 class="panel-title">MAS 2.0 - REDPASH</h3>
                    </div>
                    <div class="panel-body">
                        <form role="form" runat="server">
                            <fieldset>
                                <div class="form-group">
                                    <asp:Image ID="Image1" CssClass="center-block" runat="server" Height="130px" ImageUrl="~/imagenes/Logo_color_MAS2.png" Width="197px" />
                                    <%--<asp:Image ID="Image2" CssClass="center-block" runat="server" ImageUrl="~/imagenes/form_logo.png" />--%>
                                    <%--<img src="../imagenes/Logo_color_MAS2.png" alt="..." class="center-block" />--%>
                                </div>
                                <div class="form-group">
                                    <%--<input class="form-control" placeholder="E-mail" name="email" type="email" autofocus>--%>
                                    <label for="TxtUsuario">Usuario:</label>
                                    <asp:TextBox CssClass="form-control" ID="TxtUsuario" runat="server" placeholder="Ingrese el usuario"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <%--<input class="form-control" placeholder="Password" name="password" type="password" value="">--%>
                                    <label for="TxtContrasena">Contraseña:</label>
                                    <asp:TextBox CssClass="form-control" ID="TxtContrasena" runat="server" TextMode="Password" placeholder="Ingrese la contraseña"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:CheckBox ID="chkRememberMe" Text="Recordarme" runat="server" />
                                </div>
                                <asp:Button CssClass="btn btn-primary btn-block" ID="Button1" runat="server" Text="INGRESAR" />
                                <div id="dvMessage" runat="server" visible="false" class="alert alert-danger">
                                    <strong>Error!</strong>
                                    <asp:Label ID="lblMessage" runat="server" />
                                </div>
                            </fieldset>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>