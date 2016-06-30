<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="MiCuenta.aspx.cs" Inherits="TP_ARE.WebForms.MiCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
     <div class="control-group" > 
         <label class="control-label" >Usuario:</label>        
         <div class="controls">
             <asp:Label ID="lblusuario" class="label label-info" runat="server"></asp:Label>
        </div>
        </div>
     <div class="control-group" >  
         <label class="control-label" >Vieja contraseña:</label>
        
         <div class="controls">
        
            <asp:TextBox ID="txtContra" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="contra" runat="server" 
                ControlToValidate="txtContra" ErrorMessage="Contraseña requerida" 
                ForeColor="Red"></asp:RequiredFieldValidator>
     </div>
     </div>
        <div class="control-group" > 
         <label class="control-label" >Nueva contraseña:</label>        
         <div class="controls">
            <asp:TextBox ID="txtNuevaContra" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="contraRep" runat="server" 
                ControlToValidate="txtNuevaContra" ErrorMessage="Debe ingresar una nueva contraseña" 
                ForeColor="Red"></asp:RequiredFieldValidator>
     </div>
     </div>
    
             <div class="control-group" >         
         <div class="controls">

            <asp:Button ID="btnRegistrar" class="btn btn-primary" runat="server" Text="Cambiar Contraseña"
                onclick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" class="btn" runat="server" CausesValidation="False" 
                onclick="Button1_Click1"  Text="Cerrar Sesion" />
     </div>
     </div>  

      <div class="control-group" > 
        
        
         <div class="controls alert">
            <asp:Label ID="lblMensaje" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
            <div></div>
</asp:Content>
