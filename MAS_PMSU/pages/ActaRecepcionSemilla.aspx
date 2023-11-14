<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="ActaRecepcionSemilla.aspx.vb" Inherits="MAS_PMSU.ActaRecepcionSemilla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>    
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header"> Acta de Recepcion de Semilla</h1>
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
                            <div class="form-container" style=" position: relative;width: 100%;height: auto;">
                                <asp:TextBox CssClass="form-control" ID="txt_nombre_prod_new" runat="server" AutoPostBack="false" style="width: 90%;position: absolute;top: 0;left: 0;z-index: 1;border-right: 0;"></asp:TextBox>
                                <asp:DropDownList CssClass="form-control" ID="DropDownList7" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" style="position: relative;z-index: 0;"></asp:DropDownList>
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
                4. Variedad de Frijol
            </div>
            <div class="panel-body">
                <div class="row">
                
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Amadeus-77</label>
                                <asp:Label ID="Label3" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Amadeus" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label5" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Amadeus_Certificado" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label6" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Amadeus_Comercial" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>% Humedad:</label>
                                <asp:Label ID="Label2" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtAmadeus" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Carrizalito</label>
                                <asp:Label ID="Label4" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Carrizalito" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label7" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Carrizalito_Certificado" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label8" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Carrizalito_Comercial" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>% Humedad:</label>
                                <asp:Label ID="Label9" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtCarrizalito" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Deorho</label>
                                <asp:Label ID="Label10" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Deorho" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label11" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Deorho_Certificado" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label12" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Deorho_Comercial" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>% Humedad:</label>
                                <asp:Label ID="Label13" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtDeorho" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>ParaisitoMejoradoPM-2</label>
                                <asp:Label ID="Label15" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_ParaisitoMejoradoPM_2" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label16" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_ParaisitoMejoradoPM_2_Certificado" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label17" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_ParaisitoMejoradoPM_2_Comercial" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>% Humedad:</label>
                                <asp:Label ID="Label19" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtlb_ParaisitoMejoradoPM_2" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Hondurasnutritivo</label>
                                <asp:Label ID="Label20" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Hondurasnutritivo" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label21" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Hondurasnutritivo_Certificado" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label22" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Hondurasnutritivo_Comercial" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>% Humedad:</label>
                                <asp:Label ID="Label24" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtHondurasnutritivo" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>IntaCárdenas</label>
                                <asp:Label ID="Label25" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_IntaCardenas" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label26" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_IntaCardenas_Certificado" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label27" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_IntaCardenas_Comercial" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>% Humedad:</label>
                                <asp:Label ID="Label28" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtIntaCardenas" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Azabache40</label>
                                <asp:Label ID="Label29" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Azabache40" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label30" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Azabache40_Certificado" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label31" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Azabache40_Comercial" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>% Humedad:</label>
                                <asp:Label ID="Label32" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtAzabache40" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>LencaPrecoz</label>
                                <asp:Label ID="Label33" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_LencaPrecoz" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label34" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_LencaPrecoz_Certificado" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label35" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_LencaPrecoz_Comercial" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>% Humedad:</label>
                                <asp:Label ID="Label36" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtLencaPrecoz" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>RojoChorti</label>
                                <asp:Label ID="Label37" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_RojoChorti" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label38" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_RojoChorti_Certificado" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label39" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_RojoChorti_Comercial" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>% Humedad:</label>
                                <asp:Label ID="Label40" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtRojoChorti" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>TolupanRojo</label>
                                <asp:Label ID="Label41" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_TolupanRojo" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label42" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_TolupanRojo_Certificado" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label43" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_TolupanRojo_Comercial" runat="server" AutoPostBack="True">
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>% Humedad:</label>
                                <asp:Label ID="Label44" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtTolupanRojo" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div>
        <label></label><asp:Label ID="LabelGuardar" class="label label-warning" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button CssClass="btn btn-primary" ID="btnGuardarLote" runat="server" Text="Guardar" visible="false"/>
    </div>

    <div>
        <label></label><asp:Label ID="Label18" class="label label-warning" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" Text="Imprimir" onclick="descargaPDF" visible="false"/>
    </div>
    
    <div>
        <label></label><asp:Label ID="Label23" class="label label-warning" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button CssClass="btn btn-primary" ID="Button2" runat="server" Text="Nuevo" OnClick="vaciar" visible="false"/>
    </div>

</asp:Content>