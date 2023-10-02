<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="Busquedacodigos.aspx.vb" Inherits="MAS_PMSU.Busquedacodigos" %>

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
                    BUSQUEDA DE CODIGO DE PRODUCTOR
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>CODIGO DE PRODUCTOR 1:</label>
                                <asp:TextBox ID="TxtCodigo" CssClass="form-control" autocomplete="off" runat="server"></asp:TextBox>
                            </div>
                        </div>
                          <div class="col-lg-4">
                            <div class="form-group">
                                <label>CODIGO DE PRODUCTOR 2:</label>
                                <asp:TextBox ID="TxtCodigo2" CssClass="form-control" autocomplete="off" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <asp:LinkButton ID="BBuscar" runat="server" CssClass="btn btn-success" Text="Exportar Datos"><span class="glyphicon glyphicon-search"></span>&nbsp;Buscar codigo</asp:LinkButton>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="table-responsive">
                                <h3>
                                    <span style="float: right;"><small># Registros productor 1:</small>
                                        <asp:Label ID="lblTotalClientes" runat="server" CssClass="label label-warning" /></span>
                                </h3>
                                <p>&nbsp;</p>
                                <p>&nbsp;</p>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TConnODK3 %>" ProviderName="<%$ ConnectionStrings:TConnODK3.ProviderName %>"></asp:SqlDataSource>
                                <asp:GridView ID="GridDatos" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                    GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource1" Font-Size="Small" PageSize="150">
                                    <HeaderStyle BackColor="#8A4500" Font-Bold="True" ForeColor="White" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay actividades registradas para el codigo de productor 1!
                                    </EmptyDataTemplate>
                                    <%--Paginador...--%>
                                    <PagerTemplate>
                                        <div class="row" style="margin-top: 8px;">
                                            <div class="col-lg-1" style="text-align: right;">
                                                <h5>
                                                    <asp:Label ID="MessageLabel2" Text="Ir a la pág." runat="server" /></h5>
                                            </div>
                                            <div class="col-lg-1" style="text-align: left;">
                                                <asp:DropDownList ID="PageDropDownList" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="PageDropDownList_SelectedIndexChanged" runat="server" CssClass="form-control" /></h3>
                                            </div>
                                            <div class="col-lg-10" style="text-align: right;">
                                                <h3>
                                                    <asp:Label ID="CurrentPageLabel2" runat="server" CssClass="label label-warning" /></h3>
                                            </div>
                                        </div>
                                    </PagerTemplate>
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                        <asp:BoundField DataField="TABLA" HeaderText="TABLA" />
                                        <asp:BoundField DataField="CAMPO" HeaderText="CAMPO" />
                                        <asp:BoundField DataField="BD" HeaderText="BD" />
                                        <asp:BoundField DataField="COD_PRODUCTOR" HeaderText="COD_PRODUCTOR" />
                                        <%--<asp:BoundField DataField="COMPROMISO" HeaderText="COMPROMISO" DataFormatString="{0:0.00}" />--%>
                                        <%--<script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>--%>
                                    </Columns>
                                    <EditRowStyle BackColor="#7C6F57" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-lg-12">
                            <div class="table-responsive">
                                <h3>
                                    <span style="float: right;"><small># Registros productor 2:</small>
                                        <asp:Label ID="lblTotalClientes2" runat="server" CssClass="label label-warning" /></span>
                                </h3>
                                <p>&nbsp;</p>
                                <p>&nbsp;</p>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TConnODK3 %>" ProviderName="<%$ ConnectionStrings:TConnODK3.ProviderName %>"></asp:SqlDataSource>
                                <asp:GridView ID="GridDatos2" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                    GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource2" Font-Size="Small" PageSize="250">
                                    <HeaderStyle BackColor="#8A4500" Font-Bold="True" ForeColor="White" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay actividades registradas para el codigo de productor 2!
                                    </EmptyDataTemplate>
                                    <%--Paginador...--%>
                                  <%--  <PagerTemplate>
                                        <div class="row" style="margin-top: 8px;">
                                            <div class="col-lg-1" style="text-align: right;">
                                                <h5>
                                                    <asp:Label ID="MessageLabel2" Text="Ir a la pág." runat="server" /></h5>
                                            </div>
                                            <div class="col-lg-1" style="text-align: left;">
                                                <asp:DropDownList ID="PageDropDownList" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="PageDropDownList_SelectedIndexChanged" runat="server" CssClass="form-control" /></h3>
                                            </div>
                                            <div class="col-lg-10" style="text-align: right;">
                                                <h3>
                                                    <asp:Label ID="CurrentPageLabel2" runat="server" CssClass="label label-warning" /></h3>
                                            </div>
                                        </div>
                                    </PagerTemplate>--%>
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                        <asp:BoundField DataField="TABLA" HeaderText="TABLA" />
                                        <asp:BoundField DataField="CAMPO" HeaderText="CAMPO" />
                                        <asp:BoundField DataField="BD" HeaderText="BD" />
                                        <asp:BoundField DataField="COD_PRODUCTOR" HeaderText="COD_PRODUCTOR" />
                                        <%--<asp:BoundField DataField="COMPROMISO" HeaderText="COMPROMISO" DataFormatString="{0:0.00}" />--%>
                                        <%--<script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>--%>
                                    </Columns>
                                    <EditRowStyle BackColor="#7C6F57" />
                                </asp:GridView>
                            </div>
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
        </div>
    </div>
</asp:Content>
