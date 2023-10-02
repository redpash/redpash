<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="compfrijolprimase2019.aspx.vb" Inherits="MAS_PMSU.compfrijolprimase2019" %>

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
                    REGISTRO DE COMPROMISOS DE FRIJOL PRIMERA 2019
                </div>
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
                        <div id="divexp" runat="server">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Seleccione Comprador:</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtExportador" runat="server" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <asp:TextBox ID="TxtIn" Visible="false" runat="server"></asp:TextBox>
                            </div>
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
                                    <br />
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TConnODK %>" ProviderName="<%$ ConnectionStrings:TConnODK.ProviderName %>"></asp:SqlDataSource>
                                    <asp:GridView ID="GridDatos2" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                        GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource2" Font-Size="Small" PageSize="150" PageIndex="0">
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
                                                    <asp:CheckBox ID="chkSeleccionar" runat="server" />
                                                    <%--<asp:RadioButton ID="chkSeleccionar" runat="server" />--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="COD_PRODUCTOR" HeaderText="COD_PRODUCTOR" />
                                            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                                            <asp:BoundField DataField="SEXO" HeaderText="SEXO" />
                                            <asp:BoundField DataField="EDAD" HeaderText="EDAD" />
                                            <asp:BoundField DataField="ID_PARTIDA" HeaderText="IDENTIDAD" />

                                        </Columns>
                                        <EditRowStyle BackColor="#7C6F57" />
                                        <RowStyle BackColor="#E3EAEB" />
                                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                                    </asp:GridView>
                                    <div id="DivError" runat="server" visible="false" class="alert alert-danger">
                                        <strong>Error!</strong>
                                        <asp:Label ID="Msgerror2" runat="server" />
                                    </div>
                                </div>
                                <div class="modal-footer" style="text-align: center">
                                    <asp:Button ID="BGuardar2" Text="Guardar" Width="80px" runat="server" Class="btn btn-primary" />
                                    <asp:Button ID="BSalir2" Text="Salir" Width="80px" runat="server" Class="btn btn-primary" />
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="EditModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle"
                        aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        &times;</button>
                                    <h4 class="modal-title" id="ModalTitle">Detalle del compromiso</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:TextBox ID="TxtID" runat="server" Visible="False"></asp:TextBox>
                                    <asp:CheckBox ID="ChNuevo" runat="server" Visible="False" />
                                    <br />
                                    <label for="TxtNom">
                                        Nombre del Productor</label>
                                    <asp:TextBox ID="TxtNom" runat="server" ReadOnly="true" CssClass="form-control" autocomplete="off" />
                                    <br />
                                    <label for="TxtIden">
                                        No. Identidad</label>
                                    <asp:TextBox ID="TxtIden" runat="server" CssClass="form-control" autocomplete="off" />
                                    <br />
                                    <label for="TxtRTN">
                                        RTN</label>
                                    <asp:TextBox ID="TxtRTN" runat="server" CssClass="form-control" autocomplete="off" />
                                    <br />
                                    <label for="TxtExport">
                                        Comprador</label>
                                    <asp:TextBox ID="TxtExport" runat="server" ReadOnly="true" CssClass="form-control" autocomplete="off" />

                                    <%--     <br />
                                    <label for="TxtClave">
                                        Clave IHCAFE</label>
                                    <asp:TextBox ID="TxtClave" runat="server" CssClass="form-control" autocomplete="off" />--%>
                                    <br />
                                    <label for="TxtTipo">
                                        Variedad</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtTipo" runat="server">
                                        <asp:ListItem>Criolla</asp:ListItem>
                                        <asp:ListItem>Amadeus</asp:ListItem>
                                        <asp:ListItem>Carrizalito</asp:ListItem>
                                        <asp:ListItem>Deorho</asp:ListItem>
                                        <asp:ListItem>Azabache</asp:ListItem>
                                        <asp:ListItem>Paraisito mejorado</asp:ListItem>
                                        <asp:ListItem>Honduras nutritivo</asp:ListItem>
                                        <asp:ListItem>Inta cardenas</asp:ListItem>
                                        <asp:ListItem>Otra</asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <label for="TxtComp">
                                        QQ comprometidos</label>
                                    <asp:TextBox ID="TxtComp" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
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
                                    <h4 class="modal-title" id="ModalTitle4">Detalle del compromiso</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:TextBox ID="TxtID2" runat="server" Visible="False"></asp:TextBox>
                                    <br />
                                    <label for="TxtNomOrg">
                                        Nombre de la Organizacion</label>
                                    <asp:TextBox ID="TxtNomOrg" runat="server" ReadOnly="true" CssClass="form-control" autocomplete="off" />
                                    <br />
                                    <label for="TxtExport2">
                                        Comprador</label>
                                    <asp:TextBox ID="TxtExport2" runat="server" ReadOnly="true" CssClass="form-control" autocomplete="off" />
                                    <br />
                                    <label for="TxtTipo2">
                                        Tipo de Cafe</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtTipo2" runat="server">
                                        <asp:ListItem>Criolla</asp:ListItem>
                                        <asp:ListItem>Amadeus</asp:ListItem>
                                        <asp:ListItem>Carrizalito</asp:ListItem>
                                        <asp:ListItem>Deorho</asp:ListItem>
                                        <asp:ListItem>Azabache</asp:ListItem>
                                        <asp:ListItem>Paraisito mejorado</asp:ListItem>
                                        <asp:ListItem>Honduras nutritivo</asp:ListItem>
                                        <asp:ListItem>Inta cardenas</asp:ListItem>
                                        <asp:ListItem>Otra</asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <label for="TxtComp2">
                                        QQ comprometidos</label>
                                    <asp:TextBox ID="TxtComp2" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
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
                                    <asp:Button ID="BGuardar3" Text="Guardar" Width="80px" runat="server" Class="btn btn-primary" />
                                    <asp:Button ID="BSalir3" Text="Salir" Width="80px" runat="server" Class="btn btn-primary" />
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
                    <div class="modal fade" id="NoProdModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
                        aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <%--  <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                    &times;</button>--%>
                                    <h4 class="modal-title" id="ModalTitle5">Detalle registro de productor no antendido</h4>
                                </div>
                                <div class="modal-body">
                                    <label for="TxtIdentidad">
                                        No. de Identidad</label>
                                    <asp:TextBox ID="TxtIdentidad" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <br />
                                    <label for="TxtNombre">
                                        Nombre Completo</label>
                                    <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control" autocomplete="off" />
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
                                    <br />
                                    <label for="TxtCargo">
                                        Cargo OP</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtCargo" runat="server">
                                        <asp:ListItem>Presidente/a</asp:ListItem>
                                        <asp:ListItem>Vicepresidente/a</asp:ListItem>
                                        <asp:ListItem>Secretario/a</asp:ListItem>
                                        <asp:ListItem>Tesorero/a</asp:ListItem>
                                        <asp:ListItem>Vocal 1</asp:ListItem>
                                        <asp:ListItem>Vocal 2</asp:ListItem>
                                        <asp:ListItem>Vocal 3</asp:ListItem>
                                        <asp:ListItem>socio</asp:ListItem>
                                        <asp:ListItem>No socio</asp:ListItem>
                                    </asp:DropDownList>
                                    <div id="Div2" runat="server" visible="false" class="alert alert-danger">
                                        <strong>Error!</strong>
                                        <asp:Label ID="Label3" runat="server" />
                                    </div>
                                </div>
                                <div class="modal-footer" style="text-align: center">
                                    <asp:Button ID="BGuardar4" Text="Guardar" Width="80px" runat="server" Class="btn btn-primary" />
                                    <asp:Button ID="BSalir4" Text="Salir" Width="80px" runat="server" Class="btn btn-primary" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="NoProdModalList" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
                        aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title" id="ModalTitle6">Listado productores no atendidos</h4>
                                </div>
                                <div class="modal-body">
                                    <br />
                                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:TConnODK3 %>" ProviderName="<%$ ConnectionStrings:TConnODK3.ProviderName %>"></asp:SqlDataSource>
                                    <asp:GridView ID="GridDatos5" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                        GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource5" Font-Size="Small" PageSize="150" PageIndex="0">
                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay prodcutores no atendidos registrados!  
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSeleccionar2" runat="server" />
                                                    <%--<asp:RadioButton ID="chkSeleccionar" runat="server" />--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IDENTIDAD" HeaderText="IDENTIDAD" />
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
                                    <div id="Div3" runat="server" visible="false" class="alert alert-danger">
                                        <strong>Error!</strong>
                                        <asp:Label ID="Label4" runat="server" />
                                    </div>
                                </div>
                                <div class="modal-footer" style="text-align: center">
                                    <asp:Button ID="BGuardar5" Text="Guardar" Width="80px" runat="server" Class="btn btn-primary" />
                                    <asp:Button ID="BSalir5" Text="Salir" Width="80px" runat="server" Class="btn btn-primary" />
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="EditModal3" tabindex="-1" role="dialog" aria-labelledby="ModalTitle"
                        aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        &times;</button>
                                    <h4 class="modal-title" id="ModalTitle7">Detalle del compromiso</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:TextBox ID="TxtID3" runat="server" Visible="False"></asp:TextBox>
                                    <%--<asp:CheckBox ID="CheckBox1" runat="server" Visible="False" />--%>
                                    <br />
                                    <label for="TxtNom2">
                                        Nombre del Productor</label>
                                    <asp:TextBox ID="TxtNom2" runat="server" ReadOnly="true" CssClass="form-control" autocomplete="off" />
                                    <%--<br />
                                    <label for="TxtClave2">
                                        Clave IHCAFE</label>
                                    <asp:TextBox ID="TxtClave2" runat="server" CssClass="form-control" autocomplete="off" />--%>
                                    <br />
                                    <label for="TxtRTN2">
                                        RTN</label>
                                    <asp:TextBox ID="TxtRTN2" runat="server" CssClass="form-control" autocomplete="off" />
                                    <br />
                                    <label for="TxtExport3">
                                        Exportador</label>
                                    <asp:TextBox ID="TxtExport3" runat="server" ReadOnly="true" CssClass="form-control" autocomplete="off" />
                                         <br />
                                    <label for="TxtTipo3">
                                        Variedad</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtTipo3" runat="server">
                                        <asp:ListItem>Criolla</asp:ListItem>
                                        <asp:ListItem>Amadeus</asp:ListItem>
                                        <asp:ListItem>Carrizalito</asp:ListItem>
                                        <asp:ListItem>Deorho</asp:ListItem>
                                        <asp:ListItem>Azabache</asp:ListItem>
                                        <asp:ListItem>Paraisito mejorado</asp:ListItem>
                                        <asp:ListItem>Honduras nutritivo</asp:ListItem>
                                        <asp:ListItem>Inta cardenas</asp:ListItem>
                                        <asp:ListItem>Otra</asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <label for="TxtComp3">
                                        QQ comprometidos</label>
                                    <asp:TextBox ID="TxtComp3" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
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
                                    <div id="Div4" runat="server" visible="false" class="alert alert-danger">
                                        <strong>Error!</strong>
                                        <asp:Label ID="Label5" runat="server" />
                                    </div>
                                </div>
                                <div class="modal-footer" style="text-align: center">
                                    <asp:Button ID="BGuardar6" Text="Guardar" Width="80px" runat="server" Class="btn btn-primary" />
                                    <asp:Button ID="BSalir6" Text="Salir" Width="80px" runat="server" Class="btn btn-primary" />
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="EditFin" tabindex="-1" role="dialog" aria-labelledby="ModalTitle"
                        aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        &times;</button>
                                    <h4 class="modal-title" id="ModalTitle8">Detalle del Financiamiento</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:TextBox ID="TxtID4" runat="server" Visible="False"></asp:TextBox>
                                    <asp:TextBox ID="TxtTabla" runat="server" Visible="False"></asp:TextBox>
                                    <%--<asp:CheckBox ID="CheckBox1" runat="server" Visible="False" />--%>
                                    <br />
                                    <label for="TxtNom3">
                                        Nombre del Productor</label>
                                    <asp:TextBox ID="TxtNom3" runat="server" ReadOnly="true" CssClass="form-control" autocomplete="off" />
                                    <br />
                                    <label for="TxtQQPROD">
                                        Area Total (MZ)</label>
                                    <asp:TextBox ID="TxtAreatotal" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <br />
                                    <label for="TxtQQPROD">
                                        Area Produccion (MZ)#</label>
                                    <asp:TextBox ID="TxtAreaproduccion" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <br />
                                    <label for="TxtQQPROD">
                                        Area Plantilla (MZ)#</label>
                                    <asp:TextBox ID="TxtAreaplantilla" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <br />
                                    <label for="TxtQQPROD">
                                        Produccion obtenida cosecha 18-19 QQPS#</label>
                                    <asp:TextBox ID="TxtQQPROD" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <br />
                                    <label for="TxtQQESTIM">
                                        Produccion estimada cosecha 19-20 QQPS#</label>
                                    <asp:TextBox ID="TxtQQESTIM" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <br />
                                    <label for="TxtQQFERT">
                                        QQ fertilizante plantilla</label>
                                    <asp:TextBox ID="TxtQQFERT" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <br />
                                    <label for="TxtQQFERT2">
                                        QQ fertilizante mantenimiento</label>
                                    <asp:TextBox ID="TxtQQFERT2" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <br />
                                    <label for="TxtQQFERT3">
                                        QQ fertilizante Pre-corte</label>
                                    <asp:TextBox ID="TxtQQFERT3" runat="server" CssClass="form-control" onkeypress="return numericOnly(this);" autocomplete="off" />
                                    <br />
                                    <label for="TxtGAN1">
                                        Garantia solidaria</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtGAN1" runat="server">
                                        <asp:ListItem>NO</asp:ListItem>
                                        <asp:ListItem>SI</asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <label for="TxtGAN2">
                                        Garantia prendaria</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtGAN2" runat="server">
                                        <asp:ListItem>NO</asp:ListItem>
                                        <asp:ListItem>SI</asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <label for="TxtGAN3">
                                        Garantia hipotecaria</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtGAN3" runat="server">
                                        <asp:ListItem>NO</asp:ListItem>
                                        <asp:ListItem>SI</asp:ListItem>
                                    </asp:DropDownList>
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
                                    <asp:Button ID="BGuardar7" Text="Guardar" Width="80px" runat="server" Class="btn btn-primary" />
                                    <asp:Button ID="BSalir7" Text="Salir" Width="80px" runat="server" Class="btn btn-primary" />
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <%--<div class="panel panel-default">--%>
                            <div id="Tabs" role="tabpanel">
                                <!-- Nav tabs -->
                                <ul class="nav nav-pills" data-tabs="tablist">
                                    <li><a href="#Productores2" aria-controls="Productores2" role="tab" data-toggle="tab">Productores MAS+</a></li>
                                    <li><a href="#OP2" aria-controls="OP2" role="tab" data-toggle="tab">OP</a></li>
                                    <li><a href="#ProductoresNo2" aria-controls="ProductoresNo2" role="tab" data-toggle="tab">Productores no atendidos</a></li>
                                </ul>
                                <!-- Tab panes -->
                                <div class="tab-content">
                                    <div role="tabpanel" class="tab-pane active" id="Productores2">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                COMPROMISOS PRODUCTORES MAS+
                                            </div>
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <div class="table-responsive">
                                                            <h3>
                                                                <span style="float: right;"><small># Productores:</small>
                                                                    <asp:Label ID="lblTotalClientes" runat="server" CssClass="label label-warning" /></span>
                                                            </h3>
                                                            <p>&nbsp;</p>
                                                            <p>&nbsp;</p>
                                                            <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TConnODK3 %>" ProviderName="<%$ ConnectionStrings:TConnODK3.ProviderName %>"></asp:SqlDataSource>
                                                            <asp:GridView ID="GridDatos" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                                                GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource1" Font-Size="Small">
                                                                <HeaderStyle BackColor="#8A4500" Font-Bold="True" ForeColor="White" />
                                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                                <EmptyDataTemplate>
                                                                    ¡No hay compromisos registrados!
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
                                                                    <asp:BoundField DataField="id">
                                                                        <HeaderStyle CssClass="hide" />
                                                                        <ItemStyle CssClass="hide" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Depto_Descripcion" HeaderText="DEPARTAMENTO" />
                                                                    <asp:BoundField DataField="ec_nombre" HeaderText="ENTRENADOR" />
                                                                    <asp:BoundField DataField="OP_NOMBRE" HeaderText="OP_NOMBRE" />
                                                                    <asp:BoundField DataField="COD_PRODUCTOR" HeaderText="COD_PRODUCTOR" />
                                                                    <asp:BoundField DataField="NOMBRE" HeaderText="NOM_PRODUCTOR" />
                                                                    <asp:BoundField DataField="EXPORTADOR" HeaderText="COMPRADOR" />
                                                                    <asp:BoundField DataField="VARIEDAD" HeaderText="VARIEDAD" />
                                                                    <asp:BoundField DataField="COMPROMISO" HeaderText="COMPROMISO" DataFormatString="{0:0.00}" />
                                                                    <asp:ButtonField ButtonType="Button" Text="+ Actualizar" ControlStyle-CssClass="btn btn-success" HeaderText="+ Compromisos" CommandName="AgregarComp">
                                                                        <ControlStyle CssClass="btn btn-success"></ControlStyle>
                                                                    </asp:ButtonField>
                                                                    <%--          <asp:BoundField DataField="FINAN_FERTILIZANTE" HeaderText="FERTILIZANTE" />
                                                                    <asp:ButtonField ButtonType="Button" Text="Financiamiento" ControlStyle-CssClass="btn btn-info" HeaderText="Financiamiento" CommandName="AgregarFin">
                                                                        <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                                                    </asp:ButtonField>--%>
                                                                    <asp:ButtonField ButtonType="Button" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" CommandName="Eliminar">
                                                                        <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                                                                    </asp:ButtonField>
                                                                </Columns>
                                                                <EditRowStyle BackColor="#7C6F57" />
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
                                                        <asp:Button ID="BAgregar" runat="server" class="btn btn-success" Text="Seleccionar productores" />
                                                    </div>
                                                </div>
                                                <div id="import" runat="server">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            ......
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            ......
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            Importar archivo de EXCEL
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
                                                            1.<asp:Button ID="BDescarga" runat="server" class="btn btn-warning" Text="Descargar formato" />
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            2.<asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
                                                            3.<asp:Button ID="BCarga" runat="server" class="btn btn-warning" Text="Cargar Excel" />
                                                        </div>
                                                    </div>
                                                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div role="tabpanel" class="tab-pane" id="OP2">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                COMPROMISOS ORGANIZACION
                                            </div>
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <div class="table-responsive">
                                                            <h3>
                                                                <span style="float: right;"><small># Compromisos:</small>
                                                                    <asp:Label ID="lblTotalClientes2" runat="server" CssClass="label label-warning" /></span>
                                                            </h3>
                                                            <p>&nbsp;</p>
                                                            <p>&nbsp;</p>
                                                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:TConnODK3 %>" ProviderName="<%$ ConnectionStrings:TConnODK3.ProviderName %>"></asp:SqlDataSource>
                                                            <asp:GridView ID="GridDatos3" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                                                GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource3" Font-Size="Small">
                                                                <HeaderStyle BackColor="#8A4500" Font-Bold="True" ForeColor="White" />
                                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                                <EmptyDataTemplate>
                                                                    ¡No hay compromisos registrados!
                                                                </EmptyDataTemplate>
                                                                <%--Paginador...--%>
                                                                <PagerTemplate>
                                                                    <div class="row" style="margin-top: 8px;">
                                                                        <div class="col-lg-1" style="text-align: right;">
                                                                            <h5>
                                                                                <asp:Label ID="MessageLabel2" Text="Ir a la pág." runat="server" /></h5>
                                                                        </div>
                                                                        <div class="col-lg-1" style="text-align: left;">
                                                                            <asp:DropDownList ID="PageDropDownList2" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="PageDropDownList2_SelectedIndexChanged" runat="server" CssClass="form-control" /></h3>
                                                                        </div>
                                                                        <div class="col-lg-10" style="text-align: right;">
                                                                            <h3>
                                                                                <asp:Label ID="CurrentPageLabel2" runat="server" CssClass="label label-warning" /></h3>
                                                                        </div>
                                                                    </div>
                                                                </PagerTemplate>
                                                                <Columns>
                                                                    <asp:BoundField DataField="id">
                                                                        <HeaderStyle CssClass="hide" />
                                                                        <ItemStyle CssClass="hide" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Depto_Descripcion" HeaderText="DEPARTAMENTO" />
                                                                    <asp:BoundField DataField="ec_nombre" HeaderText="ENTRENADOR" />
                                                                    <asp:BoundField DataField="OP_NOMBRE" HeaderText="OP_NOMBRE" />
                                                                    <asp:BoundField DataField="EXPORTADOR" HeaderText="COMPRADOR" />
                                                                    <asp:BoundField DataField="VARIEDAD" HeaderText="VARIEDAD" />
                                                                    <asp:BoundField DataField="COMPROMISO" HeaderText="COMPROMISO" DataFormatString="{0:0.00}" />
                                                                    <%--<script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>--%>
                                                                    <asp:ButtonField ButtonType="Button" Text="+ Actualizar" ControlStyle-CssClass="btn btn-success" HeaderText="+ Compromisos" CommandName="AgregarComp2">
                                                                        <ControlStyle CssClass="btn btn-success"></ControlStyle>
                                                                    </asp:ButtonField>
                                                                    <asp:ButtonField ButtonType="Button" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" CommandName="Eliminar2">
                                                                        <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                                                                    </asp:ButtonField>
                                                                </Columns>
                                                                <EditRowStyle BackColor="#7C6F57" />
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
                                                        <asp:Button ID="BAgregar2" runat="server" class="btn btn-success" Text="Agregar compromiso" />
                                                        `    
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div role="tabpanel" class="tab-pane" id="ProductoresNo2">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                COMPROMISOS PRODUCTORES NO ATENDIDOS
                                            </div>
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <div class="table-responsive">
                                                            <h3>
                                                                <span style="float: right;"><small># Compromisos:</small>
                                                                    <asp:Label ID="lblTotalClientes3" runat="server" CssClass="label label-warning" /></span>
                                                            </h3>
                                                            <p>&nbsp;</p>
                                                            <p>&nbsp;</p>
                                                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:TConnODK3 %>" ProviderName="<%$ ConnectionStrings:TConnODK3.ProviderName %>"></asp:SqlDataSource>
                                                            <asp:GridView ID="GridDatos4" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                                                GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource4" Font-Size="Small">
                                                                <HeaderStyle BackColor="#8A4500" Font-Bold="True" ForeColor="White" />
                                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                                <EmptyDataTemplate>
                                                                    ¡No hay compromisos registrados!
                                                                </EmptyDataTemplate>
                                                                <%--Paginador...--%>
                                                                <PagerTemplate>
                                                                    <div class="row" style="margin-top: 8px;">
                                                                        <div class="col-lg-1" style="text-align: right;">
                                                                            <h5>
                                                                                <asp:Label ID="MessageLabel3" Text="Ir a la pág." runat="server" /></h5>
                                                                        </div>
                                                                        <div class="col-lg-1" style="text-align: left;">
                                                                            <asp:DropDownList ID="PageDropDownList3" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="PageDropDownList3_SelectedIndexChanged" runat="server" CssClass="form-control" /></h3>
                                                                        </div>
                                                                        <div class="col-lg-10" style="text-align: right;">
                                                                            <h3>
                                                                                <asp:Label ID="CurrentPageLabel3" runat="server" CssClass="label label-warning" /></h3>
                                                                        </div>
                                                                    </div>
                                                                </PagerTemplate>
                                                                <Columns>
                                                                    <asp:BoundField DataField="id">
                                                                        <HeaderStyle CssClass="hide" />
                                                                        <ItemStyle CssClass="hide" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Depto_Descripcion" HeaderText="DEPARTAMENTO" />
                                                                    <asp:BoundField DataField="ec_nombre" HeaderText="ENTRENADOR" />
                                                                    <asp:BoundField DataField="OP_NOMBRE" HeaderText="OP_NOMBRE" />
                                                                    <asp:BoundField DataField="ID_PRODUCTOR" HeaderText="ID_PRODUCTOR" />
                                                                    <asp:BoundField DataField="NOMBRE" HeaderText="NOM_PRODUCTOR" />
                                                                    <asp:BoundField DataField="EXPORTADOR" HeaderText="COMPRADOR" />
                                                                   <asp:BoundField DataField="VARIEDAD" HeaderText="VARIEDAD" />
                                                                    <asp:BoundField DataField="COMPROMISO" HeaderText="COMPROMISO" DataFormatString="{0:0.00}" />
                                                                    <%--<script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>--%>
                                                                    <asp:ButtonField ButtonType="Button" Text="+ Actualizar" ControlStyle-CssClass="btn btn-success" HeaderText="+ Compromisos" CommandName="AgregarComp3">
                                                                        <ControlStyle CssClass="btn btn-success"></ControlStyle>
                                                                    </asp:ButtonField>
                                                                    <asp:ButtonField ButtonType="Button" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" CommandName="Eliminar3">
                                                                        <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                                                                    </asp:ButtonField>
                                                                </Columns>
                                                                <EditRowStyle BackColor="#7C6F57" />
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
                                                        <asp:Button ID="BAgregar3" runat="server" class="btn btn-success" Text="Seleccionar productores" />

                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        ......
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <asp:Button ID="BRegistrar" runat="server" class="btn btn-warning" Text="Registrar productores no atendidos" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--<asp:Button ID="Button1" Text="Submit" runat="server" CssClass="btn btn-primary" />--%>
                            <asp:HiddenField ID="TabName" runat="server" />
                            <%--</div>--%>
                            <script type="text/javascript">
                                $(function () {
                                    var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "Productores2";
                                    $('#Tabs a[href="#' + tabName + '"]').tab('show');
                                    $("#Tabs a").click(function () {
                                        $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                                    });
                                });
                            </script>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
