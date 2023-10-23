<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="EnviarCorreo.aspx.vb" Inherits="MAS_PMSU.EnviarCorreo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Enviar Correo Electrónico</h1>
    

    <div>Correo del remitente</div>
    
    <div class="col-lg-3">
        <div class="form-group">
            <div>
                <asp:Label ID="lblAsunto" runat="server" Text="Remitente:"></asp:Label>
                <asp:TextBox ID="txtRemitente" runat="server" AutoPostBack="false"></asp:TextBox>
            </div>
        </div>
    </div>
    
    <div class="col-lg-3">
        <div class="form-group">
           <div>
                <asp:Label ID="lblDestinatario" runat="server" Text="Destinatario:"></asp:Label>
                <asp:TextBox ID="txtDestinatario" runat="server" AutoPostBack="false"></asp:TextBox>
           </div>
        </div>
    </div>
    
    <div class="col-lg-3">
        <div class="form-group">
           <div>
                <asp:Label ID="lblAdjunto" runat="server" Text="Adjuntar Archivo:"></asp:Label>
                <asp:FileUpload ID="fuArchivo" runat="server" />
            </div>
        </div>
    </div>

    <div>
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar Correo" OnClick="EnviarCorreo" />
    </div>
</asp:Content>