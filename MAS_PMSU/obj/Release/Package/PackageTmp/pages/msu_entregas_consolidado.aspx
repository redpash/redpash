<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="msu_entregas_consolidado.aspx.vb" Inherits="MAS_PMSU.msu_entregas_consolidado" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
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
      <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
       <div id="divdatos" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                   MÓDULO DE ENTREGAS
                    <asp:Label ID="Lb_user" Visible="false" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-4">
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
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Seleccione Departamento:</label>
                                <asp:DropDownList CssClass="form-control" ID="TxtDepto" runat="server" AutoPostBack="True"></asp:DropDownList>

                            </div>
                        </div>

                         <div class="col-lg-4">
                            <div class="form-group">
                                <label>Seleccione productor:</label>
                                <asp:DropDownList CssClass="form-control" ID="Txtproductor" runat="server" AutoPostBack="True"></asp:DropDownList>

                            </div>
                        </div>


                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="table-responsive">
                                <h3>
                                    <span style="float: right;"><small># Lotes:</small>
                                        <asp:Label ID="lblTotalClientes" runat="server" CssClass="label label-warning" BackColor="#717073" /></span>
                                      
                                         <%--  <span style="float: center;"><small>Nota QQ semilla:</small>
                                        <abbr  title="La columna QQ semilla, es la semilla clasificada ">?</abbr></span>
                                    <br />
                                     <br />
                                      <span style="float: left;"><small>Nota QQ consumo:</small>
                                        <abbr  title="La columna QQ consumo, es la semilla no clasificada ">?</abbr></span>--%>
                                </h3>
                                <p>&nbsp;</p>
                                <p>&nbsp;</p>
                                <%--<label>.</label>--%>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MConnODK4 %>" ProviderName="<%$ ConnectionStrings:MConnODK4.ProviderName %>"></asp:SqlDataSource>
                                <asp:GridView ID="GridDatos" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                    GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource1" Font-Size="Small">
                                    <FooterStyle BackColor="#00B1B0" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#00B1B0" Font-Bold="True" ForeColor="White" />
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

                                        <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                                        <asp:BoundField DataField="Productor" HeaderText="Productor" />
                                        <asp:BoundField DataField="CICLO" HeaderText="Ciclo" />
                                        <asp:BoundField DataField="VARIEDAD" HeaderText="Variedad" />   
                                    
                                        <asp:BoundField DataField="AREA_SEMBRADA" HeaderText="Area sembrada" DataFormatString="{0:0.00}" />
                                        <asp:BoundField DataField="FECHA_SIEMBRA" HeaderText="Fecha siembra" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="QQ_PRODUCCION" HeaderText="QQ Produccion" DataFormatString="{0:0.00}" />
                                         <asp:BoundField DataField="QQ_ORO" HeaderText="QQ semilla" DataFormatString="{0:0.00}" HeaderStyle-BackColor="#717073" />
                                        <asp:BoundField DataField="QQ_CONSUMO" HeaderText="QQ Consumo" DataFormatString="{0:0.00}" HeaderStyle-BackColor="#1E2172" />
                                         <asp:BoundField DataField="QQ_ORO_entregado" HeaderText="QQ semilla entregado" DataFormatString="{0:0.00}"  HeaderStyle-BackColor="#717073" />
                                        <asp:BoundField DataField="QQ_CONSUMO_entregado" HeaderText="QQ Consumo entregado" DataFormatString="{0:0.00}" HeaderStyle-BackColor="#1E2172" />
                                    <asp:BoundField DataField="habilitado" HeaderText="Habilitado"  /> 
                                         <asp:ButtonField ButtonType="Button" Text="Ventas" ControlStyle-CssClass="btn btn-danger" HeaderText="Registro ventas" CommandName="Ventas">
                                            <ControlStyle CssClass="btn btn-success"></ControlStyle>
                                        </asp:ButtonField>


<%--                                         <asp:ButtonField ButtonType="Button" Text="Editar" ControlStyle-CssClass="btn btn-warning" HeaderText="EDITAR" CommandName="Editar">
                                            <ControlStyle CssClass="btn btn-warning"></ControlStyle>
                                        </asp:ButtonField>--%>



                                          <asp:ButtonField ButtonType="Button" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar ventas" CommandName="eliminar">
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



                                   <div class="modal fade" id="DeleteModal2" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="ModalTitle3234">MAS 2.0 - TNS</h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="modal-footer" style="text-align: center">
                        <asp:Button ID="BConfirm2" Text="Aceptar" Width="80px" runat="server" Class="btn btn-primary" />
                     
                    </div>
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



                  <div class="modal fade" id="DeleteModalVENTA" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
                        aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <%--<label>.</label>--%>
                                    <h4 class="modal-title" id="ModalTitle33">MAS 2.0 - DICTA - MSU</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="modal-footer" style="text-align: center">
                                    
                                    <asp:Button ID="btn_eliminar_venta" Text="SI" Width="80px" runat="server" Class="btn btn-success" />
                                    <asp:Button ID="Button6" Text="NO" Width="80px" runat="server" Class="btn btn-danger" />
                                    <%--<label>.</label>--%>
                                </div>

                            </div>
                        </div>
                    </div>


                

                  <div class="modal fade" id="editModalVENTA" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
                        aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <%--<label>.</label>--%>
                                    <h4 class="modal-title" id="ModalTitle333">MAS 2.0 - DICTA - MSU</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:Label ID="Label7" runat="server"  style="text-align: center" Text="Label"></asp:Label>
                                </div>
                                <div class="modal-footer" style="text-align: center">
                                    
                                  
                                    <asp:Button ID="Button2" Text="Aceptar" Width="80px" runat="server" Class="btn btn-success" />
                                    <%--        <label>QQ ORO pendiente</label>--%>
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
                                    <%--      <label>QQ consumo pendiente</label>--%>
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
                                    <%--                                                     <label>QQ consumo pendiente</label>--%>
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
                                                <label>Ciclos</label>
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




                        <div id="divedit" runat="server">



      <asp:UpdatePanel ID="UpdatePanel2"
                             runat="server">
                <ContentTemplate>
                       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  





        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header"></h1>
            </div>
        </div>


        <div class="row">
            <div class="col-lg-12">



                <div class="panel panel-default">
                    <div class="panel-heading">
                     <asp:Label ID="laBEL_MESANSAJE" runat="server" Text=""></asp:Label>DETALLE DE VENTAS

      
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="auto-style3">
                                <div class="row">
                                 
                           <div class="panel panel-primary">
                                        <div class="panel-heading">
                               Identificacion 
                                            
                                        </div>

                                        
                                        <div class="panel-body">
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                         
                                   
                                                      <label>Departamento</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_departamento" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                         <br/>
                                                      <label>Codigo BCS</label>
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
                                                                          <br/>
                                       
                                
                                                      </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                <label>QQ semilla (certificada / comercial)</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_QQ_Produccion_ORO" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                      <br/>
                                                     <label>QQ semilla entregado </label>
                                                    <asp:TextBox CssClass="form-control" ID="TXT_QQ_ORO_ENTRE" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>

                                                       <br/>
                                                     <label>QQ semilla por detallar </label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_semilla_por_detallar" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                            </div>

                                                 <div class="col-lg-4">
                                                <div class="form-group">
                            <label>QQ consumo (granos, uso humano u otros usos)</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_QQ_Produccion_consumo" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                      <br/>
                                                     <label>QQ consumo  entregado</label>
                                                    <asp:TextBox CssClass="form-control" ID="TXT_QQ_CONSUMO_ENTRE" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                
                                                       <br/>
                                                     <label>QQ consumo por detallar </label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_consumo_por_detallar" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                            </div>


                                                <div class="col-lg-2">
                                                <div class="form-group">
                      <label> QQ basura</label>
                                                    <asp:TextBox CssClass="form-control" ID="Text_QQ_Produccion_basura" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                   
                                                    </div>
                                            </div>


                                        </div>
       
                                    </div>
                                </div>
                            </div>
                        </div>









                                         <div class="panel panel-primary" >
                                        <div class="panel-heading">
                                 Detalle semilla (Certificada /Comercial)
                                            
                                        </div>

                                        
                                        <div class="panel-body">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                 
                                                                                  <div class="panel panel-Info" >
                                        <div class="panel-heading">
                                                     <h4 style="text-align: center;">Venta</h4> 
                                        </div>
         </div>
                                                      <label>QQ semilla (Certificada /Comercial)</label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_qq" runat="server" TextMode="number" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                                          <br/>

                                                    <label>Precio venta QQ semilla</label><asp:Label ID="lb_precio_semilla_venta"  runat="server" CssClass="btn-warning"></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_precio" runat="server" TextMode="number" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                                               
                                                       <br/>
                                                                 <label>Comprador</label> <asp:Label ID="Lb_comprador_semilla"  runat="server" CssClass="btn-warning"></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="Dp_comprador" runat="server" AutoPostBack="True"></asp:DropDownList>  
                                                        <br/>
                                                     <label>Detalle Comprador</label> <asp:Label ID="Lb_comprador_semilla_detalle"  runat="server" CssClass="btn-warning"></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_detalle_comprador" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>


                                                    <br/>
                                                   <label>Ingreso total venta semilla</label>
                                                    <asp:TextBox CssClass="form-control" ID="txt_total_venta" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                         <br/>
                                             
                                                    <asp:Label ID="LB_VALIDACION_QQ_sEMILLA" runat="server" CssClass="btn-warning"></asp:Label>
                                                 <br/>
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
                                                  

                                                      <br/>
                                                     <label>Precio venta QQ consumo semilla</label><asp:Label ID="lb_precio_consumo_semilla"  runat="server" CssClass="btn-warning"></asp:Label>
                                                     <asp:TextBox CssClass="form-control" ID="txt_precio_consumo" runat="server" TextMode="number" AutoPostBack="True" ReadOnly="false"></asp:TextBox>


                                                      <br/>
                                                       <label>Ingreso total consumo semilla</label>
                                                     <asp:TextBox CssClass="form-control" ID="txt_ingreso_consumo" runat="server"  AutoPostBack="True" ReadOnly="true"></asp:TextBox>



                                                       <br/>
                                                        <%--      <label>QQ consumo pendiente</label>--%>
                                                     <asp:TextBox CssClass="form-control" Visible="false" ID="qq_consumo_pend" runat="server"  AutoPostBack="True" ReadOnly="true"></asp:TextBox>
                                                
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
                                          <br/>

                                                    <label>Precio venta QQ (granos, uso humano u otros usos) </label> <asp:Label ID="lb_precio_grano_venta"  runat="server" CssClass="btn-warning"></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="TXT_PRECIO_GRANO" runat="server" TextMode="number" AutoPostBack="True" ReadOnly="false"></asp:TextBox>
                                               
                                                       <br/>
                                                                 <label>Comprador</label> <asp:Label ID="lb_comprador_grano"  runat="server" CssClass="btn-warning"></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="dp_comprador_grano" runat="server" AutoPostBack="True"></asp:DropDownList>  
                                                        <br/>
                                                     <label>Detalle Comprador</label> <asp:Label ID="lb_comprador_detalle_grano"  runat="server" CssClass="btn-warning"></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="TXT_COMPRADOR_GRANO" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>


                                                    <br/>
                                                   <label>Ingreso total</label>
                                                    <asp:TextBox CssClass="form-control" ID="TXT_INGRESO_TOTAL_VENGRANO" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                        <br/>
                                             
                                                    <asp:Label ID="lb_validacion_consumo" runat="server" CssClass="btn-warning"></asp:Label>

                                                 <br/>
<%--                                                     <label>QQ consumo pendiente</label>--%>
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
                                                  

                                                      <br/>
                                                     <label>Precio QQ grano consumo</label><asp:Label ID="LB_grano_consumo"  runat="server" CssClass="btn-warning"></asp:Label>
                                                     <asp:TextBox CssClass="form-control" ID="TXT_PRECIO_GRANO_CONSUMO" runat="server" TextMode="number" AutoPostBack="True" ReadOnly="false"></asp:TextBox>


                                                      <br/>
                                                       <label>Ingreso total</label>
                                                     <asp:TextBox CssClass="form-control" ID="TXT_INGRESO_TOTAL_CONSGRANO" runat="server"  AutoPostBack="True" ReadOnly="true"></asp:TextBox>



                                                       <br/>
                                                           <%--   <label>QQ consumo pendiente</label>--%>
                                                     <asp:TextBox CssClass="form-control" Visible="false" ID="TextBox13" runat="server"  AutoPostBack="True" ReadOnly="true"></asp:TextBox>

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
                        </div>
                        <div class="row">
                            <div class="auto-style3">
                                <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
                                
       <div id="div_guardar" runat="server">
        <%--       <asp:Button ID="Guardar_registro"  class="btn btn-success" runat="server" Text="Guardar"  data-toggle="modal" data-target="#exampleModal2" />--%>
                  <button type="button" id="Guardar_registro" runat="server" class="btn btn-success" data-toggle="modal" data-target="#exampleModal2">
 Guardar
</button>

                                         <asp:Button ID="Cancelar" class="btn btn-danger" runat="server" Text="Regresar"   />
    

              </div>



   




<div class="modal fade" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabela">MAS 2.0 - TNS</h5>
    
      </div>
      <div class="modal-body">
¿Está seguro que sea ingresar el registro de venta?
      </div>
      <div class="modal-footer">
       <asp:Button ID="btn_si" Text="SI" Width="80px" runat="server" Class="btn btn-primary" />
        <button type="button" class="btn btn-danger" Width="80px" data-dismiss="modal">NO</button>
      </div>
    </div>
  </div>
</div>







                                

                                <div id="dived" runat="server">
                                    
    

                                     <button type="button" class="btn btn-warning" data-toggle="modal" data-target="#exampleModal">
  Editar
</button>
  <asp:Button ID="Cancelar_edit" class="btn btn-danger" runat="server" Text="Salir"   />
                                            </div>

                                
                                <br/>
                                <br/>

                                <asp:Label ID="lb_error" class="badge badge-pill badge-success"  runat="server" Text=""></asp:Label>

                              
  

<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">MAS 2.0 - TNS</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
     ¿Está seguro que desea actualizar el registro de venta?
      </div>
      <div class="modal-footer">
              <asp:Button ID="SI_editar"  class="btn btn-success" runat="server" Text="SI" />
                                  
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

                          </ContentTemplate>
            </asp:UpdatePanel>
        </div>



                   <%-- aqui ventas div--%>




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




</asp:Content>
