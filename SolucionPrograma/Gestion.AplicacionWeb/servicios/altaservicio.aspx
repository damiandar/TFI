<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="altaservicio.aspx.vb" Inherits="servicios_altaservicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
<tr><td>Nombre</td><td>    <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>       </td></tr>
<tr><td>Imagen</td><td><asp:FileUpload ID="FileUpload1" runat="server" /></td></tr>    
<tr><td colspan="2"><asp:ImageButton ID="btnCrearProducto" ImageUrl="~/assets/images/Boton_Solicitar_Contrasena.gif" runat="server" width="130" height="19" /></td></tr>
</table>
</asp:Content>

