<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="ProduccionCostes.aspx.vb" Inherits="MAS_PMSU.ProduccionCostes" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header"></h1>
        </div>
    </div>
    <div id="panelmasiso" runat="server">

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
                                    <asp:ListItem Text="Frijol"></asp:ListItem>
                                    <asp:ListItem Text="Maiz"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Seleccione Categoria:</label>
                                <asp:DropDownList CssClass="form-control" ID="DDL_Categ" runat="server" AutoPostBack="True">
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
                                        <asp:BoundField DataField="CICLO" HeaderText="CICLO" />
                                        <asp:BoundField DataField="VARIEDAD" HeaderText="VARIEDAD" />
                                        <asp:BoundField DataField="CATEGORIA" HeaderText="CATEGORIA" />
                                       

                                        <%--<asp:BoundField DataField="Habilitado" HeaderText="HABILITADO" />--%>

                                        <asp:ButtonField ButtonType="Button" Text="EDITAR PLAN" ControlStyle-CssClass="btn btn-success" HeaderText="EDITAR PLAN" CommandName="Editar">
                                            <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                        </asp:ButtonField>
                                        <asp:ButtonField ButtonType="Button" Text="INSCRIPCION SENASA" ControlStyle-CssClass="btn btn-danger" HeaderText="INSCRIBIR LOTE" CommandName="Eliminar">
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
                    <div class="row" runat="server" visible="false">
                        <div class="col-lg-12">
                            <%--<asp:Button ID="Button1" runat="server" Text="Exportar Datos" CssClass="btn btn-success" />--%>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning" Text="Exportar Datos"><span class="glyphicon glyphicon-save"></span>&nbsp;Exportar Datos</asp:LinkButton>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            -----------------------------
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-2">
                            <div class="form-group">
                                <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
                                <asp:Button ID="BAgregar" runat="server" Text="Agregar Inscripcion" CssClass="btn btn-success" />
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="form-group">
                                <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
                                <asp:Button CssClass="btn btn-danger" ID="Button2" runat="server" Text="Exportar orden de compra a PDF" OnClick="descargaPDF" visible="false"/>
                            </div>
                        </div>
                    </div>

                    <%--< MODAL PRODUCCION />--%>
                    <div class="modal fade" id="ModalProduccion" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
                        aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title" id="ModalProdTitle">Producción de Semilla</h4>
                                </div>

                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label for="TxtAreaSembMz">Area del terreno sembradas (Mz)</label>
                                                <asp:TextBox ID="TxtAreaSembMz" runat="server" CssClass="form-control" autocomplete="off" TextMode="Number" onchange="calculateAreaHaInsc();" AutoPostBack="false" OnTextChanged="TxtAreaSembMz_TextChanged"/>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label for="TxtAreaSembHa">Area del terreno sembradas (Ha)</label>
                                                <asp:TextBox ID="TxtAreaSembHa" runat="server" ReadOnly="true" CssClass="form-control" autocomplete="off" TextMode="Number"/>
                                            </div>
                                        </div>
                                    </div>

                                    <label for="TxtFecha">Fecha que sembró:</label>
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <asp:Label ID="Label4" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox7" TextMode="date" runat="server" AutoPostBack="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <label>¿Tuvo pérdida en el área que sembró?</label>
                                    <asp:DropDownList CssClass="form-control" ID="DDL_perdidas" runat="server" AutoPostBack="false">
                                        <asp:ListItem Text="No"></asp:ListItem>
                                        <asp:ListItem Text="Si"></asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <div id="DIVsiembraperdida" runat="server">
                                        <label>¿En cuántas manzanas de terreno que sembró tuvo pérdidas?</label>
                                        <br />
                                        <div class="col-lg-4">
                                            <label for="TxtAreaPerdMz">Area del terreno sembradas perdidas (Mz)</label>
                                            <asp:TextBox ID="TxtAreaPerdMz" runat="server" CssClass="form-control" autocomplete="off" TextMode="Number"/>
                                        </div>
                                        <div class="col-lg-4">
                                            <label for="TxtAreaPerdHa">Area de lterreno sembradas perdidas (Ha)</label>
                                            <asp:TextBox ID="TxtAreaPerdHa" runat="server" ReadOnly="true" CssClass="form-control" autocomplete="off" TextMode="Number"/>
                                        </div>
                                        <br />
                                        <label>¿Cuáles fueron los factores que le causaron pérdida en campo?</label>
                                        <div class="col-lg-8" style="display: flex;">
                                            <label style="width:80%;">Plagas y enfermedades</label>
                                            <asp:DropDownList CssClass="form-control" ID="DropDownList1" style="width:20%;" runat="server" AutoPostBack="false">
                                                <asp:ListItem Text="No"></asp:ListItem>
                                                <asp:ListItem Text="Si"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-8" style="display: flex;">
                                            <label style="width:80%;">Sequía/falta de lluvia</label>
                                            <asp:DropDownList CssClass="form-control" ID="DropDownList2" style="width:20%;" runat="server" AutoPostBack="false">
                                                <asp:ListItem Text="No"></asp:ListItem>
                                                <asp:ListItem Text="Si"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-8" style="display: flex;">
                                            <label style="width:80%;">Exceso de lluvia</label>
                                            <asp:DropDownList CssClass="form-control" ID="DropDownList3" style="width:20%;" runat="server" AutoPostBack="false">
                                                <asp:ListItem Text="No"></asp:ListItem>
                                                <asp:ListItem Text="Si"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-8" style="display: flex;">
                                            <label style="width:80%;">Baja germinación</label>
                                            <asp:DropDownList CssClass="form-control" ID="DropDownList4" style="width:20%;" runat="server" AutoPostBack="false">
                                                <asp:ListItem Text="No"></asp:ListItem>
                                                <asp:ListItem Text="Si"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-8" style="display: flex;">
                                            <label style="width:80%;">Mal manejo cultivo</label>
                                            <asp:DropDownList CssClass="form-control" ID="DropDownList5" style="width:20%;" runat="server" AutoPostBack="false">
                                                <asp:ListItem Text="No"></asp:ListItem>
                                                <asp:ListItem Text="Si"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-8" style="display: flex;">
                                            <label style="width:80%;">Otros factores (robo, daño de animales, etc.,)</label>
                                            <asp:DropDownList CssClass="form-control" ID="DropDownList6" style="width:20%;" runat="server" AutoPostBack="false">
                                                <asp:ListItem Text="No"></asp:ListItem>
                                                <asp:ListItem Text="Si"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <label> </label>
                                    <label for="TxtQQProd">Quintales producidos en campo: </label>
                                    <asp:TextBox ID="TxtQQProd" runat="server" CssClass="form-control" autocomplete="off" TextMode="Number"/>
                                    <br />
                                    <label>¿Dispone de los resultados del Centro de Procesamiento?</label>
                                    <asp:DropDownList CssClass="form-control" ID="DDL_Procesamiento" runat="server" AutoPostBack="false">
                                        <asp:ListItem Text="No"></asp:ListItem>
                                        <asp:ListItem Text="Si"></asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <div id="DIVproduccion" runat="server">
                                        <label for="TxtSemilla">Cantidad de quintales clasificados como semilla</label>
                                        <asp:TextBox ID="TxtSemilla" runat="server" CssClass="form-control" autocomplete="off" TextMode="Number"/>
                                        <br />
                                        <label for="TxtGrano">Cantidad de quintales clasificados como grano</label>
                                        <asp:TextBox ID="TxtGrano" runat="server" CssClass="form-control" autocomplete="off" TextMode="Number"/>
                                        <br />
                                        <label for="TxtBasura">Cantidad de quintales clasificados como basura</label>
                                        <asp:TextBox ID="TxtBasura" runat="server" CssClass="form-control" autocomplete="off" TextMode="Number"/>
                                    </div>
                                </div>
                                
                                <div class="modal-footer" style="text-align: center">
                                    <asp:Button ID="BtnGuardProd" Text="Guardar" Width="80px" runat="server" Class="btn btn-primary" />
                                    <asp:Button ID="BtnSaliProd" Text="Salir" Width="80px" runat="server" Class="btn btn-primary" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <script type="text/javascript">
                        function calculateAreaHaInsc() {
                            var areaMZ = parseFloat(document.getElementById('<%= TxtAreaSembMz.ClientID %>').value);
                            var total = areaMZ * 0.7;
                            document.getElementById('<%= TxtAreaSembHa.ClientID %>').value = total.toFixed(2);
                        }
                        // Función para mostrar u ocultar DIVsiembraperdida
                        function mostrarOcultarSiembraperdida() {
                            var ddlPerdidas = document.getElementById('<%= DDL_perdidas.ClientID %>');
                            var divSiembraperdida = document.getElementById('<%= DIVsiembraperdida.ClientID %>');
                            if (ddlPerdidas.value === 'Si') {
                                divSiembraperdida.style.display = 'block';
                            } else {
                                divSiembraperdida.style.display = 'none';
                            }
                        }

                        // Función para mostrar u ocultar DIVproduccion
                        function mostrarOcultarProduccion() {
                            var ddlProcesamiento = document.getElementById('<%= DDL_Procesamiento.ClientID %>');
                            var divProduccion = document.getElementById('<%= DIVproduccion.ClientID %>');
                            if (ddlProcesamiento.value === 'Si') {
                                divProduccion.style.display = 'block';
                            } else {
                                divProduccion.style.display = 'none';
                            }
                        }

                        // Asignar los eventos onchange a los DropDownList
                        document.getElementById('<%= DDL_perdidas.ClientID %>').addEventListener('change', mostrarOcultarSiembraperdida);
                        document.getElementById('<%= DDL_Procesamiento.ClientID %>').addEventListener('change', mostrarOcultarProduccion);

                        // Llamar a las funciones una vez para establecer el estado inicial
                        mostrarOcultarSiembraperdida();
                        mostrarOcultarProduccion();
                    </script>


                    <div class="modal fade" id="ModalCostos" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
                        aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title" id="ModalCostosTitle">Costos</h4>
                                </div>
                                <div class="modal-body">
                                    <label for="TxtCost1">Insumos: </label>
                                    <asp:TextBox ID="TxtCost" runat="server" CssClass="form-control" autocomplete="off" TextMode="Number"/>
                                    <br />
                                    <label for="TxtCost2">Mano de obra: </label>
                                    <asp:TextBox ID="TxtCost2" runat="server" CssClass="form-control" autocomplete="off" TextMode="Number"/>
                                    <br />
                                    <label for="TxtCost3">Equipos y maquinaria: </label>
                                    <asp:TextBox ID="TxtCost3" runat="server" CssClass="form-control" autocomplete="off" TextMode="Number"/>
                                    <br />
                                    <label for="TxtCost4">Inscripción: </label>
                                    <asp:TextBox ID="TxtCost4" runat="server" CssClass="form-control" autocomplete="off" TextMode="Number"/>
                                    <br />
                                    <label for="TxtCost5">Acondicionamiento de semilla: </label>
                                    <asp:TextBox ID="TxtCost5" runat="server" CssClass="form-control" autocomplete="off" TextMode="Number"/>
                                    <br />
                                    <label for="TxtCost6">Otros costos: </label>
                                    <asp:TextBox ID="TxtCost6" runat="server" CssClass="form-control" autocomplete="off" TextMode="Number"/>
                                    <br />
                                    <label for="TxtCost7">TOTAL: </label>
                                    <asp:TextBox ID="TxtCost7" runat="server" CssClass="form-control" autocomplete="off" TextMode="Number"/>
                                    <br />
                                </div>
                                <div class="modal-footer" style="text-align: center">
                                    <asp:Button ID="BtnGuardCost" Text="Guardar" Width="80px" runat="server" Class="btn btn-primary" />
                                    <asp:Button ID="BtnSaliCost" Text="Salir" Width="80px" runat="server" Class="btn btn-primary" />
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
                                    <h4 class="modal-title" id="ModalTitle2">MAS 2.0 - DICTA - MSU</h4>
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
                                    <h4 class="modal-title" id="ModalTitle3">MAS 2.0 - TNS</h4>
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

                    <div class="modal fade" id="AdInscrip" tabindex="-1" role="dialog" aria-labelledby="ModalTitle"
                        aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        &times;</button>
                                    <h4 class="modal-title" id="ModalTitle8">Detalle del lote sembrado</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:TextBox ID="TxtID" runat="server" Visible="False"></asp:TextBox>
                                    <asp:TextBox ID="txt_habilitado" runat="server" Visible="False"></asp:TextBox>
                                    <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>

                                    <asp:TextBox ID="TxtTabla" runat="server" Visible="False"></asp:TextBox>
                                    <%--<asp:CheckBox ID="CheckBox1" runat="server" Visible="False" />--%>
                                    <br />
                                    <label for="TxtNom3">
                                        Nombre del Productor</label>
                                    <asp:TextBox ID="TxtNom" runat="server" ReadOnly="true" CssClass="form-control" autocomplete="off" />
                                    <br />
                                    <label for="Txtciclo">
                                        Ciclo</label>
                                    <asp:TextBox ID="TxtCicloD" runat="server" ReadOnly="true" CssClass="form-control" autocomplete="off" />
                                    <br />
                                    <label for="DDL_Tipo">Tipo</label>
                                    <asp:DropDownList CssClass="form-control" ID="DDL_Tipo" runat="server" onchange="updateTxtVariedad();" OnSelectedIndexChanged="DDL_Tipo_SelectedIndexChanged" AutoPostBack="false">
                                        <asp:ListItem Text=""></asp:ListItem>
                                        <asp:ListItem id="frijol" Text="Frijol"></asp:ListItem>
                                        <asp:ListItem id="maiz" Text="Maiz"></asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <label for="TxtVariedad">Variedad</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtVariedad" runat="server">
                                    </asp:DropDownList>

                                    <script type="text/javascript">
                                        var variedades = {
                                            "Frijol": ["Amadeus77", "Carrizalito", "Deorho", "Azabache", "Paraisitomejorado", "Honduras_nutritivo", "IntaCardenas", "Lencaprecoz", "Rojochortí", "Tolupanrojo", "OtraVariedad"],
                                            "Maiz": ["Dicta Maya", "Dicta Victoria", "Otra especificar"]
                                        };

                                        // Función para actualizar las opciones de TxtVariedad
                                        function updateTxtVariedad() {
                                            var ddlTipo = document.getElementById('<%= DDL_Tipo.ClientID %>');
                                            var txtVariedad = document.getElementById('<%= TxtVariedad.ClientID %>');
                                            var selectedValue = ddlTipo.options[ddlTipo.selectedIndex].value;

                                            // Limpiar las opciones actuales en TxtVariedad
                                            txtVariedad.options.length = 0;

                                            // Agregar las nuevas opciones según el tipo seleccionado
                                            for (var i = 0; i < variedades[selectedValue].length; i++) {
                                                var option = document.createElement("option");
                                                option.text = variedades[selectedValue][i];
                                                txtVariedad.add(option);
                                            }
                                        }
                                    </script>

                                    <br />
                                    <label for="TxtCategoria">
                                        Categoria</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtCategoria" runat="server">
                                        <asp:ListItem Text=""></asp:ListItem>
                                        <asp:ListItem>Certificada</asp:ListItem>
                                        <asp:ListItem>Comercial</asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <label for="TxtQuintales">
                                        Area a Sembrar En MZ.</label>
                                    <asp:TextBox ID="TxT_AreaMZ" runat="server" CssClass="form-control" AutoPostBack="False" onchange="calculateAreaHa();" TextMode="Number" OnTextChanged="TxT_AreaMZ_TextChanged"/>
                                  
                                    
                                    <label for="Txt_AreaHa">
                                        Area a Sembrar En HA</label>
                                    <asp:TextBox ID="Txt_AreaHa" runat="server" CssClass="form-control" AutoPostBack="True" ReadOnly="true"/>
                                    <br />

                           <%--     esta funcion es de tipo javascript , con documentid agarra los valores de los textbox--%>
                                 <script type="text/javascript">
                                     function calculateAreaHa() {
                                         var areaMZ = parseFloat(document.getElementById('<%= TxT_AreaMZ.ClientID %>').value);
                                                var total = areaMZ * 0.7;
                                             document.getElementById('<%= Txt_AreaHa.ClientID %>').value = total.toFixed(2);
                                     }
                                 </script>
                                    <label for="TxtFecha">Fecha que siembrarà:</label>
                                    <div class="row">
                                        
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <asp:Label ID="Label14" class="label label-warning" runat="server" Text=""></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="TxtFechaSiembra" TextMode="date" runat="server" AutoPostBack="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                       <br />
                                    <label for="TxtRegistradaQQ">
                                        Requerimiento de semilla registrada QQ</label>
                                    <asp:TextBox ID="TxtRegistradaQQ" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" Textmode="Number"/>
                                    <br />
                                
                                     <label for="TxtCantLotes" runat="server" visible="false">
                                        Cantidad de lotes a sembrar</label>
                                    <asp:TextBox ID="TxtCantLotes" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" Textmode="Number" Visible="false" Text="1"/>
                                        <br />
                             
                                     <label for="txtNombreFinca">
                                        Nombre o No. del lote dentro de la finca</label>                           
                                        <asp:DropDownList CssClass="form-control" ID="DDL_Nlote" runat="server" AutoPostBack="false"></asp:DropDownList>

                                     <br />
                                   
                                      <label for="TxtProduccionQQMZ">
                                        Estimado de producción en campo QQ/MZ</label>                           
                                    <asp:TextBox ID="TxtProduccionQQMZ" runat="server" CssClass="form-control" AutoPostBack="False" OnTextChanged="TxtProduccionQQMZ_TextChanged" TextMode="Number" onchange="calculateAreaHaPRO();" ></asp:TextBox>
                                     <br />
                            
                                    <label for="TxtProduccionQQHA">
                                        Estimado de producción en campo QQ/HA</label>                           
                                    <asp:TextBox ID="TxtProduccionQQHA" runat="server" CssClass="form-control" Enable="false" ReadOnly="true"></asp:TextBox>
                                    <script type="text/javascript">
                                        function calculateAreaHaPRO() {
                                            var areaMZ = parseFloat(document.getElementById('<%= TxtProduccionQQMZ.ClientID %>').value);
                                            var areaHA = parseFloat(document.getElementById('<%= Txt_AreaHa.ClientID %>').value);
                                            var total = areaMZ * 0.7;
                                                  document.getElementById('<%= TxtProduccionQQHA.ClientID %>').value = total.toFixed(2);
                                        }
                                    </script>
                                     <br />
                                  
                                    <label for="TxtSemillaQQ">
                                        Estimado semilla a producir QQ.</label>                           
                                    <asp:TextBox ID="TxtSemillaQQ" runat="server" CssClass="form-control" AutoPostBack="False" OnTextChanged="TxtSemillaQQ_TextChanged" TextMode="Number" onchange="calculateAreaHaEs();"></asp:TextBox>
                                    <br />
                                
                                    <label for="TxtEstimadoProducir">
                                       Estimado semilla a producir QQ/HA</label>                           
                                    <asp:TextBox ID="TxtEstimadoProducir" runat="server" CssClass="form-control" Enable="false" ReadOnly="true"></asp:TextBox>
                                    <script type="text/javascript">
                                         var calculatedTotal = 0; // Declarar la variable para almacenar el total calculado

                                         function calculateAreaHaEs() {
                                             var areaMZ = parseFloat(document.getElementById('<%= TxtSemillaQQ.ClientID %>').value);
                                             var areaHA = parseFloat(document.getElementById('<%= Txt_AreaHa.ClientID %>').value);
                                                calculatedTotal = areaMZ * 0.7; // Guardar el total en la variable
                                             document.getElementById('<%= TxtEstimadoProducir.ClientID %>').value = calculatedTotal.toFixed(2);
                                         }
                                    </script>
                                    <br />
                                 
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
                </div>
            </div>
        </div>
    </div>

</div>

       
        <ContentTemplate>
        
            <div id="div_nuevo_prod" runat="server">

                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header"></h1>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <asp:Label ID="laBEL2" runat="server" Text=""></asp:Label>INSCRIPCIÒN 

                                    <asp:TextBox ID="TextBox2" Visible="false" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="TextBox3" Visible="false" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="TextBox4" Visible="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                          
                                                 <div class="form-group">
                                               <h3>Subir archivos</h3>
                                                <br />
                                                <div class="mb-3">
                                                <label for="FileUploadSemilla" class="form-label">Tipo de semilla recibida para sembrar el lote de producción:</label>
                                                    <asp:DropDownList CssClass="form-control" ID="CmbTipoSemilla" runat="server" AutoPostBack="False">
                                                            <asp:ListItem Text=""></asp:ListItem>
                                                            <asp:ListItem id="registrada" Text="Registrada"></asp:ListItem>
                                                            <asp:ListItem id="certificada" Text="Certificada"></asp:ListItem>
                                                            <asp:ListItem id="comercial" Text="Comercial"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                 <br />
                                                 <div class="mb-3">
                                                   <label for="FileUploadFicha" class="form-label">Ficha de inscripción de lote o campos para la producción de semilla</label>
                                                 <asp:FileUpload ID="FileUploadFicha" runat="server" class="form-control" />
                                                 </div>
                                                <br />
                                               <div class="mb-3">
                                                  <label for="FileUploadPagoTGR" class="form-label">Pago de TGR:</label>
                                                 <asp:FileUpload ID="FileUploadPagoTGR" runat="server" class="form-control" />
                                                     </div>
                                                            <br />
                                  
                                                 <label for="TxtSemillaQQ">
                                                 Etiqueta De Semilla Registrada</label>                           
                                                   <asp:FileUpload ID="FileUploadEtiquetaSemilla" runat="server" class="form-control" />
                                                   <br />
                                            <asp:Button ID="BtnUpload" runat="server" Text="Guardar" OnClick="BtnUpload_Click" AutoPostBack="True" class="btn btn-primary" />
                                                     <asp:Button ID="Button1" runat="server" Text="Regresar"  AutoPostBack="True" class="btn btn-warning" />
                                                     <hr />
                                               
                                          
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
        </ContentTemplate>
   
    

</asp:Content>