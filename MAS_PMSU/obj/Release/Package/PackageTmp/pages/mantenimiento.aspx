<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/principal.Master" CodeBehind="mantenimiento.aspx.vb" Inherits="MAS_PMSU.mantenimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


      <div id="NO_DISPONIBLE" runat="server">
            <div class="col-lg-12">
            
                <div class="panel-heading"> 
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                     <asp:TextBox ID="TextBox1" visible="false" runat="server"></asp:TextBox>
                </div>
             
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                           <h1><strong><span style="color: #000000;">MÓDULO EN MANTENIMIENTO</span></strong></h1>
                                 <br/>
                                 <br/>

                                          <asp:Image ID="Image2" runat="server" ImageUrl="~/imagenes/mantenimiento.jpg" />

                            </div>
                             </div>



                      
                    
                      
                            </div>


                      </div>

           
        </div>


</asp:Content>
