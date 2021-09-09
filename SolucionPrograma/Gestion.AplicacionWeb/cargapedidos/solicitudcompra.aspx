<%@ Page Language="VB" Buffer="true"  MaintainScrollPositionOnPostback="true" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="solicitudcompra.aspx.vb" Inherits="Tsu.Paginas.cargapedidos_solicitudcompra" title="::Productos y Auxiliares de Revendedoras::" %>
<%@ Register src="../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>
<%@ Register src="../controles/cabeceraRevendedora.ascx" tagname="cabeceraRevendedora" tagprefix="uc2" %>
<%@ Register src="../controles/grillasdecarga/grillaPedidos.ascx" tagname="grillaPedidos" tagprefix="uc3" %>

<%@ Register src="../controles/combo.ascx" tagname="combo" tagprefix="uc4" %>

<%@ Register src="../controles/detalles/detallepedidos.ascx" tagname="detalle" tagprefix="uc5" %>

<%@ Register src="../controles/AdvertenciaStock.ascx" tagname="AdvertenciaStock" tagprefix="uc6" %>
<%@ Register src="../controles/motivos.ascx" tagname="motivos" tagprefix="uc7" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Menu" Runat="Server">
<uc1:MenuIzquierda ID="MenuIzquierda1"  menu="Revendedoras"   runat="server" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
      <div class="Titulo">REVENDEDORAS</div>
      <div class="subTitulo">Productos y auxiliares</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    $(document).ready(function()    {
       
    //pasar con el +
      $('[id$="tbproducto"]').keypress(function(e) {
      if( e.which==43)  {  e.preventDefault();  $('[id$="tbCantidad"]').focus(); } });
    
      $('[id$="tbCantidad"]').keypress(function(e) {
      if( e.which==43)   {  e.preventDefault();  $('[id$="btnaceptar"]').focus(); } });
    
    //pasa con el enter
        $('[id$="tbCantidad"]').keypress(function(e) {
      if( e.which==13)   {  e.preventDefault();  $('[id$="btnaceptar"]').focus(); } });
      
        $('[id$="tbproducto"]').keypress(function(e) {
      if( e.which==13)  {  e.preventDefault();  $('[id$="tbCantidad"]').focus(); } });
 
         $('[id$="tbCantidadSolicitadaGrilla"]').keypress(function(e) {
      if( e.which==13)   {  e.preventDefault();  $('[id$="LinkButton1"]').focus(); } });

    });
    </script>
    
<asp:Panel ID="panelrevendedora" runat="server" Visible="False">
<div class="tablaSeparador1">
        <uc2:cabeceraRevendedora mostrardomicilio="true" ID="cabeceraRevendedora1" runat="server" />
        <asp:Panel ID="PanelCampania" runat="server">
                <uc4:combo ID="combo1" runat="server" />
        </asp:Panel>
</div>
</asp:Panel>

<uc5:detalle ID="detalle1" runat="server" />

<asp:Panel  runat="server" ID="PanelSeparador" Visible="false">
    <div class="tablaSeparador1">
    </div>
</asp:Panel>
    <uc3:grillaPedidos ID="grillaProductos" runat="server" />
    <uc6:AdvertenciaStock ID="AdvertenciaStock1" runat="server" />
    <uc7:motivos ID="motivos1" TipoMotivo="SOLICITUD" runat="server" />
<%-- fin panel carga y grilla --%>
<asp:Panel ID="PanelPedidoCerrado" Visible="false" runat="server">
    <div class="mensaje_info_715" >
    El pedido está cerrado.
    </div>
</asp:Panel>
</asp:Content>

