<%@ Control Language="VB" AutoEventWireup="false" CodeFile="domicilio.ascx.vb" Inherits="Tsu.Paginas.controles_domicilio" %>

<style type="text/css">
    .style1
    {
        text-align: left;
    }
</style>
 
<asp:Panel ID="nuevo" runat="server">
   <script type="text/javascript">
    $(document).ready(function()    {
   //pasar con el enter
      $('[id$="tbDomicilio"]').keypress(function(e) {
      if( e.which==13)   {  e.preventDefault();  $('[id$="tbLocalidad"]').focus(); } });
      
      $('[id$="tbLocalidad"]').keypress(function(e) {
      if( e.which==13)   {  e.preventDefault();  $('[id$="btnConfirmar"]').focus(); } });
    });
    </script>
   <div class="mensaje_contenedor" >
        <div class="mensaje_info_715">
        Si este pedido debe enviarse a otra dirección, por favor complete los datos.</div>
    </div>
   <table width="715" border="0" cellspacing="0" cellpadding="5">
  <tr>
    <td width="70px" >Direcci&oacute;n:</td>
    <td width="625px"><asp:TextBox ID="tbDomicilio" runat="server" Width="200px" style="border: 1px solid #999; width:250px; height:20px;"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbDomicilio" Display="Dynamic" ErrorMessage="Debe ingresar la dirección" ValidationGroup="VGdomicilio"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td >Localidad:</td>
    <td><asp:TextBox ID="tbLocalidad" runat="server" Width="200px" style="border: 1px solid #999; width:250px; height:20px;"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbLocalidad" Display="Dynamic" ErrorMessage="Debe ingresar la localidad" ValidationGroup="VGdomicilio"></asp:RequiredFieldValidator></td>
  </tr>  
  <tr><td >&nbsp;</td> <td>&nbsp;</td> </tr>
  <tr>
    <td >&nbsp;</td>
    <td><asp:ImageButton ID="btnConfirmar" ImageUrl="~/assets/images/boton_aceptar.gif" alt="" width="65" height="19" runat="server" ValidationGroup="VGdomicilio"/></td>
  </tr>
</table>
</asp:Panel>

<asp:Panel ID="ver" runat="server">
    <asp:Panel ID="Mensaje" runat="server" Visible="false" >
        <div class="mensaje_contenedor">
            <div class="mensaje_ok_715">Los datos han sido registrados con éxito.</div>
		</div>
	</asp:Panel>
    <table width="715" border="0" cellspacing="0" cellpadding="5">
      <tr>
        <td width="70" >Direcci&oacute;n:</td><td width="625"><asp:Literal ID="ltdomicilio" runat="server"></asp:Literal></td>
      </tr>
      <tr>
        <td >Localidad:</td><td><asp:Literal ID="ltlocalidad" runat="server"></asp:Literal></td>
      </tr>      
      <tr><td >&nbsp;</td><td>&nbsp;</td></tr>
      <tr>
        <td >&nbsp;</td>
        <td>
            <asp:ImageButton ID="btnModificar"  runat="server" ImageUrl="~/assets/images/boton_modificar.gif" alt="" width="65" height="19" /> 
            <asp:ImageButton ID="btnborrar" runat="server" ImageUrl="~/assets/images/boton_borrar.gif" OnClientClick="return confirm('¿Confirma la eliminación del domicilio?')" alt="" width="65" height="19"/>
            <asp:ImageButton ID="btnContinuar"  runat="server" ImageUrl="~/assets/images/boton_continuar.gif" alt="" width="65" height="19"/>
        </td>
      </tr>
    </table>
</asp:Panel>

<asp:Panel ID="Modificar" runat="server">
   <script type="text/javascript">
    $(document).ready(function()    {
   //pasar con el enter
      $('[id$="tbDomicilio2"]').keypress(function(e) {
      if( e.which==13)   {  e.preventDefault();  $('[id$="tbLocalidad2"]').focus(); } });
      
      $('[id$="tbLocalidad2"]').keypress(function(e) {
      if( e.which==13)   {  e.preventDefault();  $('[id$="btnConfirmar2"]').focus(); } });
    });
    </script>    
<table width="715" border="0" cellspacing="0" cellpadding="5">
  <tr>
    <td width="70px" >Direcci&oacute;n:</td>
    <td width="625px"><asp:TextBox ID="tbDomicilio2" runat="server" Width="200px" style="border: 1px solid #999; width:250px; height:20px;"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbDomicilio2" Display="Dynamic" ErrorMessage="El código no puede quedar vacío" ValidationGroup="VGdomicilio2">La dirección no puede quedar vacía.</asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td >Localidad:</td>
    <td><asp:TextBox ID="tbLocalidad2" runat="server" Width="200px" style="border: 1px solid #999; width:250px; height:20px;"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbLocalidad2" Display="Dynamic" ErrorMessage="El código no puede quedar vacío"  ValidationGroup="VGdomicilio2">La localidad no puede quedar vacía.</asp:RequiredFieldValidator></td>
  </tr>  
  <tr><td >&nbsp;</td> <td>&nbsp;</td> </tr>
  <tr>
    <td >&nbsp;</td>
    <td><asp:ImageButton ID="btnConfirmar2" ImageUrl="~/assets/images/boton_confirmar.gif" alt="" width="65" height="19" runat="server" ValidationGroup="VGdomicilio2"/>
    <asp:ImageButton ID="btnCancelar"  ImageUrl="~/assets/images/boton_cancelar.gif" runat="server" />
    </td>
  </tr>
</table>
</asp:Panel>


