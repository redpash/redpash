<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="reportcompromisosops19_20.aspx.vb" Inherits="MAS_PMSU.reportcompromisosops19_20" %>



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
                    SELECCION DE COMPROMISOS PARA FIRMA COSECHA 2019-2020 MAS+
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Seleccione Departamento:</label>
                                <asp:DropDownList CssClass="form-control" ID="TxtDepto" runat="server" AutoPostBack="True"></asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Seleccione Municipio:</label>
                                <asp:DropDownList CssClass="form-control" ID="TxtEntrenador" runat="server" AutoPostBack="True"></asp:DropDownList>

                            </div>
                        </div>
                        <div id="divexp" runat="server">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>Seleccione Exportador:</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtExportador" runat="server" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <asp:TextBox ID="TxtIn" Visible="false" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="table-responsive">
                                <h3>
                                    <span style="float: right;"><small># OP's:</small>
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
                                        ¡No hay compromisos de OP's registrados para firma!
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
                                        <asp:BoundField DataField="Muni_Descripcion" HeaderText="MUNICIPIO" />
                                        <asp:BoundField DataField="COD_ORGANIZACION" HeaderText="COD_ORGANIZACION" />
                                        <asp:BoundField DataField="OP_NOMBRE" HeaderText="OP_NOMBRE" />
                                        <asp:BoundField DataField="REPRESENTANTE_NOMBRE" HeaderText="REPRESENTANTE" />
                                        <asp:BoundField DataField="EXPORTADOR" HeaderText="EXPORTADOR" />
                                        <asp:BoundField DataField="COMPROMISO" HeaderText="COMPROMISO" DataFormatString="{0:0.00}" />
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
                            <asp:Button ID="BAgregar" runat="server" class="btn btn-success" Text="Seleccionar OP's" />
                        </div>
                    </div>
                    <div id="dexp" runat="server">
                        <div class="row">
                            <div class="col-lg-12">
                                ........
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-2">
                                Formato a imprimir:
                         <asp:DropDownList CssClass="form-control" ID="TxtTipo" runat="server">
                             <asp:ListItem>PDF</asp:ListItem>
                             <asp:ListItem>WORD</asp:ListItem>
                             <asp:ListItem>EXCEL</asp:ListItem>
                             <asp:ListItem>CSV</asp:ListItem>
                             <asp:ListItem>RTF</asp:ListItem>
                         </asp:DropDownList>
                            </div>
                            <div class="col-lg-12">
                                <asp:Button ID="BCargar" runat="server" class="btn btn-success" Text="Descargar" />
                            </div>
                        </div>
                    </div>                    
                    <div class="modal fade" id="ProdModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
                        aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title" id="ModalTitle3">Listado Organizaciones</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <label for="TxtDepto">
                                                Departamento</label>
                                            <asp:DropDownList CssClass="form-control" ID="TxtDepto2" runat="server" AutoPostBack="True" ClientIDMode="Predictable" OnSelectedIndexChanged="cambioindexdepto"></asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <br />
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <label for="TxtMuni2">
                                                Municipio</label>
                                            <asp:DropDownList CssClass="form-control" ID="TxtMuni2" runat="server" AutoPostBack="True" ClientIDMode="Predictable" OnSelectedIndexChanged="cambioindexmuni"></asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="TxtDepto2" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <br />
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TConnODK3 %>" ProviderName="<%$ ConnectionStrings:TConnODK3.ProviderName %>"></asp:SqlDataSource>
                                            <asp:GridView ID="GridDatos2" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                                GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource2" Font-Size="Small" PageSize="150" PageIndex="0">
                                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                <EmptyDataTemplate>
                                                    ¡No hay organizaciones registradas con compromisos o la organizacion ya fue seleccionada!  
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSeleccionar" runat="server" />
                                                            <%--<asp:RadioButton ID="chkSeleccionar" runat="server" />--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="COD_ORGANIZACION" HeaderText="COD_ORGANIZACION" />
                                                    <asp:BoundField DataField="OP_NOMBRE" HeaderText="OP_NOMBRE" />
                                                    <asp:BoundField DataField="REPRESENTANTE_NOMBRE" HeaderText="REPRESENTANTE" />
                                                    <asp:BoundField DataField="QQ_PS" HeaderText="COMPROMISOS" DataFormatString="{0:0.00}" />
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
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="TxtMuni2" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
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
                                    <asp:TextBox ID="TxtID" Visible="false" runat="server"></asp:TextBox>
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
        </div>
    </div>
</asp:Content>
