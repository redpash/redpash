<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="msuinscripsenasaprocos.aspx.vb" Inherits="MAS_PMSU.msuinscripsenasaprocos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <div class="panel panel-primary">
                <div class="panel-heading">
                    DETALLE DE PRODUCCION Y COSTOS
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
                                            <asp:TextBox ID="txt_tipo_costo" runat="server" Visible="false"></asp:TextBox>
                            <div class="col-lg-4">
                            <div class="form-group">
                                <label>Seleccione Productor:</label>
                                <asp:DropDownList CssClass="form-control" ID="Txtproductor" runat="server" AutoPostBack="True"></asp:DropDownList>

                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="table-responsive">
                                <h3>
                                    <span style="float: right;"><small>#Lotes:</small>
                                        <asp:Label ID="lblTotalClientes" runat="server" CssClass="label label-warning" /></span>
                                </h3>
                                <p>&nbsp;</p>
                                <p>&nbsp;</p>
                                <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MConnODK4 %>" ProviderName="<%$ ConnectionStrings:MConnODK4.ProviderName %>"></asp:SqlDataSource>
                                <asp:GridView ID="GridDatos" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                    GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource1" Font-Size="Small" HorizontalAlign="Center">
                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
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
                                             <asp:BoundField DataField="Tipo_costo">
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
                                         <asp:BoundField DataField="COSTO_TOTAL" HeaderText="COSTO TOTAL" DataFormatString="{0:0.00}" />

                                          <asp:BoundField DataField="VARIEDAD" HeaderText="VARIEDAD" />  
                                         <asp:BoundField DataField="Habilitado" HeaderText="HABILITADO" />

                                     

                                          


 
                                        <asp:ButtonField ButtonType="Button" Text="+" ControlStyle-CssClass="btn btn-warning" HeaderText="PRODUCCION" CommandName="Produccion">




                                            <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                        </asp:ButtonField>

                                            <asp:TemplateField HeaderText="Seleccionar check si se ingresa costos total">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkview" runat="server"    AutoPostBack="true" OnCheckedChanged="chkview_CheckedChanged"   />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                        <asp:ButtonField ButtonType="Button" Text="+" ControlStyle-CssClass="btn btn-danger" HeaderText="COSTOS" CommandName="Costos">
                                            <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                                        </asp:ButtonField>


                                      


                                    </Columns>
                                    <EditRowStyle BackColor="#7C6F57" />
                                    <RowStyle BackColor="#E3EAEB" HorizontalAlign="Center" />
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
                    <div class="row">
                        <div class="col-lg-12">
                            <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
                            <asp:Button ID="BAgregar" Visible="false" runat="server" Text="Agregar" CssClass="btn btn-success" />

                        </div>
                    </div>

                    <div class="modal fade" id="DeleteModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
                        aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <%--  <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                    &times;</button>--%>
                                    <h4 class="modal-title" id="ModalTitle3">MAS 2.0 - DICTA - MSU</h4>
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


                            
                       <div class="modal fade" id="DeleteModal2" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="ModalTitle33">MAS 2.0 - TNS</h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="modal-footer" style="text-align: center">
                        <asp:Button ID="BConfirm2" Text="Aceptar" Width="80px" runat="server" Class="btn btn-primary" />
                     
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
                                    <h4 class="modal-title" id="ModalTitle1">Detalle de Produccion</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:TextBox ID="TxtID" runat="server" Visible="False"></asp:TextBox>
                                       <asp:TextBox ID="txt_habilitado" runat="server" Visible="False"></asp:TextBox>
                    
                                    <%--<asp:CheckBox ID="CheckBox1" runat="server" Visible="False" />--%>
                                    <div class="row">
                                        <div class="col-lg-6">
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
                                    <h4 class="modal-title" id="ModalTitle2">Detalle de Costos</h4>
                                </div>
                                <div class="modal-body">                             
                                    <%--<asp:CheckBox ID="CheckBox1" runat="server" Visible="False" />--%>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Nombre del Productor</label>
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
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Area sembrada</label>
                                                <asp:TextBox ID="TxtareaSemb2" runat="server" Enabled="false" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Produccion de campo (QQ)</label>
                                                <asp:TextBox ID="TxtProduccion2" runat="server" Enabled="false" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                            </div>
                                        </div>
                                    </div>

                                     <div runat="server" id="div_costo_det">
                                    
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


</div>
                                      <div  runat="server" id="div_costo_total">


                                        <label> Ingresar el costo total</label>
                                    <asp:TextBox ID="txt_total" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
</div>


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


    </div>























































</asp:Content>
