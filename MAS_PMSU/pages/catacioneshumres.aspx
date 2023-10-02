<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="catacioneshumres.aspx.vb" Inherits="MAS_PMSU.catacioneshumres" %>

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
                   REGISTRO DE ENTREGAS DE CAFE HUMEDO
                </div>
                <div class="panel-body">
                    <%--<form role="form" runat="server">--%>
                    <ul class="nav nav-pills">
                        <li class="active"><a href="#Datos" data-toggle="tab">Datos</a>
                        </li>
                        <%--<li><a href="#Graficos" data-toggle="tab">Graficos</a>
                        </li>--%>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane fade in active" id="Datos">
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
                                            <label>Seleccione Entrenador:</label>
                                            <asp:DropDownList CssClass="form-control" ID="TxtEntrenador" runat="server" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>Seleccione Organización:</label>
                                            <asp:DropDownList CssClass="form-control" ID="cmborganizacion" runat="server" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.row (nested) -->

                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="table-responsive">
                                            <h3>
                                                <span style="float: right;"><small>Total de Entregas:</small>
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
                                                    ¡No hay entregas humedo registradas!  
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
                                                    <asp:BoundField DataField="Id">
                                                        <HeaderStyle CssClass="hide" />
                                                        <ItemStyle CssClass="hide" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Depto_Descripcion" HeaderText="DEPARTAMENTO" />
                                                    <asp:BoundField DataField="Correlativo" HeaderText="CORRELATIVO" />
                                                    <asp:BoundField DataField="FECHA" HeaderText="FECHA" DataFormatString="{0:d}" />
                                                    <asp:BoundField DataField="Tipo" HeaderText="TIPO" />
                                                    <asp:BoundField DataField="OP_NOMBRE" HeaderText="OP_NOMBRE" />
                                                    <asp:BoundField DataField="COD_PRODUCTOR" HeaderText="COD_PRODUCTOR" />
                                                    <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                                                    <asp:BoundField DataField="SEXO" HeaderText="SEXO" />                                                   
                                                    <asp:BoundField DataField="Dano" HeaderText="% DAÑO" />
                                                    <asp:BoundField DataField="Humedad" HeaderText="% HUMEDAD" />
                                                    <asp:BoundField DataField="Apariencia" HeaderText="APARIENCIA" />
                                                    <asp:BoundField DataField="#_Sacos" HeaderText="# SACOS" />
                                                </Columns>
                                                <EditRowStyle BackColor="#7C6F57" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
                                        <asp:Button ID="BAgregar" runat="server" class="btn btn-success" Text="Entregas OP" />
                                        <asp:Button ID="BAgregar2" runat="server" class="btn btn-primary" Text="Entregas Productor" />
                                        <asp:TextBox ID="TxtID" runat="server" Visible="false"></asp:TextBox>
                                    </div>

                                </div>

                                <div class="row">
                                    <div class="col-lg-12">
                                        <%--<asp:Button ID="Button1" runat="server" Text="Exportar Datos" CssClass="btn btn-success" />--%>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning" Text="Exportar Datos"><span class="glyphicon glyphicon-save"></span>&nbsp;Exportar Datos</asp:LinkButton>
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
                        <div class="tab-pane fade" id="Graficos">
                            <div class="row">
                                <div class="col-lg-12">
                                    <%-- <div class="embed-responsive embed-responsive-16by9">
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
