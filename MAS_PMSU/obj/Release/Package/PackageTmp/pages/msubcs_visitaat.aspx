<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="msubcs_visitaat.aspx.vb" Inherits="MAS_PMSU.msubcs_visitaat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header"></h1>
        </div>
    </div>

    <div id="divgrid" runat="server">
    <div class="row">


        <asp:TextBox ID="TxtID" Visible="false" runat="server"></asp:TextBox>
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    VISITAS DE ASISTENCIA TECNICA A BCS
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Seleccione Ciclo:</label>
                                <asp:DropDownList CssClass="form-control" ID="TxtCiclo" runat="server" AutoPostBack="True"></asp:DropDownList>
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
                                    <label>Seleccione el Mes:</label>
                                    <asp:DropDownList CssClass="form-control" ID="TxtMes" runat="server" visible="true" AutoPostBack="True">
                                        <asp:ListItem>Todos</asp:ListItem>
                                        <asp:ListItem>Enero</asp:ListItem>
                                        <asp:ListItem>Febrero</asp:ListItem>
                                        <asp:ListItem>Marzo</asp:ListItem>
                                        <asp:ListItem>Abril</asp:ListItem>
                                        <asp:ListItem>Mayo</asp:ListItem>
                                        <asp:ListItem>Junio</asp:ListItem>
                                        <asp:ListItem>Julio</asp:ListItem>
                                        <asp:ListItem>Agosto</asp:ListItem>
                                        <asp:ListItem>Septiembre</asp:ListItem>
                                        <asp:ListItem>Octubre</asp:ListItem>
                                        <asp:ListItem>Noviembre</asp:ListItem>
                                        <asp:ListItem>Diciembre</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                       


                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Seleccione productor:</label>
                                <asp:DropDownList CssClass="form-control" ID="txt_productor" runat="server" AutoPostBack="True"></asp:DropDownList>

                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="table-responsive">
                                <h3>
                                    <span style="float: right;"><small># Visitas:</small>
                                        <asp:Label ID="lblTotalClientes" runat="server" CssClass="label label-warning" /></span>
                                </h3>
                                <p>&nbsp;</p>
                                <p>&nbsp;</p>
                                <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MConnODK4 %>" ProviderName="<%$ ConnectionStrings:MConnODK4.ProviderName %>"></asp:SqlDataSource>
                                <asp:GridView ID="GridDatos" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                                    GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataSourceID="SqlDataSource1" Font-Size="Small">
                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay visitas registradas!  
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
                                       
                                          <asp:BoundField DataField="Id">
                                                <HeaderStyle CssClass="hide" />
                                                <ItemStyle CssClass="hide" />
                                            </asp:BoundField>
                                        <asp:BoundField DataField="Depto_Descripcion" HeaderText="DEPARTAMENTO" />
                                        <asp:BoundField DataField="ec_nombre" HeaderText="TECNICO" />
                                        <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />  
                                        <asp:BoundField DataField="FECHAVISITA" HeaderText="FECHA VISITA" DataFormatString="{0:d}" />                                      
                                        <asp:BoundField DataField="CICLO" HeaderText="CICLO" />
                                        <asp:BoundField DataField="ETAPA" HeaderText="ETAPA" />                                   
                                         <asp:BoundField DataField="Estado" HeaderText="Estado" />    
                                                             <asp:ButtonField ButtonType="Button" Text="Revisar" ControlStyle-CssClass="btn btn-success" HeaderText="REVISAR" CommandName="Revisar" />
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
                    <div class="row">
                        <div class="col-lg-12">
                            <%--<asp:Button ID="Button1" runat="server" Text="Exportar Datos" CssClass="btn btn-success" />--%>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning" Text="Exportar Datos"><span class="glyphicon glyphicon-save"></span>&nbsp;Exportar Datos</asp:LinkButton>
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

                </div>
            </div>
        </div>
    </div>

         </div>
















      <div id="divedit" runat="server">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header"></h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        DETALLE DE LA ASISTENCIA
                    </div>
                    <div class="panel-body">


                        <div class="row">
                            <div class="col-lg-12">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <label>DATOS GENERALES</label>
                                    </div>
                                    <div class="panel-body">

                                        <div class="row">
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>DEPARTAMENTO:</label>
                                                    <asp:TextBox ID="TxtDeptoDet" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                     <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>ENTRENADOR:</label>
                                                    <asp:TextBox ID="TxtEntrenadorDet" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>CICLO:</label>
                                                    <asp:TextBox ID="TxtOrgDet" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                   
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>PRODUCTOR :</label>
                                                    <asp:TextBox ID="TxtProductor" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>FECHA DE ENVIO:</label>
                                                    <asp:TextBox ID="TxtFechaEnvio" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>FECHA DE VISITA:</label>
                                                    <asp:TextBox ID="TxtFechaVisita" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>



                      







         




                       








                        <div class="row">
                            <div class="col-lg-12">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                       Datos de la vista
                                    </div>
                                    <div class="panel-body">

                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>#_VISITAS:</label>
                                                    <asp:TextBox ID="Txtnumerovisita" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>ETAPA</label>
                                                    <asp:TextBox ID="Txtetapa" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>



                        <div class="row">
                            <div class="col-lg-12">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Fotos Respaldo
                                    </div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>Detalle:</label>
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="GridDatos2" runat="server" CellPadding="4" ForeColor="#333333" Width="100%" PageSize="150"
                                                            GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" Font-Size="Small">
                                                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                            <EmptyDataTemplate>
                                                                ¡No hay archivos cargados!
                                                            </EmptyDataTemplate>
                                                            <AlternatingRowStyle BackColor="White" />
                                                            <Columns>

                                                                <asp:BoundField DataField="Id">
                                                                    <HeaderStyle CssClass="hide" />
                                                                    <ItemStyle CssClass="hide" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Archivo" HeaderText="Nombre del Archivo" />
                                                                <asp:BoundField DataField="Path">
                                                                    <HeaderStyle CssClass="hide" />
                                                                    <ItemStyle CssClass="hide" />
                                                                </asp:BoundField>
                                                                <asp:ButtonField ButtonType="Button" Text="Descargar" ControlStyle-CssClass="btn btn-success" HeaderText="Descargar" CommandName="Descargar"></asp:ButtonField>
                                                                <asp:ButtonField ButtonType="Button" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" CommandName="Eliminar"></asp:ButtonField>
                                                                <%--  <asp:BoundField DataField="Text" HeaderText="Nombre del Archivo" />
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkDownload" Text="Download" CommandArgument='<%# Eval("Value") %>' runat="server" OnClick="DownloadFile"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkDelete" Text="Delete" CommandArgument='<%# Eval("Value") %>' runat="server" OnClick="DeleteFile" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>--%>
                                                            </Columns>
                                                            <EditRowStyle BackColor="#7C6F57" />
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
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <asp:FileUpload ID="FileUpload1" CssClass="form-control" multiple="true" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-12">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Observaciones del Asesor
                                    </div>
                                    <div class="panel-body">

                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>Seleccione un estado:</label>
                                                    <asp:DropDownList CssClass="form-control" ID="TxtEstado" runat="server">
                                                        <asp:ListItem>En revision</asp:ListItem>
                                                        <asp:ListItem>Aprobada</asp:ListItem>
                                                        <asp:ListItem>Rechazada</asp:ListItem>
                                                        <asp:ListItem>N/A</asp:ListItem>

                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <label>Observaciones:</label>
                                                    <asp:TextBox ID="TxtObservaciones" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" Style="resize: none"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <asp:Button ID="BGuardar" Text="Guardar" Width="80px" runat="server" Class="btn btn-primary" />
                                <asp:Button ID="BSalir" Text="Cancelar" Width="80px" runat="server" Class="btn btn-danger" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

                 <div class="modal fade" id="DeleteModal19" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="ModalTitle212">MAS 2.0 - TNS</h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="modal-footer" style="text-align: center">
                        <asp:Button ID="Button4" Text="Aceptar" Width="80px" runat="server" Class="btn btn-primary" />
      
                    </div>
                </div>
            </div>
        </div>
    




        </div>
       <div class="modal fade" id="DeleteModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle2"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="ModalTitle2">MAS 2.0 - TNS</h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="modal-footer" style="text-align: center">
                        <asp:Button ID="Button1" Text="Aceptar" Width="80px" runat="server" Class="btn btn-primary" />
                   
                    </div>
                </div>
            </div>
        </div>
    
 </div>

































</asp:Content>
