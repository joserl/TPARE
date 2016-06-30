<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="TP_ARE.WebForms.RegistrarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   <div class="control-group" > 
         <label class="control-label" >Usuario:</label>        
         <div class="controls">
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="usuario" runat="server" 
                 ControlToValidate="txtUsuario" ErrorMessage="Nombre de usuario requerido" 
                 ForeColor="Red"></asp:RequiredFieldValidator>
     </div></div>
     <div class="control-group" > 
         <label class="control-label" >Contraseña:</label>        
         <div class="controls"><asp:TextBox ID="txtContra" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="contra" runat="server" 
                ControlToValidate="txtContra" ErrorMessage="Contraseña requerida" 
                ForeColor="Red"></asp:RequiredFieldValidator>
      </div></div>
     <div class="control-group" > 
         <label class="control-label" >Repetir contraseña:</label>        
         <div class="controls"><asp:TextBox ID="txtRepContra" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="contraRep" runat="server" 
                ControlToValidate="txtRepContra" ErrorMessage="Debe repetir de la contraseña" 
                ForeColor="Red"></asp:RequiredFieldValidator>
        </div></div>
     
   
    <div class="control-group" > 
         <div class="controls">
            <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Registrar" Width="115px" 
                onclick="Button1_Click" />
    </div>
    </div>
    <div class="controls alert " >          
            <asp:Label ID="lblMensaje"  runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
            </div>
</asp:Content>
