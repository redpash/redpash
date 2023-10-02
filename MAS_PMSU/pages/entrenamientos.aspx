<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="entrenamientos.aspx.vb" Inherits="MAS_PMSU.entrenamientos" %>
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
                    ENTRENAMIENTOS DE PRODUCTORES
                </div>
                <div class="panel-body">
                    <%--</form>--%>
                        <ul class="nav nav-pills">
                            <li class="active"><a href="#Datos" data-toggle="tab">Datos</a>
                            </li>
                            <li><a href="#Graficos" data-toggle="tab">Graficos</a>
                            </li>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane fade in active" id="Datos">
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
                                                <label>Seleccione Productor ECA:</label>
                                                <asp:DropDownList CssClass="form-control" ID="TxtEca" runat="server" AutoPostBack="True"></asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label>Seleccione Modulo:</label>
                                                <asp:DropDownList CssClass="form-control" ID="TxtModulo" runat="server" AutoPostBack="True"></asp:DropDownList>

                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.row (nested) -->

                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnODK %>" ProviderName="<%$ ConnectionStrings:ConnODK.ProviderName %>"></asp:SqlDataSource>
                                                <asp:GridView ID="GridDatos" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                                    GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" DataSourceID="SqlDataSource1" Font-Size="Small">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Depto_Descripcion" HeaderText="DEPARTAMENTO"
                                                            SortExpression="Depto_Descripcion" />
                                                        <asp:BoundField DataField="ec_nombre" HeaderText="ENTRENADOR"
                                                            SortExpression="ec_nombre" />
                                                        <asp:BoundField DataField="NOMBRE_MODULO" HeaderText="NOMBRE_MODULO" SortExpression="MODULO" />
                                                        <asp:BoundField DataField="FECHA_MODULO" HeaderText="FECHA"
                                                            SortExpression="FECHA_MODULO" />
                                                        <asp:BoundField DataField="CODIGO_ECA" HeaderText="CODIGO_ECA"
                                                            SortExpression="CODIGO_ECA" />
                                                        <asp:BoundField DataField="NOM_PRODUCTOR_ECA" HeaderText="NOM_PRODUCTOR_ECA"
                                                            SortExpression="NOM_PRODUCTOR_ECA" />
                                                        <asp:BoundField DataField="No_Entrenados" HeaderText="ENTRENADOS"
                                                            SortExpression="No_Entrenados" />
                                                    </Columns>
                                                    <EditRowStyle BackColor="#7C6F57" />
                                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
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
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <%--<asp:Button ID="Button1" runat="server" Text="Exportar Datos" CssClass="btn btn-success" />--%>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success" Text="Exportar Datos"><span class="glyphicon glyphicon-save"></span>&nbsp;Exportar Datos</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="Graficos">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="embed-responsive embed-responsive-16by9">
                                            <iframe class="embed-responsive-item" src="https://app.powerbi.com/view?r=eyJrIjoiZTM3MTMyMjEtY2U2YS00ZGZjLThiZGMtZDNkZDcwNDQ1ZDMzIiwidCI6ImM5NzU0NTExLTliODMtNGZmMi1iZmM4LTlkZmY2NzI1NTBmNSIsImMiOjR9" allowFullScreen="true"></iframe>
                                        </div>
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
