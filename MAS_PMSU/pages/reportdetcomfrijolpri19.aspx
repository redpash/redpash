<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="reportdetcomfrijolpri19.aspx.vb" Inherits="MAS_PMSU.reportdetcomfrijolpri19" %>


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
                    REPORTE COMPROMISOS FRIJOL PRIMERA 2019
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div id="divexp" runat="server">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Seleccione Exportador:</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtExportador" runat="server" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <asp:TextBox ID="TxtIn" Visible="false" runat="server"></asp:TextBox>
                            </div>
                        </div>
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
                                        <asp:BoundField DataField="Depto_Descripcion" HeaderText="DEPARTAMENTO" />                                        
                                        <asp:BoundField DataField="COD_ORGANIZACION" HeaderText="COD_ORGANIZACION" />
                                        <asp:BoundField DataField="OP_NOMBRE" HeaderText="OP_NOMBRE" />
                                        <asp:BoundField DataField="REPRESENTANTE_NOMBRE" HeaderText="REPRESENTANTE" />
                                        <asp:BoundField DataField="COMPRADOR" HeaderText="COMPRADOR" />
                                        <asp:BoundField DataField="QQ" HeaderText="COMPROMISO" DataFormatString="{0:0.00}" />
                                        
                                    </Columns>
                                    <EditRowStyle BackColor="#7C6F57" />
                                </asp:GridView>
                            </div>
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
                </div>
            </div>
        </div>
    </div>
</asp:Content>
