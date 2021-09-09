<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="consultas.aspx.vb" Inherits="Tsu.Paginas.administracion_consultas" title="Consultas de Revendedoras" %>
<%@ Register src="../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>
<%@ Register src="../controles/cabeceraRevendedora.ascx" tagname="cabeceraRevendedora" tagprefix="uc2" %>
<%@ Register src="../controles/GrillaConsulta.ascx" tagname="GrillaConsulta" tagprefix="uc3" %>


<asp:Content ID="Content3" ContentPlaceHolderID="Menu" Runat="Server">
<uc1:MenuIzquierda ID="MenuIzquierda1"  menu="Revendedoras"   runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
      <div class="Titulo">REVENDEDORAS</div>
      <div class="subTitulo">Consulta de pedidos anteriores</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID="panelrevendedora" runat="server" Visible="False" CssClass="tablaSeparador1">
   <uc2:cabeceraRevendedora ID="cabeceraRevendedora1" runat="server" />
   <table width="715" border="0" cellpadding="5" cellspacing="0">
    <tr class="tablaTitulo2">
      <td width="112" height="30">Elegir campa&ntilde;a</td>
      <td width="150"><asp:DropDownList ID="ddlHistCampania" runat="server" AutoPostBack="True"></asp:DropDownList></td> 
      <td><asp:Label ID="lblMensaje"  ForeColor="Blue" Text="Pedido cerrado"  runat="server" Visible="false"  ></asp:Label></td>    
    </tr>
   </table>
</asp:Panel>   
<div style="clear:both">
</div>

<%--seccion de grillas --%>
 <uc3:GrillaConsulta ID="GrillaConsulta1" micarga="false" tipo="Pedidos" runat="server" />
 <%--fin de seccion grillas--%>    
</asp:Content>

