<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="precioscafe18_19.aspx.vb" Inherits="MAS_PMSU.precioscafe18_19" EnableEventValidation="false" %>


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
                    REGISTRO DE PRECIOS CAFE COSECHA 2018-2019
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
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label>Seleccione Departamento:</label>
                                            <asp:DropDownList CssClass="form-control" ID="TxtDepto" runat="server" AutoPostBack="True"></asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label>Seleccione Municipio:</label>
                                            <asp:DropDownList CssClass="form-control" ID="TxtMuni" runat="server" AutoPostBack="True"></asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                                <!-- /.row (nested) -->

                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="table-responsive">
                                            <h3>
                                                <span style="float: right;"><small># de registros:</small>
                                                    <asp:Label ID="lblTotalClientes" runat="server" CssClass="label label-warning" /></span>
                                            </h3>
                                            <p>&nbsp;</p>
                                            <p>&nbsp;</p>
                                            <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TConnODK3 %>" ProviderName="<%$ ConnectionStrings:TConnODK3.ProviderName %>"></asp:SqlDataSource>
                                            <asp:GridView ID="GridDatos" runat="server" CellPadding="4" ForeColor="#333333" Width="100%" DataKeyNames="id"
                                                GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource1" Font-Size="Small">
                                                <HeaderStyle BackColor="#8A4500" Font-Bold="True" ForeColor="White" />
                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                <EmptyDataTemplate>
                                                    ¡No hay precios registrados!  
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
                                                    <asp:BoundField DataField="Fecha" HeaderText="FECHA" DataFormatString="{0:d}" />
                                                    
                                                    <asp:BoundField DataField="Depto_Descripcion" HeaderText="DEPARTAMENTO" />
                                                    
                                                    <asp:BoundField DataField="Muni_Descripcion" HeaderText="MUNICIPIO" />
                                                    <asp:BoundField DataField="Asesor" HeaderText="ASESOR" />
                                                    <asp:BoundField DataField="Exportador" HeaderText="EXPORTADOR" />
                                                    <asp:BoundField DataField="PrecioPHH" HeaderText="Precio pergamino humedo" />
                                                    <asp:BoundField DataField="PrecioPH" HeaderText="Precio pergamino humedo convertido a seco" />
                                                    <asp:BoundField DataField="PrecioPS" HeaderText="Precio pregamino seco" />
                                                    <asp:BoundField DataField="PrecioOro" HeaderText="Precio pergamino humedo convertido a oro" />
                                                </Columns>
                                                <EditRowStyle BackColor="#7C6F57" />
                                            </asp:GridView>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
                                        <asp:Button ID="BAgregar" runat="server" class="btn btn-success" Text="Agregar precio exportador" />
                                        <asp:Button ID="BAgregar2" runat="server" class="btn btn-success" Text="Agregar precio plaza" />
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
                                                <h4 class="modal-title" id="ModalTitle">Datos del precio Exportador</h4>
                                            </div>
                                            <div class="modal-body">
                                                <asp:TextBox ID="TxtID" runat="server" Visible="False"></asp:TextBox>
                                                <asp:CheckBox ID="ChNuevo" runat="server" Visible="False" />
                                                <label for="TxtFecha">Fecha</label>
                                                <br />
                                                <label for="TxtDia">
                                                    Dia</label>
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
                                                <label for="TxtMes">
                                                    Mes</label>
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
                                                <label for="TxtAno2">
                                                    Año</label>
                                                <asp:DropDownList CssClass="form-control" ID="TxtAno2" runat="server">
                                                    <asp:ListItem>2018</asp:ListItem>
                                                    <asp:ListItem>2019</asp:ListItem>
                                                    <asp:ListItem>2020</asp:ListItem>
                                                    <asp:ListItem>2021</asp:ListItem>
                                                    <asp:ListItem>2022</asp:ListItem>
                                                    <asp:ListItem>2023</asp:ListItem>
                                                    <asp:ListItem>2024</asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <label for="TxtAsesor">
                                                    Asesor</label>
                                                <asp:DropDownList CssClass="form-control" ID="TxtAsesor" runat="server">
                                                    <asp:ListItem>Noelia Bonilla</asp:ListItem>
                                                    <asp:ListItem>Digna Banegas</asp:ListItem>
                                                    <asp:ListItem>Celso Reyes</asp:ListItem>
                                                    <asp:ListItem>Francis Suazo</asp:ListItem>
                                                    <asp:ListItem>Daniel Euceda</asp:ListItem>
                                                    <asp:ListItem>Alejandro Rodriguez</asp:ListItem>
                                                    <asp:ListItem>Marlon Fonseca</asp:ListItem>
                                                    <asp:ListItem>Marden Rodriguez</asp:ListItem>
                                                    <asp:ListItem>Julio Guerrero</asp:ListItem>
                                                    <asp:ListItem>Isaias Baquedano</asp:ListItem>
                                                    <asp:ListItem>Salvador Avila</asp:ListItem>
                                                </asp:DropDownList>
                                                <%--<asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <label for="TxtDepto2">
                                                            Departamento</label>
                                                        <asp:DropDownList CssClass="form-control" ID="TxtDepto2" runat="server" AutoPostBack="True" ClientIDMode="Predictable" OnSelectedIndexChanged="cambioindexdepto"></asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <br />
                                                <label for="TxtMuni2">
                                                    Municipio</label>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server"
                                                    UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:DropDownList CssClass="form-control" ID="TxtMuni2" runat="server"></asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="TxtDepto2" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>--%>
                                                <br />
                                                <label for="TxtExp">
                                                    Exportador</label>
                                                <asp:DropDownList CssClass="form-control" ID="TxtExp" runat="server">
                                                    <asp:ListItem>MDH</asp:ListItem>
                                                    <asp:ListItem>BSR</asp:ListItem>
                                                    <asp:ListItem>COCAOL</asp:ListItem>
                                                    <asp:ListItem>OLAM</asp:ListItem>
                                                    <asp:ListItem>COMSA</asp:ListItem>
                                                    <asp:ListItem>CoHonducafe</asp:ListItem>
                                                    <asp:ListItem>Louis_Dreyfus</asp:ListItem>
                                                    <asp:ListItem>CAFEX</asp:ListItem>
                                                    <asp:ListItem>BECAMO</asp:ListItem>
                                                    <asp:ListItem>CAFEUNO_El_Paraiso</asp:ListItem>
                                                    <asp:ListItem>CIGRAH</asp:ListItem>
                                                    <asp:ListItem>COHORSIL</asp:ListItem>
                                                    <asp:ListItem>Coffee_Planet</asp:ListItem>
                                                    <asp:ListItem>Otro</asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <label for="TxtPHH">
                                                    Precio venta QQ cafe humedo</label>
                                                <asp:TextBox ID="TxtPHH" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                <br />
                                                <label for="TxtPH">
                                                    Precio venta QQ cafe humedo peso seco</label>
                                                <asp:TextBox ID="TxtPH" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                <br />
                                                <label for="TxtPS">
                                                    Precio venta QQ cafe seco</label>
                                                <asp:TextBox ID="TxtPS" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                 <label for="TxtOro">
                                                    Precio venta QQ cafe humedo peso en Oro</label>
                                                <asp:TextBox ID="TxtOro" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
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
                                <div class="modal fade" id="EditModal2" tabindex="-1" role="dialog" aria-labelledby="ModalTitle"
                                    aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                    &times;</button>
                                                <h4 class="modal-title" id="ModalTitle3">Datos del precio Plaza</h4>
                                            </div>
                                            <div class="modal-body">
                                                <asp:TextBox ID="TxtID2" runat="server" Visible="False"></asp:TextBox>
                                                <asp:CheckBox ID="ChNuevo2" runat="server" Visible="False" />
                                                <label for="TxtFecha">Fecha</label>
                                                <br />
                                                <label for="TxtDia">
                                                    Dia</label>
                                                <asp:DropDownList CssClass="form-control" ID="TxtDia2" runat="server">
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
                                                <label for="TxtMes">
                                                    Mes</label>
                                                <asp:DropDownList CssClass="form-control" ID="TxtMes2" runat="server">
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
                                                <label for="TxtAno2">
                                                    Año</label>
                                                <asp:DropDownList CssClass="form-control" ID="TxtAno3" runat="server">
                                                    <asp:ListItem>2018</asp:ListItem>
                                                    <asp:ListItem>2019</asp:ListItem>
                                                    <asp:ListItem>2020</asp:ListItem>
                                                    <asp:ListItem>2021</asp:ListItem>
                                                    <asp:ListItem>2022</asp:ListItem>
                                                    <asp:ListItem>2023</asp:ListItem>
                                                    <asp:ListItem>2024</asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <label for="TxtAsesor2">
                                                    Asesores</label>
                                                  <asp:DropDownList CssClass="form-control" ID="TxtAsesor2" runat="server">
                                                    <asp:ListItem>Noelia Bonilla</asp:ListItem>
                                                    <asp:ListItem>Digna Banegas</asp:ListItem>
                                                    <asp:ListItem>Celso Reyes</asp:ListItem>
                                                    <asp:ListItem>Francis Suazo</asp:ListItem>
                                                    <asp:ListItem>Daniel Euceda</asp:ListItem>
                                                    <asp:ListItem>Alejandro Rodriguez</asp:ListItem>
                                                    <asp:ListItem>Marlon Fonseca</asp:ListItem>
                                                    <asp:ListItem>Marden Rodriguez</asp:ListItem>
                                                    <asp:ListItem>Julio Guerrero</asp:ListItem>
                                                    <asp:ListItem>Isaias Baquedano</asp:ListItem>
                                                    <asp:ListItem>Salvador Avila</asp:ListItem>
                                                </asp:DropDownList>
                                                <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <label for="TxtDepto2">
                                                            Departamento</label>
                                                        <asp:DropDownList CssClass="form-control" ID="TxtDepto3" runat="server" AutoPostBack="True" ClientIDMode="Predictable" OnSelectedIndexChanged="cambioindexdepto2"></asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <br />
                                                <label for="TxtMuni2">
                                                    Municipio</label>
                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server"
                                                    UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:DropDownList CssClass="form-control" ID="TxtMuni3" runat="server"></asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="TxtDepto3" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>--%>
                                                <br />
                                                <label for="TxtPHH2">
                                                    Precio venta QQ cafe humedo</label>
                                                <asp:TextBox ID="TxtPHH2" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                <br />
                                                <label for="TxtPH2">
                                                    Precio venta QQ cafe humedo peso seco</label>
                                                <asp:TextBox ID="TxtPH2" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                <br />
                                                <label for="TxtPS2">
                                                    Precio venta QQ cafe seco</label>
                                                <asp:TextBox ID="TxtPS2" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                <label for="TxtOro2">
                                                    Precio venta QQ cafe humedo peso en Oro</label>
                                                <asp:TextBox ID="TxtOro2" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
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
                                <div class="modal fade" id="DeleteModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
                                    aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <%--  <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                    &times;</button>--%>
                                                <h4 class="modal-title" id="ModalTitle2">MAS 2.0 - TNS</h4>
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
