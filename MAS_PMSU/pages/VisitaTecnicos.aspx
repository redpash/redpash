<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="VisitaTecnicos.aspx.vb" Inherits="MAS_PMSU.VisitaTecnicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Visita Tecnicos </h1>
        </div>
    </div>

    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                1. INFORMACION GENERAL
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label>1. Su nombre completo:</label>
                            <asp:TextBox ID="txtNombreCompleto" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>1.1 Capture la coordenada GPS:</label>
                            <asp:TextBox ID="txtCoordenadaGPS" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>1.2 Favor escanear código asignado:</label>
                            <asp:TextBox ID="txtCodigoAsignado" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>1.3 Ingrese la fecha de visita al productor(a):</label>
                            <asp:TextBox ID="txtFechaVisita" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>1.4 Cuántas visitas ha realizado al productor(a): No.</label>
                            <asp:TextBox ID="txtVisitasRealizadas" CssClass="form-control" runat="server" TextMode="number"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                2. Ciclo de Siembra
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>2. Seleccione el ciclo de siembra en que reporta la visita de asistencia técnica:</label>
                            <asp:DropDownList ID="ddlCicloSiembra" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="2023 Ciclo A" Value="A"></asp:ListItem>
                                <asp:ListItem Text="2023 Ciclo B" Value="B"></asp:ListItem>
                                <asp:ListItem Text="2023 Ciclo C" Value="C"></asp:ListItem>
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
                3. Fase del Cultivo
            </div>
            <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>3. ¿En qué etapa/fase está el cultivo del frijol al realizar la visita?</label>
                                <asp:DropDownList ID="ddlEtapaFase" CssClass="form-control" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>3.1 Seleccione la fase del cultivo del frijol al realizar la visita:</label>
                                <asp:DropDownList ID="ddlFaseVisita" CssClass="form-control" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Text="Germinación (La semilla está en un ambiente favorable para germinar)" Value="Germinación"></asp:ListItem>
                                    <asp:ListItem Text="Emergencia (0-10 días)" Value="Emergencia"></asp:ListItem>
                                    <asp:ListItem Text="Crecimiento (11-34 días)" Value="Crecimiento"></asp:ListItem>
                                    <asp:ListItem Text="Floración (35-40 días)" Value="Floración"></asp:ListItem>
                                    <asp:ListItem Text="Vaina (40-60 días)" Value="Vaina"></asp:ListItem>
                                    <asp:ListItem Text="Maduración (60-80 días)" Value="Maduración"></asp:ListItem>
                                    <asp:ListItem Text="Listo para cosecha (mayor a 80 días)" Value="Listo para cosecha"></asp:ListItem>
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
                4. Variedad, Fecha de Siembra y Lote
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label>Si esta informacion ya fue reportada en una visita anterior, confirme en SI para saltar a la siguiente pregunta:</label>
                            <asp:DropDownList ID="ddlConfirmaInspeccion" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Amadeus-77</label>
                                <asp:Label ID="Label3" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Amadeus" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label5" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Amadeus_Certificado" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label6" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Amadeus_Comercial" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Fecha de siembra:</label>
                                <asp:Label ID="Label1" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtFechaAmadeus" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Carrizalito</label>
                                <asp:Label ID="Label2" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Carrizalito" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label4" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Carrizalito_Certificado" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label7" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Carrizalito_Comercial" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Fecha de siembra:</label>
                                <asp:Label ID="Label8" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtFechaCarrizalito" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Deorho</label>
                                <asp:Label ID="Label9" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Deorho" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label10" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Deorho_Certificado" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label11" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Deorho_Comercial" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Fecha de siembra:</label>
                                <asp:Label ID="Label12" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtFechaDeorho" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>ParaisitoMejoradoPM-2</label>
                                <asp:Label ID="Label13" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label14" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label15" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="DropDownList3" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Fecha de siembra:</label>
                                <asp:Label ID="Label16" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Hondurasnutritivo</label>
                                <asp:Label ID="Label17" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Hondurasnutritivo" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label18" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Hondurasnutritivo_Certificado" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label19" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Hondurasnutritivo_Comercial" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Fecha de siembra:</label>
                                <asp:Label ID="Label20" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtFechaHondurasnutritivo" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>IntaCárdenas</label>
                                <asp:Label ID="Label21" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_IntaCárdenas" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label22" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_IntaCárdenas_Certificado" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label23" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_IntaCárdenas_Comercial" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Fecha de siembra:</label>
                                <asp:Label ID="Label24" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtFechaIntaCárdenas" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Azabache40</label>
                                <asp:Label ID="Label25" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Azabache40" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label26" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_Azabache40_Certificado" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label27" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Azabache40_Comercial" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Fecha de siembra:</label>
                                <asp:Label ID="Label28" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtFechaAzabache40" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>LencaPrecoz</label>
                                <asp:Label ID="Label29" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_LencaPrecoz" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label30" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_LencaPrecoz_Certificado" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label31" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_LencaPrecoz_Comercial" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Fecha de siembra:</label>
                                <asp:Label ID="Label32" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtFechaLencaPrecoz" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>RojoChorti</label>
                                <asp:Label ID="Label33" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_RojoChorti" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label34" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_RojoChorti_Certificado" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label35" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_RojoChorti_Comercial" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Fecha de siembra:</label>
                                <asp:Label ID="Label36" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtFechaRojoChorti" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>TolupanRojo</label>
                                <asp:Label ID="Label37" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_TolupanRojo" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3"> 
                            <div class="form-group">
                                <label>Certificado</label>
                                <asp:Label ID="Label38" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="lb_TolupanRojo_Certificado" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
    
                                <label>Comercial</label>
                                <asp:Label ID="Label39" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_TolupanRojo_Comercial" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>Fecha de siembra:</label>
                                <asp:Label ID="Label40" class="label label-warning" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="txtFechaTolupanRojo" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                5. Densidad, Germinación e Inoculante
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>5. DENSIDAD, GERMINACIÓN E INOCULANTE. BRINDÓ RECOMENDACIÓN:</label>
                            <asp:DropDownList ID="ddlRecomendacion" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>5.1 ¿Qué cantidad de semilla registrada utilizó por manzana? Lbs.</label>
                            <asp:TextBox ID="txtCantidadSemilla" CssClass="form-control" runat="server" TextMode="number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>5.2 Porcentaje de germinación:</label>
                            <asp:TextBox ID="txtPorcentajeGerminacion" CssClass="form-control" runat="server" TextMode="number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>5.3 Si aplicó inoculante consulte: ¿Cuántos gramos utilizó?</label>
                            <asp:TextBox ID="txtCantidadInoculante" CssClass="form-control" runat="server" TextMode="number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>5.4 Problemas encontrados:</label>
                            <asp:TextBox ID="txtProblemasEncontrados" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>5.5 Recomendación técnica:</label>
                            <asp:TextBox ID="txtRecomendacionTecnica" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                6. Control de Malezas
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>6. Control de malezas, ¿brindó recomendación?</label>
                            <asp:DropDownList ID="ddlControlMalezas" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    
                </div>
                <div class="row">
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>6.1 Realiza control químico con herbicida selectivo:</label>
                            <asp:DropDownList ID="ddlControlQuimicoSelectivo" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>6.2 Realiza control químico con herbicida de contacto NO selectivo:</label>
                            <asp:DropDownList ID="ddlControlQuimicoNoSelectivo" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>6.3 Problemas encontrados:</label>
                            <asp:DropDownList ID="ddlProblemasControlMalezas" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label>6.4 Recomendación técnica:</label>
                            <asp:DropDownList ID="ddlRecomendacionControlMalezas" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
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
                7. Plan Nutricional
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label>7. Plan nutricional, ¿brindó recomendación?</label>
                            <asp:DropDownList ID="ddlPlanNutricional" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>7.1 Realizó este año análisis de suelo para cultivar frijol:</label>
                            <asp:DropDownList ID="ddlAnalisisSuelo" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Porque:</label>
                            <asp:TextBox ID="txtRazonSinAnalisisSuelo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>7.1.1 Las fertilizaciones las ha realizado con base a los resultados del análisis de suelo?</label>
                            <asp:DropDownList ID="ddlFertilizacionesBasadasEnAnalisis" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>7.1.2 Cuenta con los resultados del análisis de suelo?</label>
                            <asp:DropDownList ID="ddlResultadosAnalisisSuelo" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                <asp:ListItem Text="No sabe/no recuerda" Value="NoSabeNoRecuerda"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Ingrese el código del resultado del análisis:</label>
                            <asp:TextBox ID="txtCodigoResultadoAnalisis" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>7.2. APLICÓ FERTILIZANTES QUÍMICOS, ORGÁNICOS O FOLIARES:</label>
                            <asp:DropDownList ID="ddlAplicoFertilizantes" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Porque:</label>
                            <asp:TextBox ID="txtRazonSinFertilizantes" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Problemas encontrados:</label>
                            <asp:TextBox ID="txtProblemasFertilizantes" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Recomendación técnica:</label>
                            <asp:TextBox ID="txtRecomendacionFertilizantes" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                8. Prevencion y control de plagas y enfermedades
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label>8. Prevención y control de plagas y enfermedades, ¿brindó recomendación?</label>
                            <asp:DropDownList ID="ddlPrevencionControlPlagas" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>8.1 ¿Realizó algún tipo de prevención y/o control de plagas y enfermedades?</label>
                            <asp:DropDownList ID="ddlTipoPrevencionPlagas" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Porque:</label>
                            <asp:TextBox ID="txtRazonSinPrevencionPlagas" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>8.2 ¿En qué etapa/fase del cultivo le afectaron estas plagas? Seleccione una o más etapas</label>
                            <asp:CheckBoxList ID="cblEtapasAfectadas" runat="server">
                                <asp:ListItem Text="Germinación" Value="Germinacion"></asp:ListItem>
                                <asp:ListItem Text="Emergencia (0-10 días)" Value="Emergencia"></asp:ListItem>
                                <asp:ListItem Text="Crecimiento (11-34 días)" Value="Crecimiento"></asp:ListItem>
                                <asp:ListItem Text="Floración (35-40 días)" Value="Floracion"></asp:ListItem>
                                <asp:ListItem Text="Vaina (40-60 días)" Value="Vaina"></asp:ListItem>
                                <asp:ListItem Text="Maduración (60-80 días)" Value="Maduracion"></asp:ListItem>
                                <asp:ListItem Text="Listo para cosecha (mayor a 80 días)" Value="Cosecha"></asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                        <div class="form-group">
                            <label>8.3 Si le afectó una plaga o enfermedad favor estimar o consultar al productor:</label>
                            <label>¿Qué cantidad de quintales de grano estima haber dejado de producir? Cantidad libras:</label>
                            <asp:TextBox ID="txtCantidadQuintalesPerdidos" CssClass="form-control" runat="server"></asp:TextBox>
                            <label>¿Qué cantidad de área/terreno fue afectada? Cantidad manzana:</label>
                            <asp:TextBox ID="txtAreaAfectada" CssClass="form-control" runat="server"></asp:TextBox>
                            <label>Problemas encontrados:</label>
                            <asp:TextBox ID="txtProblemasPlagas" CssClass="form-control" runat="server"></asp:TextBox>
                            <label>Recomendación técnica:</label>
                            <asp:TextBox ID="txtRecomendacionPlagas" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                9. Riego
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label>9. Riego, ¿brindó recomendación?</label>
                            <asp:DropDownList ID="ddlRiegoRecomendacion" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>9.1 Observe el cultivo si presenta estrés hídrico las plantas:</label>
                            <asp:DropDownList ID="ddlEstresHidrico" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>9.2 Consulte sobre la frecuencia de riego:</label>
                            <label>a.0 Lotes regados:</label>
                            <asp:TextBox ID="txtLotesRegados" CssClass="form-control" runat="server"></asp:TextBox>
                            <label>a.1 Área Mz.:</label>
                            <asp:TextBox ID="txtAreaMz" CssClass="form-control" runat="server"></asp:TextBox>
                            <label>a.2 Cada cuantos días riega #  días:</label>
                            <asp:TextBox ID="txtFrecuenciaRiego" CssClass="form-control" runat="server"></asp:TextBox>
                            <label>a.3 Cantidad de horas de riego # Horas día:</label>
                            <asp:TextBox ID="txtHorasRiego" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>9.3 Confirme los problemas encontrados en el funcionamiento del sistema de riego:</label>
                            <div class="form-group">
                                <label for="ddlFugas">Fugas:</label>
                                <asp:DropDownList ID="ddlFugas" CssClass="form-control" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="Si" />
                                    <asp:ListItem Text="No" Value="No" />
                                </asp:DropDownList>

                                <label for="ddlReduccionCaudal">Reducción caudal:</label>
                                <asp:DropDownList ID="ddlReduccionCaudal" CssClass="form-control" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="Si" />
                                    <asp:ListItem Text="No" Value="No" />
                                </asp:DropDownList>

                                <label for="ddlDisenoRiego">Diseño:</label>
                                <asp:DropDownList ID="ddlDisenoRiego" CssClass="form-control" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="Si" />
                                    <asp:ListItem Text="No" Value="No" />
                                </asp:DropDownList>

                                <label for="ddlAguaSedimentos">Agua con sedimentos, sucio, pesada:</label>
                                <asp:DropDownList ID="ddlAguaSedimentos" CssClass="form-control" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="Si" />
                                    <asp:ListItem Text="No" Value="No" />
                                </asp:DropDownList>
                            </div>
                            <label>Otro tipo de riego:</label>
                            <asp:TextBox ID="txtOtroRiego" CssClass="form-control" runat="server"></asp:TextBox>
                            <label>Recomendación técnica:</label>
                            <asp:TextBox ID="txtRecomendacionRiego" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-primary" runat="server"/>
        </div>
    </div>
</asp:Content>
