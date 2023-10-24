<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="EnviarCorreo.aspx.vb" Inherits="MAS_PMSU.EnviarCorreo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Enviar de Solicitud de Inscripción de Lote</h1>
            </div>
        </div>

        <div class="row">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    A. Datos del Correo
                </div>
                <div class="panel-body">
                    <div class="col-lg-4">
                        <div class="form-group">
                            <asp:Label ID="lblAsunto" runat="server" Text="Remitente:      "></asp:Label>
                            <asp:TextBox ID="txtRemitente" runat="server" AutoPostBack="false" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <asp:Label ID="lblDestinatario" runat="server" Text="Destinatario:"></asp:Label>
                            <asp:TextBox ID="txtDestinatario" runat="server" AutoPostBack="false" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <asp:Label ID="lblAdjunto" runat="server" Text="Adjuntar Archivo PDF:"></asp:Label>
                            <asp:FileUpload ID="fuArchivo" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <asp:Label ID="Label1" class="label label-warning" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" Text="Enviar Correo" OnClick="EnviarCorreo" visible="true"/>
        </div>

</asp:Content>