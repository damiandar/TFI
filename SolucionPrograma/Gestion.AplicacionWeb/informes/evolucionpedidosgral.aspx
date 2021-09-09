<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="evolucionpedidosgral.aspx.vb" Inherits="Tsu.Paginas.administracion_evolucionpedidos" title="::
Evolución de pedidos::" %>
<%@ Register src="../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>
<%@ Register src="../controles/GrillaEvolucion.ascx" tagname="GrillaEvolucion" tagprefix="uc2" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1"  menu="Gestion"   runat="server" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
      <div class="Titulo">CONSULTAS</div>
      <div class="subTitulo">Evolucion general de pedidos</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Panel ID="panelfiltros" runat="server" CssClass="tablaSeparador1">
<table width="715" border="0" cellspacing="0" cellpadding="5" class="tablaTitulo1">
    <tr>
    <td width="34px"><b>Zona</b></td>
    <td width="100px"><asp:DropDownList DataTextField="zona" DataValueField="zona" ID="comboZona" runat="server" ></asp:DropDownList></td>
    <td width="70px"><b>Campa&ntilde;a</b></td>
    <td width="100px"><asp:DropDownList ID="ddlCampania" DataValueField="campania" DataTextField="campania" runat="server"></asp:DropDownList></td>
    <td width="231px" align="center"><asp:ImageButton ID="btnConfirmar" runat="server" ImageUrl="~/assets/images/Boton_Ver_Verde.gif" /></td>
    </tr>
</table> 
</asp:Panel>
<asp:Panel ID="PanelInforme" runat="server" Visible="false">
       <uc2:GrillaEvolucion ID="GrillaEvolucionCurso" general="true" tipo="Curso" runat="server" />
       <uc2:GrillaEvolucion ID="GrillaEvolucionCerrado" general="true" tipo="Cerrado" runat="server" />
</asp:Panel>
</asp:Content>

