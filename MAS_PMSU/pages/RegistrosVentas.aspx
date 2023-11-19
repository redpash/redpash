<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="RegistrosVentas.aspx.vb" Inherits="MAS_PMSU.RegistrosVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <div class="col-lg-12">
        <h1 class="page-header">Registros ventas</h1>
    </div>
</div>
<div id="panelmasiso" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Ventas
                </div>
                <div class="panel-body">
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
                                        <asp:BoundField DataField="id">
                                        <HeaderStyle CssClass="hide" />
                                        <ItemStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="comprador_cc_ventas" HeaderText="COMPRADOR" />
                                    <asp:BoundField DataField="QQ_semilla_cc_ventas" HeaderText="QQ SEMILLA CERTIFICADA/COMERCIAL" />
                                    <asp:BoundField DataField="QQ_semilla_precio_cc_venta" HeaderText="PRECIO CERTIFICADA/COMERCIAL" />
                                    <asp:BoundField DataField="ingreso_total_cc_ventas" HeaderText="TOTAL CERTIFICADA/COMERCIAL" />
                                    <asp:BoundField DataField="QQ_semilla_cc_consumo" HeaderText="QQ CONSUMO SEMILLA" />
                                    <asp:BoundField DataField="QQ_semilla_precio_cc_consumo" HeaderText="PRECIO SEMILLA CONSUMO" />
                                    <asp:BoundField DataField="ingreso_total_cc_consumo" HeaderText="TOTAL SEMILLA CONSUMO" />
                                    <asp:BoundField DataField="QQ_grano_humano_snc_ventas" HeaderText="QQ GRANO " />
                                    <asp:BoundField DataField="QQ_grano_humano_precio_snc_ventas" HeaderText="PRECIO GRANO" />
                                    <asp:BoundField DataField="ingreso_total_snc_ventas" HeaderText="TOTAL GRANO" />
                                    <asp:BoundField DataField="QQ_grano_snc_consumo" HeaderText="QQ CONSUMO GRANO" />
                                    <asp:BoundField DataField="QQ_grano_precio_snc_consumo" HeaderText="PRECIO GRANO CONSUMO" />
                                    <asp:BoundField DataField="ingreso_total_snc_consumo" HeaderText="TOTAL GRANO CONUSMO" />                            
                                       
                                    <asp:ButtonField ButtonType="Button" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" CommandName="Eliminar">
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

    <div class="row">
        <div class="col-lg-12">

                <div class="panel-body">

                    <div class="row">
                        <div class="auto-style3">
                            <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
                            <div id="div_guardar" runat="server">
                                <%--       <asp:Button ID="Guardar_registro"  class="btn btn-success" runat="server" Text="Guardar"  data-toggle="modal" data-target="#exampleModal2" />--%>
                                <button type="button" id="Guardar_registro" runat="server" class="btn btn-success" data-toggle="modal" data-target="#exampleModal2" visible="false">Guardar</button>
                                <asp:Button ID="Cancelar" class="btn btn-danger" runat="server" Text="Regresar" Visible="false"/>
                            </div>
                            <div class="modal fade" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="exampleModalLabela">MAS 2.0 - TNS</h5>

                                        </div>
                                        <div class="modal-body">¿Está seguro que sea ingresar el registro de venta?</div>
                                        <div class="modal-footer">
                                            <asp:Button ID="btn_si" Text="SI" Width="80px" runat="server" Class="btn btn-primary" />
                                            <button type="button" class="btn btn-danger" width="80px" data-dismiss="modal">NO</button>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div id="dived" runat="server">
                                
                                <asp:Button ID="Cancelar_edit" class="btn btn-danger" runat="server" Text="Salir" Visible="true"/>
                            </div>
                            <br />
                            <br />
                            <asp:Label ID="lb_error" class="badge badge-pill badge-success" runat="server" Text=""></asp:Label>

                            <!-- Modal -->
                            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="exampleModalLabel">MAS 2.0 - TNS</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            ¿Está seguro que desea actualizar el registro de venta?
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button ID="SI_editar" class="btn btn-success" runat="server" Text="SI" />
                                            <button type="button" class="btn btn-danger" data-dismiss="modal">NO</button>
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
</asp:Content>
