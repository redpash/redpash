<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="Registro_Banco_Semilla.aspx.vb" Inherits="MAS_PMSU.Registro_Banco_Semilla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>

    <div id="divdatos" runat="server">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header"></h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Registros de Bancos Comunitarios de Semilla
                    </div>
                    <div class="panel-body">
                        <asp:TextBox CssClass="form-control" ID="Txt_Id_Eliminar" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>
                        <%--<form role="form" runat="server">--%>
                        <%--  <ul class="nav nav-pills">
                                    <li class="active"><a href="#Datos" data-toggle="tab">Datos</a>
                                    </li>
                                    <%--<li><a href="#Graficos" data-toggle="tab">Graficos</a>
                        </li>--%>
                        <%--</ul>--%>
                        <div class="tab-content">
                            <div class="tab-pane fade in active" id="Datos">
                                <div class="panel-body">

                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Seleccione Departamento:</label>
                                                <asp:DropDownList CssClass="form-control" ID="TxTdepto" runat="server" AutoPostBack="True"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Seleccione asesor:</label>

                                                <asp:DropDownList CssClass="form-control" ID="TxtEntrenador" runat="server" AutoPostBack="True"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Seleccione Tipo banco:</label>
                                                <asp:DropDownList CssClass="form-control" ID="cmborganizacion" runat="server" AutoPostBack="True"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <asp:TextBox ID="txt_admin" runat="server" Visible="false"></asp:TextBox>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <div class="card bg-warning mb-3">
                                                    <div class="card-body">
                                                        <label>Si desea registrar un nuevo banco, seleccionar tipo de banco de semilla</label>
                                                        <asp:DropDownList CssClass="form-control" ID="ComboTipoBanco" runat="server" AutoPostBack="True">
                                                            <asp:ListItem Text="Seleccionar..."></asp:ListItem>
                                                            <asp:ListItem id="organizacion1" Text="Organización"></asp:ListItem>
                                                            <asp:ListItem id="individua1" Text="Individual"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <%--   boton exportar--%>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <%--<label>Seleccione Entrenador:</label>--%>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <%--<label>Seleccione Organización:</label>--%>
                                            </div>
                                        </div>

                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <div id="div_admin" runat="server">
                                                    <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-warning" Width="212px"><span class="glyphicon glyphicon-plus"></span>&nbsp; Agregar nueva organización</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <div id="div3" runat="server">
                                                    <asp:LinkButton ID="LinkButton4" runat="server" CssClass="btn btn-warning" Visible="False"><span class="glyphicon glyphicon-plus"></span>&nbsp; Individual</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- /.row (nested) -->

                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                <h3>
                                                    <span style="float: right;"><small># Bancos comunitarios:</small>
                                                        <asp:Label ID="LabelTot" runat="server" CssClass="label label-primary" /></span>
                                                </h3>
                                                <p>&nbsp;</p>
                                                <p>&nbsp;</p>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conn_REDPASH %>" ProviderName="<%$ ConnectionStrings:conn_REDPASH.ProviderName %>"></asp:SqlDataSource>
                                                <asp:GridView ID="GridDatos" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                                    GridLines="None" AllowPaging="True" AutoGenerateColumns="False" PageSize="8"   CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource1" Font-Size="Small">
                                                    <FooterStyle BackColor="#40E0D0" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#40E0D0" Font-Bold="True" ForeColor="White" />
                                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                    <EmptyDataTemplate>
                                                        ¡No hay organizaciones bancos!
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
                                                        <asp:BoundField DataField="ec_nombre" HeaderText="ASESOR" />
                                                        <asp:BoundField DataField="Depto_Descripcion" HeaderText="DEPARTAMENTO" />
                                                        <asp:BoundField DataField="FECHA_REGISTRO" HeaderText="FECHA REGISTRO" />
                                                        <asp:BoundField DataField="TIPO_BCS" HeaderText="TIPO REGISTRO" />
                                                        <asp:BoundField DataField="COD_BCS" HeaderText="CODIGO BANCO" />
                                                        <asp:BoundField DataField="Nombre_concat" HeaderText="NOMBRE/ ORG" />

                                                        <asp:BoundField DataField="Cuenta_Bancaria" HeaderText="TIENE CUENTA BANCARIA" />
                                                        <asp:BoundField DataField="Experiencia_Produccion" HeaderText="EXPERIENCIA EN PRODUCCION" />
                                                        <asp:BoundField DataField="Esta_Asociado" HeaderText="ESTA ASOCIADO" />
                                                        <asp:BoundField DataField="Tiempo_Experiencia" HeaderText="AÑOS DE EXPERIENCIA" />

                                                        <asp:ButtonField ButtonType="Button" Text="Actualizar" ControlStyle-CssClass="btn btn-info" HeaderText="Actualizar" CommandName="Actualizar">
                                                            <ControlStyle CssClass="btn btn-warning"></ControlStyle>
                                                        </asp:ButtonField>

                                                        <asp:ButtonField ButtonType="Button" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" CommandName="Eliminar">
                                                            <ControlStyle CssClass="btn btn-danger"></ControlStyle>
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
                                        <div id="divExportaciones" runat="server">

                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <h1 class="page-header"></h1>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="panel panel-primary">
                                                        <div class="panel-heading">
                                                            Exportar a Excell
                                                        </div>
                                                        <div class="panel-body">
                                                            <div>
                                                                <div class="row">
                                                                    <div class="col-lg-12">

                                                                        <asp:Button ID="Button10" runat="server" CssClass="btn btn-warning" Text="Exportar a Excel" OnClick="ExportarExceelOrg_Click" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <asp:TextBox ID="tns" runat="server" Visible="false"></asp:TextBox>
                                            <%--<asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Exportar Datos" />--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="Graficos">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="embed-responsive embed-responsive-16by9">
                                            <%--<iframe class="embed-responsive-item" src="https://app.powerbi.com/view?r=eyJrIjoiZWM4MWI1YTEtMjE0NC00MDBmLTk2NTItNDlkZjI1YjJhNDgyIiwidCI6ImM5NzU0NTExLTliODMtNGZmMi1iZmM4LTlkZmY2NzI1NTBmNSIsImMiOjR9" allowfullscreen="true"></iframe>--%>
                                            <iframe width="800" height="600" src="https://app.powerbi.com/view?r=eyJrIjoiMThlMjc3M2EtNzY1Ny00ZjVkLTk2ZWItNTk1NDBhMmFhZjU3IiwidCI6ImVhOGEzNmMwLTczOGItNGNiNC05MzhjLTY5YTUwNWJiNjg5OCIsImMiOjF9" frameborder="0" allowfullscreen="true"></iframe>
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

        <%--AGREGAR NUEVO CIERRE DIV AL FINAL --%>

        <asp:TextBox ID="txt_id" Visible="false" runat="server"></asp:TextBox>

        <div id="divedit" runat="server">
            <div class="row">

                <div class="col-lg-12">
                    <h1 class="page-header"></h1>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            1.1 ORGANIZACIÓN DE PRODUCTORES(AS)/EMPRESA
                        </div>
                        <div class="panel-body">

                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            <label>INFORMACIÓN GENERAL </label>
                                        </div>
                                        <div class="panel-body">

                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <label>1.Nombre completo del representante:</label>
                                                        <asp:TextBox CssClass="form-control" ID="TXT_nombre_joven" runat="server" AutoPostBack="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <label>2. DNI:</label>
                                                        <asp:TextBox CssClass="form-control" ID="TXT_DNI" runat="server" AutoPostBack="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <label>3. # Telefono:</label>
                                                        <asp:TextBox CssClass="form-control" ID="TXT_telefono" runat="server" AutoPostBack="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            <label>Constitución legal</label>
                                        </div>
                                        <div class="panel-body">

                                            <div class="row">

                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <label>Personeria juridica</label>
                                                        <asp:DropDownList CssClass="form-control" ID="Txttrabaja" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>Si</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                            <asp:ListItem>En_Tramite</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <br />

                                                        <label>Número de personeria juridica</label>
                                                        <asp:TextBox CssClass="form-control" ID="txt_det_personeria" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <label>RTN</label>
                                                        <asp:DropDownList CssClass="form-control" ID="gb_rtn" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>Si</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                            <asp:ListItem>En_Tramite</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <br />

                                                        <label>Número de RTN</label>
                                                        <asp:TextBox CssClass="form-control" ID="txt_det_rtn" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <label>CAI</label>
                                                        <asp:DropDownList CssClass="form-control" ID="gb_cai" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>Si</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                            <asp:ListItem>En_Tramite</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <br />

                                                        <label>Número de CAI</label>
                                                        <asp:TextBox CssClass="form-control" ID="txt_det_cai" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            <label>Detalle de socios (as)</label>
                                        </div>
                                        <div class="panel-body">

                                            <div class="row">

                                                <div class="col-lg-4">
                                                    <div class="form-group">

                                                        <label>Número socios Hombres</label>
                                                        <asp:TextBox CssClass="form-control" ID="txt_socio_H" runat="server" AutoPostBack="True"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">

                                                        <label>Número socios Mujeres</label>
                                                        <asp:TextBox CssClass="form-control" ID="txt_socio_m" runat="server" AutoPostBack="True"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">

                                                        <label>Total socios</label>
                                                        <asp:TextBox CssClass="form-control" ID="txt_socio_total" runat="server" AutoPostBack="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12">
                        <asp:Label ID="lberror" class="btn-warning" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="row">
                        <div class="col-lg-6">
                            <asp:Button ID="Guardar" OnClientClick="$('#exampleModal2').modal('hide');" Text="Guardar" Width="80px" data-toggle="modal" data-target="#exampleModal2" runat="server" Class="btn btn-Primary" />

                            <asp:Button ID="BSalir" Text="Regresar" Width="80px" runat="server" Class="btn btn-danger" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%--DESDE AQUI NUEVO FORMULARIO--%>

    <asp:UpdatePanel ID="UpdatePanel2"
        runat="server">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div id="div_nuevo_prod" runat="server">

                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header"></h1>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <asp:Label ID="laBEL2" runat="server" Text=""></asp:Label>REGISTRAR NUEVO BANCO COMUNITARIO

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
                                                        IDENTIFICACIÒN GEOGRAFICA
                                                    </div>
                                                    <section id="todoDeptos" runat="server">
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
                                                    </section>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                             

                                <div class="row">

                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            DATOS GENERALES DEL REPRESENTANTE
                                        </div>

                                        <div class="panel-body">
                                            <div class="col-lg-3">
                                                <div class="form-group">

                                                    <label>Nombre Representante</label><asp:Label ID="lb_nombre_new" class="label label-warning" runat="server" Text=""></asp:Label>

                                                    <asp:TextBox CssClass="form-control" ID="txt_nombre_prod_new" runat="server" AutoPostBack="True"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-lg-3">
                                                <div class="form-group">

                                                    <label>Sexo representante</label>
                                                    <asp:Label ID="Label14" class="label label-warning" runat="server" Text=""></asp:Label>

                                                    <asp:DropDownList CssClass="form-control" ID="gb_sexo_new" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>Hombre</asp:ListItem>
                                                        <asp:ListItem>Mujer</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-lg-3">
                                                <div class="form-group">

                                                    <label>Edad representante</label><asp:Label ID="LabelEdad" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="txtEdadRepresentante" TextMode="number" runat="server" AutoPostBack="True" MaxLength="13"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-lg-3">
                                                <div class="form-group">

                                                    <label>DNI representante</label><asp:Label ID="lb_dni_new" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_dni_new" TextMode="number" runat="server" AutoPostBack="True" MaxLength="13"></asp:TextBox>
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

                                                    <label># Socios Hombres</label><asp:Label ID="LB_SOCIO_H_NEW" class="label label-warning" runat="server" Text=""></asp:Label>

                                                    <asp:TextBox CssClass="form-control" ID="TXT_SOCIO_H_NEW" runat="server" TextMode="number" AutoPostBack="True" MaxLength="8"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">

                                                    <label># Socios MUjeres</label><asp:Label ID="LB_SOCIO_M_NEW" class="label label-warning" runat="server" Text=""></asp:Label>

                                                    <asp:TextBox CssClass="form-control" ID="TXT_SOCIO_M_NEW" runat="server" TextMode="number" AutoPostBack="True" MaxLength="8"></asp:TextBox>
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

                                                    <asp:DropDownList CssClass="form-control" ID="individual_new" runat="server" AutoPostBack="True" Visible="False">
                                                        <asp:ListItem>Organizacion</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">

                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            REGISTRAR NUEVO BANCO COMUNITARIO
                                        </div>

                                        <div class="panel-body">

                                            <div class="col-lg-3">
                                                <div class="form-group">

                                                    <label>Nombre de la organización</label><asp:Label ID="LB_OP_NOMBRE_NEW" class="label label-warning" runat="server" Text=""></asp:Label>

                                                    <asp:DropDownList CssClass="form-control" ID="Dl_OP_Todos" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-lg-3">
                                                <div class="form-group">

                                                    <label>Direccion de Organizcion</label><asp:Label ID="LB_DIRECCION_NEW" class="label label-warning" runat="server" Text=""></asp:Label>

                                                    <asp:TextBox CssClass="form-control" ID="TXT_OPDIRECCION_NEW" runat="server" AutoPostBack="True"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-lg-3">
                                                <div class="form-group">

                                                    <label>Tipo organizacion</label><asp:Label ID="Label3" class="label label-warning" runat="server" Text=""></asp:Label>

                                                    <asp:DropDownList CssClass="form-control" ID="gb_tipo_new" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>Asociacion_Productores</asp:ListItem>
                                                        <asp:ListItem>Caja_Rural</asp:ListItem>
                                                        <asp:ListItem>Empresa_servicios_multiples</asp:ListItem>
                                                        <asp:ListItem>Organizacion_Indigena</asp:ListItem>
                                                        <asp:ListItem>Organizacion_Mujeres</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-lg-3">
                                                <div class="form-group">

                                                    <label>Fecha de creacion organizacion</label><asp:Label ID="Label5" class="label label-warning" runat="server" Text=""></asp:Label>

                                                    <asp:TextBox CssClass="form-control" ID="TXT_FECHA_CREATE_OP" runat="server" TextMode="date" AutoPostBack="True"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">

                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            CONSTITUCIÓN LEGAL DE LA ORGANIZACIÓN
                                        </div>

                                        <div class="panel-body">

                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>Tiene RTN</label><asp:Label ID="Label6" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="GB_RTN_new" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>No</asp:ListItem>
                                                        <asp:ListItem>Si</asp:ListItem>
                                                    </asp:DropDownList>

                                                    <br />
                                                    <label>Digitar el numero de RTN</label><asp:Label ID="LB_RTN" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="TXT_RTN_new" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>Tiene personeria </label>
                                                    <asp:Label ID="Label8" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="GB_PERSONERIA_new" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>No</asp:ListItem>
                                                        <asp:ListItem>Si</asp:ListItem>
                                                    </asp:DropDownList>

                                                    <br />
                                                    <label>Digitar el numero de personeria</label><asp:Label ID="LB_PERSONERIA" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="TXT_PERSONERIA_new" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>Tiene CAI </label>
                                                    <asp:Label ID="Label10" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="GB_CAI_new" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>No</asp:ListItem>
                                                        <asp:ListItem>Si</asp:ListItem>
                                                    </asp:DropDownList>

                                                    <br />
                                                    <label>Digitar el numero de CAI</label><asp:Label ID="LB_CAI" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="TXT_CAI_new" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="panel-heading">

                                                <label>
                                                    Informaciòn Para Realizar Transferencias Bancarias
                                                </label>
                                                <asp:Label ID="Label150" class="label label-warning" runat="server" Text=""></asp:Label>
                                            </div>

                                            <div class="panel-body">

                                                <div class="col-lg-4">
                                                    <div class="form-group">

                                                        <label>¿Poseè Cuenta Bancaria?</label><asp:Label ID="Label1" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_CuentaBancaria_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>No</asp:ListItem>
                                                            <asp:ListItem>Si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="form-group">

                                                        <label>Tipo De Cuenta Bancaria</label><asp:Label ID="Label4" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_CuentaAhorroBanco_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>Cuenta De Ahorro </asp:ListItem>
                                                            <asp:ListItem>Cuenta De Cheques </asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">

                                                        <label>Lista de Bancos </label>
                                                        <asp:Label ID="Label143" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_ListaBancosAhorro_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>Banco Atlántida S.A.</asp:ListItem>
                                                            <asp:ListItem>Banco de Occidente S.A.</asp:ListItem>
                                                            <asp:ListItem>Banco de Los Trabajadores</asp:ListItem>
                                                            <asp:ListItem>Banco Financiera Centroamericana S.A. (FICENSA)</asp:ListItem>
                                                            <asp:ListItem>Banco Hondureño del Café S.A. (BANHCAFE)</asp:ListItem>
                                                            <asp:ListItem>Banco del País S.A.</asp:ListItem>
                                                            <asp:ListItem>Banco Financiera Comercial Hondureña S.A. (FICOHSA)</asp:ListItem>
                                                            <asp:ListItem>Banco Lafise Honduras  S.A.</asp:ListItem>
                                                            <asp:ListItem>Banco Davivienda Honduras S.A.</asp:ListItem>
                                                            <asp:ListItem>Banco Promérica S.A.</asp:ListItem>
                                                            <asp:ListItem>Banco de Desarrollo Rural Honduras S.A.</asp:ListItem>
                                                            <asp:ListItem>Banco Azteca de Honduras S.A.</asp:ListItem>
                                                            <asp:ListItem>Banco Popular S.A.</asp:ListItem>
                                                            <asp:ListItem>Banco de América Central Honduras S.A. – Bac | Honduras</asp:ListItem>
                                                            <asp:ListItem>Banco de Honduras (Citi Honduras)</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">

                                                        <label>Nùmero De Cuenta</label><asp:Label ID="Label144" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        <asp:TextBox CssClass="form-control" ID="txt_cuentaAhorroBanco_org" TextMode="number" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">

                                                        <label>Nombre Beneficiario </label>
                                                        <asp:Label ID="Label145" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        <asp:TextBox CssClass="form-control" ID="txt_BeneficiaroAhorro_Org" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%--   DESARROLLO FORMULARIO CONSULTAS--%>

                                <div class="row">

                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            EXPERIENCIA PREVIA
                                        </div>

                                        <div class="panel-body">

                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>Ha tenido experiencia en producir semilla certificada </label>
                                                    <asp:Label ID="text_experiencia_new" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_Experiencia_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>No</asp:ListItem>
                                                        <asp:ListItem>Si</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <section id="Experiencia_Previa" runat="server" autopostback="True">
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <label>Cantidad de Años</label><asp:Label ID="Label9" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        <asp:TextBox CssClass="form-control" ID="Text_Anos_Experiencia_new" TextMode="number" runat="server" AutoPostBack="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <label>tipo de semilla </label>
                                                        <asp:Label ID="Label7" class="label label-warning" runat="server" Text=""></asp:Label>

                                                        <asp:DropDownList CssClass="form-control" ID="Dl_TipoSemillan_Org" runat="server" AutoPostBack="True">

                                                            <asp:ListItem>Frijol</asp:ListItem>
                                                            <asp:ListItem>Maiz </asp:ListItem>
                                                            <asp:ListItem> Café </asp:ListItem>
                                                            <asp:ListItem> Otros </asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                                <label>2.2 ME PODRIA DESCRIBIR SU PAPEL EN LA CADENA DE SEMILLAS </label>
                                                <asp:Label ID="Label11" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <br />
                                                <br />
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <label>a. Manejo de proyecto proyecto de distribuicion de semilla: </label>
                                                        <asp:Label ID="Label15" class="label label-warning" runat="server" Text=""></asp:Label>

                                                        <asp:DropDownList CssClass="form-control" ID="Dl_ManejoProyecto_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">

                                                        <label>b. Produjo Semilla registrada: </label>
                                                        <asp:Label ID="Label17" class="label label-warning" runat="server" Text=""></asp:Label>

                                                        <asp:DropDownList CssClass="form-control" ID="Dl_ProdujoSemilla_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="form-group">

                                                        <label>c. Produjo Semilla certificada: </label>
                                                        <asp:Label ID="Label18" class="label label-warning" runat="server" Text=""></asp:Label>

                                                        <asp:DropDownList CssClass="form-control" ID="Dl_ProdujoSemillaCer_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <label>d. Brindo asistencia tecnica : </label>
                                                        <asp:Label ID="Label19" class="label label-warning" runat="server" Text=""></asp:Label>

                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Asistencia_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <label>e. Apoyo en las inscripciones ante SENASA : </label>
                                                        <asp:Label ID="Label20" class="label label-warning" runat="server" Text=""></asp:Label>

                                                        <asp:DropDownList CssClass="form-control" ID="Dl_ApoyoInscripciones_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <label>Otro.. </label>
                                                        <asp:Label ID="Label21" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        <asp:TextBox CssClass="form-control" ID="Txt_Otro_Org" runat="server" AutoPostBack="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </section>
                                        </div>
                                    </div>
                                </div>
   
                            <section id="Experiencia_Previa2" runat="server" autopostback="True">
                                <div class="row">

                                    <div class="col-lg-4">
                                        <div class="panel panel-primary">
                                            <div class="panel-heading">
                                                2.3 Por favor describa el tipo de instituciones (ej. ONG, Gobierno) con las que ha colaborado anteriormente
                                            </div>

                                            <div class="panel-body">

                                                <label>Seleccione la Institución</label>
                                                <asp:Label ID="Label22" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_Fao_Org" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>FAO </asp:ListItem>
                                                    <asp:ListItem>DICTA</asp:ListItem>
                                                    <asp:ListItem>ZAMORANO</asp:ListItem>
                                                    <asp:ListItem>CASA COMERCIAL</asp:ListItem>
                                                    <asp:ListItem>Otro</asp:ListItem>
                                                </asp:DropDownList>

                                                <br />
                                                <label>Otro.. </label>
                                                <asp:Label ID="Label26" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="Txt_OtroInst_Org" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-4">
                                        <div class="panel panel-primary">
                                            <div class="panel-heading">
                                                2.4
                                            </div>

                                            <div class="panel-body">

                                                <label>Esta afiliado o pertenece a una RED o Asociaciòn de productores de semilla ? </label>
                                                <asp:Label ID="Label27" class="label label-warning" runat="server" Text=""></asp:Label>

                                                <asp:DropDownList CssClass="form-control" ID="Dl_Afiliado_Org" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>

                                                <br />

                                                <label>Si es positivo, favor consultar el nombre de la RED o de la Asociaciòn: </label>
                                                <asp:Label ID="Label28" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="Txt_NombreRed_Org" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </section>

                            <div class="row">

                                <div class="col-lg-12">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            3. ACCESO A TIERRA
                                        </div>

                                        <div class="panel-body">

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Que cantidad de tierra propia posee en total ? MZ: </label>
                                                    <asp:Label ID="Label30" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="Txt_CantTierra_Org" TextMode="number" runat="server" AutoPostBack="True"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Maiz </label>
                                                    <asp:Label ID="Label29" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_Maiz_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <label>Cantidad de Terreno </label>
                                                    <asp:Label ID="Label32" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="Txt_CantTerreno_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>FRIJOL </label>
                                                    <asp:Label ID="Label31" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_Frijol_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <label>Cantidad de Terreno </label>
                                                    <asp:Label ID="Label33" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="Txt_CantTerrenoFrijol_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    <br />
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>SORGO </label>
                                                    <asp:Label ID="Label34" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_Sorgo_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <label>Cantidad de Terreno </label>
                                                    <asp:Label ID="Label35" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="Txt_CantTerrenoSorgo_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Café </label>
                                                    <asp:Label ID="Label36" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_Cafe_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <label>Cantidad de Terreno </label>
                                                    <asp:Label ID="Label37" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="Txt_CantTerrenoCafe_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    <br />
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Hortaliza </label>
                                                    <asp:Label ID="Label38" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_Hortaliza_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <label>Cantidad de Terreno Hortaliza </label>
                                                    <asp:Label ID="Label39" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="Txt_CantTerrenoHortaliza_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    <br />
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Frutales </label>
                                                    <asp:Label ID="Label40" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_Frutales_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <label>Cantidad de Terreno Frutales </label>
                                                    <asp:Label ID="Label41" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_CantTerrenoFrutales_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    <br />
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Ganaderia </label>
                                                    <asp:Label ID="Label42" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_Ganaderia_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <label>Cantidad de Terreno Ganaderia </label>
                                                    <asp:Label ID="Label43" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="Txt_CantTerrenoGanaderia_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    <br />
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Conservacion/ Bosque </label>
                                                    <asp:Label ID="Label44" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_Conservacion_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <label>Cantidad de Terreno Conservacion Bosque </label>
                                                    <asp:Label ID="Label45" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_TerrenoBosque_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    <br />
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Otros </label>
                                                    <asp:Label ID="Label46" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_OtrosCosecha_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <label>Cantidad de Terreno Otros </label>
                                                    <asp:Label ID="Label47" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="Txt_TerrenoOtros_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    <label>Espesifique el tipo de cultivo </label>
                                                    <asp:Label ID="Label48" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="Txt_TipoCultivo_Org" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">

                                <div class="col-lg-4">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            3.3 cuál es el área total de terreno disponible para produccion de semilla certificada de frijol?
                                        </div>

                                        <div class="panel-body">

                                            <label>Cantidad de Terreno en MZ </label>
                                            <asp:Label ID="Label51" class="label label-warning" runat="server" Text=""></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="Txt_CantTerrenoMz_Org" TextMode="number" runat="server" AutoPostBack="True"></asp:TextBox>
                                            <br />
                                            <label>Cantidad de lotes o campos disponibles </label>
                                            <asp:Label ID="Label52" class="label label-warning" runat="server" Text=""></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="Txt_Cantlotes_Org" TextMode="number" runat="server" AutoPostBack="True"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                      
                            <%--para pregunta 3.4--%>
                            <div class="row">

                                <div class="col-lg-4">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            3.4 ¿Como es la topografía del terreno disponible para producción de semilla certificada de frijol?
                                        </div>

                                        <div class="panel-body">

                                            <label>Seleccione la Topografìa Adecuada  </label>
                                            <asp:Label ID="Label154" class="label label-warning" runat="server" Text=""></asp:Label>
                                            <asp:DropDownList CssClass="form-control" ID="Dl_topografia_Org" runat="server" AutoPostBack="True">
                                                <asp:ListItem>Llano/o casi plano (0 a 3 % de pendiente) </asp:ListItem>
                                                <asp:ListItem>Ligeramente inclinado (3 a 7 % de pendiente)</asp:ListItem>
                                                <asp:ListItem>Moderadamente inclinado(7 a 12 % de pendiente)  </asp:ListItem>
                                                <asp:ListItem>Fuertemente ondulado(12 a 25% de pendiente) </asp:ListItem>
                                                <asp:ListItem>Ligeramente escarpado/empinado(25 a 55% de pendiente)</asp:ListItem>
                                                <asp:ListItem>Fuertemente escarpado/empinado(55 a 80% de pendiente)</asp:ListItem>
                                                <asp:ListItem> Muy escarpado/empinado (Mayor a 80% pendiente)</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <%--cierre 3.4--%>

                            <div class="row">

                                <div class="col-lg-12">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            3.3 Tiene acceso a una fuente de Agua en el Terreno donde produce frijol?
                                        </div>
                                        <div class="panel-body">
                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>1. Dentro de la finca </label>
                                                    <asp:Label ID="Label50" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <br />

                                                    <label>RIO </label>
                                                    <asp:Label ID="Label49" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_Rio_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <br />
                                                    <label>POZO </label>
                                                    <asp:Label ID="Label54" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_Pozo_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <br />
                                                    <label>Ojo de agua </label>
                                                    <asp:Label ID="Label53" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_OjoAgua_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">

                                <div class="col-lg-12">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            3.3
                                        </div>
                                        <div class="panel-body">
                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>1. Fuera de la finca </label>
                                                    <asp:Label ID="Label55" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <br />

                                                    <label>RIO </label>
                                                    <asp:Label ID="Label56" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_RioFuera_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <br />
                                                    <label>POZO </label>
                                                    <asp:Label ID="Label57" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_PozoFuera_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <br />
                                                    <label>Ojo de agua </label>
                                                    <asp:Label ID="Label58" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_OjoFuera_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">

                                <div class="col-lg-12">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            3.5.2
                                        </div>
                                        <div class="panel-body">
                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>¿Posee sistema de riego?  </label>
                                                    <asp:Label ID="Label59" class="label label-warning" runat="server" Text=""></asp:Label>

                                                    <asp:DropDownList CssClass="form-control" ID="Dl_SistemaRiego_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>¿Qué tipo de sistema de riego posee? </label>
                                                    <asp:Label ID="Label62" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_TipoSistema_Org" runat="server" AutoPostBack="True"  Enabled="False">

                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem>Aspersión</asp:ListItem>
                                                        <asp:ListItem>Goteo</asp:ListItem>
                                                        <asp:ListItem>Gravedad </asp:ListItem>
                                                        <asp:ListItem>Otro</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>¿Cuál es el área de terreno que tiene bajo riego?. </label>
                                                    <asp:Label ID="Label61" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="Txt_AreaBajo_Org" TextMode="number" runat="server" AutoPostBack="True"  Enabled="False"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">

                                <div class="col-lg-12">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            3.5.2.1 ¿Què tipo de energía utiliza para el funcionamiento del sistema de riego?
                                        </div>
                                        <div class="panel-body">
                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>No requiere</label>
                                                    <asp:Label ID="Label155" class="label label-warning" runat="server" Text=""></asp:Label>

                                                    <asp:DropDownList CssClass="form-control" ID="Dl_NoRequiere_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>Combustión </label>
                                                    <asp:Label ID="Label158" class="label label-warning" runat="server" Text=""></asp:Label>

                                                    <asp:DropDownList CssClass="form-control" ID="Dl_Combustion_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>Eléctrica</label>
                                                    <asp:Label ID="Label156" class="label label-warning" runat="server" Text=""></asp:Label>

                                                    <asp:DropDownList CssClass="form-control" ID="Dl_Electrica_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>Solar</label>
                                                    <asp:Label ID="Label157" class="label label-warning" runat="server" Text=""></asp:Label>

                                                    <asp:DropDownList CssClass="form-control" ID="Dl_Solar_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>Otra explique:</label>
                                                    <asp:Label ID="Label159" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="Txt_OtraEnergia_Org" runat="server" AutoPostBack="True"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-lg-12">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            3.6 ¿A qué distancia del hogar está ubicada la propiedad principal donde cultiva frijol?
                                        </div>
                                        <div class="panel-body">
                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>Distancia en Km</label>
                                                    <asp:Label ID="Label160" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="Txt_DistanciaKm_Org" TextMode="number" runat="server" AutoPostBack="True"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">

                                <div class="col-lg-12">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            3.7 ¿En el camino más cercano a la propiedad donde cultiva frijol, pueden transitar los vehículos todo el año?  
                                        </div>
                                        <div class="panel-body">
                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>¿En el camino más cercano a la propiedad donde cultiva frijol, pueden transitar los vehículos todo el año?  </label>
                                                    <asp:Label ID="Label161" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_CaminoCercano_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">

                                <div class="col-lg-12">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            3.8  ¿Que medio usa para transportar el grano/semilla de frijol  desde el lugar donde acopia el producto al mercado o sitio de venta más cercano donde usualmente lo vende?
                                        </div>

                                        <div class="panel-body">
                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>Automóvil    </label>
                                                    <asp:Label ID="Label162" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_Automovil_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>Pick-up    </label>
                                                    <asp:Label ID="Label163" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_PickUp_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>Motocicleta  </label>
                                                    <asp:Label ID="Label164" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_Moto_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>Bicicleta  </label>
                                                    <asp:Label ID="Label165" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_Bici_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>Caballo, mula, macho</label>
                                                    <asp:Label ID="Label166" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dl_Mula_Org" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                
                                                <div class="form-group">

                                                    <label>Tiene Otro.   </label>
                                                    <asp:Label ID="Label64" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="DL_Otro_Transporte" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>

                                                    <label>Otro Especifique :</label>
                                                    <asp:Label ID="Label167" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="Txt_OtroTransporte_Org" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>

                                                     </div>
                                                </div>
                                           
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-lg-6">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            4.0    INVERSIONES EN INFRAESTRUCTURA POST COSECHA
                                        </div>

                                        <div class="panel-body">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <label>4.1  ¿Qué tipos de infraestructura posee?    </label>
                                                    <asp:Label ID="Label174" class="label label-warning" runat="server" Text="" enable="false"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="row">

                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>A.    Bodega / centro de acopio   </label>
                                                        <asp:Label ID="Label168" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="col-sm-2">

                                                    <div class="form-group">
                                                        <br />
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Bodega_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-sm-2">

                                                    <div class="form-group">
                                                        <br />
                                                        <label>Cantidad : </label>
                                                        <asp:Label ID="Label175" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-sm-2">

                                                    <div class="form-group">
                                                        <br />
                                                        <asp:TextBox CssClass="form-control" ID="Txt_CantidadBodega_Org" TextMode="number" runat="server" enable="false" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>B.  Secadoras solares  </label>
                                                        <asp:Label ID="Label169" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Secadoras_Org" runat="server" AutoPostBack="True">

                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">

                                                    <div class="form-group">
                                                        <br />
                                                        <label>Cantidad : </label>
                                                        <asp:Label ID="Label178" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:TextBox CssClass="form-control" ID="Txt_CantidadSecadores_Org" TextMode="number" runat="server" enable="false" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>C.  Secadoras mecánicas  </label>
                                                        <asp:Label ID="Label170" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_SecaMecanica_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>Cantidad : </label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:Label ID="Label171" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        <asp:TextBox CssClass="form-control" ID="Txt_SecaMecanica_Org" TextMode="number" runat="server" enable="false" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>D.  Computadora </label>
                                                        <asp:Label ID="Label172" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Pc_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>Cantidad :</label>
                                                        <asp:Label ID="Label173" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />

                                                        <asp:TextBox CssClass="form-control" ID="Txt_Pc_Org" runat="server" TextMode="number" enable="false" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>E. Aspersión/bomba mochila</label>
                                                        <asp:Label ID="Label179" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_EquipoAspersion_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>Cantidad : </label>
                                                        <asp:Label ID="Label180" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:TextBox CssClass="form-control" ID="Txt_EquipoAspersion_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>F.  Desgranadora</label>
                                                        <asp:Label ID="Label181" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Desgranadora_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>Cantidad :</label>
                                                        <asp:Label ID="Label182" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:TextBox CssClass="form-control" ID="Txt_Desgranadora_Org" TextMode="number" runat="server" enable="false" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">

                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>G.  Zaranda</label>
                                                        <asp:Label ID="Label183" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">

                                                        <br />
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Zaranda_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>Cantidad  </label>
                                                        <asp:Label ID="Label184" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:TextBox CssClass="form-control" ID="Txt_Zaranda_Org" runat="server" TextMode="number" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>H.  Maquinaria disponible </label>
                                                        <asp:Label ID="Label185" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Tractor_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>Cantidad  </label>
                                                        <asp:Label ID="Label186" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:TextBox CssClass="form-control" ID="Txt_Tractor_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>I.  Arado</label>
                                                        <asp:Label ID="Label187" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Arado_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>Cantidad  </label>
                                                        <asp:Label ID="Label188" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:TextBox CssClass="form-control" ID="Txt_Arado_Org" TextMode="number" runat="server" enable="false" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>H.  Acamadora</label>
                                                        <asp:Label ID="Label189" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Acamadora_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>Cantidad  </label>
                                                        <asp:Label ID="Label190" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:TextBox CssClass="form-control" ID="Txt_Acamadora_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>J.  Sembradora</label>
                                                        <asp:Label ID="Label191" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Sembradora_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>Cantidad  </label>
                                                        <asp:Label ID="Label192" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:TextBox CssClass="form-control" ID="Txt_Sembradora_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>K.  Clasificadora</label>
                                                        <asp:Label ID="Label193" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Clasificadora_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>Cantidad  </label>
                                                        <asp:Label ID="Label194" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:TextBox CssClass="form-control" ID="Txt_Clasificadora_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>l.  Pulidora</label>
                                                        <asp:Label ID="Label195" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Pulidora_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>Cantidad  </label>
                                                        <asp:Label ID="Label196" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:TextBox CssClass="form-control" ID="Txt_Pulidora_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>M.  Envasadora</label>
                                                        <asp:Label ID="Label197" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />

                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Envasadora_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>Cantidad  </label>
                                                        <asp:Label ID="Label198" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:TextBox CssClass="form-control" ID="Txt_Envasadora_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>N.  Bomba de motor-riego</label>
                                                        <asp:Label ID="Label199" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Bomba_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>Cantidad  </label>
                                                        <asp:Label ID="Label200" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:TextBox CssClass="form-control" ID="Txt_Bomba_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>O.  Patio de secado</label>
                                                        <asp:Label ID="Label201" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Patio_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />

                                                        <label>Cantidad:</label>
                                                        <asp:Label ID="Label202" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:TextBox CssClass="form-control" ID="Txt_Patio_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>P.  Otras </label>
                                                        <asp:Label ID="Label60" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_OtrasInfra_Org" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>no</asp:ListItem>
                                                            <asp:ListItem>si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <label>Escriba Otra</label>
                                                        <asp:Label ID="Label63" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <asp:TextBox CssClass="form-control" ID="Txt_OtrasInfra_Org" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                     
                            <%-- FIN FORMULARIO CONSULTAS--%>

                            <div class="row">

                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        ASIGNAR ORGANIZACIÓN Y ASESOR TECNICO
                                    </div>

                                    <div class="panel-body">

                                        <div class="form-group">

                                            <label>Seleccionar asesor técnico</label><asp:Label ID="lb_asesor_new" class="label label-warning" runat="server" Text=""></asp:Label>

                                            <asp:DropDownList CssClass="form-control" ID="gb_ec_new" runat="server" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                       </div>
                        </div>
                <div id="div2" runat="server">
                    <%--       <asp:Button ID="Guardar_registro"  class="btn btn-success" runat="server" Text="Guardar"  data-toggle="modal" data-target="#exampleModal2" />--%>
                    <button type="button" id="btn_nuevo_prod" runat="server" class="btn btn-success" data-toggle="modal" data-target="#exampleModal222">
                        Guardar
                    </button>

                    <asp:Button ID="Button3" class="btn btn-danger" runat="server" Text="Regresar" />
                </div>
                <div id="divModify" runat="server">
                    <%--       <asp:Button ID="Guardar_registro"  class="btn btn-success" runat="server" Text="Guardar"  data-toggle="modal" data-target="#exampleModal2" />--%>
                    <button type="button" id="Modificar_Org" runat="server" class="btn btn-warning" data-toggle="modal" data-target="#exampleModal2">
                        Modificar
                    </button>

                    <asp:Button ID="Button12" class="btn btn-danger" runat="server" Text="Regresar" />
                </div>
            </div>

            <%--<label>.</label>--%>

            <%--INICIO DIV FORMULARIO INDIVIDUAL--%>

            <%-- FIN FORMULARIO--%>

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

            <div class="row">
                <div class="auto-style3">
                    <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>

                    <div class="modal fade" id="exampleModal222" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabela22">Red Pash</h5>
                                </div>
                                <div class="modal-body">
                                    ¿Está seguro que sea registrar una nueva organización?
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

            <div class="row">
                <div class="auto-style3">
                    <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>

                    <div class="modal fade" id="ModalDelete" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabela2222">Red Pash</h5>
                                </div>
                                <div class="modal-body">
                                    ¿Está seguro de eliminar el registro?
                                </div>
                                <div class="modal-footer">

                                    <asp:Button ID="Btn_Eliminar_Si" Text="SI" Width="80px" runat="server" Class="btn btn-Success" />
                                    <button type="button" id="Button8" runat="server" class="btn btn-danger" data-dismiss="modal">NO</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />

                    <asp:Label ID="Label73" class="badge badge-pill badge-success" runat="server" Text=""></asp:Label>

                    <!-- Modal -->
                </div>
            </div>

            <%--      HASTA AQUI NUEVO FORM--%>

            <%--     DESDE aqui FORMULARIO INDIVIDUAL--%>

            <div class="row">
                <div class="auto-style3">
                    <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>

                    <div class="modal fade" id="exampleModal2222" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabela222">Red Pash</h5>
                                </div>
                                <div class="modal-body">
                                    ¿Está seguro que sea registrar un nuevo Productor Independiente?
                                </div>
                                <div class="modal-footer">

                                    <asp:Button ID="BtnGuardar" Text="Guardar" Width="80px" runat="server" Class="btn btn-Success" />
                                    <button type="button" id="Button7" runat="server" class="btn btn-danger" data-dismiss="modal">NO</button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <br />
                    <br />

                    <asp:Label ID="Label139" class="badge badge-pill badge-success" runat="server" Text=""></asp:Label>

                    <!-- Modal -->
                </div>
            </div>

            <%--      HASTA AQUI NUEVO FORM--%>

            <div id="divIndividual" runat="server">

                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header"></h1>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <asp:Label ID="laBEL2000" runat="server" Text="">REGISTRAR NUEVO PRODUCTOR INDEPENDIENTE</asp:Label>

                                    <asp:TextBox ID="TextBox18" Visible="false" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="TextBox22" Visible="false" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="TextBox23" Visible="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="row">

                                                <div class="panel panel-primary">
                                                    <div class="panel-heading">
                                                        Informacion General
                                                    </div>

                                                    <div class="panel-body">
                                                        <div class="col-lg-3">
                                                            <div class="form-group">

                                                                <label>Departamento</label>
                                                                <asp:Label ID="Lb_depto_In" class="label label-warning" runat="server" Text=""></asp:Label>

                                                                <asp:DropDownList CssClass="form-control" ID="Dl_Departamento_Individual" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                            </div>
                                                        </div>

                                                        <div class="col-lg-3">
                                                            <div class="form-group">

                                                                <label>Municipio</label><asp:Label ID="Lb_Muni_IN" class="label label-warning" runat="server" Text=""></asp:Label>

                                                                <asp:DropDownList CssClass="form-control" ID="Dl_Municipio_Individual" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                            </div>
                                                        </div>

                                                        <div class="col-lg-3">
                                                            <div class="form-group">

                                                                <label>Aldea</label>
                                                                <asp:Label ID="Lb_aldea_In" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                <asp:DropDownList CssClass="form-control" ID="Dl_Aldea_Individual" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                            </div>
                                                        </div>

                                                        <div class="col-lg-3">
                                                            <div class="form-group">

                                                                <label>Caserio</label>
                                                                <asp:Label ID="Lb_caseerio_In" class="label label-warning" runat="server" Text=""></asp:Label>

                                                                <asp:DropDownList CssClass="form-control" ID="Dl_Caserio_Individual" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                            </div>
                                                        </div>
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

                                                        <label>Nombre Completo Del Productor</label><asp:Label ID="Lb_nombre_in" class="label label-warning" runat="server" Text=""></asp:Label>

                                                        <asp:TextBox CssClass="form-control" ID="Txt_Nombre_Completo_IN" runat="server" AutoPostBack="True"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-3">
                                                    <div class="form-group">

                                                        <label>Sexo Productor</label>
                                                        <asp:Label ID="Label68" class="label label-warning" runat="server" Text=""></asp:Label>

                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Sexo_In" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>Hombre</asp:ListItem>
                                                            <asp:ListItem>Mujer</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                                <div class="col-lg-3">
                                                    <div class="form-group">

                                                        <label>Edad Productor</label><asp:Label ID="Lb_Edad_In" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        <asp:TextBox CssClass="form-control" ID="Txt_Edad_In" TextMode="number" runat="server" AutoPostBack="True" MaxLength="13"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-3">
                                                    <div class="form-group">
                                                        <label>DNI Productor</label><asp:Label ID="Lb_Dni_In" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        <asp:TextBox CssClass="form-control" ID="Txt_Dni_In" TextMode="number" runat="server" AutoPostBack="True" MaxLength="13"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group">

                                                        <label>RTN (14 dígitos, sin guiones ni espacios)</label><asp:Label ID="Label140" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        <asp:TextBox CssClass="form-control" ID="Txt_Rtn_In" TextMode="number" runat="server" AutoPostBack="True" MaxLength="13"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-3">
                                                    <div class="form-group">

                                                        <label># Telefono</label><asp:Label ID="Lb_Tel_In" class="label label-warning" runat="server" Text=""></asp:Label>

                                                        <asp:TextBox CssClass="form-control" ID="Txt_Telefono_In" runat="server" TextMode="number" AutoPostBack="True" MaxLength="8"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group">

                                                        <label>Fecha de Registro</label><asp:Label ID="Label72" class="label label-warning" runat="server" Text=""></asp:Label>

                                                        <asp:TextBox CssClass="form-control" ID="Fecha_Individual" runat="server" TextMode="date" AutoPostBack="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="panel panel-primary">
                                            <div class="panel-heading">
                                                Informaciòn Para Realizar Transferencias Bancarias
                                            </div>

                                            <div class="panel-body">

                                                <div class="col-lg-3">
                                                    <div class="form-group">

                                                        <label>¿Poseè Cuenta Bancaria?</label><asp:Label ID="Label80" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Cuenta_IN" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>No</asp:ListItem>
                                                            <asp:ListItem>Si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group">

                                                        <label>¿Tipo De Cuenta?</label><asp:Label ID="Label76" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Ahorro_In" runat="server" AutoPostBack="True" Enabled="False">
                                                            <asp:ListItem>Cuenta de Ahorro</asp:ListItem>
                                                            <asp:ListItem>Cuenta de Cheques</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                                <div class="col-lg-3">
                                                    <div class="form-group">

                                                        <label>Lista de Bancos </label>
                                                        <asp:Label ID="Label82" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        <asp:DropDownList CssClass="form-control" ID="Dl_Bancos_In" runat="server" AutoPostBack="True" Enabled="False">
                                                            <asp:ListItem>Banco Atlántida S.A.</asp:ListItem>
                                                            <asp:ListItem>Banco de Occidente S.A.</asp:ListItem>
                                                            <asp:ListItem>Banco de Los Trabajadores</asp:ListItem>
                                                            <asp:ListItem>Banco Financiera Centroamericana S.A. (FICENSA)</asp:ListItem>
                                                            <asp:ListItem>Banco Hondureño del Café S.A. (BANHCAFE)</asp:ListItem>
                                                            <asp:ListItem>Banco del País S.A.</asp:ListItem>
                                                            <asp:ListItem>Banco Financiera Comercial Hondureña S.A. (FICOHSA)</asp:ListItem>
                                                            <asp:ListItem>Banco Lafise Honduras  S.A.</asp:ListItem>
                                                            <asp:ListItem>Banco Davivienda Honduras S.A.</asp:ListItem>
                                                            <asp:ListItem>Banco Promérica S.A.</asp:ListItem>
                                                            <asp:ListItem>Banco de Desarrollo Rural Honduras S.A.</asp:ListItem>
                                                            <asp:ListItem>Banco Azteca de Honduras S.A.</asp:ListItem>
                                                            <asp:ListItem>Banco Popular S.A.</asp:ListItem>
                                                            <asp:ListItem>Banco de América Central Honduras S.A. – Bac | Honduras</asp:ListItem>
                                                            <asp:ListItem>Banco de Honduras (Citi Honduras)</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                                <div class="col-lg-3">
                                                    <div class="form-group">

                                                        <label>Nùmero De Cuenta</label><asp:Label ID="Label85" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        <asp:TextBox CssClass="form-control" TextMode="number" ID="txt_NCuenta_In" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-3">
                                                    <div class="form-group">

                                                        <label>Nombre Beneficiario </label>
                                                        <asp:Label ID="Label87" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        <asp:TextBox CssClass="form-control" ID="Txt_NombreBen_In" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <br />
                                                        <hr />
                                                        <br />
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <div class="col-lg-3">
                                                            <div class="form-group">

                                                                <label>Grupo de Edad que reside en su Hogar?</label><asp:Label ID="Label77" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                <br />
                                                                <label>Grupo De Edad</label><asp:Label ID="Label78" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                <asp:DropDownList CssClass="form-control" ID="Dl_Grupo_Edad" runat="server" AutoPostBack="True">
                                                                    <asp:ListItem>Menores de 6 años</asp:ListItem>
                                                                    <asp:ListItem>Entre 6 y 14 años</asp:ListItem>
                                                                    <asp:ListItem>Entre 15 a 65 años</asp:ListItem>
                                                                    <asp:ListItem>Mayores de 65 años</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <div class="form-group">
                                                                <label>Genero</label><asp:Label ID="Label83" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                <br />
                                                                <label>Masculino</label><asp:Label ID="Label79" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                <asp:TextBox CssClass="form-control" ID="Txt_Maculino_In" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                                <label>Femenino</label><asp:Label ID="Label81" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                <asp:TextBox CssClass="form-control" ID="Txt_Femenino_In" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                            </div>
                                                            <div class="col-lg-3">
                                                                <div class="form-group">
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-lg-3">
                                                            <div class="form-group">
                                                                <label>Familiares Involucrados</label><asp:Label ID="Label84" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                <br />
                                                                <label>#Hombres</label><asp:Label ID="lb_Hombres_Involucrados" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                <asp:TextBox CssClass="form-control" ID="txt_Hombres_Involucrados" TextMode="number" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                <label>#Mujeres</label><asp:Label ID="lb_Mujeres_Involucrados1" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                <asp:TextBox CssClass="form-control" ID="txt_Mujeres_Involucrados" TextMode="number" runat="server" AutoPostBack="True"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-12">
                                                    <div class="col-lg-3">
                                                        <div class="form-group">

                                                            <label>Productor de Semilla</label><asp:Label ID="Label86" class="label label-warning" runat="server" Text=""></asp:Label>
                                                            <br />
                                                            <label>Tipo De Semilla</label><asp:Label ID="Label141" class="label label-warning" runat="server" Text=""></asp:Label>
                                                            <asp:DropDownList CssClass="form-control" ID="Dl_Semilla_Frijol" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>Frijol</asp:ListItem>
                                                                <asp:ListItem>Maiz</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--   DESARROLLO FORMULARIO CONSULTAS--%>
                                    <div class="row">

                                        <div class="panel panel-primary">
                                            <div class="panel-heading">
                                                EXPERIENCIA PREVIA
                                            </div>

                                            <div class="panel-body">

                                                <div class="col-lg-4">
                                                    <div class="form-group">

                                                        <label>Ha tenido experiencia en producir semilla certificada </label>
                                                        <asp:Label ID="Label88" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        <asp:DropDownList CssClass="form-control" ID="Tiene_Experiencia" runat="server" AutoPostBack="True">
                                                            <asp:ListItem>No</asp:ListItem>
                                                            <asp:ListItem>Si</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                                <section id="SectionExperiencia" runat="server" autopostback="True">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">

                                                            <label>Cantidad de Años </label>
                                                            <asp:Label ID="Label_Cantida_Anos" class="label label-warning" runat="server" Text="" Visible="false" EnableTheming="False"></asp:Label>
                                                            <asp:TextBox CssClass="form-control" ID="Cantidad_Anos" runat="server" TextMode="number" ReadOnly="False" AutoPostBack="True" Visible="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group">

                                                            <label>tipo de semilla </label>
                                                            <asp:Label ID="Label_Tipo_Semilla" class="label label-warning" runat="server" Text="" Visible="false"></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="Tipo_Semilla" runat="server" AutoPostBack="True" Visible="False">

                                                                <asp:ListItem>Frijol</asp:ListItem>
                                                                <asp:ListItem>Maiz </asp:ListItem>
                                                                <asp:ListItem> Café </asp:ListItem>
                                                                <asp:ListItem> Otros </asp:ListItem>
                                                            </asp:DropDownList>
                                                            <%-- /////////--%>
                                                        </div>
                                                    </div>

                                                    <label>2.2 ME PODRIA DESCRIBIR SU PAPEL EN LA CADENA DE SEMILLAS </label>
                                                    <asp:Label ID="Label91" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <br />
                                                    <br />
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>a. Manejo de proyecto proyecto de distribuicion de semilla: </label>
                                                            <asp:Label ID="Label92" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="Distribucion_Semilla" runat="server" AutoPostBack="True" Visible="False">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>b. Produjo Semilla registrada: </label>
                                                            <asp:Label ID="Label93" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="Semilla_Registrada" runat="server" AutoPostBack="True" Visible="False">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group">

                                                            <label>c. Produjo Semilla certificada: </label>
                                                            <asp:Label ID="Label94" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="Semilla_Certificada" runat="server" AutoPostBack="True" Visible="False">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>

                                                            <br />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>d. Brindo asistencia tecnica : </label>
                                                            <asp:Label ID="Label95" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="Asistencia_Tecnica" runat="server" AutoPostBack="True" Visible="False">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>e. Apoyo en las inscripciones ante SENASA : </label>
                                                            <asp:Label ID="Label96" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="Apoyo_Inscripciones_Senasa" runat="server" AutoPostBack="True" Visible="False">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label>Otro.. </label>
                                                            <asp:Label ID="Label97" class="label label-warning" runat="server" Text=""></asp:Label>
                                                            <asp:TextBox CssClass="form-control" ID="Otra_Produccion" runat="server" ReadOnly="False" AutoPostBack="True" Visible="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </section>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                          

                        <div class="row">

                            <div class="col-lg-4">
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        2.3 Por favor describa el tipo de instituciones (ej. ONG, Gobierno) con las que ha colaborado anteriormente
                                    </div>

                                    <div class="panel-body">

                                        <label>Seleccione la Institución</label>
                                        <asp:Label ID="Label89" class="label label-warning" runat="server" Text=""></asp:Label>
                                        <asp:DropDownList CssClass="form-control" ID="Dl_Fao_In" runat="server" AutoPostBack="True">
                                            <asp:ListItem>FAO </asp:ListItem>
                                            <asp:ListItem>DICTA</asp:ListItem>
                                            <asp:ListItem>ZAMORANO</asp:ListItem>
                                            <asp:ListItem>CASA COMERCIAL</asp:ListItem>
                                            <asp:ListItem>Otro</asp:ListItem>
                                        </asp:DropDownList>

                                        <br />
                                        <label>Otro.. </label>
                                        <asp:Label ID="Label90" class="label label-warning" runat="server" Text=""></asp:Label>
                                        <asp:TextBox CssClass="form-control" ID="Txt_Otro_Inst_In" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        2.4
                                    </div>

                                    <div class="panel-body">

                                        <label>Esta afiliado o pertenece a una RED o Asociaciòn de productores de semilla ? </label>
                                        <asp:Label ID="Label101" class="label label-warning" runat="server" Text=""></asp:Label>

                                        <asp:DropDownList CssClass="form-control" ID="Dl_Afiliado_In" runat="server" AutoPostBack="True">
                                            <asp:ListItem>no</asp:ListItem>
                                            <asp:ListItem>si</asp:ListItem>
                                        </asp:DropDownList>

                                        <br />

                                        <label>Si es positivo, favor consultar el nombre de la RED o de la Asociaciòn: </label>
                                        <asp:Label ID="Label102" class="label label-warning" runat="server" Text=""></asp:Label>
                                        <asp:TextBox CssClass="form-control" ID="Txt_NombreRed_In" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-lg-12">
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        3. ACCESO A TIERRA
                                    </div>

                                    <div class="panel-body">

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Que cantidad de tierra propia posee en total ? MZ: </label>
                                                <asp:Label ID="Label103" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="Txt_CantierraMz_In" TextMode="number" runat="server" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Maiz </label>
                                                <asp:Label ID="Label104" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_Maiz_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                                <label>Cantidad de Terreno </label>
                                                <asp:Label ID="Label105" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="Txt_CantMaiz_In" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>FRIJOL </label>
                                                <asp:Label ID="Label106" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_Frijol_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                                <label>Cantidad de Terreno </label>
                                                <asp:Label ID="Label107" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="Txt_CantTerrenoFrijol_In" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                <br />
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>SORGO </label>
                                                <asp:Label ID="Label108" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_Sorgo_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                                <label>Cantidad de Terreno </label>
                                                <asp:Label ID="Label109" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="Txt_CantSorgo_In" runat="server" TextMode="number" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Café </label>
                                                <asp:Label ID="Label110" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_Cafe_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                                <label>Cantidad de Terreno </label>
                                                <asp:Label ID="Label111" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="Txt_CantCafe_In" runat="server" TextMode="number" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                <br />
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Hortaliza </label>
                                                <asp:Label ID="Label112" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_Hortaliza_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                                <label>Cantidad de Terreno Hortaliza </label>
                                                <asp:Label ID="Label113" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="Txt_CantHortaliza_In" runat="server" TextMode="number" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                <br />
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Frutales </label>
                                                <asp:Label ID="Label114" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_Frutales_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                                <label>Cantidad de Terreno Frutales </label>
                                                <asp:Label ID="Label115" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="Txt_CantFrutales_In" runat="server" TextMode="number" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                <br />
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Ganaderia </label>
                                                <asp:Label ID="Label116" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_Ganaderia_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                                <label>Cantidad de Terreno Ganaderia </label>
                                                <asp:Label ID="Label117" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="Dl_CantGanaderia_In" runat="server" TextMode="number" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                <br />
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Conservacion/ Bosque </label>
                                                <asp:Label ID="Label118" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_Conservacion_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                                <label>Cantidad de Terreno Conservacion Bosque </label>
                                                <asp:Label ID="Label119" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="Dl_CantTerreno_In" runat="server" TextMode="number" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                <br />
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Otros </label>
                                                <asp:Label ID="Label120" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="DlOtroTerreno_IN" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                                <label>Cantidad de Terreno Otros </label>
                                                <asp:Label ID="Label121" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="Txt_CantTerreno_In" runat="server" TextMode="number" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                <label>Espesifique el tipo de cultivo </label>
                                                <asp:Label ID="Label122" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="Txt_CantTipoOtro_In" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-lg-4">
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        3.3 cuál es el área total de terreno disponible para produccion de semilla certificada de frijol?
                                    </div>

                                    <div class="panel-body">

                                        <label>Cantidad de Terreno en MZ </label>
                                        <asp:Label ID="Label123" class="label label-warning" runat="server" Text=""></asp:Label>
                                        <asp:TextBox CssClass="form-control" ID="Txt_CantTerrenoMz_IN" runat="server" TextMode="number" AutoPostBack="True"></asp:TextBox>
                                        <br />
                                        <label>Cantidad de lotes o campos disponibles </label>
                                        <asp:Label ID="Label124" class="label label-warning" runat="server" Text=""></asp:Label>
                                        <asp:TextBox CssClass="form-control" ID="Txt_CantLotesDis_IN" TextMode="number" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--para pregunta 3.4--%>
                        <div class="row">

                            <div class="col-lg-4">
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        3.4 ¿Como es la topografía del terreno disponible para producción de semilla certificada de frijol?
                                    </div>

                                    <div class="panel-body">

                                        <label>Seleccione la Topografìa Adecuada  </label>
                                        <asp:Label ID="Label125" class="label label-warning" runat="server" Text=""></asp:Label>
                                        <asp:DropDownList CssClass="form-control" ID="Dl_Pendiente_In" runat="server" AutoPostBack="True">
                                            <asp:ListItem>Llano/o casi plano (0 a 3 % de pendiente) </asp:ListItem>
                                            <asp:ListItem>Ligeramente inclinado (3 a 7 % de pendiente)</asp:ListItem>
                                            <asp:ListItem>Moderadamente inclinado(7 a 12 % de pendiente)  </asp:ListItem>
                                            <asp:ListItem>Fuertemente ondulado(12 a 25% de pendiente) </asp:ListItem>
                                            <asp:ListItem>Ligeramente escarpado/empinado(25 a 55% de pendiente)</asp:ListItem>
                                            <asp:ListItem>Fuertemente escarpado/empinado(55 a 80% de pendiente)</asp:ListItem>
                                            <asp:ListItem> Muy escarpado/empinado (Mayor a 80% pendiente)</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--cierre 3.4--%>

                        <div class="row">

                            <div class="col-lg-12">
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        3.4 Tiene acceso a una fuente de Agua en el Terreno donde produce frijol?
                                    </div>

                                    <div class="panel-body">
                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <label>1. Dentro de la finca </label>
                                                <asp:Label ID="Label126" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <br />

                                                <label>RIO </label>
                                                <asp:Label ID="Label127" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_Rio_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <br />
                                                <label>POZO </label>
                                                <asp:Label ID="Label128" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_Pozo_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <br />
                                                <label>Ojo de agua </label>
                                                <asp:Label ID="Label129" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_OjoAguaIn_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-lg-12">
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                       3.4.1 Tiene acceso a una fuente de Agua en el Terreno donde produce frijol?
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <label>1. Fuera de la finca </label>
                                                <asp:Label ID="Label130" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <br />

                                                <label>RIO </label>
                                                <asp:Label ID="Label131" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_RioFuera_IN" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <br />
                                                <label>POZO </label>
                                                <asp:Label ID="Label132" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_PozoFuera_IN" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <br />
                                                <label>Ojo de agua </label>
                                                <asp:Label ID="Label133" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_OjoDeAguaFuera_IN" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-lg-12">
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        3.5.2  ¿Posee sistema de riego? 
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <label>¿Posee sistema de riego?  </label>
                                                <asp:Label ID="Label134" class="label label-warning" runat="server" Text=""></asp:Label>

                                                <asp:DropDownList CssClass="form-control" ID="Dl_SistemaRiego_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <label>¿Qué tipo de sistema de riego posee? </label>
                                                <asp:Label ID="Label135" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_TipoSisistema_In" runat="server" AutoPostBack="True" Enabled="False">

                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem>Aspersión</asp:ListItem>
                                                    <asp:ListItem>Goteo</asp:ListItem>
                                                    <asp:ListItem>Gravedad </asp:ListItem>
                                                    <asp:ListItem>Otro</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>¿Cuál es el área de terreno que tiene bajo riego?. </label>
                                                <asp:Label ID="Label136" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="Txt_AreaRiego_IN" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-lg-12">
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        3.5.2.1 ¿Què tipo de energía utiliza para el funcionamiento del sistema de riego?
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <label>No requiere</label>
                                                <asp:Label ID="Label137" class="label label-warning" runat="server" Text=""></asp:Label>

                                                <asp:DropDownList CssClass="form-control" ID="Dl_RequiereSistema_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <label>Combustión </label>
                                                <asp:Label ID="Label176" class="label label-warning" runat="server" Text=""></asp:Label>

                                                <asp:DropDownList CssClass="form-control" ID="Dl_Combustion_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <label>Eléctrica</label>
                                                <asp:Label ID="Label177" class="label label-warning" runat="server" Text=""></asp:Label>

                                                <asp:DropDownList CssClass="form-control" ID="Dl_Electrica_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <label>Solar</label>
                                                <asp:Label ID="Label203" class="label label-warning" runat="server" Text=""></asp:Label>

                                                <asp:DropDownList CssClass="form-control" ID="Dl_Solar_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <label>Otra explique:</label>
                                                <asp:Label ID="Label204" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="Txt_OtraEnergia_In" runat="server" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-lg-12">
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        3.6 ¿A qué distancia del hogar está ubicada la propiedad principal donde cultiva frijol?
                                    </div>

                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="form-group">

                                                    <label>Distancia en Km</label>
                                                    <asp:Label ID="Label205" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="Txt_DistanciaKm_IN" TextMode="number" runat="server" AutoPostBack="True"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-lg-12">
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        3.7 ¿En el camino más cercano a la propiedad donde cultiva frijol, pueden transitar los vehículos todo el año?  
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <label>¿En el camino más cercano a la propiedad donde cultiva frijol, pueden transitar los vehículos todo el año?  </label>
                                                <asp:Label ID="Label206" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_CaminoPropiedad_IN" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-12">
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        3.8  ¿Que medio usa para transportar el grano/semilla de frijol  desde el lugar donde acopia el producto al mercado o sitio de venta más cercano donde usualmente lo vende?
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <label>Automóvil    </label>
                                                <asp:Label ID="Label207" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_Auto_in" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <label>Pick-up    </label>
                                                <asp:Label ID="Label208" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_Pick_IN" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <label>Motocicleta  </label>
                                                <asp:Label ID="Label209" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_Moto_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <label>Bicicleta  </label>
                                                <asp:Label ID="Label210" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_Bici_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">

                                                <label>Caballo, mula, macho</label>
                                                <asp:Label ID="Label211" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="Dl_Caballo_In" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>no</asp:ListItem>
                                                    <asp:ListItem>si</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                   <label>Tiene Otro.   </label>
                                                    <asp:Label ID="Label65" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="DL_Otro_Transporte_In" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>no</asp:ListItem>
                                                        <asp:ListItem>si</asp:ListItem>
                                                    </asp:DropDownList>

                                                <label>Otro Especifique :</label>
                                                <asp:Label ID="Label212" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="Txt_OtroTrans_In" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="panel panel-primary">
                                            <div class="panel-heading">
                                                4.0    INVERSIONES EN INFRAESTRUCTURA POST COSECHA
                                            </div>

                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <label>4.1  ¿Qué tipos de infraestructura posee?    </label>
                                                        <asp:Label ID="Label23" class="label label-warning" runat="server" Text="" enable="false"></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="row">

                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>A.    Bodega / centro de acopio   </label>
                                                            <asp:Label ID="Label24" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-2">

                                                        <div class="form-group">
                                                            <br />
                                                            <asp:DropDownList CssClass="form-control" ID="Dl_Bodega_In" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-2">

                                                        <div class="form-group">
                                                            <br />
                                                            <label>Cantidad : </label>
                                                            <asp:Label ID="Label25" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-2">

                                                        <div class="form-group">
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="Dl_CantBodega_In" TextMode="number" runat="server" enable="false" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>B.  Secadoras solares  </label>
                                                            <asp:Label ID="Label146" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:DropDownList CssClass="form-control" ID="Dl_Secadora_In" runat="server" AutoPostBack="True">

                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">

                                                        <div class="form-group">
                                                            <br />
                                                            <label>Cantidad : </label>
                                                            <asp:Label ID="Label147" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="Dl_CantSecadora_In" runat="server" TextMode="number" enable="false" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>C.  Secadoras mecánicas  </label>
                                                            <asp:Label ID="Label148" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:DropDownList CssClass="form-control" ID="Dl_SecMecanica_In" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>Cantidad : </label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:Label ID="Label149" class="label label-warning" runat="server" Text=""></asp:Label>
                                                            <asp:TextBox CssClass="form-control" ID="Dl_CantSecMecanica_In" runat="server" TextMode="number" enable="false" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>D.  Computadora </label>
                                                            <asp:Label ID="Label151" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:DropDownList CssClass="form-control" ID="Dl_Pc_In" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>Cantidad :</label>
                                                            <asp:Label ID="Label152" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />

                                                            <asp:TextBox CssClass="form-control" ID="Txt_CantPc_In" runat="server" TextMode="number" enable="false" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>E. Aspersión/bomba mochila</label>
                                                            <asp:Label ID="Label153" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:DropDownList CssClass="form-control" ID="Dl_Equipo_In" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>Cantidad : </label>
                                                            <asp:Label ID="Label213" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="Dl_CantEquipo_In" runat="server" TextMode="number" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>F.  Desgranadora</label>
                                                            <asp:Label ID="Label214" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:DropDownList CssClass="form-control" ID="Dl_Des_In" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>Cantidad :</label>
                                                            <asp:Label ID="Label215" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="Txt_CantDes_IN" runat="server" TextMode="number" enable="false" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">

                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>G.  Zaranda</label>
                                                            <asp:Label ID="Label216" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">

                                                            <br />
                                                            <asp:DropDownList CssClass="form-control" ID="Dl_Zaranda_In" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>Cantidad  </label>
                                                            <asp:Label ID="Label217" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="Txt_CantZara_IN" runat="server" TextMode="number" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>H.  Maquinaria disponible </label>
                                                            <asp:Label ID="Label218" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:DropDownList CssClass="form-control" ID="Dl_Maquinaria_IN" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>Cantidad  </label>
                                                            <asp:Label ID="Label219" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="Txt_CantidadMaquinaria_In" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-sm-4">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>I.  Arado</label>
                                                            <asp:Label ID="Label220" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:DropDownList CssClass="form-control" ID="Dl_Arado_IN" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>Cantidad  </label>
                                                            <asp:Label ID="Label221" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="Txt_CantidadArado_In" TextMode="number" runat="server" enable="false" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>H.  Acamadora</label>
                                                            <asp:Label ID="Label222" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:DropDownList CssClass="form-control" ID="Dl_Aca_In" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>Cantidad  </label>
                                                            <asp:Label ID="Label223" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="Dl_CantAca_In" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>J.  Sembradora</label>
                                                            <asp:Label ID="Label224" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:DropDownList CssClass="form-control" ID="Dl_Sembra_In" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>Cantidad  </label>
                                                            <asp:Label ID="Label225" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="Dl_CantSembra_In" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>K.  Clasificadora</label>
                                                            <asp:Label ID="Label226" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:DropDownList CssClass="form-control" ID="Dl_Clasifica_In" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>Cantidad  </label>
                                                            <asp:Label ID="Label227" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="Txt_CantidadClasifica_IN" TextMode="number" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>l.  Pulidora</label>
                                                            <asp:Label ID="Label228" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:DropDownList CssClass="form-control" ID="Dl_Pulidora_In" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>Cantidad  </label>
                                                            <asp:Label ID="Label229" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="Txt_CanPuli_IN" runat="server" TextMode="number" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>M.  Envasadora</label>
                                                            <asp:Label ID="Label230" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />

                                                            <asp:DropDownList CssClass="form-control" ID="Dl_Envasa_In" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>Cantidad  </label>
                                                            <asp:Label ID="Label231" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="Txt_CantEnvasa_In" runat="server" TextMode="number" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>N.  Bomba de motor-riego</label>
                                                            <asp:Label ID="Label232" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:DropDownList CssClass="form-control" ID="Dl_Bomba_In" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>Cantidad  </label>
                                                            <asp:Label ID="Label233" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="Txt_CanTBomba_IN" runat="server" TextMode="number" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>O.  Patio de secado</label>
                                                            <asp:Label ID="Label234" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:DropDownList CssClass="form-control" ID="Dl_Patio_IN" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />

                                                            <label>Cantidad:</label>
                                                            <asp:Label ID="Label235" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="Dl_PatioCant_IN" runat="server" TextMode="number" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>P.  Otras </label>
                                                            <asp:Label ID="Label236" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:DropDownList CssClass="form-control" ID="Dl_OtrasCosas_IN" runat="server" AutoPostBack="True">
                                                                <asp:ListItem>no</asp:ListItem>
                                                                <asp:ListItem>si</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <label>Escriba Otra</label>
                                                            <asp:Label ID="Label237" class="label label-warning" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="Txt_OtrasCosas_IN" runat="server" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
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

                                <div class="form-group">

                                    <label>Seleccionar asesor técnico</label><asp:Label ID="Asignar_Acesor_In" class="label label-warning" runat="server" Text=""></asp:Label>

                                    <asp:DropDownList CssClass="form-control" ID="Lb_Asignar_Acesor_Ind" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                      </div>
                        </div>
                    <div id="div4" runat="server">
                        <%--       <asp:Button ID="Guardar_registro"  class="btn btn-success" runat="server" Text="Guardar"  data-toggle="modal" data-target="#exampleModal2" />--%>
                        <button type="button" id="Button2" runat="server" class="btn btn-success" data-toggle="modal" data-target="#exampleModal2222">
                            Guardar
                        </button>

                        <asp:Button ID="Button4" class="btn btn-danger" runat="server" Text="Regresar" />
                    </div>
                    <div id="divModifiyIn" runat="server">
                        <%--       <asp:Button ID="Guardar_registro"  class="btn btn-success" runat="server" Text="Guardar"  data-toggle="modal" data-target="#exampleModal2" />--%>
                        <button type="button" id="ButtonModificar_In" runat="server" class="btn btn-warning" data-toggle="modal" data-target="#exampleModaIndividual">
                            Modificar
                        </button>

                        <asp:Button ID="Button13" class="btn btn-danger" runat="server" Text="Regresar" />
                    </div>
                </div>
            </div>

            <%-- FIN FORMULARIO CONSULTAS--%>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel4"
        runat="server">
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="modal fade" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Red Pash</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ¿Está seguro que desea actualizar el registro de la Organización?
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnsiActualizarOrg" class="btn btn-primary" runat="server" Text="SI" />

                    <button type="button" class="btn btn-danger" data-dismiss="modal">NO</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="exampleModaIndividual" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabelIndividual">Red Pash</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ¿Está seguro que desea actualizar el registro de la Organización?
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnsiActualizarIn" class="btn btn-primary" runat="server" Text="SI" />

                    <button type="button" class="btn btn-danger" data-dismiss="modal">NO</button>
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="lblMensajeError" runat="server" CssClass="error-message" Visible="false"></asp:Label>

    <%--   boton exportar--%>
    <%--        <div id="divexportar" runat="server">

                <div class="row">
                    <div class="col-lg-12">
                                        <br />
                                        <asp:Button ID="Button6" runat="server" CssClass="btn btn-primary" Text="Exportar a Excel" OnClick="Button1_Click" />
                                   </div>
                            </div>
                    </div>--%>
</asp:Content>