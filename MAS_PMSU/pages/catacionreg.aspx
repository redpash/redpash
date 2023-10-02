﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="catacionreg.aspx.vb" Inherits="MAS_PMSU.catacionreg" %>

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
            <div class="row">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Datos OP:                       
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-5">
                                <div class="form-group">
                                    <label>Nombre de la OP:</label>
                                    <asp:TextBox ID="TxtNombreOP" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-5">
                                <div id="divp" runat="server" class="form-group">
                                    <label>Productor:</label>
                                    <asp:TextBox ID="TxtNombreProd" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div id="divp2" runat="server" class="form-group">
                                    <label>.</label>
                                    <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
                                    <asp:Button ID="Buscar" class="btn btn-success" runat="server" Text="Buscar Productor" />
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="TxtCodOP" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="TxtCodProd" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="TxtTipo" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                    </div>

                </div>

            </div>
            <div class="row">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Ingrese fecha catacion:                       
                    </div>
                    <div class="panel-body">
                        <div class="col-lg-12">
                            <div style="width: 400px">
                                <div style="float: left; width: 70px">
                                    <label>Dia:</label>
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
                                </div>
                                <div style="float: left; width: 120px">
                                    <label>Mes:</label>
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
                                <div style="float: left; width: 80px">
                                    <label>Año:</label>
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

                            <br />
                        </div>
                    </div>

                </div>

            </div>

            <div class="row">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Datos de la muestra                      
                    </div>
                    <div class="panel-body">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Correlativo:</label>
                                <asp:TextBox ID="TxtCorrelativo" CssClass="form-control" runat="server" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Muestra de:</label>
                                <asp:DropDownList CssClass="form-control" ID="TxtMuestra" runat="server">
                                    <asp:ListItem>Pre compra</asp:ListItem>
                                    <asp:ListItem>Compra</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Exportador:</label>
                                <asp:DropDownList CssClass="form-control" ID="TxtExportador" runat="server">
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
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Variedad:</label>
                                <asp:DropDownList CssClass="form-control" ID="TxtVariedad" runat="server">
                                    <asp:ListItem>Lempira</asp:ListItem>
                                    <asp:ListItem>Parainema</asp:ListItem>
                                    <asp:ListItem>Catuaí</asp:ListItem>
                                    <asp:ListItem>Pacas</asp:ListItem>
                                    <asp:ListItem>IHCAFE 90</asp:ListItem>
                                    <asp:ListItem>Caturra</asp:ListItem>
                                    <asp:ListItem>Bourbon</asp:ListItem>
                                    <asp:ListItem>Typica</asp:ListItem>
                                    <asp:ListItem>Maragogype</asp:ListItem>
                                    <asp:ListItem>Pacamara</asp:ListItem>
                                    <asp:ListItem>Colombia</asp:ListItem>
                                    <asp:ListItem>San Ramon</asp:ListItem>
                                    <asp:ListItem>Otra</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <div class="row">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Ingrese los datos siguientes:                       
                    </div>
                    <div class="panel-body">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Altitud:</label>
                                <asp:TextBox ID="TxtAltitud" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Rendimiento TRILLA:</label>
                                <asp:TextBox ID="TxtRendimiento" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>% Daño:</label>
                                <asp:TextBox ID="TxtDano" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>% Humedad</label>
                                <asp:TextBox ID="TxtHumedad" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                </div>

            </div>
            <div class="row">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Seleccione si fue catado, en caso de ser NO explique la razón:
                    </div>
                    <div class="panel-body">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Catacion:</label>
                                <asp:DropDownList CssClass="form-control" ID="TxtCatacion" runat="server" AutoPostBack="True">
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-9">
                            <div class="form-group">
                                <label>Observación:</label>
                                <asp:TextBox ID="TxtObservacion" CssClass="form-control" runat="server" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="diva" runat="server">
                <div class="row">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Selecciones los atributos                       
                        </div>
                        <div class="panel-body">
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <label>Apariencia:</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtApariencia" runat="server">
                                        <asp:ListItem>Excelente</asp:ListItem>
                                        <asp:ListItem>Muy buena </asp:ListItem>
                                        <asp:ListItem>Buena</asp:ListItem>
                                        <asp:ListItem>Regular </asp:ListItem>
                                        <asp:ListItem>Bajo</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <label>Fragancia:</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtFragancia" runat="server">
                                        <asp:ListItem>Caramelo</asp:ListItem>
                                        <asp:ListItem>Te de rosas</asp:ListItem>
                                        <asp:ListItem>Chocolate</asp:ListItem>
                                        <asp:ListItem>Cítrico</asp:ListItem>
                                        <asp:ListItem>Dulce</asp:ListItem>
                                        <asp:ListItem>Floral</asp:ListItem>
                                        <asp:ListItem>Frutas</asp:ListItem>
                                        <asp:ListItem>Miel</asp:ListItem>
                                        <asp:ListItem>Panela</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <label>Aroma:</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtAroma" runat="server">
                                        <asp:ListItem>Caramelo</asp:ListItem>
                                        <asp:ListItem>Vino</asp:ListItem>
                                        <asp:ListItem>Chocolate</asp:ListItem>
                                        <asp:ListItem>Cítrico</asp:ListItem>
                                        <asp:ListItem>Dulce</asp:ListItem>
                                        <asp:ListItem>Floral</asp:ListItem>
                                        <asp:ListItem>Frutas</asp:ListItem>
                                        <asp:ListItem>Miel</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <label>Acidez:</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtAcidez" runat="server">
                                        <asp:ListItem>Aguda</asp:ListItem>
                                        <asp:ListItem>Baja</asp:ListItem>
                                        <asp:ListItem>Buena</asp:ListItem>
                                        <asp:ListItem>Intensa</asp:ListItem>
                                        <asp:ListItem>Acidez fina (Refinada)</asp:ListItem>
                                        <asp:ListItem>Viva</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <label>Cuerpo:</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtCuerpo" runat="server">
                                        <asp:ListItem>Aterciopelado</asp:ListItem>
                                        <asp:ListItem>Compacto</asp:ListItem>
                                        <asp:ListItem>Cremoso</asp:ListItem>
                                        <asp:ListItem>Redondo</asp:ListItem>
                                        <asp:ListItem>Suave</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <label>Sabor:</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtSabor" runat="server">
                                        <asp:ListItem>Almendra</asp:ListItem>
                                        <asp:ListItem>Hierba</asp:ListItem>
                                        <asp:ListItem>Mani</asp:ListItem>
                                        <asp:ListItem>Baya</asp:ListItem>
                                        <asp:ListItem>Caramelo</asp:ListItem>
                                        <asp:ListItem>Chocolate</asp:ListItem>
                                        <asp:ListItem>Complejo</asp:ListItem>
                                        <asp:ListItem>Floral</asp:ListItem>
                                        <asp:ListItem>Fruta</asp:ListItem>
                                        <asp:ListItem>Grosella negra</asp:ListItem>
                                        <asp:ListItem>Melocoton</asp:ListItem>
                                        <asp:ListItem>Nuez</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Nota Final                       
                        </div>
                        <div class="panel-body">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Nota Final:</label>
                                    <asp:TextBox ID="TxtNota" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Calidad:</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtCalidad" runat="server">
                                        <asp:ListItem>STD</asp:ListItem>
                                        <asp:ListItem>SHG</asp:ListItem>
                                        <asp:ListItem>HG</asp:ListItem>
                                        <asp:ListItem>Dañado</asp:ListItem>
                                        <asp:ListItem>GOURMET</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Formato:</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtFormato" runat="server">
                                        <asp:ListItem>SCAA</asp:ListItem>
                                        <asp:ListItem>IHCAFE</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>QQ pergamino seco:</label>
                                    <asp:TextBox ID="TxtQQPS" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
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
        <div class="col-lg-12">
            <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
            <asp:Button ID="GuardarD" class="btn btn-danger" runat="server" Text="Guardar " />
            <asp:Button ID="Cancelar" class="btn btn-danger" runat="server" Text="Cancelar" />
        </div>

    </div>
    <div class="modal fade" id="ProdModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="ModalTitle3">Listado Productores</h4>
                </div>
                <div class="modal-body">
                    <asp:TextBox ID="TxtID" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="TxtID2" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TConnODK %>" ProviderName="<%$ ConnectionStrings:TConnODK.ProviderName %>"></asp:SqlDataSource>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridDatos2" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource2" Font-Size="Small" PageSize="100" PageIndex="0">
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
                                            <%--<asp:RadioButton ID="chkSeleccionar" runat="server" />--%>
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
    <div class="modal fade" id="DeleteModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="ModalTitle2">MAS 2.0 - TNS</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <asp:Button ID="BConfirm" Text="Aceptar" Width="80px" runat="server" Class="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
