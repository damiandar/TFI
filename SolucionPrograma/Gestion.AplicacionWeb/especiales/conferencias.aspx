<%@ Page Title="::Vista de conferencias::" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="conferencias.aspx.vb" Inherits="Tsu.Paginas.especiales_conferencias" %>
<%@ Register src="../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<%@ Register src="../controles/conferencia/GrillaConferencias.ascx" tagname="GrillaConferencias" tagprefix="uc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1"  menu="Consultas"   runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
    <div class="Titulo">Conferencias</div>
<div class="subTitulo">Vista de conferencias</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true" EnableScriptGlobalization="True" >        </asp:ToolkitScriptManager>   
   <table width="715" border="0" cellspacing="0" cellpadding="5" class="tablaTitulo1">
<tr>
<td>Zona: <asp:DropDownList DataTextField="zona" DataValueField="zona" ID="comboZona" runat="server" AutoPostBack="True"></asp:DropDownList></td>
<td> Año: <asp:DropDownList ID="ddlAnio" runat="server" AutoPostBack="true"></asp:DropDownList>  </td>
<td> Campaña: <asp:DropDownList ID="ComboCampania" runat="server" AutoPostBack="True"></asp:DropDownList></td>
</tr>
</table>
    <uc2:GrillaConferencias ID="GrillaConferencias1" runat="server" />
</asp:Content>

