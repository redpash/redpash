﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="Registro_Portal_Sag.aspx.vb" Inherits="MAS_PMSU.Registro_Portal_Sag" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header"></h1>
        </div>
    </div>
    <div id="panelmasiso" runat="server">

        <asp:TextBox ID="Txtnombreproductor" runat="server" Visible="false" Enabled="false"></asp:TextBox>

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
                                    <label>Seleccione Productor con lote registrado:</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtProductor" runat="server" AutoPostBack="True"></asp:DropDownList>
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

                                            <asp:ButtonField ButtonType="Button" Text="EDITAR PLAN" HeaderText="EDITAR PLAN" CommandName="Editar">
                                            </asp:ButtonField>
                                            <asp:ButtonField ButtonType="Button" Text="INSCRIPCION SENASA" HeaderText="INSCRIBIR LOTE" CommandName="Eliminar">
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
                        <div class="row" runat="server">
                            <div class="col-lg-12">
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning" Text="Exportar Datos"><span class="glyphicon glyphicon-save"></span>&nbsp;Exportar Datos</asp:LinkButton>
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
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
                                        <asp:Button CssClass="btn btn-danger" ID="Button2" runat="server" Text="Exportar orden de compra a PDF" OnClick="descargaPDF" Visible="false" />
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
                                            <h4 class="modal-title" id="ModalTitle2">REDPASH </h4>
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

                            <div class="modal fade" id="DeleteModal3" tabindex="-1" role="dialog" aria-labelledby="ModalTitle3" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h4 class="modal-title" id="ModalTitle4">REDPASH</h4>
                                        </div>
                                        <div class="modal-body">
                                            <asp:Label ID="Label4" runat="server" Text="El productor no tiene ningun lote registrado. ¿Desea agregarlo?"></asp:Label>
                                        </div>
                                        <div class="modal-footer" style="text-align: center">
                                            <asp:Button ID="Button4" Text="Si" Width="80px" runat="server" Class="btn btn-primary" />
                                            <asp:Button ID="Button5" Text="No" Width="80px" runat="server" Class="btn btn-warning" />
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
                                            <asp:Label ID="Label7" class="label label-warning" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="TxtNom" runat="server" Enabled="false" CssClass="form-control" autocomplete="off" />
                                            <br />
                                            <label for="Txtciclo">
                                                Ciclo</label>
                                            <asp:Label ID="Label5" class="label label-warning" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="TxtCicloD" runat="server" Enabled="false" CssClass="form-control" autocomplete="off" />
                                            <br />
                                            <label for="DDL_Tipo">Tipo</label>
                                            <asp:Label ID="Label8" class="label label-warning" runat="server" Text=""></asp:Label>
                                            <asp:DropDownList CssClass="form-control" ID="DDL_Tipo" runat="server" onchange="updateTxtVariedad();" Enabled="false" OnSelectedIndexChanged="DDL_Tipo_SelectedIndexChanged" AutoPostBack="false">
                                                <asp:ListItem Text=""></asp:ListItem>
                                                <asp:ListItem id="frijol" Text="Frijol"></asp:ListItem>
                                                <asp:ListItem id="maiz" Text="Maiz"></asp:ListItem>
                                            </asp:DropDownList>
                                            <br />
                                            <label for="TxtVariedad">Variedad</label>
                                            <asp:Label ID="Label9" class="label label-warning" runat="server" Text=""></asp:Label>
                                            <asp:DropDownList CssClass="form-control" Enabled="false" ID="TxtVariedad" runat="server">
                                            </asp:DropDownList>

                                            <script type="text/javascript">
                                                var variedades = {
                                                    "Frijol": ["","Amadeus77", "Carrizalito", "Deorho", "Azabache", "Paraisitomejorado", "Honduras_nutritivo", "IntaCardenas", "Lencaprecoz", "Rojochortí", "Tolupanrojo", "OtraVariedad"],
                                                    "Maiz": ["", "Dicta Maya", "Dicta Victoria", "Otra especificar"]
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
                                            <asp:Label ID="Label10" class="label label-warning" runat="server" Text=""></asp:Label>
                                            <asp:DropDownList CssClass="form-control" Enabled="false" ID="TxtCategoria" runat="server" ReadOnly="true">
                                                <asp:ListItem Text=""></asp:ListItem>
                                                <asp:ListItem>Certificada</asp:ListItem>
                                                <asp:ListItem>Comercial</asp:ListItem>
                                            </asp:DropDownList>
                                            <br />
                                            <asp:UpdatePanel runat="server" ID="updatePanel" UpdateMode="Conditional">
                                                <ContentTemplate>

                                                    <label for="txtNombreFinca">
                                                        Nombre o No. del lote dentro de la finca</label>
                                                    <asp:Label ID="lbDDL_Nlote" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList CssClass="form-control" ID="DDL_Nlote" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_Nlote_SelectedIndexChanged">
                                                        <asp:ListItem Text=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <br />

                                                    <label for="TxtQuintales">Area a Sembrar En MZ.</label>
                                                    <asp:Label ID="lbAreaMZ" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox ID="TxT_AreaMZ" runat="server" CssClass="form-control" AutoPostBack="False" onchange="calculateAreaHa();" OnTextChanged="TxT_AreaMZ_TextChanged" onkeypress="return numericOnly(this);"/>
                                                    <asp:RegularExpressionValidator ID="RegexValidator" runat="server" ControlToValidate="TxT_AreaMZ" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                                    
                                                    <label for="Txt_AreaHa">Area a Sembrar En HA</label>
                                                    <asp:TextBox ID="Txt_AreaHa" runat="server" CssClass="form-control" AutoPostBack="True" ReadOnly="true" />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Txt_AreaHa" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
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
                                                                <asp:Label ID="lbFechaSiembra" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                <asp:TextBox CssClass="form-control" ID="TxtFechaSiembra" TextMode="date" runat="server" AutoPostBack="false"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <label for="TxtRegistradaQQ">
                                                        Requerimiento de semilla registrada QQ</label>
                                                    <asp:Label ID="lbRegistradaQQ" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox ID="TxtRegistradaQQ" runat="server" CssClass="form-control" AutoPostBack="true" onkeypress="return numericOnly(this);" autocomplete="off" OnTextChanged="TxtRegistradaQQ_TextChanged"/>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TxtRegistradaQQ" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                                    <br />

                                                    <label for="TxtCantLotes" runat="server" visible="false">
                                                        Cantidad de lotes a sembrar</label>
                                                    <asp:Label ID="lbCantLotes" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox ID="TxtCantLotes" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" Visible="false" Text="1" />
                                                    <br />

                                                    <label for="TxtProduccionQQMZ">
                                                        Estimado de producción en campo QQ/MZ</label>
                                                    <asp:Label ID="lbProduccionQQMZ" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox ID="TxtProduccionQQMZ" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="TxtProduccionQQMZ_TextChanged" onchange="calculateAreaHaPRO();" onkeypress="return numericOnly(this);"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TxtProduccionQQMZ" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                                    <br />

                                                    <label for="TxtProduccionQQHA">
                                                        Estimado de producción en campo QQ/HA</label>
                                                    <asp:TextBox ID="TxtProduccionQQHA" runat="server" CssClass="form-control" Enable="false" ReadOnly="true"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TxtProduccionQQHA" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
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
                                                        Estimado semilla a producir QQ/MZ.</label>
                                                    <asp:Label ID="lbSemillaQQ" class="label label-warning" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox ID="TxtSemillaQQ" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="TxtSemillaQQ_TextChanged" onchange="calculateAreaHaEs();" onkeypress="return numericOnly(this);"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TxtSemillaQQ" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                                    <br />

                                                    <label for="TxtEstimadoProducir">
                                                        Estimado semilla a producir QQ/HA</label>
                                                    <asp:TextBox ID="TxtEstimadoProducir" runat="server" CssClass="form-control" Enable="false" ReadOnly="true"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TxtEstimadoProducir" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
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
                                                </ContentTemplate>
                                            </asp:UpdatePanel>


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

                                        <%-- <script>
                                      $(function () {

                                          $("#<%=TxtProductor.ClientID%>").select2();

          })
                                  </script>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>


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
                                            <asp:Label ID="Label14" runat="server" Text="" BackColor="Red" ForeColor="White" Visible="false">Solo archivos PNG/JPG/JPEG se aceptan</asp:Label>
                                            <asp:FileUpload ID="FileUploadFicha" runat="server" class="form-control" accept=".png,.jpg,.jpeg"/>
                                        </div>
                                        <br />
                                        <div class="mb-3">
                                            <label for="FileUploadPagoTGR" class="form-label">Pago de TGR:</label>
                                            <asp:Label ID="Label15" runat="server" Text="" BackColor="Red" ForeColor="White" Visible="false">Solo archivos PNG/JPG/JPEG se aceptan</asp:Label>
                                            <asp:FileUpload ID="FileUploadPagoTGR" runat="server" class="form-control" accept=".png,.jpg,.jpeg"/>
                                        </div>
                                        <br />
                                        <div class="mb-3">
                                            <label for="TxtSemillaQQ">Etiqueta De Semilla Registrada</label>
                                            <asp:Label ID="Label16" runat="server" Text="" BackColor="Red" ForeColor="White" Visible="false">Solo archivos PNG/JPG/JPEG se aceptan</asp:Label>
                                            <asp:FileUpload ID="FileUploadEtiquetaSemilla" runat="server" class="form-control" accept=".png,.jpg,.jpeg"/>
                                        </div>
                                        <br />

                                        <asp:Label ID="Label12" runat="server" Text="" BackColor="Red" ForeColor="White" Visible="false">Antes debes ingresar toda la información</asp:Label>
                                        <asp:Label ID="Label13" runat="server" Text="" BackColor="Green" ForeColor="White" Visible="false">Archivos ingresados con exito</asp:Label>
                                        <br />
                                        <asp:Button ID="BtnUpload" runat="server" Text="Guardar" OnClick="BtnUpload_Click" AutoPostBack="false" class="btn btn-primary" />
                                        <asp:Button ID="Button1" runat="server" Text="Regresar" AutoPostBack="True" class="btn btn-primary" />
                                        <hr />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="modal fade" id="DeleteModal4" tabindex="-1" role="dialog" aria-labelledby="ModalTitle5" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="ModalTitle5">REDPASH</h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="Label11" runat="server" Text="El productor no tiene ningun lote registrado. ¿Desea agregarlo?"></asp:Label>
                    </div>
                    <div class="modal-footer" style="text-align: center">
                        <asp:Button ID="Button6" Text="Aceptar" Width="80px" runat="server" Class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
