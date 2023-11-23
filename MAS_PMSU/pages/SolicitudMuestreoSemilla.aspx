<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="SolicitudMuestreoSemilla.aspx.vb" Inherits="MAS_PMSU.SolicitudMuestreoSemilla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Solicitud de Muestreo de Semilla</h1>
        </div>
    </div>
    
    <div id="Div2" runat="server">
        <div class="row">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Generar Solicitud de Muestreo de Semilla
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-2">
                            <div class="form-group">
                                <asp:Button CssClass="btn btn-primary" ID="BtnSoliMuesSemi" runat="server" Text="Generar PDF" OnClick="BtnSoliMuesSemi_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="DivGridG" runat="server">
        <div class="row">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Datos Generales
                </div>

                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Seleccione Productor:</label>
                                <asp:DropDownList CssClass="form-control" ID="TxtProductorG" runat="server" AutoPostBack="True"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Seleccione Cultivo:</label>
                                <asp:DropDownList CssClass="form-control" ID="DDL_SelCultG" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_SelCultG_SelectedIndexChanged">
                                    <asp:ListItem Text=""></asp:ListItem>
                                    <asp:ListItem Text="Frijol"></asp:ListItem>
                                    <asp:ListItem Text="Maiz"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Button CssClass="btn btn-primary" ID="BtnNewSol" runat="server" Text="Nueva Solicitud de Muestreo de Semillas" Visible="true" OnClick="BtnNewSol_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="table-responsive">
                                <h3>
                                    <span style="float: right;"><small># Solicitudes:</small>
                                        <asp:Label ID="lblTotalClientes" runat="server" CssClass="label label-warning" /></span>
                                </h3>
                                <p>&nbsp;</p>
                                <p>&nbsp;</p>
                                <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conn_REDPASH %>" ProviderName="<%$ ConnectionStrings:conn_REDPASH.ProviderName %>"></asp:SqlDataSource>
                                <asp:GridView ID="GridDatos" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                    GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource1" Font-Size="Small">
                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay bancos inscritos!
                                    </EmptyDataTemplate>
                                    <%--Paginador...--%>
                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
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
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>

                                        <asp:BoundField DataField="ID">
                                            <HeaderStyle CssClass="hide" />
                                            <ItemStyle CssClass="hide" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="productor" HeaderText="PRODUCTOR" />
                                        <asp:BoundField DataField="departamento" HeaderText="DEPARTAMENTO" />
                                        <asp:BoundField DataField="municipio" HeaderText="MUNICIPIO" />
                                        <asp:BoundField DataField="aldea" HeaderText="ALDEA" />
                                        <asp:BoundField DataField="caserio" HeaderText="CASERIO" />
                                        <asp:BoundField DataField="ciclo" HeaderText="CICLO" />
                                        <asp:BoundField DataField="cultivo" HeaderText="CULTIVO" />
                                        <asp:BoundField DataField="variedadFrijol" HeaderText="VARIEDAD FRIJOL" />
                                        <asp:BoundField DataField="variedadMaiz" HeaderText="VARIEDAD MAÍZ" />
                                        <asp:BoundField DataField="lote_produc_semilla" HeaderText="LOTE" />
                                        <asp:BoundField DataField="cantidad_QQ_cosechada" HeaderText="QQ COSECHA" />
                                        <asp:BoundField DataField="FECHA_COSECHA" HeaderText="FECHA DE COSECHA" />

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
                            <%--<asp:Button ID="Button1" runat="server" Text="Exportar Datos" CssClass="btn btn-success" />--%>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning" Text="Exportar Datos"><span class="glyphicon glyphicon-save"></span>&nbsp;Exportar Datos</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="DivGrid" runat="server">
        <div class="row">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Agregar Nueva Solicitud de Muestreo de Semilla
                </div>

                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Seleccione Ciclo:</label>
                                <asp:Label ID="Label7" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="TxtCiclo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="VerificarTextBox">
                                    <asp:ListItem Text=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Seleccione Productor:</label>
                                <asp:Label ID="Label8" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="TxtProductor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="TxtProductor_SelectedIndexChanged">
                                    <asp:ListItem Text=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Departamento</label>
                                <asp:Label ID="lb_dept_new" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="txtCodDep" runat="server" AutoPostBack="true" ReadOnly="true" Visible="false" CausesValidation="false"></asp:TextBox>
                                <asp:DropDownList CssClass="form-control" ID="gb_departamento_new" runat="server" AutoPostBack="True" OnSelectedIndexChanged="VerificarTextBox" Enabled="false">
                                    <asp:ListItem Text=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Municipio</label><asp:Label ID="lb_mun_new" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="TxtCodMun" runat="server" AutoPostBack="true" ReadOnly="true" Visible="false" CausesValidation="false"></asp:TextBox>
                                <asp:DropDownList CssClass="form-control" ID="gb_municipio_new" runat="server" AutoPostBack="True" OnSelectedIndexChanged="VerificarTextBox" Enabled="false">
                                    <asp:ListItem Text=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Aldea</label>
                                <asp:Label ID="lb_aldea_new" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="gb_aldea_new" runat="server" AutoPostBack="True" OnSelectedIndexChanged="VerificarTextBox" Enabled="false">
                                    <asp:ListItem Text=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Caserio</label>
                                <asp:Label ID="lb_caserio_new" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="gb_caserio_new" runat="server" AutoPostBack="True" OnSelectedIndexChanged="VerificarTextBox" Enabled="false">
                                    <asp:ListItem Text=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Selecciones Cultivo:</label><asp:Label ID="Label2" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:Label ID="Label9" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="CmbTipoSemilla" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CmbTipoSemilla_SelectedIndexChanged">
                                    <asp:ListItem Text=""></asp:ListItem>
                                    <asp:ListItem id="Frijol" Text="Frijol"></asp:ListItem>
                                    <asp:ListItem id="Maiz" Text="Maiz"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <section id="Section1" runat="server">
                            <div class="col-lg-3" id="VariedadFrijol" runat="server" visible="false">
                                <div class="form-group">
                                    <div class="form-group">
                                        <label>Variedad Frijol</label>
                                        <asp:Label ID="Label3" class="label label-warning" runat="server" Text=""></asp:Label>
                                        <asp:DropDownList CssClass="form-control" ID="DDL_VariedadF" runat="server" AutoPostBack="true" OnSelectedIndexChanged="VerificarTextBox">
                                            <asp:ListItem Text=""></asp:ListItem>
                                            <asp:ListItem id="Amadeus77v1" Text="Amadeus-77"></asp:ListItem>
                                            <asp:ListItem id="Carrizalitov1" Text="Carrizalito"></asp:ListItem>
                                            <asp:ListItem id="Azabachev1" Text="Azabache"></asp:ListItem>
                                            <asp:ListItem id="Paraisitomejoradov1" Text="Paraisito mejorado PM-2"></asp:ListItem>
                                            <asp:ListItem id="Deorhov1" Text="Deorho"></asp:ListItem>
                                            <asp:ListItem id="IntaCardenasv1" Text="Inta Cárdenas"></asp:ListItem>
                                            <asp:ListItem id="Lencaprecozv1" Text="Lenca precoz"></asp:ListItem>
                                            <asp:ListItem id="Rojochortív1" Text="Rojo chortí"></asp:ListItem>
                                            <asp:ListItem id="Tolupanrojov1" Text="Tolupan rojo"></asp:ListItem>
                                            <asp:ListItem id="Hondurasnutritivov1" Text="Honduras nutritivo"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-3" id="VariedadMaiz" runat="server" visible="false">
                                <div class="form-group">
                                    <label>Variedades Maiz</label>
                                    <asp:Label ID="Label4" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="DDL_VariedadM" runat="server" AutoPostBack="true" OnSelectedIndexChanged="VerificarTextBox">
                                        <asp:ListItem Text=""></asp:ListItem>
                                        <asp:ListItem id="DictaMayav1" Text="Dicta Maya"></asp:ListItem>
                                        <asp:ListItem id="DictaVictoriav1" Text="Dicta Victoria"></asp:ListItem>
                                        <asp:ListItem id="OtroMaizv1" Text="Otro"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </section>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Seleccione Categoria:</label>
                                <asp:Label ID="Label10" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="DDL_Categ" runat="server" AutoPostBack="true" OnSelectedIndexChanged="VerificarTextBox">
                                    <asp:ListItem Text=""></asp:ListItem>
                                    <asp:ListItem Text="Basica"></asp:ListItem>
                                    <asp:ListItem Text="Certificada"></asp:ListItem>
                                    <asp:ListItem Text="Registrada"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="txt">Lote de Produccion de Semilla:</label>
                                <asp:Label ID="Label1" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="TxtLoteSemi" runat="server" AutoPostBack="true" ReadOnly="true"></asp:TextBox>
                                <asp:TextBox CssClass="form-control" ID="Txtcount" runat="server" AutoPostBack="true" ReadOnly="true" Visible="false" CausesValidation="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="txt">Fecha de la cosecha:</label>
                                <asp:Label ID="Label5" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="TxtFechCose" runat="server" AutoPostBack="true" TextMode="Date" OnTextChanged="VerificarTextbox"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="txt">Cantidad de quintales cosechados:</label>
                                <asp:Label ID="Label6" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="TxtQQCose" runat="server" AutoPostBack="true" TextMode="Number" OnTextChanged="VerificarTextbox"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Button CssClass="btn btn-primary" ID="BtnNewActa" runat="server" Text="Guardar registro de muestreo de semilla" Visible="true" OnClick="btnGuardarActa_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-2">
                            <div class="form-group">
                                <asp:Button CssClass="btn btn-primary" ID="BtnRegre" runat="server" Text="Regresar" OnClick="vaciar" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div id="Div1" runat="server">
        <div class="row">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Generar Solicitud de Muestreo de Semilla
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="txt">Fecha de la cosecha:</label>
                                <asp:Label ID="Label13" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="txtFechaSoli" runat="server" AutoPostBack="true" TextMode="Date" OnTextChanged="Verificar"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="TxtLugar">Lugar:</label>
                                <asp:Label ID="Label14" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="TxtLugar" runat="server" AutoPostBack="true" OnTextChanged="Verificar"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="TxtNombComp">Para (nombre):</label>
                                <asp:Label ID="Label15" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="TxtNombComp" runat="server" AutoPostBack="true" OnTextChanged="Verificar"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="TxtNombCarg">Cargo:</label>
                                <asp:Label ID="Label16" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="TxtNombCarg" runat="server" AutoPostBack="true" OnTextChanged="Verificar"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Seleccione Ciclo:</label>
                                <asp:Label ID="Label11" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="DDL_Ciclo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Verificar">
                                    <asp:ListItem Text=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Departamento</label>
                                <asp:Label ID="Label12" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="DDL_Depto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Verificar">
                                    <asp:ListItem Text=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-2">
                            <div class="form-group">
                                <asp:Button CssClass="btn btn-primary" ID="BtnImprimir" runat="server" Text="Descargar en PDF " OnClick="descargaPDF" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-2">
                            <div class="form-group">
                                <asp:Button CssClass="btn btn-primary" ID="BtnNuevo" runat="server" Text="Regresar" OnClick="vaciar" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div>
        <label></label>
        <asp:Label ID="LabelGuardar" class="label label-warning" runat="server" Text=""></asp:Label>
        <br />
        <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
        <asp:Button CssClass="btn btn-primary" ID="btnGuardarActa" runat="server" Text="Guardar" Visible="false" />
    </div>

    <div class="modal fade" id="DeleteModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="ModalTitle2">REDPASH</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="Label103" runat="server" Text="Primero rellene los campos solicitados"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <asp:Button ID="BConfirm" Text="Aceptar" Width="80px" runat="server" Class="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
