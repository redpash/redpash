<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="WebForm3.aspx.vb" Inherits="MAS_PMSU.WebForm3" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>--%>
    <script type="text/javascript" src="../vendor/jquery/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#txtchilddatepicker").datepicker();
        });
    </script>
    <p>
        Child Page Date:
        <input type="text" id="txtchilddatepicker">
    </p>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <%--<script type="text/javascript" src='../vendor/jquery/prueba/jquery.min.js'></script>--%>
</asp:Content>
