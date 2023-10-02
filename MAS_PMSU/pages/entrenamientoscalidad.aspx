<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="entrenamientoscalidad.aspx.vb" Inherits="MAS_PMSU.registro_organizaciones" %>

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
                    CAPACITACIONES EN CALIDAD A ORGANIZACIONES
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
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Seleccione Departamento:</label>
                                            <asp:DropDownList CssClass="form-control" ID="TxtDepto" runat="server" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Seleccione Entrenador:</label>
                                            <asp:DropDownList CssClass="form-control" ID="TxtEntrenador" runat="server" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Seleccione Organización:</label>
                                            <asp:DropDownList CssClass="form-control" ID="cmborganizacion" runat="server" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Seleccione Modulo:</label>
                                            <asp:DropDownList CssClass="form-control" ID="TxtTema" runat="server" AutoPostBack="True"></asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                                <!-- /.row (nested) -->
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="table-responsive">
                                            <h3>
                                                <span style="float: right;"><small>Total de capacitados:</small>
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
                                                    ¡No hay capacitados registrados!  
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
                                                    <asp:ButtonField ButtonType="Button" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" CommandName="Eliminar">
                                                        <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                                                    </asp:ButtonField>
                                                    <asp:BoundField DataField="id">
                                                        <HeaderStyle CssClass="hide" />
                                                        <ItemStyle CssClass="hide" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="id2">
                                                        <HeaderStyle CssClass="hide" />
                                                        <ItemStyle CssClass="hide" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Depto_Descripcion" HeaderText="DEPARTAMENTO" />
                                                    <asp:BoundField DataField="ec_nombre" HeaderText="ENTRENADOR" />
                                                    <asp:BoundField DataField="mod_nombre" HeaderText="MODULO" />
                                                    <asp:BoundField DataField="fecha" HeaderText="FECHA" DataFormatString="{0:d}" />
                                                    <asp:BoundField DataField="OP_NOMBRE" HeaderText="OP_NOMBRE" />
                                                    <asp:BoundField DataField="COD_PRODUCTOR" HeaderText="COD_PRODUCTOR" />
                                                    <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                                                    <asp:BoundField DataField="SEXO" HeaderText="SEXO" />
                                                </Columns>
                                                <EditRowStyle BackColor="#7C6F57" />
                                            </asp:GridView>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
                                        <asp:Button ID="BAgregar" runat="server" class="btn btn-success" Text="Agregar productores socios entrenados" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <%--<script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>--%>
                                        <asp:Button ID="BAgregar2" runat="server" class="btn btn-success" Text="Agregar productores no socios entrenados" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning" Text="Exportar Datos"><span class="glyphicon glyphicon-save"></span>&nbsp;Exportar Datos</asp:LinkButton>
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
                                <div class="modal fade" id="ProdModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
                                    aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <%--  <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                    &times;</button>--%>
                                                <h4 class="modal-title" id="ModalTitle3">Listado Productores</h4>
                                            </div>
                                            <div class="modal-body">
                                                <asp:TextBox ID="TxtID" runat="server" Visible="False"></asp:TextBox>
                                                <asp:TextBox ID="TxtID2" runat="server" Visible="False"></asp:TextBox>
                                                <asp:TextBox ID="TxtTip" runat="server" Visible="False"></asp:TextBox>
                                                <label for="TxtFecha">Fecha de Capacitacion</label>
                                                <%--<asp:TextBox ID="TxtFecha" CssClass="form-control" runat="server" placeholder="Dia/Mes/Año"></asp:TextBox>--%>
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
                                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TConnODK %>" ProviderName="<%$ ConnectionStrings:TConnODK.ProviderName %>"></asp:SqlDataSource>
                                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GridDatos2" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                                            GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource2" Font-Size="Small" OnPageIndexChanging="GridDatos2_PageIndexChanging" PageSize="100" PageIndex="0">
                                                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                            <EmptyDataTemplate>
                                                                ¡No hay prodcutores registrados!  
                                                            </EmptyDataTemplate>
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkSeleccionar" runat="server" AutoPostBack="true" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="COD_PRODUCTOR" HeaderText="COD_PRODUCTOR" />
                                                                <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                                                                <asp:BoundField DataField="SEXO" HeaderText="SEXO" />
                                                                <asp:BoundField DataField="EDAD" HeaderText="EDAD" />
                                                            </Columns>
                                                            <EditRowStyle BackColor="#7C6F57" />
                                                            <RowStyle BackColor="#E3EAEB" />
                                                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                                                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                                                        </asp:GridView>
                                                        <%--<asp:Button ID="Button1" runat="server" OnClick="btClick1" Text="Button" />--%>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <div id="DivError" runat="server" visible="false" class="alert alert-danger">
                                                    <strong>Error!</strong>
                                                    <asp:Label ID="Msgerror2" runat="server" />
                                                </div>
                                            </div>
                                            <div class="modal-footer" style="text-align: center">
                                                <asp:Button ID="BGuardar" Text="Guardar" Width="80px" runat="server" Class="btn btn-primary" />
                                                <asp:Button ID="BSalir" Text="Salir" Width="80px" runat="server" Class="btn btn-primary" />
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal fade" id="NoProdModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
                                    aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <%--  <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                    &times;</button>--%>
                                                <h4 class="modal-title" id="ModalTitle4">Detalle Productor</h4>
                                            </div>
                                            <div class="modal-body">
                                                <label for="TxtFecha">
                                                    Fecha de capacitacion</label>
                                                <asp:TextBox ID="TxtFecha" runat="server" CssClass="form-control" ReadOnly="true" autocomplete="off" />
                                                <br />
                                                <label for="TxtNombre">
                                                    Nombre Completo</label>
                                                <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control" autocomplete="off" />
                                                <br />
                                                <label for="TxtIdentidad">
                                                    No. de Identidad</label>
                                                <asp:TextBox ID="TxtIdentidad" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                <br />
                                                <label for="TxtEdad">
                                                    Edad</label>
                                                <asp:TextBox ID="TxtEdad" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                <br />
                                                <label for="TxtSexo">
                                                    Sexo</label>
                                                <asp:DropDownList CssClass="form-control" ID="TxtSexo" runat="server">
                                                    <asp:ListItem>Hombre</asp:ListItem>
                                                    <asp:ListItem>Mujer</asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <label for="TxtTelefono">
                                                    Telefono</label>
                                                <asp:TextBox ID="TxtTelefono" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                                <script type="text/javascript">
                                                    function numericOnly(elementRef) {
                                                        var keyCodeEntered = (event.which) ? event.which : (window.event.keyCode) ? window.event.keyCode : -1;
                                                        if ((keyCodeEntered >= 48) && (keyCodeEntered <= 57)) {
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

                </div>
            </div>
        </div>
    </div>
</asp:Content>
