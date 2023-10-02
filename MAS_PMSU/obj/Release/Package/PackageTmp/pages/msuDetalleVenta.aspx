<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="msuDetalleVenta.aspx.vb" Inherits="MAS_PMSU.msuDetalleVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            display: block;
            width: 100%;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }
        .auto-style3 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 100%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }

 
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header"></h1>
        </div>
    </div>
       <div id="divdatos" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    DETALLE DE VENTAS
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Seleccione Ciclo:</label>
                                <asp:DropDownList CssClass="form-control" ID="TxtCiclo" runat="server" AutoPostBack="True">
                                    <asp:ListItem>Todos</asp:ListItem>
                                    <asp:ListItem>2019-Ciclo A</asp:ListItem>
                                    <asp:ListItem>2019-Ciclo B</asp:ListItem>
                                    <asp:ListItem>2019-Ciclo C</asp:ListItem>
                                    <asp:ListItem>2019-Ciclo A</asp:ListItem>
                                    <asp:ListItem>2019-Ciclo B</asp:ListItem>
                                    <asp:ListItem>2019-Ciclo C</asp:ListItem>
                                    <asp:ListItem>2020-Ciclo A</asp:ListItem>
                                    <asp:ListItem>2020-Ciclo B</asp:ListItem>
                                    <asp:ListItem>2020-Ciclo C</asp:ListItem>
                                    <asp:ListItem>2021-Ciclo A</asp:ListItem>
                                    <asp:ListItem>2021-Ciclo B</asp:ListItem>
                                    <asp:ListItem>2021-Ciclo C</asp:ListItem>
                                    <asp:ListItem>2022-Ciclo A</asp:ListItem>
                                    <asp:ListItem>2022-Ciclo B</asp:ListItem>
                                    <asp:ListItem>2022-Ciclo C</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Seleccione Departamento:</label>
                                <asp:DropDownList CssClass="form-control" ID="TxtDepto" runat="server" AutoPostBack="True"></asp:DropDownList>

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
                                <%--<label>.</label>--%>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MConnODK4 %>" ProviderName="<%$ ConnectionStrings:MConnODK4.ProviderName %>"></asp:SqlDataSource>
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
                                        <asp:BoundField DataField="ID2">
                                            <HeaderStyle CssClass="hide" />
                                            <ItemStyle CssClass="hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Departamento" HeaderText="DEPARTAMENTO" />
                                        <asp:BoundField DataField="Productor" HeaderText="PRODUCTOR" />
                                        <asp:BoundField DataField="CICLO" HeaderText="CICLO" />
                                        <asp:BoundField DataField="VARIEDAD" HeaderText="VARIEDAD" />                               
                                        <asp:BoundField DataField="AREA_SEMBRADA" HeaderText="AREA SEMBRADA" DataFormatString="{0:0.00}" />
                                        <asp:BoundField DataField="FECHA_SIEMBRA" HeaderText="FECHA SIEMBRA" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="QQ_PRODUCCION" HeaderText="QQ PRODUCCION" DataFormatString="{0:0.00}" />
                                         <asp:BoundField DataField="QQ_ORO" HeaderText="QQ ORO" DataFormatString="{0:0.00}" />
                                        <asp:BoundField DataField="QQ_CONSUMO" HeaderText="QQ CONSUMO" DataFormatString="{0:0.00}" />
                                         <asp:BoundField DataField="REGISTRO" HeaderText="REGISTRO DE VENTAS" />   
                                    <%--    <asp:ButtonField ButtonType="Button" Text="+" ControlStyle-CssClass="btn btn-warning" HeaderText="PRODUCCION" CommandName="Produccion">
                                            <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                        </asp:ButtonField>
                                        <asp:ButtonField ButtonType="Button" Text="+" ControlStyle-CssClass="btn btn-danger" HeaderText="COSTOS" CommandName="Costos">
                                            <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                                        </asp:ButtonField>--%>
                                         <asp:ButtonField ButtonType="Button" Text="Ventas" ControlStyle-CssClass="btn btn-danger" HeaderText="VENTAS" CommandName="Costos">
                                            <ControlStyle CssClass="btn btn-success"></ControlStyle>
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
                            <%--<label>.</label>--%>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning" Text="Exportar Datos"><span class="glyphicon glyphicon-save"></span>&nbsp;Exportar Datos</asp:LinkButton>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
                            <asp:Button ID="BAgregar" Visible="false" runat="server" Text="Agregar" CssClass="btn btn-success" />

                        </div>
                    </div>
                       </div>
                    <div class="modal fade" id="DeleteModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
                        aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <%--<label>.</label>--%>
                                    <h4 class="modal-title" id="ModalTitle3">MAS 2.0 - DICTA - MSU</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="modal-footer" style="text-align: center">
                                    <asp:Button ID="BConfirm" Text="Aceptar" Width="80px" runat="server" Class="btn btn-primary" />
                                    <asp:Button ID="BBorrarsi" Text="SI" Width="80px" runat="server" Class="btn btn-primary" />
                                    <asp:Button ID="BBorrarno" Text="NO" Width="80px" runat="server" Class="btn btn-primary" />
                                    <%--<label>.</label>--%>
                                </div>

                            </div>
                        </div>
                    </div>









                    <div class="modal fade" id="DetProduccion" tabindex="-1" role="dialog" aria-labelledby="ModalTitle"
                        aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        &times;</button>
                                    <h4 class="modal-title" id="ModalTitle1">Detalle de Ventas</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:TextBox ID="TxtID" runat="server" Visible="False"></asp:TextBox>
                                    <%--<label>.</label>--%>
                                    <div class="row">
                                         <div class="col-lg-3">
                                            <div class="form-group">
                                                <label>CODIGO BCS </label>
                                                <asp:TextBox ID="TextBox1" runat="server" Enabled="false" CssClass="form-control" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label>Nombre del Productor</label>
                                                <asp:TextBox ID="TxtNom" runat="server" Enabled="false" CssClass="form-control" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label>Ciclo</label>
                                                <asp:TextBox ID="TxtCicloD" runat="server" Enabled="false" CssClass="form-control" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label>Variedad</label>
                                                <asp:TextBox ID="TxtVariedad" runat="server" Enabled="false" CssClass="form-control" autocomplete="off" />
                                            </div>
                                        </div>
                                    </div>
                                    <label for="TxtFecha">Fecha de siembra:</label>
                                    <div class="row">
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <label>Dia</label>
                                                <asp:DropDownList CssClass="form-control" ID="TxtDia" runat="server">
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>3</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem>5</asp:ListItem>
                                                    <asp:ListItem>6</asp:ListItem>
                                                    <asp:ListItem>7</asp:ListItem>
                                                    <asp:ListItem>8</asp:ListItem>
                                                    <asp:ListItem>9</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>11</asp:ListItem>
                                                    <asp:ListItem>12</asp:ListItem>
                                                    <asp:ListItem>13</asp:ListItem>
                                                    <asp:ListItem>14</asp:ListItem>
                                                    <asp:ListItem>15</asp:ListItem>
                                                    <asp:ListItem>16</asp:ListItem>
                                                    <asp:ListItem>17</asp:ListItem>
                                                    <asp:ListItem>18</asp:ListItem>
                                                    <asp:ListItem>19</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>21</asp:ListItem>
                                                    <asp:ListItem>22</asp:ListItem>
                                                    <asp:ListItem>23</asp:ListItem>
                                                    <asp:ListItem>24</asp:ListItem>
                                                    <asp:ListItem>25</asp:ListItem>
                                                    <asp:ListItem>26</asp:ListItem>
                                                    <asp:ListItem>27</asp:ListItem>
                                                    <asp:ListItem>28</asp:ListItem>
                                                    <asp:ListItem>29</asp:ListItem>
                                                    <asp:ListItem>30</asp:ListItem>
                                                    <asp:ListItem>31</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Mes</label>
                                                <asp:DropDownList CssClass="form-control" ID="TxtMes" runat="server">
                                                    <asp:ListItem>Enero</asp:ListItem>
                                                    <asp:ListItem>Febrero</asp:ListItem>
                                                    <asp:ListItem>Marzo</asp:ListItem>
                                                    <asp:ListItem>Abril</asp:ListItem>
                                                    <asp:ListItem>Mayo</asp:ListItem>
                                                    <asp:ListItem>Junio</asp:ListItem>
                                                    <asp:ListItem>Julio</asp:ListItem>
                                                    <asp:ListItem>Agosto</asp:ListItem>
                                                    <asp:ListItem>Septiembre</asp:ListItem>
                                                    <asp:ListItem>Octubre</asp:ListItem>
                                                    <asp:ListItem>Noviembre</asp:ListItem>
                                                    <asp:ListItem>Diciembre</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label>Año</label>
                                                <asp:DropDownList CssClass="form-control" ID="TxtAno" runat="server">
                                                    <asp:ListItem>2018</asp:ListItem>
                                                    <asp:ListItem>2019</asp:ListItem>
                                                    <asp:ListItem>2020</asp:ListItem>
                                                    <asp:ListItem>2021</asp:ListItem>
                                                    <asp:ListItem>2022</asp:ListItem>
                                                    <asp:ListItem>2023</asp:ListItem>
                                                    <asp:ListItem>2024</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <label>Area sembrada</label>
                                    <asp:TextBox ID="TxtAreaSemb" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <label>Area perdida</label>
                                    <asp:TextBox ID="TxtAreaPerdida" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <label>Causas de perdidas</label>
                                    <asp:TextBox ID="TxtCausasPerdida" runat="server" CssClass="form-control" autocomplete="off" />
                                    <label>Produccion de campo (QQ)</label>
                                    <asp:TextBox ID="TxtProduccion" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <label>Semilla oro (QQ)</label>
                                    <asp:TextBox ID="TxtSemilla" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <label>Grano para consumo (QQ)</label>
                                    <asp:TextBox ID="TxtConsumo" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <label>Basura (QQ)</label>
                                    <asp:TextBox ID="Txtbasura" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />

                                    <script type="text/javascript">
                                        function numericOnly(elementRef) {
                                            var keyCodeEntered = (event.which) ? event.which : (window.event.keyCode) ? window.event.keyCode : -1;

                                            // Un-comment to discover a key that I have forgotten to take into account...
                                            //alert(keyCodeEntered);

                                            if ((keyCodeEntered >= 48) && (keyCodeEntered <= 57)) {
                                                return true;
                                            }
                                                // '+' sign...
                                                //else if (keyCodeEntered == 43) {
                                                //    // Allow only 1 plus sign ('+')...
                                                //    if ((elementRef.value) && (elementRef.value.indexOf('+') >= 0))
                                                //        return false;
                                                //    else
                                                //        return true;
                                                //}
                                                //    // '-' sign...
                                                //else if (keyCodeEntered == 45) {
                                                //    // Allow only 1 minus sign ('-')...
                                                //    if ((elementRef.value) && (elementRef.value.indexOf('-') >= 0))
                                                //        return false;
                                                //    else
                                                //        return true;
                                                //}
                                                // '.' decimal point...
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
                                    <div id="Div5" runat="server" visible="false" class="alert alert-danger">
                                        <strong>Error!</strong>
                                        <asp:Label ID="Label6" runat="server" />
                                    </div>
                                </div>
                                <div class="modal-footer" style="text-align: center">
                                    <asp:Button ID="BGuardar" Text="Guardar" Width="80px" runat="server" Class="btn btn-primary" />
                                    <asp:Button ID="BSalir" Text="Salir" Width="80px" runat="server" Class="btn btn-primary" />
                                </div>

                            </div>
                        </div>
                    </div>











                    <div class="modal fade" id="DetCostos" tabindex="-1" role="dialog" aria-labelledby="ModalTitle"
                        aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        &times;</button>
                                    <h4 class="modal-title" id="ModalTitle2">Detalle de Ventas</h4>
                                </div>
                                <div class="modal-body">                             
                                    <%--<label>.</label>--%>
                                    <div class="row">   <div class="col-lg-3">
                                            <div class="form-group">
                                                <label>Codigo BCS</label>
                                                <asp:TextBox ID="TextBox2" runat="server" Enabled="false" CssClass="form-control" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label>Nombre</label>
                                                <asp:TextBox ID="TxtNom2" runat="server" Enabled="false" CssClass="form-control" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label>Ciclo</label>
                                                <asp:TextBox ID="TxtCicloD2" runat="server" Enabled="false" CssClass="form-control" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label>Variedad</label>
                                                <asp:TextBox ID="TxtVariedad2" runat="server" Enabled="false" CssClass="form-control" autocomplete="off" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label>Departamento</label>
                                                <asp:TextBox ID="TxtareaSemb2" runat="server" Enabled="false" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label>Municipio</label>
                                                <asp:TextBox ID="TxtProduccion2" runat="server" Enabled="false" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                            </div>
                                        </div>
                                         <div class="col-lg-3">
                                            <div class="form-group">
                                                <label>Aldea</label>
                                                <asp:TextBox ID="TextBox3" runat="server" Enabled="false" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                            </div>
                                               </div>
                                              <div class="col-lg-3">
                                            <div class="form-group">
                                                <label>Caserio</label>
                                                <asp:TextBox ID="TextBox4" runat="server" Enabled="false" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                            </div>
                                        </div>
                                    
                                    </div>
                                    <label>Insumos</label>
                                    <asp:TextBox ID="TxtInsumos" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <label>Mano de obra</label>
                                    <asp:TextBox ID="TxtMano" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <label>Equipo y maquinaria</label>
                                    <asp:TextBox ID="TxtEquipo" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <label>Otros</label>
                                    <asp:TextBox ID="TxtOtros" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <label>Inscripción</label>
                                    <asp:TextBox ID="TxtInscri" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <label>Acondicionamiento de semilla</label>
                                    <asp:TextBox ID="TxtAcond" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <script type="text/javascript">
                                        function numericOnly(elementRef) {
                                            var keyCodeEntered = (event.which) ? event.which : (window.event.keyCode) ? window.event.keyCode : -1;

                                            // Un-comment to discover a key that I have forgotten to take into account...
                                            //alert(keyCodeEntered);

                                            if ((keyCodeEntered >= 48) && (keyCodeEntered <= 57)) {
                                                return true;
                                            }
                                                // '+' sign...
                                                //else if (keyCodeEntered == 43) {
                                                //    // Allow only 1 plus sign ('+')...
                                                //    if ((elementRef.value) && (elementRef.value.indexOf('+') >= 0))
                                                //        return false;
                                                //    else
                                                //        return true;
                                                //}
                                                //    // '-' sign...
                                                //else if (keyCodeEntered == 45) {
                                                //    // Allow only 1 minus sign ('-')...
                                                //    if ((elementRef.value) && (elementRef.value.indexOf('-') >= 0))
                                                //        return false;
                                                //    else
                                                //        return true;
                                                //}
                                                // '.' decimal point...
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
                                    <div id="Div1" runat="server" visible="false" class="alert alert-danger">
                                        <strong>Error!</strong>
                                        <asp:Label ID="Label2" runat="server" />
                                    </div>
                                </div>
                                <div class="modal-footer" style="text-align: center">
                                    <asp:Button ID="BGuardar2" Text="Guardar" Width="80px" runat="server" Class="btn btn-primary" />
                                    <asp:Button ID="BSalir2" Text="Salir" Width="80px" runat="server" Class="btn btn-primary" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



      <asp:UpdatePanel ID="UpdatePanel2"
                             runat="server">
                <ContentTemplate>
                       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  

                        <div id="divedit" runat="server">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header"></h1>
            </div>
        </div>


        <div class="row">
            <div class="col-lg-12">



                <div class="panel panel-info">
                    <div class="panel-heading">
                     <asp:Label ID="laBEL_MESANSAJE" runat="server" Text=""></asp:Label>DETALLE DE VENTAS

      
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="auto-style3">
                                <div class="row">
                                 
                           <div class="panel panel-info">
                                        <div class="panel-heading">
                               IDENTIFICACION
                                            
                                        </div>

                                        
                                        <div class="panel-body">
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                 
                                   
                                                      <label>Departamento</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_departamento" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                         <br/>
                                                      <label>CODIGO BCS</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_codigo_bcs" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                          <br/>
                                                        <label>Categoria</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_categoria" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                         
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Municipio</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_municipio" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                               <br/>
                                                   <label>Nombre Productor</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_nombre_productor" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                             
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Aldea</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_aldea" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                 <br/>
                                                      <label>Ciclo</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_ciclo" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                        
                                                
                                                </div>
                                            </div>

                                       <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Caserio</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_caserio" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                 <br/>
                                                
                                               <label>Variedad</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_variedad" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                         
                                                </div>
                                            </div>
                    

                                                      

                                         
                                          

                                        </div>
                                    </div>







                                        <div class="panel panel-info">
                                        <div class="panel-heading">
                                  PRODUCCION 
                                            
                                        </div>

                                        
                                        <div class="panel-body">
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                 
                                   
                                                      <label>QQ PRODUCCION</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_QQ_Produccion" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                

                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>QQ ORO (SEMILLA CERTIFICADA)</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_QQ_Produccion_ORO" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                             

                                                  

                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>QQ CONSUMO (GRANO, USO HUMANO U OTROS USOS)</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_QQ_Produccion_consumo" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                </div>
                                            </div>

                                       <div class="col-lg-2">
                                                <div class="form-group">
                                                    <label> QQ BASURA</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_QQ_Produccion_basura" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                </div>
                                            </div>
                    
                                                 

                                         
                                          

                                        </div>
                                    </div>






                                        <div class="row">
                                            <asp:TextBox ID="TxtCodOP" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                                            <asp:TextBox ID="TxtCodProd" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                                            <asp:TextBox ID="TxtTipo" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                                            <asp:TextBox ID="TxtEdit" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                                        </div>

                                    </div>

                          



                               <%--<label>.</label>--%>



                                <div class="row">


                                      <div id="Div3" runat="server">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                   A CONTINUACIÓN DETALLE LAS VENTAS DE LOS QQ ORO o SEMILLA CERTIFICADA DISPONIBLES Y DETALLAR CANTIDAD DE VENTAS                                      
                                        </div>

                                        
                                        <div class="panel-body">
                                          
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>QQ ORO DISPONIBLES</label>
                                                 <asp:TextBox CssClass="form-control" ID="Text_QQ_disponible_oro" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                          
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>SELECCIONAR CANTIDAD DE VENTAS</label>
                                               <asp:DropDownList CssClass="form-control" ID="drop_total_Ventas" runat="server" AutoPostBack="True">
                                                     <asp:ListItem>1</asp:ListItem>
                                                      <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>3</asp:ListItem>
                                                    
                                                     
                                                   
                                                        
                                                </asp:DropDownList> 
                                                </div>
                                            </div>
                                            

                                              


                                        </div>
                                        
                                    </div>
                                    </div>

















                                  
                                     <div id="venta1" runat="server">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                    1 VENTAS DE SEMILLA                                          
                                        </div>

                                        
                                        <div class="panel-body">
                                          
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Cuanto QQ de semilla Vendió</label>
                                                    <asp:TextBox CssClass="form-control" ID="text_cantidad_qq_semilla" runat="server" AutoPostBack="True" ReadOnly="false" TextMode="Number"></asp:TextBox>
                                            
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Precio de venta por libra</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_precio_semilla" TextMode="Number" runat="server" AutoPostBack="True"></asp:TextBox>
                                       

                                                </div>
                                            </div>
                                               <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Comprador</label>
                                                    <asp:Label ID="LB_comprador_1" runat="server" CssClass="alert-danger"></asp:Label> <asp:DropDownList CssClass="form-control" ID="Drop_comprador" runat="server" AutoPostBack="True">
                                                     <asp:ListItem>Seleccionar ↓</asp:ListItem>
                                                      <asp:ListItem>Agroservicio</asp:ListItem>
                                                    <asp:ListItem>Directamente al productor</asp:ListItem>
                                                         <asp:ListItem>SAG</asp:ListItem>
                                                       <asp:ListItem>DICTA</asp:ListItem>
                                                    <asp:ListItem>ONG / Proyectos</asp:ListItem>
                                                         <asp:ListItem>Organización de productores</asp:ListItem>
                                                       <asp:ListItem>Proyecto MAS</asp:ListItem>
                                                    <asp:ListItem>Red Pash</asp:ListItem>
                                                         <asp:ListItem>Otro</asp:ListItem>
                                                     
                                                   
                                                        
                                                </asp:DropDownList>            </div>
                                            </div>

                                              <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Detalle otro Comprador</label>
                                                    <asp:TextBox CssClass="form-control" ID="text_comprador_detalle" runat="server" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                                                </div>
                                            </div>


                                        </div>
                                        
                                    </div>
                                    </div>








 
                                     <div id="venta2" runat="server">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                    2 VENTAS DE SEMILLA                                          
                                        </div>

                                        
                                        <div class="panel-body">
                                          
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Cuanto QQ de semilla Vendió</label>
                                                    <asp:TextBox CssClass="form-control" TextMode="Number" ID="text_cantidad_qq_semilla2" runat="server" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                                            
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Precio de venta por libra</label>
                                                    <asp:TextBox CssClass="form-control" TextMode="Number" ID="Text_precio_semilla2" runat="server" AutoPostBack="True"></asp:TextBox>
                                       

                                                </div>
                                            </div>
                                               <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Seleccionar</label>
                                                    <asp:Label ID="LB_comprador_2" runat="server" CssClass="alert-danger"></asp:Label> 
                                                  <asp:DropDownList CssClass="form-control" ID="Drop_comprador2" runat="server" AutoPostBack="True">
                                                     <asp:ListItem>Seleccionar ↓</asp:ListItem>
                                                      <asp:ListItem>Agroservicio</asp:ListItem>
                                                    <asp:ListItem>Directamente al productor</asp:ListItem>
                                                         <asp:ListItem>SAG</asp:ListItem>
                                                       <asp:ListItem>DICTA</asp:ListItem>
                                                    <asp:ListItem>ONG / Proyectos</asp:ListItem>
                                                         <asp:ListItem>Organización de productores</asp:ListItem>
                                                       <asp:ListItem>Proyecto MAS</asp:ListItem>
                                                    <asp:ListItem>Red Pash</asp:ListItem>
                                                         <asp:ListItem>Otro</asp:ListItem>
                                                     
                                                   
                                                        
                                                </asp:DropDownList>            </div>
                                            </div>

                                              <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Detalle otro Comprador</label>
                                                    <asp:TextBox CssClass="form-control" ID="text_comprador_detalle2" runat="server" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                                                </div>
                                            </div>


                                        </div>
                                        
                                    </div>
                                    </div>

                                     
                                     <div id="venta3" runat="server">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                    3 VENTAS DE SEMILLA                                          
                                        </div>

                                        
                                        <div class="panel-body">
                                          
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Cuanto QQ de semilla Vendió</label>
                                                    <asp:TextBox CssClass="form-control" TextMode="Number" ID="text_cantidad_qq_semilla3" runat="server" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                                            
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Precio de venta por libra</label>
                                                    <asp:TextBox CssClass="form-control" TextMode="Number" ID="Text_precio_semilla3" runat="server" AutoPostBack="True"></asp:TextBox>
                                       

                                                </div>
                                            </div>
                                               <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Seleccionar</label>
                                                     <asp:Label ID="LB_comprador_3" runat="server" CssClass="alert-danger"></asp:Label> 
                                                  <asp:DropDownList CssClass="form-control" ID="Drop_comprador3" runat="server" AutoPostBack="True">
                                                     <asp:ListItem>Seleccionar ↓</asp:ListItem>
                                                      <asp:ListItem>Agroservicio</asp:ListItem>
                                                    <asp:ListItem>Directamente al productor</asp:ListItem>
                                                         <asp:ListItem>SAG</asp:ListItem>
                                                       <asp:ListItem>DICTA</asp:ListItem>
                                                    <asp:ListItem>ONG / Proyectos</asp:ListItem>
                                                         <asp:ListItem>Organización de productores</asp:ListItem>
                                                       <asp:ListItem>Proyecto MAS</asp:ListItem>
                                                    <asp:ListItem>Red Pash</asp:ListItem>
                                                         <asp:ListItem>Otro</asp:ListItem>
                                                     
                                                   
                                                        
                                                </asp:DropDownList>            </div>
                                            </div>

                                              <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Detalle otro Comprador</label>
                                                    <asp:TextBox CssClass="form-control" ID="text_comprador_detalle3" runat="server" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                                                </div>
                                            </div>


                                        </div>
                                        
                                    </div>
                                    </div>


















































                   

    


<div id="Div4" runat="server">

     <div class="panel panel-primary">
                                        <div class="panel-heading">
                                     DESTINO DEL GRANO PARA LA VENTA
                                        
                                        </div>

                                        
                                        <div class="panel-body">
                                             <div class="form-group">
                                                    <label>Vendio el Grano</label>
                                                  <asp:DropDownList CssClass="form-control" ID="Drop_venta_grano" runat="server" AutoPostBack="True" Width="200px">
                                                     <asp:ListItem>No</asp:ListItem>
                                                     <asp:ListItem>SI</asp:ListItem>
                                                       
                                                </asp:DropDownList>          
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Cuanto QQ de grano Vendió</label>
                                                    <asp:TextBox CssClass="form-control" TextMode="Number" ID="Text_qq_granos_vendio" runat="server" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                                  
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Precio de venta por libra</label>
                                                    <asp:TextBox CssClass="form-control" TextMode="Number" ID="Text_precio_grano_venta" runat="server" AutoPostBack="True"></asp:TextBox>
                               
                                                </div>
                                            </div>
                                               <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Seleccionar</label>
                                                      <asp:Label ID="LB_comprador_4" runat="server" CssClass="alert-danger"></asp:Label> 
                                                  <asp:DropDownList CssClass="form-control" ID="Drop_comprador_grano" runat="server" AutoPostBack="True">
                                                     <asp:ListItem>Seleccionar ↓</asp:ListItem>
                                                      <asp:ListItem>Agroservicio</asp:ListItem>
                                                    <asp:ListItem>Directamente al productor</asp:ListItem>
                                                         <asp:ListItem>SAG</asp:ListItem>
                                                       <asp:ListItem>DICTA</asp:ListItem>
                                                    <asp:ListItem>ONG / Proyectos</asp:ListItem>
                                                         <asp:ListItem>Organización de productores</asp:ListItem>
                                                       <asp:ListItem>Proyecto MAS</asp:ListItem>
                                                    <asp:ListItem>Red Pash</asp:ListItem>
                                                         <asp:ListItem>Otro</asp:ListItem>
                                                     
                                                   
                                                        
                                                </asp:DropDownList>            </div>
                                            </div>

                                              <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Detalle otro Comprador</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_detalle_Comprador_grano" runat="server" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                                                </div>
                                            </div>


                                        </div>
                                    </div>

      </div>





                                    


     <div class="panel panel-primary">
                                        <div class="panel-heading">
                                  SEMILLA PARA CONSUMO U OTROS DESTINOS
                                         
                                        </div>

                                        
                                        <div class="panel-body">
                                           <div class="form-group">
                                                    <label>consumo Semilla</label>
                                                  <asp:DropDownList CssClass="auto-style2" TextMode="Number" ID="Drop_consumo" runat="server" AutoPostBack="True" Width="200px" >
                                                     <asp:ListItem>No</asp:ListItem>
                                                     <asp:ListItem>SI</asp:ListItem>
                                                       
                                                </asp:DropDownList>          
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Cuanto QQ de Semilla Destinó</label>
                                                    <asp:TextBox CssClass="form-control" TextMode="Number" ID="Text_qq_consumo" runat="server" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                               
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Precio de venta por libra en mercado</label>
                                                   <asp:TextBox CssClass="form-control" ID="Text_precio_consumo" runat="server" AutoPostBack="True" ReadOnly="false"></asp:TextBox>

                                                </div>
                                            </div>
                                

                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label style="height: 20px; width: 201px">Detalle el uso</label>
                                                    <asp:TextBox CssClass="form-control"  ID="Text_uso_semilla" runat="server" AutoPostBack="True" ReadOnly="True" MaxLength="200"></asp:TextBox>
                               
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                     <div class="panel panel-success">
                                        <div class="panel-heading">
                                   Resumen Venta Semilla 
                                       
                                        </div>

                                     
                                             
                                        <div class="panel-body">

                                              <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Valor ventas</label>
                                                     <asp:TextBox CssClass="form-control" ID="Text_ingreso_venta_semilla" runat="server" AutoPostBack="True" ReadOnly="True" ></asp:TextBox>
                                   <asp:TextBox CssClass="form-control" ID="Text_Total_granos" runat="server" AutoPostBack="True" ReadOnly="TRUE" Visible="False"></asp:TextBox>
                               
                                                    <asp:TextBox CssClass="form-control" ID="Text_valor_venta" runat="server" AutoPostBack="True" ReadOnly="TRUE" Visible="False"></asp:TextBox>
                               
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                  <label>Valor consumo</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_valor_consumo" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                               
                                                </div>
                                            </div>




                                            
                        <div class="col-lg-3">
                                                <div class="form-group">
                                                  <label>Total Ingresos Semilla</label>
                                                    <asp:TextBox CssClass="form-control" ID="text_total_ingreso" runat="server" AutoPostBack="True" ReadOnly="TRUE"></asp:TextBox>
                               
                                                </div>
                                            </div>

                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                     <label>QQ semilla disponibles</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_qq_disponibles_semilla" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                               
                                                </div>
                                            </div>
                      
                                        </div>
                                    </div>

                                         






                                         <div class="panel panel-danger">
                                        <div class="panel-heading">
                                            DESTINO DEL GRANO PARA VENTA /MENUDA/GRANO PEQUEÑO COMO SEMILLA, USO HUMANO U OTROS USOS
                                          
                                        </div>

                                           <br/>
                 <p><strong>QUE DESTINO LE DIO AL GRANO QUE NO CUMPLI&Oacute; EL EST&Aacute;NDAR DE CALIDAD DE SEMILLA: (VENTA, CONSUMO FAMILIAR U OTROS.)</strong></p>

                                        <div class="panel-body">
                                           <div class="form-group">
                                            
                                               <label>QQ Disponible Menuda/ Grano Pequeño</label>
                                                    <asp:TextBox CssClass="form-control" TextMode="Number" ID="Text_menuda_disponible" ReadOnly="True" runat="server" Width="200px" AutoPostBack="True" ></asp:TextBox>  
                                                  <br/>
                                                    <label>Venta Grano</label>
                                                  <asp:DropDownList CssClass="auto-style2" TextMode="Number" ID="Drop_menuda" runat="server" AutoPostBack="True" Width="200px" >
                                                     <asp:ListItem>No</asp:ListItem>
                                                     <asp:ListItem>SI</asp:ListItem>
                                                       
                                                </asp:DropDownList> 
                                               
                                             
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label style="height: 20px; width: 201px">Cuanto QQ de grano Destinó</label>
                                                    <asp:TextBox CssClass="form-control" TextMode="Number" ID="Text_qq_menuda" runat="server" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                               
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Precio de venta por libra en mercado</label>
                                                   <asp:TextBox CssClass="form-control" ID="Text_precio_menuda" runat="server" AutoPostBack="True" ReadOnly="false" TextMode="Number"></asp:TextBox>

                                                </div>
                                            </div>
                                


                                        </div>
                                    </div>


        <div class="panel panel-danger">
                                        <div class="panel-heading">
                                    DESTINO DEL GRANO PARA CONSUMO /MENUDA/GRANO PEQUEÑO COMO SEMILLA, USO HUMANO U OTROS USOS
                                          
                                        </div>

                                           <br/>
<p><strong>QUE DESTINO LE DIO AL GRANO QUE NO CUMPLI&Oacute; EL EST&Aacute;NDAR DE CALIDAD DE SEMILLA: (CONSUMO FAMILIAR U OTROS.)</strong></p>                                        <div class="panel-body">
                                           <div class="form-group">
                                            
                                          
                                                    <label>Consumo u otro uso del grano</label>
                                                  <asp:DropDownList CssClass="auto-style2" TextMode="Number" ID="Drop_grano_otros" runat="server" AutoPostBack="True" Width="200px" >
                                                     <asp:ListItem>No</asp:ListItem>
                                                     <asp:ListItem>SI</asp:ListItem>
                                                       
                                                </asp:DropDownList> 
                                               
                                             
                               
                                            </div>
                                           
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label style="height: 20px; width: 201px">Cuanto QQ de grano Destinó</label>
                                                    <asp:TextBox CssClass="form-control" TextMode="Number" ID="Text_qq_granos_otros" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                               
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Precio de venta por libra en mercado</label>
                                                   <asp:TextBox CssClass="form-control" ID="Text_precio_granos_otros" TextMode="Number" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>

                                                </div>
                                            </div>
                                
      <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label style="height: 20px; width: 201px">Detalle el uso</label>
                                                    <asp:TextBox CssClass="form-control"  ID="Text_detalle_consumo" runat="server" AutoPostBack="True" ReadOnly="True" MaxLength="200"></asp:TextBox>
                               
                                                </div>
                                            </div>

                                        </div>
                                    </div>





     <div class="panel panel-success">
                                        <div class="panel-heading">
                                   Resumen Grano 
                                         
                                        </div>

                                        
                                        <div class="panel-body">
                                          
                                          


                                             <div class="col-lg-3">
                                                <div class="form-group">
                                                  <label>Valor venta Grano</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_Valor_menuda" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                               
                                                </div>
                                            </div>


                                       
                                                      <div class="col-lg-3">
                                                <div class="form-group">
                                                  <label>Valor Consumo Grano</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_valor_consumo_granos" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                               
                                                </div>
                                            </div>



                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                  <label>Ingreso Total Grano</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_menuda_semilla_total" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                               
                                                </div>
                                            </div>

                                             <div class="col-lg-3">
                                                <div class="form-group">
                                                  <label>QQ Granos disponible</label>
                                                   <asp:TextBox CssClass="form-control" ID="disponible_menuda"  runat="server"  AutoPostBack="True" Visible="true" ReadOnly="True" ></asp:TextBox>
                              
                                                </div>
                                            </div>

                                               

                                        </div>
                                    </div>



                                        <div  class="panel panel-info">
                                        <div class="panel-heading">
                                   Resumen Total
                                         
                                        </div>

                                        
                                        <div class="panel-body">
                                          
                                          


                                             <div class="col-lg-4">
                                                <div class="form-group">
                                                  <label>Ingreso Total Semilla</label>
                                                    <asp:TextBox CssClass="form-control" ID="Total_ingreso_semilla" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                               
                                                </div>
                                            </div>

                                             <div class="col-lg-4">
                                                <div class="form-group">
                                                  <label>Ingreso Total Grano</label>
                                                    <asp:TextBox CssClass="form-control" ID="Total_ingreso_grano" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                               
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                  <label>Ingreso Total</label>
                                                    <asp:TextBox CssClass="form-control" ID="Total_ingreso_general" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                           
                                                </div>
                                            </div>

                                               

                                        </div>
                                                <asp:Label ID="Lb_menuda" runat="server" CssClass="alert-danger"></asp:Label>
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
                            </div>
                        </div>
                        <div class="row">
                            <div class="auto-style3">
                                <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
                                
                                <button type="button" id="Guardar_registro"  class="btn btn-success" runat="server" data-toggle="modal" data-target="#exampleModal">
 Guardar </button>
                                
               
                            
                                <asp:Button ID="Cancelar" class="btn btn-danger" runat="server" Text="Regresar"   />

                                       

                                <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Detalle de venta de Semilla y granos</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
  ¿ Desea guardar el registro de ventas?
      </div>
      <div class="modal-footer">
 
          <asp:Button ID="SI" class="btn btn-success" runat="server" visible="false" Text="SI" />
     <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="SI"   />
                 <button type="button" class="btn btn-danger" data-dismiss="modal">NO</button>
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




        <div class="modal fade" id="NoProdModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <%-- <div class="row">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            Ingrese fecha del ingreso de la ficha:                       
                                        </div>
                                        <div class="panel-body">
                                         
                                            <div class="col-lg-3">
                                                <asp:TextBox ID="TxtFecha" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                        <h4 class="modal-title" id="ModalTitle5">Detalle Productor no registrado</h4>
                    </div>
                    <div class="modal-body">
                        <asp:TextBox ID="TxtNR" runat="server" Visible="False"></asp:TextBox>
                        <label for="TxtNombre">
                            Nombre Completo</label>
                        <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control" autocomplete="off" />
                        <br />
                        <label for="TxtIdentidad">
                            No. de Identidad</label>
                        <asp:TextBox ID="TxtIdentidad" runat="server" CssClass="form-control" onkeypress="return numericOnly2(this);" autocomplete="off" />
                        <br />
                        <label for="TxtSexo">
                            Sexo</label>
                        <asp:DropDownList CssClass="form-control" ID="TxtSexo" runat="server">
                            <asp:ListItem>Hombre</asp:ListItem>
                            <asp:ListItem>Mujer</asp:ListItem>
                        </asp:DropDownList>
                        <script type="text/javascript">
                            function numericOnly2(elementRef) {
                                var keyCodeEntered = (event.which) ? event.which : (window.event.keyCode) ? window.event.keyCode : -1;
                                if ((keyCodeEntered >= 48) && (keyCodeEntered <= 57)) {
                                    return true;
                                }
                                return false;
                            }
                        </script>
                        <div id="Div2" runat="server" visible="false" class="alert alert-danger">
                            <strong>Error!</strong>
                            <asp:Label ID="Label4" runat="server" />
                        </div>
                    </div>
                    <div class="modal-footer" style="text-align: center">
                        <asp:Button ID="Button3" Text="Guardar" Width="80px" runat="server" Class="btn btn-primary" />
                        <asp:Button ID="Button4" Text="Salir" Width="80px" runat="server" Class="btn btn-primary" />
                    </div>

                </div>
            </div>
        </div>




        <div class="modal fade" id="DeleteModal3" tabindex="-1" role="dialog" aria-labelledby="ModalTitle3"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="ModalTitl5">MAS 2.0 - TNS</h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="modal-footer" style="text-align: center">
                        <asp:Button ID="Button5" Text="Aceptar" Width="80px" runat="server" Class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>


      </ContentTemplate>
            </asp:UpdatePanel>

</asp:Content>
