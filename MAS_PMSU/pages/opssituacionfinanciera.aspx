<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="opssituacionfinanciera.aspx.vb" Inherits="MAS_PMSU.opssituacionfinanciera" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header"></h1>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    SITUACION FINANCIERA DE LAS ORGANIZACIONES
                </div>
                <div class="panel-body">
                    <%--<form role="form" runat="server">--%>
                    <ul class="nav nav-pills">
                        <li class="active"><a href="#Datos" data-toggle="tab">Datos</a>
                        </li>
                        <li><a href="#Graficos" data-toggle="tab">Graficos</a>
                        </li>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane fade in active" id="Datos">
                            <div class="panel-body">
                                <div class="row">
                                    <%--<div class="col-lg-4">
                                        <div class="form-group">
                                            <label>Seleccione Departamento:</label>
                                            <asp:DropDownList CssClass="form-control" ID="TxtDepto" runat="server" AutoPostBack="True"></asp:DropDownList>

                                        </div>
                                    </div>--%>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label>Seleccione Tecnico:</label>
                                            <asp:DropDownList CssClass="form-control" ID="TxtEntrenador" runat="server" AutoPostBack="True"></asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label>Seleccione Organización:</label>
                                            <asp:DropDownList CssClass="form-control" ID="cmborganizacion" runat="server" AutoPostBack="True"></asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                                <!-- /.row (nested) -->

                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="table-responsive">
                                            <h3>
                                                <span style="float: right;"><small>Total de registros:</small>
                                                    <asp:Label ID="lblTotalClientes" runat="server" CssClass="label label-warning" /></span>
                                            </h3>
                                            <p>&nbsp;</p>
                                            <p>&nbsp;</p>
                                            <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnODK2 %>" ProviderName="<%$ ConnectionStrings:ConnODK2.ProviderName %>"></asp:SqlDataSource>
                                            <asp:GridView ID="GridDatos" runat="server" CellPadding="4" ForeColor="#333333" Width="100%" DataKeyNames="id"
                                                GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource1" Font-Size="Small">
                                                <HeaderStyle BackColor="#8A4500" Font-Bold="True" ForeColor="White" />
                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                <EmptyDataTemplate>
                                                    ¡No hay datos registrados!  
                                                </EmptyDataTemplate>
                                                <%--Paginador...--%>
                                                <PagerTemplate>
                                                    <div class="row" style="margin-top: 8px;">
                                                        <div class="col-lg-1" style="text-align: right;">
                                                            <h5>
                                                                <asp:Label ID="MessageLabel" Text="Ir a la pág." runat="server" /></h5>
                                                        </div>
                                                        <div class="col-lg-1" style="text-align: left;">
                                                            <asp:DropDownList ID="PageDropDownList" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="PageDropDownList_SelectedIndexChanged" runat="server" CssClass="form-control" /></h3>
                                                        </div>
                                                        <div class="col-lg-10" style="text-align: right;">
                                                            <h3>
                                                                <asp:Label ID="CurrentPageLabel" runat="server" CssClass="label label-warning" /></h3>
                                                        </div>
                                                    </div>
                                                </PagerTemplate>
                                                <Columns>
                                                    <asp:ButtonField ButtonType="Button" Text="Editar" ControlStyle-CssClass="btn btn-warning" HeaderText="Editar" CommandName="Editar">
                                                        <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                                    </asp:ButtonField>
                                                    <asp:ButtonField ButtonType="Button" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" CommandName="Eliminar">
                                                        <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                                                    </asp:ButtonField>
                                                    <asp:BoundField DataField="id">
                                                        <HeaderStyle CssClass="hide" />
                                                        <ItemStyle CssClass="hide" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Depto_Descripcion" HeaderText="DEPARTAMENTO" />
                                                    <asp:BoundField DataField="asesor_nombre" HeaderText="ASESOR" />
                                                    <asp:BoundField DataField="OP_NOMBRE" HeaderText="OP_NOMBRE" />
                                                    <asp:BoundField DataField="Trimestre" HeaderText="Trimestre" />
                                                    <asp:BoundField DataField="Ano" HeaderText="Año" />
                                                    <asp:BoundField DataField="Cartera_Prestamos" HeaderText="Cartera_Prestamos" />
                                                    <asp:BoundField DataField="Mora_Prestamos" HeaderText="Mora_Prestamos" />
                                                    <asp:BoundField DataField="Depositos_Ahorro" HeaderText="Depositos_Ahorro" />
                                                    <asp:BoundField DataField="Prestamos_Pagar" HeaderText="Prestamos_Pagar" />
                                                    <asp:BoundField DataField="Capital_Social" HeaderText="Capital_Social" />
                                                    <asp:BoundField DataField="Reserva" HeaderText="Capital_Semilla" />
                                                    <asp:BoundField DataField="Intereses_Cobrados" HeaderText="Intereses_Cobrados" />
                                                    <asp:BoundField DataField="Intereses_Pagados" HeaderText="Intereses_Pagados" />
                                                    <asp:BoundField DataField="Capital_Trabajo" HeaderText="Capital_Trabajo" />
                                                </Columns>
                                                <EditRowStyle BackColor="#7C6F57" />
                                            </asp:GridView>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
                                        <%--<input type="button" id="BAgregar" class="btn btn-success" value="Agregar registro" />--%>
                                        <asp:Button ID="BAgregar" runat="server" class="btn btn-success" Text="Agregar registro" />
                                        <%--  <script type="text/javascript">
                                                $(function () {
                                                    $("#BAgregar").click(function () {
                                                        $('#EditModal').modal('show');
                                                    });
                                                });
                                            </script>--%>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <%--<asp:Button ID="Button1" runat="server" Text="Exportar Datos" CssClass="btn btn-success" />--%>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning" Text="Exportar Datos"><span class="glyphicon glyphicon-save"></span>&nbsp;Exportar Datos</asp:LinkButton>
                                    </div>

                                </div>
                                <div class="modal fade" id="EditModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle"
                                    aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                    &times;</button>
                                                <h4 class="modal-title" id="ModalTitle">Datos del Registro</h4>
                                            </div>
                                            <div class="modal-body">
                                                <asp:TextBox ID="TxtID" runat="server" Visible="False" ></asp:TextBox>
                                                <asp:CheckBox ID="ChNuevo" runat="server" Visible="False" />
                                                <label for="TxtOrg">
                                                    CRAC</label>
                                                <%--<asp:TextBox ID="TxtOrg" runat="server" CssClass="form-control" ReadOnly="True" />--%>
                                                <asp:DropDownList CssClass="form-control" ID="TxtOrg" runat="server" Enabled="False"></asp:DropDownList>
                                                <br />
                                                <label for="TxtTrimestre">
                                                    Trimestre</label>
                                                <asp:DropDownList CssClass="form-control" ID="TxtTrimestre" runat="server">
                                                    <asp:ListItem>I</asp:ListItem>
                                                    <asp:ListItem>II</asp:ListItem>
                                                    <asp:ListItem>III</asp:ListItem>
                                                    <asp:ListItem>IV</asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <label for="TxtAno">
                                                    Año</label>
                                                <asp:DropDownList CssClass="form-control" ID="TxtAno" runat="server">
                                                    <asp:ListItem>2018</asp:ListItem>
                                                    <asp:ListItem>2019</asp:ListItem>
                                                    <asp:ListItem>2020</asp:ListItem>
                                                    <asp:ListItem>2021</asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <label for="TxtValor">
                                                    Cartera acumulada de prestamos Lps.</label>
                                                <asp:TextBox ID="TxtCartera" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                <script type="text/javascript">
                                                    function numericOnly(elementRef) {
                                                        var keyCodeEntered = (event.which) ? event.which : (window.event.keyCode) ? window.event.keyCode : -1;

                                                        // Un-comment to discover a key that I have forgotten to take into account...
                                                        //alert(keyCodeEntered);

                                                        if ((keyCodeEntered >= 48) && (keyCodeEntered <= 57)) {
                                                            return true;
                                                        }
                                                        else if (keyCodeEntered == 46) {
                                                            // Allow only 1 decimal point ('.')...
                                                            if ((elementRef.value) && (elementRef.value.indexOf('.') >= 0))
                                                                return false;
                                                            else
                                                                return true;
                                                        }

                                                        return false;
                                                    }
                                                </script>
                                                <br />
                                                <label for="TxtValor">
                                                    Saldo de Prestamos en Mora Lps.</label>
                                                <asp:TextBox ID="TxtMora" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                <script type="text/javascript">
                                                    function numericOnly(elementRef) {
                                                        var keyCodeEntered = (event.which) ? event.which : (window.event.keyCode) ? window.event.keyCode : -1;

                                                        // Un-comment to discover a key that I have forgotten to take into account...
                                                        //alert(keyCodeEntered);

                                                        if ((keyCodeEntered >= 48) && (keyCodeEntered <= 57)) {
                                                            return true;
                                                        }
                                                        else if (keyCodeEntered == 46) {
                                                            // Allow only 1 decimal point ('.')...
                                                            if ((elementRef.value) && (elementRef.value.indexOf('.') >= 0))
                                                                return false;
                                                            else
                                                                return true;
                                                        }

                                                        return false;
                                                    }
                                                </script>
                                                <br />
                                                <label for="TxtValor">
                                                    Depósitos de Ahorro Lps.</label>
                                                <asp:TextBox ID="TxtDepositos" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                <script type="text/javascript">
                                                    function numericOnly(elementRef) {
                                                        var keyCodeEntered = (event.which) ? event.which : (window.event.keyCode) ? window.event.keyCode : -1;

                                                        // Un-comment to discover a key that I have forgotten to take into account...
                                                        //alert(keyCodeEntered);

                                                        if ((keyCodeEntered >= 48) && (keyCodeEntered <= 57)) {
                                                            return true;
                                                        }
                                                        else if (keyCodeEntered == 46) {
                                                            // Allow only 1 decimal point ('.')...
                                                            if ((elementRef.value) && (elementRef.value.indexOf('.') >= 0))
                                                                return false;
                                                            else
                                                                return true;
                                                        }

                                                        return false;
                                                    }
                                                </script>
                                                <br />
                                                <label for="TxtValor">
                                                    Prestamos por Pagar Lps.</label>
                                                <asp:TextBox ID="TxtPrestamos" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                <script type="text/javascript">
                                                    function numericOnly(elementRef) {
                                                        var keyCodeEntered = (event.which) ? event.which : (window.event.keyCode) ? window.event.keyCode : -1;

                                                        // Un-comment to discover a key that I have forgotten to take into account...
                                                        //alert(keyCodeEntered);

                                                        if ((keyCodeEntered >= 48) && (keyCodeEntered <= 57)) {
                                                            return true;
                                                        }
                                                        else if (keyCodeEntered == 46) {
                                                            // Allow only 1 decimal point ('.')...
                                                            if ((elementRef.value) && (elementRef.value.indexOf('.') >= 0))
                                                                return false;
                                                            else
                                                                return true;
                                                        }

                                                        return false;
                                                    }
                                                </script>
                                                <br />
                                                <label for="TxtValor">
                                                    Capital Social Lps.</label>
                                                <asp:TextBox ID="TxtCapital" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                <script type="text/javascript">
                                                    function numericOnly(elementRef) {
                                                        var keyCodeEntered = (event.which) ? event.which : (window.event.keyCode) ? window.event.keyCode : -1;

                                                        // Un-comment to discover a key that I have forgotten to take into account...
                                                        //alert(keyCodeEntered);

                                                        if ((keyCodeEntered >= 48) && (keyCodeEntered <= 57)) {
                                                            return true;
                                                        }
                                                        else if (keyCodeEntered == 46) {
                                                            // Allow only 1 decimal point ('.')...
                                                            if ((elementRef.value) && (elementRef.value.indexOf('.') >= 0))
                                                                return false;
                                                            else
                                                                return true;
                                                        }

                                                        return false;
                                                    }
                                                </script>
                                                <br />
                                                <label for="TxtValor">
                                                    Reservas Lps.</label>
                                                <asp:TextBox ID="TxtReservas" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                <script type="text/javascript">
                                                    function numericOnly(elementRef) {
                                                        var keyCodeEntered = (event.which) ? event.which : (window.event.keyCode) ? window.event.keyCode : -1;

                                                        // Un-comment to discover a key that I have forgotten to take into account...
                                                        //alert(keyCodeEntered);

                                                        if ((keyCodeEntered >= 48) && (keyCodeEntered <= 57)) {
                                                            return true;
                                                        }
                                                        else if (keyCodeEntered == 46) {
                                                            // Allow only 1 decimal point ('.')...
                                                            if ((elementRef.value) && (elementRef.value.indexOf('.') >= 0))
                                                                return false;
                                                            else
                                                                return true;
                                                        }

                                                        return false;
                                                    }
                                                </script>
                                                <br />
                                                <label for="TxtValor">
                                                    Capital Semilla Lps.
                                                </label>
                                                <asp:TextBox ID="TxtSemilla" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                <script type="text/javascript">
                                                    function numericOnly(elementRef) {
                                                        var keyCodeEntered = (event.which) ? event.which : (window.event.keyCode) ? window.event.keyCode : -1;

                                                        // Un-comment to discover a key that I have forgotten to take into account...
                                                        //alert(keyCodeEntered);

                                                        if ((keyCodeEntered >= 48) && (keyCodeEntered <= 57)) {
                                                            return true;
                                                        }
                                                        else if (keyCodeEntered == 46) {
                                                            // Allow only 1 decimal point ('.')...
                                                            if ((elementRef.value) && (elementRef.value.indexOf('.') >= 0))
                                                                return false;
                                                            else
                                                                return true;
                                                        }

                                                        return false;
                                                    }
                                                </script>
                                                <br />
                                                <label for="TxtValor">
                                                    Intereses cobrados y otros Ingresos Lps.
                                                </label>
                                                <asp:TextBox ID="TxtInteresesCobrados" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                <script type="text/javascript">
                                                    function numericOnly(elementRef) {
                                                        var keyCodeEntered = (event.which) ? event.which : (window.event.keyCode) ? window.event.keyCode : -1;

                                                        // Un-comment to discover a key that I have forgotten to take into account...
                                                        //alert(keyCodeEntered);

                                                        if ((keyCodeEntered >= 48) && (keyCodeEntered <= 57)) {
                                                            return true;
                                                        }
                                                        else if (keyCodeEntered == 46) {
                                                            // Allow only 1 decimal point ('.')...
                                                            if ((elementRef.value) && (elementRef.value.indexOf('.') >= 0))
                                                                return false;
                                                            else
                                                                return true;
                                                        }

                                                        return false;
                                                    }
                                                </script>
                                                <br />
                                                <label for="TxtValor">
                                                    Intereses pagados y otros Gastos Lps.
                                                </label>
                                                <asp:TextBox ID="TxtInteresesPagados" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                <script type="text/javascript">
                                                    function numericOnly(elementRef) {
                                                        var keyCodeEntered = (event.which) ? event.which : (window.event.keyCode) ? window.event.keyCode : -1;

                                                        // Un-comment to discover a key that I have forgotten to take into account...
                                                        //alert(keyCodeEntered);

                                                        if ((keyCodeEntered >= 48) && (keyCodeEntered <= 57)) {
                                                            return true;
                                                        }
                                                        else if (keyCodeEntered == 46) {
                                                            // Allow only 1 decimal point ('.')...
                                                            if ((elementRef.value) && (elementRef.value.indexOf('.') >= 0))
                                                                return false;
                                                            else
                                                                return true;
                                                        }

                                                        return false;
                                                    }
                                                </script>
                                                <br />
                                                <label for="TxtValor">
                                                    Capital de Trabajo Lps.
                                                </label>
                                                <asp:TextBox ID="TxtTrabajo" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                <script type="text/javascript">
                                                    function numericOnly(elementRef) {
                                                        var keyCodeEntered = (event.which) ? event.which : (window.event.keyCode) ? window.event.keyCode : -1;

                                                        // Un-comment to discover a key that I have forgotten to take into account...
                                                        //alert(keyCodeEntered);

                                                        if ((keyCodeEntered >= 48) && (keyCodeEntered <= 57)) {
                                                            return true;
                                                        }
                                                        else if (keyCodeEntered == 46) {
                                                            // Allow only 1 decimal point ('.')...
                                                            if ((elementRef.value) && (elementRef.value.indexOf('.') >= 0))
                                                                return false;
                                                            else
                                                                return true;
                                                        }

                                                        return false;
                                                    }
                                                </script>
                                                <div id="dvMessage" runat="server" visible="false" class="alert alert-danger">
                                                    <strong>Error!</strong>
                                                    <asp:Label ID="lblMessage" runat="server" />
                                                </div>
                                            </div>
                                            <div class="modal-footer" style="text-align: center">
                                                <asp:Button ID="BGuardar" Text="Guardar" Width="80px" runat="server" Class="btn btn-primary" />
                                                <asp:Button ID="BSalir" Text="Salir" Width="80px" runat="server" Class="btn btn-primary" />
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal fade" id="DeleteModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
                                    aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <%--  <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                    &times;</button>--%>
                                                <h4 class="modal-title" id="ModalTitle2">MAS 2.0 - FUNDER</h4>
                                            </div>
                                            <div class="modal-body">
                                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                            </div>
                                            <div class="modal-footer" style="text-align: center">
                                                <asp:Button ID="BConfirm" Text="Aceptar" Width="80px" runat="server" Class="btn btn-primary" />
                                                <asp:Button ID="BBorrarsi" Text="SI" Width="80px" runat="server" Class="btn btn-primary" />
                                                <asp:Button ID="BBorrarno" Text="NO" Width="80px" runat="server" Class="btn btn-primary" />
                                                <%--<asp:Button ID="Button2" Text="Salir" Width="80px" runat="server" Class="btn btn-primary" />--%>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>


                        </div>
                        <div class="tab-pane fade" id="Graficos">
                            <div class="row">
                                <div class="col-lg-12">
                                    <%--<div class="embed-responsive embed-responsive-16by9">
                                        <iframe class="embed-responsive-item" src="https://app.powerbi.com/view?r=eyJrIjoiZWM4MWI1YTEtMjE0NC00MDBmLTk2NTItNDlkZjI1YjJhNDgyIiwidCI6ImM5NzU0NTExLTliODMtNGZmMi1iZmM4LTlkZmY2NzI1NTBmNSIsImMiOjR9" allowfullscreen="true"></iframe>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%--</form>--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
