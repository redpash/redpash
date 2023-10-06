<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="InscripcionSENASA.aspx.vb" Inherits="MAS_PMSU.InscripcionSENASA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>

    <div id="divdatos" runat="server">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header"> Incripción SENASA</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Registros de Bancos Comunitarios de Semilla
                    </div>
                    <div class="panel-body">
                        <asp:TextBox CssClass="form-control" ID="Txt_Id_Eliminar" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>
                        <%--<form role="form" runat="server">--%>
                        <%--  <ul class="nav nav-pills">
                                    <li class="active"><a href="#Datos" data-toggle="tab">Datos</a>
                                    </li>
                                    <%--<li><a href="#Graficos" data-toggle="tab">Graficos</a>
                        </li>--%>
                        <%--</ul>--%>
                        <div class="tab-content">
                            <div class="tab-pane fade in active" id="Datos">
                                <div class="panel-body">

                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Seleccione asesor:</label>

                                                <asp:DropDownList CssClass="form-control" ID="TxtEntrenador" runat="server" AutoPostBack="True"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Seleccione Departamento:</label>
                                                <asp:DropDownList CssClass="form-control" ID="TxTdepto" runat="server" AutoPostBack="True"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Seleccione Tipo banco:</label>
                                                <asp:DropDownList CssClass="form-control" ID="cmborganizacion" runat="server" AutoPostBack="True"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- /.row (nested) -->

                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                <h3>
                                                    <span style="float: right;"><small># Bancos comunitarios:</small>
                                                        <asp:Label ID="LabelTot" runat="server" CssClass="label label-primary" /></span>
                                                </h3>
                                                <p>&nbsp;</p>
                                                <p>&nbsp;</p>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conn_REDPASH %>" ProviderName="<%$ ConnectionStrings:conn_REDPASH.ProviderName %>"></asp:SqlDataSource>
                                                <asp:GridView ID="GridDatos" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                                    GridLines="None" AllowPaging="True" AutoGenerateColumns="False" PageSize="8"   CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource1" Font-Size="Small">
                                                    <FooterStyle BackColor="#40E0D0" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#40E0D0" Font-Bold="True" ForeColor="White" />
                                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                    <EmptyDataTemplate>
                                                        ¡No hay organizaciones bancos!
                                                    </EmptyDataTemplate>
                                                    <%--Paginador...--%>
                                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                    <PagerTemplate>
                                                        <div class="row" style="margin-top: 8px;">
                                                            <div class="col-lg-1" style="text-align: right;">
                                                                <h5>
                                                                    <asp:Label ID="MsgL" Text="Ir a la pág." runat="server" /></h5>
                                                            </div>
                                                            <div class="col-lg-1" style="text-align: left;">
                                                                <asp:DropDownList ID="CmbPage" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="CmbPage_SelectedIndexChanged" runat="server" CssClass="form-control" /></h3>
                                                            </div>
                                                            <div class="col-lg-10" style="text-align: right;">
                                                                <h3>
                                                                    <asp:Label ID="PagActual" runat="server" CssClass="label label-primary" /></h3>
                                                            </div>
                                                        </div>
                                                    </PagerTemplate>
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="id">
                                                            <HeaderStyle CssClass="hide" />
                                                            <ItemStyle CssClass="hide" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ec_nombre" HeaderText="ASESOR" />
                                                        <asp:BoundField DataField="Depto_Descripcion" HeaderText="DEPARTAMENTO" />
                                                        <asp:BoundField DataField="FECHA_REGISTRO" HeaderText="FECHA REGISTRO" />
                                                        <asp:BoundField DataField="TIPO_BCS" HeaderText="TIPO REGISTRO" />
                                                        <asp:BoundField DataField="COD_BCS" HeaderText="CODIGO BANCO" />
                                                        <asp:BoundField DataField="Nombre_concat" HeaderText="NOMBRE/ ORG" />

                                                        <asp:BoundField DataField="Cuenta_Bancaria" HeaderText="TIENE CUENTA BANCARIA" />
                                                        <asp:BoundField DataField="Experiencia_Produccion" HeaderText="EXPERIENCIA EN PRODUCCION" />
                                                        <asp:BoundField DataField="Esta_Asociado" HeaderText="ESTA ASOCIADO" />
                                                        <asp:BoundField DataField="Tiempo_Experiencia" HeaderText="AÑOS DE EXPERIENCIA" />

                                                        <asp:ButtonField ButtonType="Button" Text="Actualizar" ControlStyle-CssClass="btn btn-info" HeaderText="Actualizar" CommandName="Actualizar">
                                                            <ControlStyle CssClass="btn btn-warning"></ControlStyle>
                                                        </asp:ButtonField>

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
                                        <div id="divExportaciones" runat="server">

                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <h1 class="page-header"></h1>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="panel panel-primary">
                                                        <div class="panel-heading">
                                                            Exportar a Excell
                                                        </div>
                                                        <div class="panel-body">
                                                            <div>
                                                                <div class="row">
                                                                    <div class="col-lg-12">

                                                                        <asp:Button ID="Button10" runat="server" CssClass="btn btn-warning" Text="Exportar a Excel" OnClick="ExportarExceelOrg_Click" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <asp:TextBox ID="tns" runat="server" Visible="false"></asp:TextBox>
                                            <%--<asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Exportar Datos" />--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="Graficos">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="embed-responsive embed-responsive-16by9">
                                            <%--<iframe class="embed-responsive-item" src="https://app.powerbi.com/view?r=eyJrIjoiZWM4MWI1YTEtMjE0NC00MDBmLTk2NTItNDlkZjI1YjJhNDgyIiwidCI6ImM5NzU0NTExLTliODMtNGZmMi1iZmM4LTlkZmY2NzI1NTBmNSIsImMiOjR9" allowfullscreen="true"></iframe>--%>
                                            <iframe width="800" height="600" src="https://app.powerbi.com/view?r=eyJrIjoiMThlMjc3M2EtNzY1Ny00ZjVkLTk2ZWItNTk1NDBhMmFhZjU3IiwidCI6ImVhOGEzNmMwLTczOGItNGNiNC05MzhjLTY5YTUwNWJiNjg5OCIsImMiOjF9" frameborder="0" allowfullscreen="true"></iframe>
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

    </div>

    <%--DESDE AQUI NUEVO FORMULARIO--%>

    <div class="modal fade" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Red Pash</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ¿Está seguro que desea actualizar el registro de la Organización?
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnsiActualizarOrg" class="btn btn-primary" runat="server" Text="SI" />

                    <button type="button" class="btn btn-danger" data-dismiss="modal">NO</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="exampleModaIndividual" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabelIndividual">Red Pash</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ¿Está seguro que desea actualizar el registro de la Organización?
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnsiActualizarIn" class="btn btn-primary" runat="server" Text="SI" />

                    <button type="button" class="btn btn-danger" data-dismiss="modal">NO</button>
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="lblMensajeError" runat="server" CssClass="error-message" Visible="false"></asp:Label>

    <%--   boton exportar--%>
    <%--        <div id="divexportar" runat="server">

                <div class="row">
                    <div class="col-lg-12">
                                        <br />
                                        <asp:Button ID="Button6" runat="server" CssClass="btn btn-primary" Text="Exportar a Excel" OnClick="Button1_Click" />
                                   </div>
                            </div>
                    </div>--%>
</asp:Content>