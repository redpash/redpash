<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="SolicitudInscripcionDeLotes.aspx.vb" Inherits="MAS_PMSU.SolicitudInscripcionDeLotes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>    
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header"> Solicitud de Inscripción de Lotes</h1>
        </div>
    </div>

    <div class="row">

        <div class="panel panel-primary">
            <div class="panel-heading">
                A. DATOS GENERALES DEL REPRESENTANTE
            </div>

            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Nombre Del Productor </label>
                            <asp:Label ID="lb_nombre_new" class="label label-warning" runat="server" Text=""></asp:Label>
                            <div class="form-container" style=" position: relative;width: 100%;height: auto;">
                                <asp:TextBox CssClass="form-control" ID="txt_nombre_prod_new" runat="server" AutoPostBack="false" OnTextChanged="VerificarTextBox" style="width: 90%;position: absolute;top: 0;left: 0;z-index: 1;border-right: 0;"></asp:TextBox>
                                <asp:DropDownList CssClass="form-control" ID="DropDownList7" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" style="position: relative;z-index: 0;"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label for="txtNombreFinca">Lotes registrados previamente:</label>
                            <asp:DropDownList CssClass="form-control" ID="DDL_Nlote" runat="server" AutoPostBack="true">
                                <asp:ListItem Text=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-lg-3">
                        <asp:Button CssClass="btn btn-primary" ID="btnbuscarProductor" runat="server" Text="Nuevo Lote" OnClick="buscar_productor"/>
                        <asp:Button CssClass="btn btn-primary" ID="btnNuevoProductor" runat="server" Text="Agregar Productor" />
                    </div>
                </div>

                <div class="row" id="PanelA1" runat="server" visible="false">
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Representante Legal</label><asp:Label ID="LB_RepresentanteLegal" class="label label-warning" runat="server" Text=""></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="Txt_Representante_Legal" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>Cedula de Identidad</label><asp:Label ID="Lb_CedulaIdentidad" class="label label-warning" runat="server" Text=""></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="TxtIdentidad" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox" onkeypress="return numericOnly(this);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>Extendida En :</label><asp:Label ID="Label1" class="label label-warning" runat="server" Text=""></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="TextBox1" TextMode="date" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Residencia</label><asp:Label ID="LbResidencia" class="label label-warning" runat="server" Text=""></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="TxtResidencia" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>Telefono</label><asp:Label ID="LblTelefono" class="label label-warning" runat="server" Text=""></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="TxtTelefono" runat="server" AutoPostBack="true" MaxLength="9" OnTextChanged="VerificarTextBox" onkeypress="return numericOnly(this);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>No. De Registro de Productor</label><asp:Label ID="LbNoRegistro" class="label label-warning" runat="server" Text=""></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="txtNoRegistro" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row" id="PanelA2" runat="server" visible="false">
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Nombre del Multiplicador o Reproductor:</label><asp:Label ID="lbNombreRe" class="label label-warning" runat="server" Text=""></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="txtNombreRe" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>Identidad del Multiplicador:</label><asp:Label ID="lbIdentidadRe" class="label label-warning" runat="server" Text=""></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="txtIdentidadRe" runat="server" AutoPostBack="true" MaxLength="13" OnTextChanged="VerificarTextBox" onkeypress="return numericOnly(this);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>Telefono del Multiplicador:</label><asp:Label ID="LbTelefonoRe" class="label label-warning" runat="server" Text=""></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="TxtTelefonoRe" runat="server" AutoPostBack="true" MaxLength="8" OnTextChanged="VerificarTextBox" onkeypress="return numericOnly(this);"></asp:TextBox>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <div class="row" id="PanelB" runat="server" visible="false">

        <div class="panel panel-primary">
            <div class="panel-heading">
                B. UBICACION GEOGRAFICA
            </div>

            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>Nombre De la finca </label>
                            <asp:Label ID="LblNombreFinca" class="label label-warning" runat="server" Text=""></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="TxtNombreFinca" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox"></asp:TextBox>
                        </div>
                    </div>

                    <section id="todoDeptos" runat="server">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Departamento</label>
                                <asp:Label ID="lb_dept_new" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="txtCodDep" runat="server" AutoPostBack="true" ReadOnly="true" Visible="false"></asp:TextBox>
                                <asp:DropDownList CssClass="form-control" ID="gb_departamento_new" runat="server" AutoPostBack="True" OnSelectedIndexChanged="VerificarTextBox">
                                    <asp:ListItem Text=" "></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Municipio</label><asp:Label ID="lb_mun_new" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="TxtCodMun" runat="server" AutoPostBack="true" ReadOnly="true" Visible="false"></asp:TextBox>
                                <asp:DropDownList CssClass="form-control" ID="gb_municipio_new" runat="server" AutoPostBack="True" OnSelectedIndexChanged="VerificarTextBox">
                                    <asp:ListItem Text=" "></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Aldea</label>
                                <asp:Label ID="lb_aldea_new" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="gb_aldea_new" runat="server" AutoPostBack="True" OnSelectedIndexChanged="VerificarTextBox">
                                    <asp:ListItem Text=" "></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Caserio</label>
                                <asp:Label ID="lb_caserio_new" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="gb_caserio_new" runat="server" AutoPostBack="True" OnSelectedIndexChanged="VerificarTextBox">
                                    <asp:ListItem Text=" "></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </section>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>Encargado de la finca</label><asp:Label ID="LblPersonaFinca" class="label label-warning" runat="server" Text=""></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="TxtPersonaFinca" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>Nombre o numero de Lote</label><asp:Label ID="LbLote" class="label label-warning" runat="server" Text=""></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="TxtLote" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>Croquis del Lote</label>
                            <asp:Label ID="Label5" class="label label-warning" runat="server" Text=""></asp:Label>
                            <asp:Label ID="Label25" runat="server" Text="" class="label label-warning" Visible="false">Solo archivos PNG/JPG/JPEG se aceptan</asp:Label>
                            <!-- Agrega el control FileUpload para cargar una imagen -->
                            <asp:FileUpload ID="fileUpload" runat="server" PostBackUrl="SolicitudInscripcionDeLotes.aspx" accept=".png,.jpg,.jpeg"/>
                        </div>
                    </div>
                </div>
                

            </div>
        </div>
    </div>
    

    <asp:UpdatePanel runat="server" ID="Updatepanel666"> 
        <ContentTemplate>
            <div class="row" id="PanelC" runat="server" visible="false">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        C. ORIGEN DE LA SEMILLA A SEMBRAR
                    </div>

                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Cultivo</label><asp:Label ID="Label2" class="label label-warning" runat="server" Text=""></asp:Label>
                                      <asp:DropDownList CssClass="form-control" ID="CmbTipoSemilla" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CmbTipoSemilla_SelectedIndexChanged">
                                       <asp:ListItem Text=""></asp:ListItem>
                                       <asp:ListItem id="frijol" Text="Frijol"></asp:ListItem>
                                       <asp:ListItem id="maiz" Text="Maiz"></asp:ListItem>
                                     </asp:DropDownList>
                                </div>
                            </div>

                            <section id="Section1" runat="server">
                                <div class="col-lg-3" id="VariedadFrijol" runat="server" Visible="false">
                                    <div class="form-group">
                                        <div class="form-group">
                                            <label>Variedad Frijol</label>
                                            <asp:Label ID="Label3" class="label label-warning" runat="server" Text=""></asp:Label>
                                            <asp:DropDownList CssClass="form-control" ID="DropDownList5" runat="server" AutoPostBack="true" OnSelectedIndexChanged="VerificarTextBox">
                                                <asp:ListItem Text=""></asp:ListItem>
                                                <asp:ListItem id="Amadeus77v1" Text="Amadeus-77"></asp:ListItem>
                                                <asp:ListItem id="Carrizalitov1" Text="Carrizalito"></asp:ListItem>
                                                <asp:ListItem id="Azabachev1" Text="Azabache"></asp:ListItem>
                                                <asp:ListItem id="Paraisitomejoradov1" Text="Paraisito mejorado PM-2"></asp:ListItem>
                                                <asp:ListItem id="Deorhov1" Text="Deorho"></asp:ListItem>
                                                <asp:ListItem id="IntaCardenasv1" Text="Inta Cárdenas"></asp:ListItem>
                                                <asp:ListItem id="Lencaprecozv1" Text="Lenca precoz"></asp:ListItem>
                                                <asp:ListItem id="Rojochortív1" Text="Rojo chortí"></asp:ListItem>
                                                <asp:ListItem id="Tolupanrojov1" Text="Tolupan rojo"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-3" id="VariedadMaiz" runat="server" Visible="false">
                                    <div class="form-group">
                                        <label>Variedades Maiz</label><asp:Label ID="Label4" class="label label-warning" runat="server" Text=""></asp:Label>
                                        <asp:DropDownList CssClass="form-control" ID="DropDownList6" runat="server" AutoPostBack="true" OnSelectedIndexChanged="VerificarTextBox">
                                            <asp:ListItem  Text=""></asp:ListItem>
                                            <asp:ListItem id="DictaMayav1" Text="Dicta Maya"></asp:ListItem>
                                            <asp:ListItem id="DictaVictoriav1" Text="Dicta Victoria"></asp:ListItem>
                                            <asp:ListItem id="OtroMaizv1" Text="Otro"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </section>
          
                            <div class="col-lg-3">
                                <div class="form-group">

                                    <label>Productor</label><asp:Label ID="Label22" class="label label-warning" runat="server" Text=""></asp:Label>

                                    <asp:TextBox CssClass="form-control" ID="txtprodsem" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">

                                    <label>Lote No.</label><asp:Label ID="Label8" class="label label-warning" runat="server" Text=""></asp:Label>

                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Fecha de Analisis</label><asp:Label ID="Label9" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" TextMode="date" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Año de Producción </label>
                                    <asp:Label ID="Label10" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox" onkeypress="return numericOnly(this);"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>       
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel runat="server" ID="Updatepanel1"> 
        <ContentTemplate>
            <div class="row"  id="PanelD" runat="server" visible="false">

            <div class="panel panel-primary">
                <div class="panel-heading">
                    D. SEMILLA A PRODUCIR
                </div>

                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Categoria</label><asp:Label ID="Label6" class="label label-warning" runat="server" Text=""></asp:Label>
                                  <asp:DropDownList CssClass="form-control" ID="DdlCategoria" runat="server" AutoPostBack="true" OnSelectedIndexChanged="VerificarTextBox">
                                   <asp:ListItem Text=""></asp:ListItem>
                                   <asp:ListItem id="basica" Text="Basica"></asp:ListItem>
                                   <asp:ListItem id="registrada" Text="Registrada"></asp:ListItem>
                                   <asp:ListItem id="certificada" Text="Certificada"></asp:ListItem>
                                 </asp:DropDownList>
                            </div>
                        </div>

                        <section id="Section3" runat="server">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <div class="form-group">
                                        <label>Tipo</label>
                                        <asp:Label ID="Label7" class="label label-warning" runat="server" Text=""></asp:Label>
                                        <asp:DropDownList CssClass="form-control" ID="DdlTipo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="VerificarTextBox">
                                            <asp:ListItem Text=""></asp:ListItem>
                                            <asp:ListItem id="linea" Text="Linea"></asp:ListItem>
                                            <asp:ListItem id="variedad" Text="Variedad"></asp:ListItem>
                                            <asp:ListItem id="hibrido" Text="Hibrido"></asp:ListItem>
                   
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </section>
            
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Cultivo</label><asp:Label ID="Label11" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                    <asp:ListItem Text=""></asp:ListItem>
                                    <asp:ListItem id="frijolcultivo" Text="Frijol"></asp:ListItem>
                                    <asp:ListItem id="maizcultivo" Text="Maiz"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <section id="Section4" runat="server">
                            <div class="col-lg-3" visible="false" id="variedadfrijol2" runat="server">
                                <div class="form-group">
                                    <div class="form-group">
                                        <label>Variedad Frijol</label>
                                        <asp:Label ID="Label15" class="label label-warning" runat="server" Text=""></asp:Label>
                                        <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="VerificarTextBox">
                                            <asp:ListItem Text=""></asp:ListItem>
                                            <asp:ListItem id="Amadeus77v" Text="Amadeus-77"></asp:ListItem>
                                            <asp:ListItem id="Carrizalitov" Text="Carrizalito"></asp:ListItem>
                                            <asp:ListItem id="Azabachev" Text="Azabache"></asp:ListItem>
                                            <asp:ListItem id="Paraisitomejoradov" Text="Paraisito mejorado PM-2"></asp:ListItem>
                                            <asp:ListItem id="Deorhov" Text="Deorho"></asp:ListItem>
                                            <asp:ListItem id="IntaCardenasv" Text="Inta Cárdenas"></asp:ListItem>
                                            <asp:ListItem id="Lencaprecozv" Text="Lenca precoz"></asp:ListItem>
                                            <asp:ListItem id="Rojochortív" Text="Rojo chortí"></asp:ListItem>
                                            <asp:ListItem id="Tolupanrojov" Text="Tolupan rojo"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </section>

                        <section id="Section5" runat="server">
                            <div class="col-lg-3" visible="false" id="variedadmaiz2" runat="server">
                                <div class="form-group">
                                    <label>Variedades Maiz</label><asp:Label ID="Label16" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="VerificarTextBox">
                                        <asp:ListItem  Text=""></asp:ListItem>
                                        <asp:ListItem id="DictaMayav" Text="Dicta Maya"></asp:ListItem>
                                        <asp:ListItem id="DictaVictoriav" Text="Dicta Victoria"></asp:ListItem>
                                        <asp:ListItem id="OtroMaizv" Text="Otro"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </section>
                    </div>
                    
                  
                    <div class="row">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Superficie a Sembrar Ha:</label><asp:Label ID="Label12" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="TxtHectareas" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox" CausesValidation="false" onkeypress="return numericOnly(this);"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TxtHectareas" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" style="color:red;"/>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Superficie en MZ</label><asp:Label ID="Label13" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="TxtSuperficieMZ" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox" Enabled="false"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TxtSuperficieMZ" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" style="color:red;"/>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Fecha Aproximada de Siembra </label>
                                <asp:Label ID="Label14" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="TxtFechaSiembra" TextMode="date" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Fecha Aproximada de Cosecha</label>
                                <asp:Label ID="Label17" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="TxtCosecha" TextMode="date" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class ="row">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Produccion Estimada por Ha</label>
                                <asp:Label ID="Label19" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="TxtProHectareas" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox" onkeypress="return numericOnly(this);"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtProHectareas" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" style="color:red;"/>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Produccion Estimada por Mz</label>
                                <asp:Label ID="Label20" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" AutoPostBack="true" OnTextChanged="VerificarTextBox" Enabled="false"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegexValidator" runat="server" ControlToValidate="TextBox7" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" style="color:red;"/>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">

                                <label>Destino</label><asp:Label ID="Label21" class="label label-warning" runat="server" Text=""></asp:Label>

                                <asp:DropDownList CssClass="form-control" ID="DropDownList4" runat="server" AutoPostBack="true" OnSelectedIndexChanged="VerificarTextBox">
                                    <asp:ListItem  Text=""></asp:ListItem>
                                    <asp:ListItem id="mercado" Text="Mercado Local"></asp:ListItem>
                                    <asp:ListItem id="exportacion" Text="Exportación"></asp:ListItem>
                                    <asp:ListItem id="ambas" Text="Ambas"></asp:ListItem>

                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>                    
                    
                </div>
            </div>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div>
        <label></label><asp:Label ID="LabelGuardar" class="label label-warning" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button CssClass="btn btn-primary" ID="btnGuardarLote" runat="server" Text="Guardar" OnClick="guardarSoli_lote" visible="false"/>
    </div>

    <div>
        <label></label><asp:Label ID="Label18" class="label label-warning" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" Text="Imprimir Hoja de Datos del Lote Registrado" onclick="descargaPDF" visible="false"/>
    </div>
    
    <div>
        <label></label><asp:Label ID="Label23" class="label label-warning" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button CssClass="btn btn-primary" ID="Button2" runat="server" Text="Nuevo" OnClick="vaciar" visible="false"/>
    </div>

    <div class="row">
        <div class="col-lg-3">
            <div class="form-group">
                <asp:Label ID="lblAdjunto" runat="server" class="label label-warning" Text="Adjuntar Archivo PDF:" visible="false" ></asp:Label>
                <asp:FileUpload ID="fuArchivo" runat="server" visible="false" style="margin-top: 10px;" />
            </div>
        </div>
    </div>
    <div>
        <asp:Label ID="Label24" class="label label-warning" runat="server" Text="" visible="false" ></asp:Label>
        <br />
        <asp:Button CssClass="btn btn-primary" ID="Button3" runat="server" Text="Enviar Correo" OnClick="EnviarCorreo" visible="false"/>
    </div>
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
</asp:Content>