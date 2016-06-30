<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP_ARE.WebForms.Registrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="control-group" > 
         <label class="control-label" >Usuario</label>        
         <div class="controls">
             <asp:TextBox ID="txtusaurio" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="validarUsuario" runat="server" 
                 ControlToValidate="txtusaurio" ErrorMessage="EL campo usuario es requerido" 
                 ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="control-group" > 
         <label class="control-label" >Contraseña:</label>
        <div class="controls">
         
                 <asp:TextBox ID="txtContra" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="validarPas" runat="server" 
                ControlToValidate="txtContra" ErrorMessage="Contraseña requerida" 
                ForeColor="Red"></asp:RequiredFieldValidator>
        
        </div></div>
     <div class="control-group" >      
     <div class="controls">  
         
         <label class="checkbox" >
         
          <asp:CheckBox ID="cbRecordar" runat="server" />Recordarme</label>
          </div></div>
      <div class="control-group" > 
     <div class="controls">
                     <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Iniciar Sesion" 
            onclick="Button1_Click" />
            <asp:Button ID="btnRegistrar" class="btn" runat="server" Text="Registrarse" 
                onclick="btnRegistrar_Click"  CausesValidation="False" />
        </div></div>
     <div class="controls alert">
            <asp:Label ID="txtMensaje" runat="server" ForeColor="Red"></asp:Label>
      </div>
    
   
</asp:Content>
