<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="Ventas.aspx.vb" Inherits="MAS_PMSU.Ventas" EnableEventValidation="false"%>

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
                                    <asp:ListItem Text=" "></asp:ListItem>
                                    <asp:ListItem Text="Frijol"></asp:ListItem>
                                    <asp:ListItem Text="Maiz"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Seleccione Categoria:</label>
                                <asp:DropDownList CssClass="form-control" ID="DDL_Categ" runat="server" AutoPostBack="True">
                                    <asp:ListItem Text=" "></asp:ListItem>
                                    <asp:ListItem Text="Basica"></asp:ListItem>
                                    <asp:ListItem Text="Certificada"></asp:ListItem>
                                    <asp:ListItem Text="Registrada"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label></label><asp:Label ID="Label23" class="label label-warning" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Button CssClass="btn btn-primary" ID="Button3" runat="server" Text="Reiniciar" OnClick="limpiarFiltros" visible="true"/>
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
                                        <asp:BoundField DataField="Tipo_cultivo" HeaderText="CULTIVO" />
                                        <asp:BoundField DataField="CATEGORIA" HeaderText="CATEGORIA" />
                                        <asp:BoundField DataField="CICLO" HeaderText="CICLO" />
                                        <asp:BoundField DataField="VARIEDAD" HeaderText="VARIEDAD" />
                                        <asp:BoundField DataField="NOMBRE_LOTE_FINCA" HeaderText="NUMERO DE LOTE" />
                                        <asp:BoundField DataField="AREA_SEMBRADA_MZ" HeaderText="AREA INSCRITA EN MZ" />
                                        <asp:BoundField DataField="AREA_SEMBRADA_HA" HeaderText="AREA INSCRITA EN HA" />
                                        <asp:BoundField DataField="FECHA_SIEMBRA" HeaderText="FECHA DE SIEMBRA INSCRITA" />
                                        <asp:BoundField DataField="ESTIMADO_PRO_QQ_MZ" HeaderText="COSECHA INSCRITA EN MZ" />
                                        <asp:BoundField DataField="ESTIMADO_PRO_QQ_HA" HeaderText="COSECHA INSCRITA EN HA" />
                                        <%--<asp:BoundField DataField="Habilitado" HeaderText="HABILITADO" />--%>

                                        <asp:ButtonField ButtonType="Button" Text="+" ControlStyle-CssClass="btn btn-success" HeaderText="PRODUCCIÓN" CommandName="Editar">
                                            <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                        </asp:ButtonField>
<%--                                        <asp:TemplateField HeaderText="Check costo">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:ButtonField ButtonType="Button" Text="+" ControlStyle-CssClass="btn btn-danger" HeaderText="COSTOS" CommandName="Eliminar">
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
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>