<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="Ventas.aspx.vb" Inherits="MAS_PMSU.Ventas" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Ventas</h1>
        </div>
    </div>
    <div id="panelmasiso" runat="server">
        <div id="Div1" runat="server">
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Registro Plan Producciòn Semilla Frijol
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label>Seleccione Cultivo:</label>
                                        <asp:DropDownList CssClass="form-control" ID="DDL_cultivo" runat="server" AutoPostBack="True">
                                            <asp:ListItem Text=" "></asp:ListItem>
                                            <asp:ListItem Text="Frijol"></asp:ListItem>
                                            <asp:ListItem Text="Maiz"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label>Seleccione Categoria:</label>
                                        <asp:DropDownList CssClass="form-control" ID="DDL_Categ" runat="server" AutoPostBack="True">
                                            <asp:ListItem Text=" "></asp:ListItem>
                                            <asp:ListItem Text="Basica"></asp:ListItem>
                                            <asp:ListItem Text="Certificada"></asp:ListItem>
                                            <asp:ListItem Text="Registrada"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label></label>
                                        <asp:Label ID="Label23" class="label label-warning" runat="server" Text=""></asp:Label>
                                        <br />
                                        <asp:Button CssClass="btn btn-primary" ID="Button3" runat="server" Text="Reiniciar" OnClick="limpiarFiltros" Visible="true" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label>Seleccione Ciclo:</label>
                                        <asp:DropDownList CssClass="form-control" ID="TxtCiclo" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label>Seleccione Departamento:</label>
                                        <asp:DropDownList CssClass="form-control" ID="TxtDepto" runat="server" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label>Seleccione Productor:</label>
                                        <asp:DropDownList CssClass="form-control" ID="TxtProductor" runat="server" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="table-responsive">
                                        <h3>
                                            <span style="float: right;"><small># Lotes:</small>
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
                                                <asp:BoundField DataField="Departamento" HeaderText="DEPARTAMENTO" />
                                                <asp:BoundField DataField="Productor" HeaderText="PRODUCTOR" />
                                                <asp:BoundField DataField="Cultivo" HeaderText="CULTIVO" />
                                                <asp:BoundField DataField="CATEGORIA" HeaderText="CATEGORIA" />
                                                <asp:BoundField DataField="CICLO" HeaderText="CICLO" />
                                                <asp:BoundField DataField="VARIEDAD" HeaderText="VARIEDAD" />
                                                <asp:BoundField DataField="AREA_HA" HeaderText="AREA INSCRITA EN HA" />
                                                <asp:BoundField DataField="AREA_MZ" HeaderText="AREA INSCRITA EN MZ" />
                                                <asp:BoundField DataField="Fecha_siembra" HeaderText="FECHA DE SIEMBRA INSCRITA" />
                                                <asp:BoundField DataField="QQ_Produccion_Campo" HeaderText="QQ DE PRODUCCION EN CAMPO" />
                                                <asp:BoundField DataField="QQ_Oro" HeaderText="QQ DE SEMILLA ORO" />
                                                <asp:BoundField DataField="QQ_Grano" HeaderText="QQ DE SEMILLA GRANO" />
                                                <asp:BoundField DataField="QQ_Basura" HeaderText="QQ DE SEMILLA BASURA" />
                                                <asp:BoundField DataField="Habilitado" HeaderText="HABILITADO" />
                                                <asp:BoundField DataField="QQ_semilla_entregado" HeaderText="QQ DE SEMILLA ENTREGADO" />
                                                <asp:BoundField DataField="QQ_consumo_entregado" HeaderText="QQ DE CONSUMO ENTREGADO" />
                                                <%--<asp:BoundField DataField="Habilitado" HeaderText="HABILITADO" />--%>

                                                <asp:ButtonField ButtonType="Button" Text="Ventas" ControlStyle-CssClass="btn btn-success" HeaderText="Ventas" CommandName="Ventas">
                                                    <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                                </asp:ButtonField>
                                                <%--                                        <asp:TemplateField HeaderText="Check costo">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                            </ItemTemplate>
                                            </asp:TemplateField>--%>
                                                <asp:ButtonField ButtonType="Button" Text="Registros ventas" ControlStyle-CssClass="btn btn-danger" HeaderText="Registros ventas" CommandName="Eliminar">
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
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="Div2" runat="server">
            <div class="row">
                <div class="col-lg-12">
                    <h2>Detalle de Ventas</h2>
                    <div class="panel-body">

                        <div class="row">
                            <div class="panel panel-primary">
                                <div class="panel-heading">Identificacion</div>
                                <div class="panel-body">
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Departamento</label>
                                            <asp:TextBox CssClass="form-control" ID="Text_departamento" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                            <br />
                                            <label>Codigo BCS</label>
                                            <asp:TextBox CssClass="form-control" ID="Text_codigo_bcs" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                            <asp:TextBox CssClass="form-control" ID="TxtId2" runat="server" AutoPostBack="True" ReadOnly="True" Visible="false"></asp:TextBox>
                                            <br />
                                            <label>Categoria</label>
                                            <asp:TextBox CssClass="form-control" ID="Text_categoria" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Municipio</label>
                                            <asp:TextBox CssClass="form-control" ID="Text_municipio" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                            <br />
                                            <label>Nombre Productor</label>
                                            <asp:TextBox CssClass="form-control" ID="Text_nombre_productor" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Aldea</label>
                                            <asp:TextBox CssClass="form-control" ID="Text_aldea" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                            <br />
                                            <label>Ciclo</label>
                                            <asp:TextBox CssClass="form-control" ID="Text_ciclo" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Caserio</label>
                                            <asp:TextBox CssClass="form-control" ID="Text_caserio" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                            <br />
                                            <label>Variedad</label>
                                            <asp:TextBox CssClass="form-control" ID="Text_variedad" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            <label>Producción</label>
                                        </div>
                                        <div class="panel-body">
                                            <div class="row">
                                                <div class="col-lg-3">
                                                    <div class="form-group">
                                                        <label>QQ Producción</label>
                                                        <asp:TextBox CssClass="form-control" ID="Text_QQ_Produccion" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group">
                                                        <label>QQ semilla (certificada / comercial)</label>
                                                        <asp:TextBox CssClass="form-control" ID="Text_QQ_Produccion_ORO" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                        <br />
                                                        <label>QQ semilla entregado </label>
                                                        <asp:TextBox CssClass="form-control" ID="TXT_QQ_ORO_ENTRE" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                        <br />
                                                        <label>QQ semilla por detallar </label>
                                                        <asp:TextBox CssClass="form-control" ID="txt_semilla_por_detallar" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <label>QQ consumo (granos, uso humano u otros usos)</label>
                                                        <asp:TextBox CssClass="form-control" ID="Text_QQ_Produccion_consumo" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                        <br />
                                                        <label>QQ consumo  entregado</label>
                                                        <asp:TextBox CssClass="form-control" ID="TXT_QQ_CONSUMO_ENTRE" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                        <br />
                                                        <label>QQ consumo por detallar </label>
                                                        <asp:TextBox CssClass="form-control" ID="txt_consumo_por_detallar" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <label>QQ basura</label>
                                                        <asp:TextBox CssClass="form-control" ID="Text_QQ_Produccion_basura" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    Detalle semilla (Certificada /Comercial)
                                </div>
                                <div class="panel-body">
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <div class="panel panel-Info">
                                                <div class="panel-heading">
                                                    <h4 style="text-align: center;">Venta</h4>
                                                </div>
                                            </div>
                                            <label>QQ semilla (Certificada /Comercial)</label>
                                            <asp:TextBox CssClass="form-control" ID="txt_qq" runat="server" TextMode="number" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                                            <br />
                                            <label>Precio venta QQ semilla</label><asp:Label ID="lb_precio_semilla_venta" runat="server" CssClass="btn-warning"></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txt_precio" runat="server" TextMode="number" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                                            <br />
                                            <label>Comprador</label>
                                            <asp:Label ID="Lb_comprador_semilla" runat="server" CssClass="btn-warning"></asp:Label>
                                            <asp:DropDownList CssClass="form-control" ID="Dp_comprador" runat="server" AutoPostBack="True"></asp:DropDownList>
                                            <br />
                                            <label>Detalle Comprador</label>
                                            <asp:Label ID="Lb_comprador_semilla_detalle" runat="server" CssClass="btn-warning"></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txt_detalle_comprador" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                            <br />
                                            <label>Ingreso total venta semilla</label>
                                            <asp:TextBox CssClass="form-control" ID="txt_total_venta" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                            <br />
                                            <asp:Label ID="LB_VALIDACION_QQ_sEMILLA" runat="server" CssClass="btn-warning"></asp:Label>
                                            <br />
                                            <%--        <label>QQ ORO pendiente</label>--%>
                                            <asp:TextBox CssClass="form-control" Visible="false" ID="txt_qq_oro_pend" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <div class="panel panel-info">
                                                <div class="panel-heading">
                                                    <h4 style="text-align: center;">Consumo</h4>
                                                </div>
                                            </div>
                                            <label>QQ consumo semilla </label>
                                            <asp:TextBox CssClass="form-control" ID="txt_qq_consumo" runat="server" TextMode="number" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                                            <br />
                                            <label>Precio venta QQ consumo semilla</label><asp:Label ID="lb_precio_consumo_semilla" runat="server" CssClass="btn-warning"></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txt_precio_consumo" runat="server" TextMode="number" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                                            <br />
                                            <label>Ingreso total consumo semilla</label>
                                            <asp:TextBox CssClass="form-control" ID="txt_ingreso_consumo" runat="server" AutoPostBack="True" ReadOnly="true"></asp:TextBox>
                                            <br />
                                            <asp:TextBox CssClass="form-control" Visible="false" ID="qq_consumo_pend" runat="server" AutoPostBack="True" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    Detalle QQ Semilla no clasificada (granos, uso humano u otros usos)
                                </div>
                                <div class="panel-body">
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <div class="panel panel-info">
                                                <div class="panel-heading">
                                                    <h4 style="text-align: center;">Venta</h4>
                                                </div>
                                            </div>
                                            <label>QQ venta (granos, uso humano u otros usos)</label>
                                            <asp:TextBox CssClass="form-control" ID="TXT_QQ_VENTA_GRANO" runat="server" TextMode="number" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                                            <br />
                                            <label>Precio venta QQ (granos, uso humano u otros usos) </label>
                                            <asp:Label ID="lb_precio_grano_venta" runat="server" CssClass="btn-warning"></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="TXT_PRECIO_GRANO" runat="server" TextMode="number" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                                            <br />
                                            <label>Comprador</label>
                                            <asp:Label ID="lb_comprador_grano" runat="server" CssClass="btn-warning"></asp:Label>
                                            <asp:DropDownList CssClass="form-control" ID="dp_comprador_grano" runat="server" AutoPostBack="True"></asp:DropDownList>
                                            <br />
                                            <label>Detalle Comprador</label>
                                            <asp:Label ID="lb_comprador_detalle_grano" runat="server" CssClass="btn-warning"></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="TXT_COMPRADOR_GRANO" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                            <br />
                                            <label>Ingreso total</label>
                                            <asp:TextBox CssClass="form-control" ID="TXT_INGRESO_TOTAL_VENGRANO" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                            <br />
                                            <asp:Label ID="lb_validacion_consumo" runat="server" CssClass="btn-warning"></asp:Label>
                                            <br />
                                            <asp:TextBox CssClass="form-control" Visible="false" ID="TextBox9" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <div class="panel panel-info">
                                                <div class="panel-heading">
                                                    <h4 style="text-align: center;">Consumo</h4>
                                                </div>
                                            </div>
                                            <label>QQ grano consumo</label>
                                            <asp:TextBox CssClass="form-control" ID="TXT_QQ_GRANO_CONSUMO" runat="server" TextMode="number" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                                            <br />
                                            <label>Precio QQ grano consumo</label><asp:Label ID="LB_grano_consumo" runat="server" CssClass="btn-warning"></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="TXT_PRECIO_GRANO_CONSUMO" runat="server" TextMode="number" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                                            <br />
                                            <label>Ingreso total</label>
                                            <asp:TextBox CssClass="form-control" ID="TXT_INGRESO_TOTAL_CONSGRANO" runat="server" AutoPostBack="True" ReadOnly="true"></asp:TextBox>
                                            <br />
                                            <asp:TextBox CssClass="form-control" Visible="false" ID="TextBox13" runat="server" AutoPostBack="True" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <asp:TextBox ID="txt_fuente" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                                <asp:TextBox ID="txt_habilitado" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                                <asp:TextBox ID="TxtCodOP" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                                <asp:TextBox ID="TxtCodProd" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                                <asp:TextBox ID="TxtTipo" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                                <asp:TextBox ID="TxtEdit" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                                <asp:TextBox ID="txt_qq_entregado" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                                <asp:TextBox ID="txt_qq_entregado_consumo" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                            </div>

                        </div>

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
                                <div id="div_guardar" runat="server">
                                    <%--       <asp:Button ID="Guardar_registro"  class="btn btn-success" runat="server" Text="Guardar"  data-toggle="modal" data-target="#exampleModal2" />--%>
                                    <button type="button" id="Guardar_registro" runat="server" class="btn btn-success" data-toggle="modal" data-target="#exampleModal2">Guardar</button>
                                    <asp:Button ID="Cancelar" class="btn btn-danger" runat="server" Text="Regresar" />
                                </div>
                                <div class="modal fade" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="exampleModalLabela">MAS 2.0 - TNS</h5>

                                            </div>
                                            <div class="modal-body">¿Está seguro que sea ingresar el registro de venta?</div>
                                            <div class="modal-footer">
                                                <asp:Button ID="btn_si" Text="SI" Width="80px" runat="server" Class="btn btn-primary" />
                                                <button type="button" class="btn btn-danger" width="80px" data-dismiss="modal">NO</button>
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

    </div>

</asp:Content>
