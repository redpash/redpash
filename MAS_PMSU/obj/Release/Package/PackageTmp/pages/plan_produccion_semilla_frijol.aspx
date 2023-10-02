<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="plan_produccion_semilla_frijol.aspx.vb" Inherits="MAS_PMSU.plan_produccion_semilla_frijol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>

    <asp:UpdatePanel ID="UpdatePanel2"
        runat="server">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <div id="div_nuevo_prod" runat="server">

                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header"></h1>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12">

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <asp:Label ID="laBEL2" runat="server" Text=""></asp:Label>PLAN PRODUCCIÓN DE SEMILLA DE FRIJOL

                  <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
                                <asp:TextBox ID="TextBox2" Visible="false" runat="server"></asp:TextBox>
                                <asp:TextBox ID="TextBox3" Visible="false" runat="server"></asp:TextBox>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="row">

                                            <div class="panel panel-primary">
                                                <div class="panel-heading">
                                                    Registro Semilla SAG
                                                </div>

                                                <div class="panel-body">
                                                    <div class="col-lg-4">
                                                        <div class="form-group">

                                                            <label>Selecione el ciclo de siembra</label>
                                                            <asp:Label ID="lb_dept_new" class="label label-warning" runat="server" Text=""></asp:Label>

                                                            <asp:DropDownList CssClass="form-control" ID="Text_Ciclo_new" runat="server" AutoPostBack="True">

                                                                <asp:ListItem></asp:ListItem>
                                                                <asp:ListItem>Primera</asp:ListItem>
                                                                <asp:ListItem>Postrera </asp:ListItem>
                                                                <asp:ListItem>Verano </asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="form-group">

                                                            <label>2. Cantidad Total de quintales de semilla requerida para el ciclo</label>
                                                            <asp:Label ID="cantidad_quintales" class="label label-warning" runat="server" Text=""></asp:Label>
                                                            <br />
                                                            <br />
                                                            <label>Certificada Quintales</label>
                                                            <asp:Label ID="Label1" class="label label-warning" runat="server" Text=""></asp:Label>
                                                            <asp:TextBox CssClass="form-control" ID="TextBox_quintales" runat="server" AutoPostBack="True"></asp:TextBox>
                                                            <label>Comercial Quintales</label>
                                                            <asp:Label ID="Label4" class="label label-warning" runat="server" Text=""></asp:Label>
                                                            <asp:TextBox CssClass="form-control" ID="txt_Comercial_Quintales" runat="server" AutoPostBack="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">

                                            <div class="col-lg-12">
                                                <div class="panel panel-primary">
                                                    <div class="panel-heading">
                                                        2.1. Seleccione la variedad de frijol
                                                    </div>

                                                    <div class="panel-body">

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

                                                            <span style="margin-right: 20px;"></span>
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
                                                            <span style="margin-right: 20px;"></span>
                                                            <div class="form-group ">
                                                                <label>Inventario Existente Certificado</label>
                                                                <asp:Label ID="Label7" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                <asp:TextBox CssClass="form-control" ID="txt_In_Certificado_Amadeus" runat="server" AutoPostBack="True"></asp:TextBox>

                                                                <label>Inventario Existente Comercial</label>
                                                                <asp:Label ID="Label8" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                <asp:TextBox CssClass="form-control" ID="txt_In_Comercial_Amadeus" runat="server" AutoPostBack="True"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <span style="margin-right: 20px;"></span>
                                                            <div class="form-group">
                                                                <label>Cantidad de semilla requerida Certificado</label>
                                                                <asp:Label ID="Label9" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                <asp:TextBox CssClass="form-control" ID="txt_Re_Certificado_Amadeus" runat="server" AutoPostBack="True"></asp:TextBox>

                                                                <label>Cantidad de semilla requerida Comercial</label>
                                                                <asp:Label ID="Label10" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                <asp:TextBox CssClass="form-control " ID="txt_Re_Comercial_Amadeus" runat="server" AutoPostBack="True"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <br />
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <div class="col-lg-12">
                                                            <hr />
                                                        </div>
                                                        <%--  aqui comienza de carrizalito--%>
                                                        <div>
                                                            <div class="col-lg-3">

                                                                <div class="form-group">
                                                                    <label>Carrizalito </label>
                                                                    <asp:Label ID="Label11" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                    <asp:DropDownList CssClass="form-control" ID="lb_Carrizalito" runat="server" AutoPostBack="True">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>Si</asp:ListItem>
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-3">

                                                                <span style="margin-right: 20px;"></span>
                                                                <div class="form-group">
                                                                    <label>Certificado</label>
                                                                    <asp:Label ID="Label12" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                    <asp:DropDownList CssClass="form-control" ID="lb_Certificado_Carrizalito" runat="server" AutoPostBack="True">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>Si</asp:ListItem>
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                    </asp:DropDownList>

                                                                    <label>Comercial</label>
                                                                    <asp:Label ID="Label14" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                    <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Comercial_Carrizalito" runat="server" AutoPostBack="True">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem>Si</asp:ListItem>
                                                                        <asp:ListItem>No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-3">
                                                                <span style="margin-right: 20px;"></span>
                                                                <div class="form-group ">
                                                                    <label>Inventario Existente Certificado</label>
                                                                    <asp:Label ID="Label15" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                    <asp:TextBox CssClass="form-control" ID="txt_In_Certificado_Carrtizalito" runat="server" AutoPostBack="True"></asp:TextBox>

                                                                    <label>Inventario Existente Comercial</label>
                                                                    <asp:Label ID="Label16" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                    <asp:TextBox CssClass="form-control" ID="txt_In_Comercial_Carrtizalito" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-3">
                                                                <span style="margin-right: 20px;"></span>
                                                                <div class="form-group">
                                                                    <label>Cantidad de semilla requerida Certificado</label>
                                                                    <asp:Label ID="Label17" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                    <asp:TextBox CssClass="form-control" ID="txt_re_Certificado_Carrizalito" runat="server" AutoPostBack="True"></asp:TextBox>

                                                                    <label>Cantidad de semilla requerida Comercial</label>
                                                                    <asp:Label ID="Label18" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                    <asp:TextBox CssClass="form-control " ID="txt_re_Comercial_Carrizalito" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <%--aqui termina carrizalito--%>

                                                            <div class="col-lg-12">
                                                                <hr />
                                                            </div>
                                                            <%--aqui comienza Deorho--%>
                                                            <div>
                                                                <div class="col-lg-3">

                                                                    <div class="form-group">
                                                                        <label>Deorho </label>
                                                                        <asp:Label ID="Label133" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                        <asp:DropDownList CssClass="form-control" ID="lb_Deorho" runat="server" AutoPostBack="True">
                                                                            <asp:ListItem></asp:ListItem>
                                                                            <asp:ListItem>Si</asp:ListItem>
                                                                            <asp:ListItem>No</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-3">

                                                                    <span style="margin-right: 20px;"></span>
                                                                    <div class="form-group">
                                                                        <label>Certificado</label>
                                                                        <asp:Label ID="Label19" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                        <asp:DropDownList CssClass="form-control" ID="lb_Certificado_Deohoro" runat="server" AutoPostBack="True">
                                                                            <asp:ListItem></asp:ListItem>
                                                                            <asp:ListItem>Si</asp:ListItem>
                                                                            <asp:ListItem>No</asp:ListItem>
                                                                        </asp:DropDownList>

                                                                        <label>Comercial</label>
                                                                        <asp:Label ID="Label20" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                        <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Comercial_Deohoro" runat="server" AutoPostBack="True">
                                                                            <asp:ListItem></asp:ListItem>
                                                                            <asp:ListItem>Si</asp:ListItem>
                                                                            <asp:ListItem>No</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-3">
                                                                    <span style="margin-right: 20px;"></span>
                                                                    <div class="form-group ">
                                                                        <label>Inventario Existente Certificado</label>
                                                                        <asp:Label ID="Label21" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                        <asp:TextBox CssClass="form-control" ID="txt_Ce_Deorho" runat="server" AutoPostBack="True"></asp:TextBox>

                                                                        <label>Inventario Existente Comercial</label>
                                                                        <asp:Label ID="Label22" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                        <asp:TextBox CssClass="form-control" ID="txt_Co_Deorho" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-3">
                                                                    <span style="margin-right: 20px;"></span>
                                                                    <div class="form-group">
                                                                        <label>Cantidad de semilla requerida Certificado</label>
                                                                        <asp:Label ID="Label23" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                        <asp:TextBox CssClass="form-control" ID="txt_Re_Ce_Deorho" runat="server" AutoPostBack="True"></asp:TextBox>

                                                                        <label>Cantidad de semilla requerida Comercial</label>
                                                                        <asp:Label ID="Label24" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                        <asp:TextBox CssClass="form-control " ID="txt_Re_Co_Deorho" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <%--      fin de deorho--%>
                                                                <div class="col-lg-12">
                                                                    <hr />
                                                                </div>

                                                                <%--    incio de Azabache	--%>

                                                                <div>
                                                                    <div class="col-lg-3">

                                                                        <div class="form-group">
                                                                            <label>Azabache </label>
                                                                            <asp:Label ID="Label25" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                            <asp:DropDownList CssClass="form-control" ID="lb_Azabache" runat="server" AutoPostBack="True">
                                                                                <asp:ListItem></asp:ListItem>
                                                                                <asp:ListItem>Si</asp:ListItem>
                                                                                <asp:ListItem>No</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-3">

                                                                        <span style="margin-right: 20px;"></span>
                                                                        <div class="form-group">
                                                                            <label>Certificado</label>
                                                                            <asp:Label ID="Label26" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                            <asp:DropDownList CssClass="form-control" ID="lb_Certificado_Azabache" runat="server" AutoPostBack="True">
                                                                                <asp:ListItem></asp:ListItem>
                                                                                <asp:ListItem>Si</asp:ListItem>
                                                                                <asp:ListItem>No</asp:ListItem>
                                                                            </asp:DropDownList>

                                                                            <label>Comercial</label>
                                                                            <asp:Label ID="Label27" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                            <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Comercial_Azabache" runat="server" AutoPostBack="True">
                                                                                <asp:ListItem></asp:ListItem>
                                                                                <asp:ListItem>Si</asp:ListItem>
                                                                                <asp:ListItem>No</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-3">
                                                                        <span style="margin-right: 20px;"></span>
                                                                        <div class="form-group ">
                                                                            <label>Inventario Existente Certificado</label>
                                                                            <asp:Label ID="Label28" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                            <asp:TextBox CssClass="form-control" ID="txt_In_Certificado_Azabache" runat="server" AutoPostBack="True"></asp:TextBox>

                                                                            <label>Inventario Existente Comercial</label>
                                                                            <asp:Label ID="Label29" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                            <asp:TextBox CssClass="form-control" ID="txt_In_Comercial_Azabache" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-3">
                                                                        <span style="margin-right: 20px;"></span>
                                                                        <div class="form-group">
                                                                            <label>Cantidad de semilla requerida Certificado</label>
                                                                            <asp:Label ID="Label30" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                            <asp:TextBox CssClass="form-control" ID="txt_Re_Certificado_Azabache" runat="server" AutoPostBack="True"></asp:TextBox>

                                                                            <label>Cantidad de semilla requerida Comercial</label>
                                                                            <asp:Label ID="Label48" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                            <asp:TextBox CssClass="form-control " ID="txt_Re_Comercial_Azabache" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                        </div>
                                                                    </div>

                                                                    <%--   fin de azabache --%>
                                                                    <div class="col-lg-12">
                                                                        <hr />
                                                                    </div>

                                                                    <%--   inicio de Paraisito mejorado PM-2--%>
                                                                    <div>
                                                                        <div class="col-lg-3">

                                                                            <div class="form-group">
                                                                                <label>Paraisito mejorado PM-2 </label>
                                                                                <asp:Label ID="Label49" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                <asp:DropDownList CssClass="form-control" ID="lb_Paraisito" runat="server" AutoPostBack="True">
                                                                                    <asp:ListItem></asp:ListItem>
                                                                                    <asp:ListItem>Si</asp:ListItem>
                                                                                    <asp:ListItem>No</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-lg-3">

                                                                            <span style="margin-right: 20px;"></span>
                                                                            <div class="form-group">
                                                                                <label>Certificado</label>
                                                                                <asp:Label ID="Label50" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                <asp:DropDownList CssClass="form-control" ID="lb_Certificado_Paraisito" runat="server" AutoPostBack="True">
                                                                                    <asp:ListItem></asp:ListItem>
                                                                                    <asp:ListItem>Si</asp:ListItem>
                                                                                    <asp:ListItem>No</asp:ListItem>
                                                                                </asp:DropDownList>

                                                                                <label>Comercial</label>
                                                                                <asp:Label ID="Label51" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Comercial_Paraisito" runat="server" AutoPostBack="True">
                                                                                    <asp:ListItem></asp:ListItem>
                                                                                    <asp:ListItem>Si</asp:ListItem>
                                                                                    <asp:ListItem>No</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-lg-3">
                                                                            <span style="margin-right: 20px;"></span>
                                                                            <div class="form-group ">
                                                                                <label>Inventario Existente Certificado</label>
                                                                                <asp:Label ID="Label52" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                <asp:TextBox CssClass="form-control" ID="txt_Ex_Certificado_Paraisito" runat="server" AutoPostBack="True"></asp:TextBox>

                                                                                <label>Inventario Existente Comercial</label>
                                                                                <asp:Label ID="Label53" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                <asp:TextBox CssClass="form-control" ID="txt_Ex_Comercial_Paraisito" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-lg-3">
                                                                            <span style="margin-right: 20px;"></span>
                                                                            <div class="form-group">
                                                                                <label>Cantidad de semilla requerida Certificado</label>
                                                                                <asp:Label ID="Label54" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                <asp:TextBox CssClass="form-control" ID="txt_Re_Certificado_Paraisito" runat="server" AutoPostBack="True"></asp:TextBox>

                                                                                <label>Cantidad de semilla requerida Comercial</label>
                                                                                <asp:Label ID="Label55" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                <asp:TextBox CssClass="form-control " ID="txt_Re_Comercial_Paraisito" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                            </div>
                                                                        </div>

                                                                        <%--  Fin de parasito mejorado--%>
                                                                        <div class="col-lg-12">
                                                                            <hr />
                                                                        </div>
                                                                        <%--    Inicio de Honduras nutritivo--%>
                                                                        <div>
                                                                            <div class="col-lg-3">

                                                                                <div class="form-group">
                                                                                    <label>Honduras Nutritivo </label>
                                                                                    <asp:Label ID="Label56" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:DropDownList CssClass="form-control" ID="lb_Honduras" runat="server" AutoPostBack="True">
                                                                                        <asp:ListItem></asp:ListItem>
                                                                                        <asp:ListItem>Si</asp:ListItem>
                                                                                        <asp:ListItem>No</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-lg-3">

                                                                                <span style="margin-right: 20px;"></span>
                                                                                <div class="form-group">
                                                                                    <label>Certificado</label>
                                                                                    <asp:Label ID="Label57" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:DropDownList CssClass="form-control" ID="lb_Certificado_Honduras" runat="server" AutoPostBack="True">
                                                                                        <asp:ListItem></asp:ListItem>
                                                                                        <asp:ListItem>Si</asp:ListItem>
                                                                                        <asp:ListItem>No</asp:ListItem>
                                                                                    </asp:DropDownList>

                                                                                    <label>Comercial</label>
                                                                                    <asp:Label ID="Label58" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Comercial_Honduras" runat="server" AutoPostBack="True">
                                                                                        <asp:ListItem></asp:ListItem>
                                                                                        <asp:ListItem>Si</asp:ListItem>
                                                                                        <asp:ListItem>No</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-lg-3">
                                                                                <span style="margin-right: 20px;"></span>
                                                                                <div class="form-group ">
                                                                                    <label>Inventario Existente Certificado</label>
                                                                                    <asp:Label ID="Label59" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:TextBox CssClass="form-control" ID="txt_In_Certificado_Honduras" runat="server" AutoPostBack="True"></asp:TextBox>

                                                                                    <label>Inventario Existente Comercial</label>
                                                                                    <asp:Label ID="Label60" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:TextBox CssClass="form-control" ID="txt_In_Comercial_Honduras" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-lg-3">
                                                                                <span style="margin-right: 20px;"></span>
                                                                                <div class="form-group">
                                                                                    <label>Cantidad de semilla requerida Certificado</label>
                                                                                    <asp:Label ID="Label61" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:TextBox CssClass="form-control" ID="txt_Re_Certificado_Honduras" runat="server" AutoPostBack="True"></asp:TextBox>

                                                                                    <label>Cantidad de semilla requerida Comercial</label>
                                                                                    <asp:Label ID="Label62" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:TextBox CssClass="form-control " ID="txt_Re_Comercial_Honduras" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <%-- fin de Honduras nutritivo--%>
                                                                        <div class="col-lg-12">
                                                                            <hr />
                                                                        </div>

                                                                        <%--  Incio de Inta Cárdenas--%>
                                                                        <div>
                                                                            <div class="col-lg-3">

                                                                                <div class="form-group">
                                                                                    <label>Inta Cárdenas </label>
                                                                                    <asp:Label ID="Label63" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:DropDownList CssClass="form-control" ID="lb_Inta" runat="server" AutoPostBack="True">
                                                                                        <asp:ListItem></asp:ListItem>
                                                                                        <asp:ListItem>Si</asp:ListItem>
                                                                                        <asp:ListItem>No</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-lg-3">

                                                                                <span style="margin-right: 20px;"></span>
                                                                                <div class="form-group">
                                                                                    <label>Certificado</label>
                                                                                    <asp:Label ID="Label64" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:DropDownList CssClass="form-control" ID="lb_Certificado_Inta" runat="server" AutoPostBack="True">
                                                                                        <asp:ListItem></asp:ListItem>
                                                                                        <asp:ListItem>Si</asp:ListItem>
                                                                                        <asp:ListItem>No</asp:ListItem>
                                                                                    </asp:DropDownList>

                                                                                    <label>Comercial</label>
                                                                                    <asp:Label ID="Label65" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Comercial_Inta" runat="server" AutoPostBack="True">
                                                                                        <asp:ListItem></asp:ListItem>
                                                                                        <asp:ListItem>Si</asp:ListItem>
                                                                                        <asp:ListItem>No</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-lg-3">
                                                                                <span style="margin-right: 20px;"></span>
                                                                                <div class="form-group ">
                                                                                    <label>Inventario Existente Certificado</label>
                                                                                    <asp:Label ID="Label66" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:TextBox CssClass="form-control" ID="txt_In_Certificado_Inta" runat="server" AutoPostBack="True"></asp:TextBox>

                                                                                    <label>Inventario Existente Comercial</label>
                                                                                    <asp:Label ID="Label67" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:TextBox CssClass="form-control" ID="txt_In_Comercial_Inta" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-lg-3">
                                                                                <span style="margin-right: 20px;"></span>
                                                                                <div class="form-group">
                                                                                    <label>Cantidad de semilla requerida Certificado</label>
                                                                                    <asp:Label ID="Label68" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:TextBox CssClass="form-control" ID="txt_Re_Certificado_Inta" runat="server" AutoPostBack="True"></asp:TextBox>

                                                                                    <label>Cantidad de semilla requerida Comercial</label>
                                                                                    <asp:Label ID="Label69" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:TextBox CssClass="form-control " ID="txt_Re_Comercial_Inta" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <%--   fin de Inta --%>

                                                                        <div class="col-lg-12">
                                                                            <hr />
                                                                        </div>

                                                                        <%--   inicio de Lenca precoz--%>
                                                                        <div>
                                                                            <div class="col-lg-3">

                                                                                <div class="form-group">
                                                                                    <label>Lenca precoz </label>
                                                                                    <asp:Label ID="Label70" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:DropDownList CssClass="form-control" ID="lb_Lenca" runat="server" AutoPostBack="True">
                                                                                        <asp:ListItem></asp:ListItem>
                                                                                        <asp:ListItem>Si</asp:ListItem>
                                                                                        <asp:ListItem>No</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-lg-3">
                                                                                <span style="margin-right: 20px;"></span>
                                                                                <div class="form-group">
                                                                                    <label>Certificado</label>
                                                                                    <asp:Label ID="Label71" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:DropDownList CssClass="form-control" ID="lb_Certificado_Lenca" runat="server" AutoPostBack="True">
                                                                                        <asp:ListItem></asp:ListItem>
                                                                                        <asp:ListItem>Si</asp:ListItem>
                                                                                        <asp:ListItem>No</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <label>Comercial</label>
                                                                                    <asp:Label ID="Label72" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Comercial_Lenca" runat="server" AutoPostBack="True">
                                                                                        <asp:ListItem></asp:ListItem>
                                                                                        <asp:ListItem>Si</asp:ListItem>
                                                                                        <asp:ListItem>No</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-lg-3">
                                                                                <span style="margin-right: 20px;"></span>
                                                                                <div class="form-group ">
                                                                                    <label>Inventario Existente Certificado</label>
                                                                                    <asp:Label ID="Label73" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:TextBox CssClass="form-control" ID="lb_In_Certificado_Lenca" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                                    <label>Inventario Existente Comercial</label>
                                                                                    <asp:Label ID="Label74" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:TextBox CssClass="form-control" ID="lb_In_Comercial_Lenca" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-lg-3">
                                                                                <span style="margin-right: 20px;"></span>
                                                                                <div class="form-group">
                                                                                    <label>Cantidad de semilla requerida Certificado</label>
                                                                                    <asp:Label ID="Label75" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:TextBox CssClass="form-control" ID="txt_Re_Certificado_Lenca" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                                    <label>Cantidad de semilla requerida Comercial</label>
                                                                                    <asp:Label ID="Label76" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:TextBox CssClass="form-control " ID="txt_Re_Comercial_Lenca" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <%--   Fin de Lenca precoz--%>
                                                                        <div class="col-lg-12">
                                                                            <hr />
                                                                        </div>
                                                                        <%--  Inicio de  Rojo chortí--%>
                                                                        <div>
                                                                            <div class="col-lg-3">

                                                                                <div class="form-group">
                                                                                    <label>Rojo chortí </label>
                                                                                    <asp:Label ID="Label77" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:DropDownList CssClass="form-control" ID="lb_Rojo" runat="server" AutoPostBack="True">
                                                                                        <asp:ListItem></asp:ListItem>
                                                                                        <asp:ListItem>Si</asp:ListItem>
                                                                                        <asp:ListItem>No</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-lg-3">

                                                                                <span style="margin-right: 20px;"></span>
                                                                                <div class="form-group">
                                                                                    <label>Certificado</label>
                                                                                    <asp:Label ID="Label78" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:DropDownList CssClass="form-control" ID="lb_Certificado_Rojo" runat="server" AutoPostBack="True">
                                                                                        <asp:ListItem></asp:ListItem>
                                                                                        <asp:ListItem>Si</asp:ListItem>
                                                                                        <asp:ListItem>No</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <label>Comercial</label>
                                                                                    <asp:Label ID="Label79" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Comercial_Rojo" runat="server" AutoPostBack="True">
                                                                                        <asp:ListItem></asp:ListItem>
                                                                                        <asp:ListItem>Si</asp:ListItem>
                                                                                        <asp:ListItem>No</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-lg-3">
                                                                                <span style="margin-right: 20px;"></span>
                                                                                <div class="form-group ">
                                                                                    <label>Inventario Existente Certificado</label>
                                                                                    <asp:Label ID="Label80" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:TextBox CssClass="form-control" ID="lb_In_Certificado_Rojo" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                                    <label>Inventario Existente Comercial</label>
                                                                                    <asp:Label ID="Label81" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:TextBox CssClass="form-control" ID="lb_In_Comercial_Rojo" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-lg-3">
                                                                                <span style="margin-right: 20px;"></span>
                                                                                <div class="form-group">
                                                                                    <label>Cantidad de semilla requerida Certificado</label>
                                                                                    <asp:Label ID="Label82" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:TextBox CssClass="form-control" ID="txt_Re_Certificado_Rojo" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                                    <label>Cantidad de semilla requerida Comercial</label>
                                                                                    <asp:Label ID="Label83" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                    <asp:TextBox CssClass="form-control " ID="txt_Re_Comercial_Rojo" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <%--    fin de rojo --%>
                                                                        <div class="col-lg-12">
                                                                            <hr />
                                                                        </div>
                                                                        <%--   Inicio Tolupan rojo	--%>
                                                                        <div class="col-lg-3">

                                                                            <div class="form-group">
                                                                                <label>Tolupan rojo </label>
                                                                                <asp:Label ID="Label84" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                <asp:DropDownList CssClass="form-control" ID="lb_Tolupan" runat="server" AutoPostBack="True">
                                                                                    <asp:ListItem></asp:ListItem>
                                                                                    <asp:ListItem>Si</asp:ListItem>
                                                                                    <asp:ListItem>No</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-lg-3">
                                                                            <span style="margin-right: 20px;"></span>
                                                                            <div class="form-group">
                                                                                <label>Certificado</label>
                                                                                <asp:Label ID="Label85" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                <asp:DropDownList CssClass="form-control" ID="lb_Certificado_Tolupan" runat="server" AutoPostBack="True">
                                                                                    <asp:ListItem></asp:ListItem>
                                                                                    <asp:ListItem>Si</asp:ListItem>
                                                                                    <asp:ListItem>No</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <label>Comercial</label>
                                                                                <asp:Label ID="Label86" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Comercial_Tolupan" runat="server" AutoPostBack="True">
                                                                                    <asp:ListItem></asp:ListItem>
                                                                                    <asp:ListItem>Si</asp:ListItem>
                                                                                    <asp:ListItem>No</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-lg-3">
                                                                            <span style="margin-right: 20px;"></span>
                                                                            <div class="form-group ">
                                                                                <label>Inventario Existente Certificado</label>
                                                                                <asp:Label ID="Label87" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                <asp:TextBox CssClass="form-control" ID="txt_In_Certificado_Tolupan" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                                <label>Inventario Existente Comercial</label>
                                                                                <asp:Label ID="Label88" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                <asp:TextBox CssClass="form-control" ID="txt_In_Comercial_Tolupan" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-lg-3">
                                                                            <span style="margin-right: 20px;"></span>
                                                                            <div class="form-group">
                                                                                <label>Cantidad de semilla requerida Certificado</label>
                                                                                <asp:Label ID="Label89" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                <asp:TextBox CssClass="form-control" ID="txt_Re_Certificado_Tolupan" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                                <label>Cantidad de semilla requerida Comercial</label>
                                                                                <asp:Label ID="Label90" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                                <asp:TextBox CssClass="form-control " ID="txt_Re_Comercial_Tolupan" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <%-- fin de tolupan rojo--%>
                                                                    <div class="col-lg-12">
                                                                        <hr />
                                                                    </div>

                                                                    <%-- inicio de otro--%>
                                                                    <div class="col-lg-3">

                                                                        <div class="form-group">
                                                                            <label>Otra variedad, especificar nombre comercial </label>
                                                                            <asp:Label ID="Label91" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                            <asp:TextBox CssClass="form-control " ID="lb_Otra" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-3">
                                                                        <span style="margin-right: 20px;"></span>
                                                                        <div class="form-group">
                                                                            <label>Certificado</label>
                                                                            <asp:Label ID="Label92" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                            <asp:DropDownList CssClass="form-control" ID="lb_Certificado_Otra" runat="server" AutoPostBack="True">
                                                                                <asp:ListItem></asp:ListItem>
                                                                                <asp:ListItem>Si</asp:ListItem>
                                                                                <asp:ListItem>No</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <label>Comercial</label>
                                                                            <asp:Label ID="Label93" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                            <asp:DropDownList CssClass="form-control form-control-lg" ID="lb_Comercial_Otra" runat="server" AutoPostBack="True">
                                                                                <asp:ListItem></asp:ListItem>
                                                                                <asp:ListItem>Si</asp:ListItem>
                                                                                <asp:ListItem>No</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-3">
                                                                        <span style="margin-right: 20px;"></span>
                                                                        <div class="form-group ">
                                                                            <label>Inventario Existente Certificado</label>
                                                                            <asp:Label ID="Label94" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                            <asp:TextBox CssClass="form-control" ID="txt_In_Certificado_Otra" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                            <label>Inventario Existente Comercial</label>
                                                                            <asp:Label ID="Label95" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                            <asp:TextBox CssClass="form-control" ID="lb_In_Comercial_Otra" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-3">
                                                                        <span style="margin-right: 20px;"></span>
                                                                        <div class="form-group">
                                                                            <label>Cantidad de semilla requerida Certificado</label>
                                                                            <asp:Label ID="Label96" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                            <asp:TextBox CssClass="form-control" ID="txt_Re_Certificado_Otra" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                            <label>Cantidad de semilla requerida Comercial</label>
                                                                            <asp:Label ID="Label97" class="label label-warning" runat="server" Text=""></asp:Label>
                                                                            <asp:TextBox CssClass="form-control " ID="txt_Re_Comercial_Otra" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <%--        fin de otro--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <script type="text/javascript">
                                        function numericOnly(elementRef) {
                                            var keyCodeEntered = (event.which) ? event.which : (window.event.keyCode) ? window.event.keyCode : -1;

                                            // Un-comment to discover a key that I have forgotten to take into account...
                                            //alert(keyCodeEntered);

                                            if ((keyCodeEntered >= 48) && (keyCodeEntered <= 57)) {
                                                return true;
                                            }
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
                                </div>

                                <div id="div2" runat="server">
                                    <%--       <asp:Button ID="Guardar_registro"  class="btn btn-success" runat="server" Text="Guardar"  data-toggle="modal" data-target="#exampleModal2" />--%>
                                    <button type="button" id="btn_nuevo_prod" runat="server" class="btn btn-success" data-toggle="modal" data-target="#exampleModal222">
                                        Guardar
                                    </button>

                                    <asp:Button ID="Button3" class="btn btn-danger" runat="server" Text="Regresar" />
                                </div>
                            </div>

                            <div class="row">
                                <div class="auto-style3">
                                    <script type="text/javascript" src='../vendor/jquery/jquery-1.8.3.min.js'></script>

                                    <div class="modal fade" id="exampleModal222" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                        <div class="modal-dialog" role="document">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <h5 class="modal-title" id="exampleModalLabela22">IHMA</h5>
                                                </div>
                                                <div class="modal-body">
                                                    ¿Está seguro que sea registrar una nueva Producción de Frijól?
                                                </div>
                                                <div class="modal-footer">

                                                    <asp:Button ID="btn_si_nuevo" Text="SI" Width="80px" runat="server" Class="btn btn-Success" />
                                                    <button type="button" id="Button5" runat="server" class="btn btn-danger" data-dismiss="modal">NO</button>
                                                    <%-- <asp:Button ID="Button1" Text="SI" Width="80px" runat="server" Class="btn btn-Success" />--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                    <br />

                                    <asp:Label ID="Label13" class="badge badge-pill badge-success" runat="server" Text=""></asp:Label>

                                    <!-- Modal -->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
</div>

              <%--      HASTA AQUI NUEVO FORM--%>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="modal fade" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">MAS 2.0 - IHMA</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ¿Está seguro que desea actualizar el registro de las Organización?
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnsi" class="btn btn-primary" runat="server" Text="SI" />

                    <button type="button" class="btn btn-danger" data-dismiss="modal">NO</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>