<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Paginas.Master" CodeBehind="WebForm2.aspx.vb" Inherits="MAS_PMSU.WebForm2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    $(function () {
        $("#txtchilddatepicker").datepicker();
    });
    </script>
    <p>
        Child Page Date:
        <input type="text" id="txtchilddatepicker">
    </p>
</asp:Content>