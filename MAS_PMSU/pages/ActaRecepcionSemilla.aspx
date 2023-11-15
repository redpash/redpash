<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="ActaRecepcionSemilla.aspx.vb" Inherits="MAS_PMSU.ActaRecepcionSemilla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Acta de Recepcion de Semilla</h1>
        </div>
    </div>

    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                A. Datos Generales
            </div>

            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label for="txt">Fecha de recepción:</label>
                            <asp:Label ID="Label14" class="label label-warning" runat="server" Text=""></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="txtFechaSiembra" TextMode="date" runat="server" AutoPostBack="false"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Nombre Del Productor </label>
                            <asp:Label ID="lb_nombre_new" class="label label-warning" runat="server" Text=""></asp:Label>
                            <div class="form-container" style="position: relative; width: 100%; height: auto;">
                                <asp:TextBox CssClass="form-control" ID="txt_nombre_prod_new" runat="server" AutoPostBack="false" Style="width: 90%; position: absolute; top: 0; left: 0; z-index: 1; border-right: 0;"></asp:TextBox>
                                <asp:DropDownList CssClass="form-control" ID="DropDownList7" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" Style="position: relative; z-index: 0;"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label for="txt">Cédula de Identidad:</label>
                            <asp:Label ID="Label1" class="label label-warning" runat="server" Text=""></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="TxtCeduIden" runat="server" AutoPostBack="false"></asp:TextBox>
                        </div>
                    </div>
                </div>

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
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                Variedad de Frijol
            </div>
            <div class="panel-body">


                <div class="row">

                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Amadeus-77</label>
                                <asp:Label ID="Label3" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="DDL_Amadeus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Verificarvariedades">
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div id="div1" runat="server">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Certificado</label>
                                    <asp:Label ID="Label5" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="DDL_Amadeus_Certificado" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>

                                    <label>Comercial</label>
                                    <asp:Label ID="Label6" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control form-control-lg" ID="DDL_Amadeus_Comercial" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>% Humedad:</label>
                                    <asp:RegularExpressionValidator ID="RegexValidator" runat="server" ControlToValidate="txtAmadeusHumedad" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label2" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtAmadeusHumedad" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label># Bultos:</label>
                                    <asp:Label ID="Label45" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtBultosAmadeus" CssClass="form-control" runat="server" TextMode="number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Peso M. Prima:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPesoPrimAmadeus" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label46" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoPrimAmadeus" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label>Peso Bruto:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPesoBrutAmadeus" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label47" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoBrutAmadeus" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Carrizalito</label>
                                <asp:Label ID="Label4" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="DDL_Carrizalito" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Verificarvariedades">
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="div2" runat="server">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Certificado</label>
                                    <asp:Label ID="Label7" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="DDL_Carrizalito_Certificado" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>

                                    <label>Comercial</label>
                                    <asp:Label ID="Label8" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control form-control-lg" ID="DDL_Carrizalito_Comercial" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>% Humedad:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCarrizalitoHumedad" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label9" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtCarrizalitoHumedad" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label># Bultos:</label>
                                    <asp:Label ID="Label10" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtBultosCarrizalito" CssClass="form-control" runat="server" TextMode="number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Peso M. Prima:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPesoPrimCarrizalito" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label11" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoPrimCarrizalito" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label>Peso Bruto:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtPesoBrutCarrizalito" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label12" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoBrutCarrizalito" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Deorho</label>
                                <asp:Label ID="Label13" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="DDL_Deorho" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Verificarvariedades">
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="div3" runat="server">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Certificado</label>
                                    <asp:Label ID="Label15" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="DDL_Deorho_Certificado" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>

                                    <label>Comercial</label>
                                    <asp:Label ID="Label16" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control form-control-lg" ID="DDL_Deorho_Comercial" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>% Humedad:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtDeorhoHumedad" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label17" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtDeorhoHumedad" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label># Bultos:</label>
                                    <asp:Label ID="Label19" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtBultosDeorho" CssClass="form-control" runat="server" TextMode="number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Peso M. Prima:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtPesoPrimDeorho" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label20" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoPrimDeorho" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label>Peso Bruto:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtPesoBrutDeorho" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label21" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoBrutDeorho" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Azabache</label>
                                <asp:Label ID="Label22" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="DDL_Azabache" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Verificarvariedades">
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="div4" runat="server">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Certificado</label>
                                    <asp:Label ID="Label24" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="DDL_Azabache_Certificado" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>

                                    <label>Comercial</label>
                                    <asp:Label ID="Label25" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control form-control-lg" ID="DDL_Azabache_Comercial" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>% Humedad:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtAzabacheHumedad" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label26" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtAzabacheHumedad" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label># Bultos:</label>
                                    <asp:Label ID="Label27" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtBultosAzabache" CssClass="form-control" runat="server" TextMode="number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Peso M. Prima:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtPesoPrimAzabache" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label28" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoPrimAzabache" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label>Peso Bruto:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtPesoBrutAzabache" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label29" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoBrutAzabache" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Paraisito Mejorado PM2</label>
                                <asp:Label ID="Label30" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="DDL_ParaisitoMejoradoPM2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Verificarvariedades">
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="div5" runat="server">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Certificado</label>
                                    <asp:Label ID="Label31" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="DDL_ParaisitoMejoradoPM2_Certificado" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>

                                    <label>Comercial</label>
                                    <asp:Label ID="Label32" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control form-control-lg" ID="DDL_ParaisitoMejoradoPM2_Comercial" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>% Humedad:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtParaisitoMejoradoPM2Humedad" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label33" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtParaisitoMejoradoPM2Humedad" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label># Bultos:</label>
                                    <asp:Label ID="Label34" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtBultosParaisitoMejoradoPM2" CssClass="form-control" runat="server" TextMode="number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Peso M. Prima:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtPesoPrimParaisitoMejoradoPM2" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label35" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoPrimParaisitoMejoradoPM2" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label>Peso Bruto:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="txtPesoBrutParaisitoMejoradoPM2" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label36" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoBrutParaisitoMejoradoPM2" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Honduras nutritivo</label>
                                <asp:Label ID="Label37" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="DDL_Hondurasnutritivo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Verificarvariedades">
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="div6" runat="server">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Certificado</label>
                                    <asp:Label ID="Label38" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="DDL_Hondurasnutritivo_Certificado" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>

                                    <label>Comercial</label>
                                    <asp:Label ID="Label39" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control form-control-lg" ID="DDL_Hondurasnutritivo_Comercial" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>% Humedad:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="txtHondurasnutritivoHumedad" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label40" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtHondurasnutritivoHumedad" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label># Bultos:</label>
                                    <asp:Label ID="Label41" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtBultosHondurasnutritivo" CssClass="form-control" runat="server" TextMode="number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Peso M. Prima:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="txtPesoPrimHondurasnutritivo" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label42" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoPrimHondurasnutritivo" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label>Peso Bruto:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ControlToValidate="txtPesoBrutHondurasnutritivo" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label43" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoBrutHondurasnutritivo" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Inta Cardenas</label>
                                <asp:Label ID="Label44" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="DDL_IntaCardenas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Verificarvariedades">
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="div7" runat="server">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Certificado</label>
                                    <asp:Label ID="Label48" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="DDL_IntaCardenas_Certificado" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>

                                    <label>Comercial</label>
                                    <asp:Label ID="Label49" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control form-control-lg" ID="DDL_IntaCardenas_Comercial" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>% Humedad:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ControlToValidate="txtIntaCardenasHumedad" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label50" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtIntaCardenasHumedad" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label># Bultos:</label>
                                    <asp:Label ID="Label51" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtBultosIntaCardenas" CssClass="form-control" runat="server" TextMode="number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Peso M. Prima:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ControlToValidate="txtPesoPrimIntaCardenas" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label52" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoPrimIntaCardenas" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label>Peso Bruto:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ControlToValidate="txtPesoBrutIntaCardenas" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label53" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoBrutIntaCardenas" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Lenca precoz</label>
                                <asp:Label ID="Label54" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="DDL_Lencaprecoz" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Verificarvariedades">
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="div8" runat="server">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Certificado</label>
                                    <asp:Label ID="Label55" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="DDL_Lencaprecoz_Certificado" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>

                                    <label>Comercial</label>
                                    <asp:Label ID="Label56" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control form-control-lg" ID="DDL_Lencaprecoz_Comercial" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>% Humedad:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ControlToValidate="txtLencaprecozHumedad" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label57" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtLencaprecozHumedad" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label># Bultos:</label>
                                    <asp:Label ID="Label58" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtBultosLencaprecoz" CssClass="form-control" runat="server" TextMode="number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Peso M. Prima:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ControlToValidate="txtPesoPrimLencaprecoz" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label59" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoPrimLencaprecoz" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label>Peso Bruto:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server" ControlToValidate="txtPesoBrutLencaprecoz" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label60" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoBrutLencaprecoz" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Rojo chorti</label>
                                <asp:Label ID="Label61" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="DDL_Rojochorti" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Verificarvariedades">
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="div9" runat="server">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Certificado</label>
                                    <asp:Label ID="Label62" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="DDL_Rojochorti_Certificado" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>

                                    <label>Comercial</label>
                                    <asp:Label ID="Label63" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control form-control-lg" ID="DDL_Rojochorti_Comercial" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>% Humedad:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" ControlToValidate="txtRojochortiHumedad" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label64" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtRojochortiHumedad" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label># Bultos:</label>
                                    <asp:Label ID="Label65" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtBultosRojochorti" CssClass="form-control" runat="server" TextMode="number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Peso M. Prima:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server" ControlToValidate="txtPesoPrimRojochorti" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label66" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoPrimRojochorti" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label>Peso Bruto:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator26" runat="server" ControlToValidate="txtPesoBrutRojochorti" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label67" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoBrutRojochorti" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Tolupan rojo</label>
                                <asp:Label ID="Label68" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="DDL_Tolupanrojo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Verificarvariedades">
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="div10" runat="server">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Certificado</label>
                                    <asp:Label ID="Label69" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="DDL_Tolupanrojo_Certificado" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>

                                    <label>Comercial</label>
                                    <asp:Label ID="Label70" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control form-control-lg" ID="DDL_Tolupanrojo_Comercial" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>% Humedad:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server" ControlToValidate="txtTolupanrojoHumedad" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label71" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtTolupanrojoHumedad" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label># Bultos:</label>
                                    <asp:Label ID="Label72" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtBultosTolupanrojo" CssClass="form-control" runat="server" TextMode="number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Peso M. Prima:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator28" runat="server" ControlToValidate="txtPesoPrimTolupanrojo" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label73" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoPrimTolupanrojo" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label>Peso Bruto:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator29" runat="server" ControlToValidate="txtPesoBrutTolupanrojo" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label74" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoBrutTolupanrojo" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Otra variedad, especificar nombre comercial:</label>
                                <asp:Label ID="Label75" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="DDL_Otravariedad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Verificarvariedades">
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="div11" runat="server">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Certificado</label>
                                    <asp:Label ID="Label76" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="DDL_Otravariedad_Certificado" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>

                                    <label>Comercial</label>
                                    <asp:Label ID="Label77" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:DropDownList CssClass="form-control form-control-lg" ID="DDL_Otravariedad_Comercial" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>% Humedad:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator30" runat="server" ControlToValidate="txtOtravariedadHumedad" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label78" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtOtravariedadHumedad" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label># Bultos:</label>
                                    <asp:Label ID="Label79" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtBultosOtravariedad" CssClass="form-control" runat="server" TextMode="number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label>Peso M. Prima:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator31" runat="server" ControlToValidate="txtPesoPrimOtravariedad" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label80" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoPrimOtravariedad" CssClass="form-control" runat="server"></asp:TextBox>
                                    <label>Peso Bruto:</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator32" runat="server" ControlToValidate="txtPesoBrutOtravariedad" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="Ingresa un número válido." Display="Dynamic" Style="color: red;" />
                                    <asp:Label ID="Label81" class="label label-warning" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtPesoBrutOtravariedad" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <div>
        <label></label>
        <asp:Label ID="LabelGuardar" class="label label-warning" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button CssClass="btn btn-primary" ID="btnGuardarLote" runat="server" Text="Guardar" Visible="true" />
    </div>

    <div>
        <label></label>
        <asp:Label ID="Label18" class="label label-warning" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" Text="Imprimir" OnClick="descargaPDF" Visible="false" />
    </div>

    <div>
        <label></label>
        <asp:Label ID="Label23" class="label label-warning" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button CssClass="btn btn-primary" ID="Button2" runat="server" Text="Nuevo" OnClick="vaciar" Visible="false" />
    </div>

</asp:Content>
