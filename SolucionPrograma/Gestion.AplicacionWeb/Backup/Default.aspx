<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Tsu.Paginas._Default" title="::Bienvenida::" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
   <tr><td>Apellido y Nombre:</td><td><asp:Literal runat="server" ID="ltApellido"></asp:Literal></td><td>Zona:</td><td><asp:Literal runat="server" ID="ltZona"></asp:Literal></td></tr>
   <tr><td>Cuenta:</td><td><asp:Literal runat="server" ID="ltCuenta"></asp:Literal></td><td>Grupo:</td><td><asp:Literal runat="server" ID="ltGrupo"></asp:Literal></td></tr>
   <tr><td>Documento:</td><td><asp:Literal runat="server" ID="ltDocumento"></asp:Literal></td></tr>

</table>
</asp:Content>

