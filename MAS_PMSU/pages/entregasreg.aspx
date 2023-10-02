<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="entregasreg.aspx.vb" Inherits="MAS_PMSU.entregasreg" %>

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
                        </div>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="TxtCodOP" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Ingrese fecha de la entrega:                       
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
                        Datos de la entrega                      
                    </div>
                    <div class="panel-body">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Nota de peso:</label>
                                <asp:TextBox ID="TxtNotaPeso" CssClass="form-control" runat="server" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
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
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Café entregado:</label>
                                <asp:DropDownList CssClass="form-control" ID="TxtEntrega" runat="server" AutoPostBack="True">
                                    <asp:ListItem>QQ_PH</asp:ListItem>
                                    <asp:ListItem>QQ_PS</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div id="divtip" runat="server" class="form-group">
                                <label>Tipo:</label>
                                <asp:DropDownList CssClass="form-control" ID="TxtTipoCafe" runat="server">
                                    <asp:ListItem>Central estándar</asp:ListItem>
                                    <asp:ListItem>High Grown (HG)</asp:ListItem>
                                    <asp:ListItem>Strictly High Grown (SHG)</asp:ListItem>
                                    <asp:ListItem>Especiales</asp:ListItem>
                                    <asp:ListItem>No sabe</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Datos del lote:                       
                    </div>
                    <div class="panel-body">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Peso Destarado:</label>
                                <asp:TextBox ID="TxtPeso" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Descuentos:                       
                    </div>
                    <div class="panel-body">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>% Daño o Rebaja:</label>
                                <asp:TextBox ID="TxtDano" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div id="divhum" runat="server" class="form-group">
                                <label>% Humedad:</label>
                                <asp:TextBox ID="TxtHumedad" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div id="div1" runat="server" class="form-group">
                                <%--<label>% Humedad:</label>--%>
                                <asp:TextBox ID="TxtDescDano" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off" Visible="False"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div id="div2" runat="server" class="form-group">
                                <%--<label>% Humedad:</label>--%>
                                <asp:TextBox ID="TxtDescHumedad" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off" Visible="False"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div id="div3" runat="server" class="form-group">
                                <%--<label>% Humedad:</label>--%>
                                <asp:TextBox ID="TxtPesoFinal" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off" Visible="False"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Precios exportador:                       
                    </div>
                    <div class="panel-body">
                        <div class="col-lg-7">
                            <div class="form-group">
                                <label>Precio base Lps./QQPS:</label>
                                <asp:TextBox ID="TxtPreciobase" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div id="divprecal" runat="server" class="col-lg-7">
                            <div class="form-group">
                                <label>Valor adicional por calidad Lps./QQPS:</label>
                                <asp:TextBox ID="TxtPreciocalidad" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div id="divpretrans" runat="server" class="col-lg-7">
                            <div class="form-group">
                                <label>Valor flete / transporte Lps./QQPS:</label>
                                <asp:TextBox ID="TxtPrecioflete" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                </div>

            </div>
            <div class="row">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Precio de Plaza:
                    </div>
                    <div class="panel-body">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Precio de Plaza Lps./Libras pergamino seco:</label>
                                <asp:TextBox ID="TxtPrecioPlaza" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <asp:TextBox ID="TxtLiqExport" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off" Visible="False"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <asp:TextBox ID="TxtLiqPlaza" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off" Visible="False"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <asp:TextBox ID="TxtLiqDif" CssClass="form-control" runat="server" onkeypress="return numericOnly(this);" autocomplete="off" Visible="False"></asp:TextBox>
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
    
    <div class="modal fade" id="DeleteModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="ModalTitle2">MAS 2.0 - OPS</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <asp:Button ID="BConfirm" Text="Aceptar" Width="80px" runat="server" Class="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
