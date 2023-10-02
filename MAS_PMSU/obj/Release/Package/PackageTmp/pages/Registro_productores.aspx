<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="Registro_productores.aspx.vb" Inherits="MAS_PMSU.Registro_productores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header"></h1>
        </div>
    </div>
    <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
    <asp:UpdatePanel ID="UpdatePanel2"
        runat="server">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <div id="div_datos" runat="server">

                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                REGISTRO DE PRODUCTORES (Red Pash)
                            </div>
                            <div class="panel-body">
                                <%--<form role="form" runat="server">--%>
                                <ul class="nav nav-pills">
                                    <li class="active"><a href="#Datos" data-toggle="tab">Datos</a>
                                    </li>
                                </ul>
                                <div class="tab-content">
                                    <div class="tab-pane fade in active" id="Datos">
                                        <div class="panel-body">
                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <label>Seleccione Departamento:</label>
                                                        <asp:DropDownList CssClass="form-control" ID="TxtDepto" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <label>Seleccione proyecto:</label>
                                                        <asp:DropDownList CssClass="form-control" ID="TxtEntrenador" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <%--  <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>Seleccione Organización:</label>
                                        </div>
                                    </div>--%>
                                                <asp:DropDownList CssClass="form-control" ID="cmborganizacion" Visible="false" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>Buscar por nombre:</label>
                                                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Digite el nombre productor y presione ENTER para buscar" autocomplete="off" AutoPostBack="true"></asp:TextBox>
                                                            <br />
                                                            <div id="div_admin" runat="server">
                                                                <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-warning" Text="Exportar Datos"><span class="glyphicon glyphicon-plus"></span>&nbsp; Agregar nuevo productor (a)</asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- /.row (nested) -->

                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="table-responsive">
                                                        <h3>
                                                            <span style="float: right;"><small># Productores:</small>
                                                                <asp:Label ID="LabelTot" runat="server" CssClass="label label-primary" /></span>
                                                        </h3>
                                                        <p>&nbsp;</p>
                                                        <p>&nbsp;</p>
                                                        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conn_REDPASH %>" ProviderName="<%$ ConnectionStrings:conn_REDPASH.ProviderName %>"></asp:SqlDataSource>
                                                        <asp:GridView ID="GridDatos" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                                            GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource1" Font-Size="Small">
                                                            <FooterStyle BackColor="#40E0D0" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#40E0D0" Font-Bold="True" ForeColor="White" />
                                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                            <EmptyDataTemplate>
                                                                ¡No hay productores registrados!
                                                            </EmptyDataTemplate>
                                                            <%--Paginador...--%>
                                                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                            <PagerTemplate>
                                                                <div class="row" style="margin-top: 8px;">
                                                                    <div class="col-lg-1" style="text-align: right;">
                                                                        <h5>
                                                                            <asp:Label ID="MsgL" Text="Ir a la pág." runat="server" /></h5>
                                                                    </div>
                                                                    <div class="col-lg-1" style="text-align: left;">
                                                                        <asp:DropDownList ID="CmbPage" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="CmbPage_SelectedIndexChanged" runat="server" CssClass="form-control" /></h3>
                                                                    </div>
                                                                    <div class="col-lg-10" style="text-align: right;">
                                                                        <h3>
                                                                            <asp:Label ID="PagActual" runat="server" CssClass="label label-primary" /></h3>
                                                                    </div>
                                                                </div>
                                                            </PagerTemplate>
                                                            <AlternatingRowStyle BackColor="White" />
                                                            <Columns>
                                                                <asp:BoundField DataField="id">
                                                                    <HeaderStyle CssClass="hide" />
                                                                    <ItemStyle CssClass="hide" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Depto_Descripcion" HeaderText="DEPARTAMENTO" />
                                                                <asp:BoundField DataField="CATEGORIA CLIENTE" HeaderText="CATEGORIA" />
                                                                <asp:BoundField DataField="ID_PARTIDA" HeaderText="DNI" />
                                                                <asp:BoundField DataField="NOMBRE" HeaderText="NOM_PRODUCTOR" />
                                                                <asp:BoundField DataField="SEXO" HeaderText="SEXO" />
                                                                <asp:BoundField DataField="TELEFONO_PROPIO" HeaderText="TELEFONO" />
                                                                <asp:BoundField DataField="PROYECTO" HeaderText="PROYECTO" />
                                                                <asp:ButtonField ButtonType="Button" Text="Actualizar" ControlStyle-CssClass="btn btn-info" HeaderText="Actualizar" CommandName="Actualizar">
                                                                    <ControlStyle CssClass="btn btn-warning"></ControlStyle>
                                                                </asp:ButtonField>
                                                            </Columns>
                                                            <EditRowStyle BackColor="#7C6F57" />
                                                            <RowStyle BackColor="#E3EAEB" />
                                                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                                                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <asp:TextBox ID="tns" runat="server" Visible="false"></asp:TextBox>
                                                    <asp:TextBox ID="txt_admin" runat="server" Visible="false"></asp:TextBox>
                                                    <%--<asp:Button ID="Button1" runat="server" Text="Exportar Datos" CssClass="btn btn-success" />--%>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success" Visible="false" Text="Exportar Datos"><span class="glyphicon glyphicon-save"></span>&nbsp;Exportar Datos</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="Graficos">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="embed-responsive embed-responsive-16by9">
                                                    <%--<iframe class="embed-responsive-item" src="https://app.powerbi.com/view?r=eyJrIjoiZjljY2MyNmItODE5ZS00YjMzLTllM2MtNGFkM2FkNWU5NzQ2IiwidCI6ImM5NzU0NTExLTliODMtNGZmMi1iZmM4LTlkZmY2NzI1NTBmNSIsImMiOjR9" allowfullscreen="true"></iframe>--%>
                                                    <iframe width="800" height="600" src="https://app.powerbi.com/view?r=eyJrIjoiMDNiNDZiMjMtYzA5NC00YzFiLTk4ZmQtNjcwNTc1OWE5N2E3IiwidCI6ImVhOGEzNmMwLTczOGItNGNiNC05MzhjLTY5YTUwNWJiNjg5OCIsImMiOjF9" frameborder="0" allowfullscreen="true"></iframe>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%--</form>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%--
                    div para actualizar --%>

            <div id="div_actualizar" runat="server">

                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header"></h1>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12">

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <asp:Label ID="laBEL_MESANSAJE" runat="server" Text=""></asp:Label>ACTUALIZACIÓN DE PRODUCTOR

                  <asp:TextBox ID="txt_id" Visible="false" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txt_id_part" Visible="false" runat="server"></asp:TextBox>
                                <asp:TextBox ID="TXT_VERSION" Visible="false" runat="server"></asp:TextBox>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="row">

                                            <div class="panel panel-primary">
                                                <div class="panel-heading">
                                                    Identificacion
                                                </div>

                                                <div class="panel-body">
                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label>Departamento</label>
                                                            <asp:Label ID="lb_depto" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="TXT_departamento_add" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label>Municipio</label><asp:Label ID="lb_municipio" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="TXT_municipio_add" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label>Aldea</label>
                                                            <asp:Label ID="lb_aldea" class="label label-warning" runat="server" Text=""></asp:Label>
                                                            <asp:DropDownList CssClass="form-control" ID="TXT_aldea_add" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label>caserio</label>
                                                            <asp:Label ID="lb_caserio" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="TXT_caserio_add" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">

                                            <div class="panel panel-primary">
                                                <div class="panel-heading">
                                                    Datos generales
                                                </div>

                                                <div class="panel-body">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">

                                                            <label>Nombre</label><asp:Label ID="lb_nombre" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:TextBox CssClass="form-control" ID="txt_nombre_add" runat="server" AutoPostBack="True"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-4">
                                                        <div class="form-group">

                                                            <label>DNI (Sin guiones)</label><asp:Label ID="lb_dni" class="label label-warning" runat="server" Text=""></asp:Label>
                                                            <asp:TextBox CssClass="form-control" ID="txt_dni_add" runat="server" AutoPostBack="True" MaxLength="13"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-2">
                                                        <div class="form-group">

                                                            <label>Edad</label><asp:Label ID="lb_edad" class="label label-warning" runat="server" Text=""></asp:Label>
                                                            <asp:TextBox CssClass="form-control" ID="txt_edad" runat="server" AutoPostBack="True"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-2">
                                                        <div class="form-group">

                                                            <label>Numero telefono</label><asp:Label ID="lb_telefono" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:TextBox CssClass="form-control" ID="txt_telefono_add" runat="server" AutoPostBack="True" MaxLength="8"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">

                                            <div class="panel panel-primary">
                                                <div class="panel-heading">
                                                    Participantes
                                                </div>

                                                <div class="panel-body">
                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label>Nombre</label>

                                                            <asp:TextBox CssClass="form-control" ID="txt_nombre_par" runat="server" AutoPostBack="True"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-2">
                                                        <div class="form-group">

                                                            <label>DNI</label>
                                                            <asp:TextBox CssClass="form-control" ID="txt_dni" runat="server" AutoPostBack="True"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-2">
                                                        <div class="form-group">

                                                            <label>Edad</label>

                                                            <asp:TextBox CssClass="form-control" ID="txt_edad_part" runat="server" AutoPostBack="True" TextMode="number"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-2">
                                                        <div class="form-group">

                                                            <label>Sexo</label>
                                                            <asp:DropDownList CssClass="form-control" ID="dp_sexo_part" runat="server">
                                                                <asp:ListItem>Mujer</asp:ListItem>
                                                                <asp:ListItem>Hombre</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-2">
                                                        <div class="form-group">

                                                            <asp:Button ID="Btn_add" class="btn btn-success" runat="server" Text=" + Participantes" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <asp:Label ID="lb_add" runat="server" class="label label-warning" Text=""></asp:Label>
                                        </div>
                                        <br />

                                        <div class="row">
                                            <div class="panel panel-primary">
                                                <div class="panel-heading">
                                                    <label>Detalle de participantes:</label>
                                                </div>
                                                <div class="panel-body">

                                                    <div class="row">

                                                        <div class="table-responsive">
                                                            <h3>
                                                                <span style="float: left;"><small>Total registros:</small>
                                                                    <asp:Label ID="Label1" runat="server" CssClass="label label-primary" /></span>
                                                            </h3>
                                                            <p>&nbsp;</p>
                                                            <p>&nbsp;</p>
                                                            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:conn_REDPASH %>" ProviderName="<%$ ConnectionStrings:conn_REDPASH.ProviderName %>"></asp:SqlDataSource>
                                                            <asp:GridView ID="GV_contacto" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                                                GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" Font-Size="Small">
                                                                <AlternatingRowStyle BackColor="White" />
                                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                                <EmptyDataTemplate>
                                                                    ¡No hay Participantes registrados!
                                                                </EmptyDataTemplate>
                                                                <Columns>
                                                                    <asp:BoundField DataField="id">
                                                                        <HeaderStyle CssClass="hide" />
                                                                        <ItemStyle CssClass="hide" />
                                                                    </asp:BoundField>

                                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                                                    <asp:BoundField DataField="DNI" HeaderText="DNI" />
                                                                    <asp:BoundField DataField="EDAD" HeaderText="EDAD" />
                                                                    <asp:BoundField DataField="SEXO" HeaderText="SEXO" />
                                                                    <asp:ButtonField ButtonType="Button" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" CommandName="Eliminar">
                                                                        <ControlStyle CssClass="btn btn-warning"></ControlStyle>
                                                                    </asp:ButtonField>
                                                                </Columns>
                                                                <EditRowStyle BackColor="#7C6F57" />
                                                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#90d0f5" Font-Bold="True" ForeColor="#035787" />
                                                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                                                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                                <RowStyle BackColor="#E3EAEB" />
                                                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <%--<label>.</label>--%>

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
                                    </div>

                                    <div id="div_guardar" runat="server">
                                        <%--       <asp:Button ID="Guardar_registro"  class="btn btn-success" runat="server" Text="Guardar"  data-toggle="modal" data-target="#exampleModal2" />--%>
                                        <button type="button" id="Guardar_registro" runat="server" class="btn btn-success" data-toggle="modal" data-target="#exampleModal2">
                                            Guardar
                                        </button>

                                        <asp:Button ID="Cancelar" class="btn btn-danger" runat="server" Text="Regresar" />
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="auto-style3">
                                        <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>

                                        <div class="modal fade" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                            <div class="modal-dialog" role="document">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabela">MAS 2.0 - TNS</h5>
                                                    </div>
                                                    <div class="modal-body">
                                                        ¿Está seguro que sea actualiar el registro de productor?
                                                    </div>
                                                    <div class="modal-footer">
                                                        <asp:Button ID="btn_si" Text="SI" Width="80px" runat="server" Class="btn btn-Success" />
                                                        <button type="button" id="btn_cancelar" runat="server" class="btn btn-danger" data-dismiss="modal">NO</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <br />

                                        <asp:Label ID="lb_error" class="badge badge-pill badge-success" runat="server" Text=""></asp:Label>

                                        <!-- Modal -->
                                        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                            <div class="modal-dialog" role="document">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabel">MAS 2.0 - IHMA</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        ¿Está seguro que desea actualizar el registro del productor?
                                                    </div>
                                                    <div class="modal-footer">
                                                        <asp:Button ID="SI_editar" class="btn btn-success" runat="server" Text="SI" />

                                                        <button type="button" class="btn btn-danger" data-dismiss="modal">NO</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Modal -->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%-- 'nuevo productor formulario--%>

            <div id="div_nuevo_prod" runat="server">

                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header"></h1>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12">

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <asp:Label ID="laBEL2" runat="server" Text=""></asp:Label>REGISTRAR NUEVO PRODUCTOR (A)

                  <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
                                <asp:TextBox ID="TextBox2" Visible="false" runat="server"></asp:TextBox>
                                <asp:TextBox ID="TextBox3" Visible="false" runat="server"></asp:TextBox>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="row">

                                            <div class="panel panel-primary">
                                                <div class="panel-heading">
                                                    Identificacion
                                                </div>

                                                <div class="panel-body">
                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label>Departamento</label>
                                                            <asp:Label ID="lb_dept_new" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="gb_departamento_new" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label>Municipio</label><asp:Label ID="lb_mun_new" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="gb_municipio_new" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label>Aldea</label>
                                                            <asp:Label ID="lb_aldea_new" class="label label-warning" runat="server" Text=""></asp:Label>
                                                            <asp:DropDownList CssClass="form-control" ID="gb_aldea_new" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label>Caserio</label>
                                                            <asp:Label ID="lb_caserio_new" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="gb_caserio_new" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">

                                            <div class="panel panel-primary">
                                                <div class="panel-heading">
                                                    Datos generales
                                                </div>

                                                <div class="panel-body">
                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label>Nombre</label><asp:Label ID="lb_nombre_new" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:TextBox CssClass="form-control" ID="txt_nombre_prod_new" runat="server" AutoPostBack="True"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label>Sexo</label>
                                                            <asp:Label ID="Label14" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="gb_sexo_new" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>Hombre</asp:ListItem>
                                                                <asp:ListItem>Mujer</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label>DNI (Sin guiones)</label><asp:Label ID="lb_dni_new" class="label label-warning" runat="server" Text=""></asp:Label>
                                                            <asp:TextBox CssClass="form-control" ID="txt_dni_new" TextMode="number" runat="server" AutoPostBack="True" MaxLength="13"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label>Edad</label><asp:Label ID="lb_edad_new" class="label label-warning" runat="server" Text=""></asp:Label>
                                                            <asp:TextBox CssClass="form-control" ID="txt_edad_new" TextMode="number" runat="server" AutoPostBack="True"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label># Telefono</label><asp:Label ID="lb_telefono_new" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:TextBox CssClass="form-control" ID="txt_telefono_new" runat="server" TextMode="number" AutoPostBack="True" MaxLength="8"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label>Fecha de nacimiento</label><asp:Label ID="Label11" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:TextBox CssClass="form-control" ID="txt_fecha_nacimiento_new" TextMode="date" runat="server" AutoPostBack="True" MaxLength="8"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label>Cargo</label>
                                                            <asp:Label ID="Label12" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="gb_cargo_nuevo" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>Presidente/a</asp:ListItem>
                                                                <asp:ListItem>Vicepresidente/a</asp:ListItem>
                                                                <asp:ListItem>Secretario/a</asp:ListItem>
                                                                <asp:ListItem>Tesorero/a</asp:ListItem>
                                                                <asp:ListItem>Vocal 1</asp:ListItem>
                                                                <asp:ListItem>Vocal 2</asp:ListItem>
                                                                <asp:ListItem>Vocal 3</asp:ListItem>
                                                                <asp:ListItem>socio</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label>Sabe Leer</label>
                                                            <asp:Label ID="Label15" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="gb_sabeleer_new" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>SI</asp:ListItem>
                                                                <asp:ListItem>NO</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label>Cadena</label>
                                                            <asp:Label ID="Label16" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="gb_cadena_new" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>FRIJOL</asp:ListItem>
                                                                <asp:ListItem>MAIZ</asp:ListItem>

                                                                <asp:ListItem>FRIJOL-MAIZ</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">

                                            <div class="panel panel-primary">
                                                <div class="panel-heading">
                                                    ASIGNAR ORGANIZACIÓN Y ASESOR TECNICO
                                                </div>

                                                <div class="panel-body">
                                                    <div class="col-lg-6">
                                                        <div class="form-group">

                                                            <label>Seleccionar organización</label><asp:Label ID="lb_ops_new" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="gb_opS_new" runat="server" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-6">
                                                        <div class="form-group">

                                                            <label>Seleccionar asesor técnico</label><asp:Label ID="lb_asesor_new" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="gb_ec_new" runat="server" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <%--<label>.</label>--%>

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
                                    </div>

                                    <div id="div2" runat="server">
                                        <%--       <asp:Button ID="Guardar_registro"  class="btn btn-success" runat="server" Text="Guardar"  data-toggle="modal" data-target="#exampleModal2" />--%>
                                        <button type="button" id="btn_nuevo_prod" runat="server" class="btn btn-success" data-toggle="modal" data-target="#exampleModal222">
                                            Guardar
                                        </button>

                                        <asp:Button ID="Button3" class="btn btn-danger" runat="server" Text="Regresar" />
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="auto-style3">
                                        <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>

                                        <div class="modal fade" id="exampleModal222" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                            <div class="modal-dialog" role="document">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabela22">IHMA</h5>
                                                    </div>
                                                    <div class="modal-body">
                                                        ¿Está seguro que sea registrar el nuevo productor?
                                                    </div>
                                                    <div class="modal-footer">
                                                        <asp:Button ID="btn_si_nuevo" Text="SI" Width="80px" runat="server" Class="btn btn-Success" />
                                                        <button type="button" id="Button5" runat="server" class="btn btn-danger" data-dismiss="modal">NO</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <br />

                                        <asp:Label ID="Label13" class="badge badge-pill badge-success" runat="server" Text=""></asp:Label>

                                        <!-- Modal -->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>