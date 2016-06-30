<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TP_ARE.WebForms.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<fieldset><legend>Contacta con nosotros.</legend>
<div class="control-group">
<label class="control-label">Nombre:</label>
<div class="controls">
    <asp:TextBox class="span5" ID="TextBox1" runat="server"></asp:TextBox>
</div>
</div>
<div class="control-group">
<label class="control-label">Apellido:</label>
<div class="controls">
    <asp:TextBox class="span5" ID="TextBox2" runat="server"></asp:TextBox>
</div>
</div>
<div class="control-group">
<label class="control-label">Email:</label>
<div class="controls">
    <asp:TextBox class="span5" ID="TextBox3" runat="server"></asp:TextBox>
</div>
</div>
<div class="control-group">
<label class="control-label">Teléfono:</label>
<div class="controls">
    <asp:TextBox  class="span5" ID="TextBox4" runat="server"></asp:TextBox>
</div>
</div>
<div class="control-group">
<label class="control-label">Mensaje:</label>
<div class="controls">
    <asp:TextBox class="span5" ID="TextBox5" runat="server" Rows="5" Columns="20" TextMode="MultiLine"></asp:TextBox>
</div>
</div>
<div class="control-group">
<div class="controls">
    <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Enviar" />
</div>
</div>
</fieldset>
</asp:Content>
