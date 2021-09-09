<%@ Control Language="VB" AutoEventWireup="false"  CodeFile="cargaConferencia.ascx.vb"  Inherits="controles_cargaConferencia" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<link href="../../assets/css/black.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript">    
function GetCode(source, eventArgs) {
    document.getElementById('<%=hCodigoSalon.ClientID %>').value = eventArgs.get_value();
    document.getElementById('<%=hNombreSalon.ClientID %>').value = document.getElementById('<%=tbSalon.ClientID %>').value;
    }

</script>
<script type="text/javascript">
    $(document).ready(function()    {
      $('[id$="tbFecha"]').keypress(function(e) {
      if( (e.which==43) || (e.which==13)) {  
      if (!$(this).val()) {
      e.preventDefault();  $('[id$="tbFecha"]').focus(); } 
      else {
      e.preventDefault();  $('[id$="tbHora"]').focus(); }} });
      $('[id$="tbHora"]').keypress(function(e) {
      if( (e.which==43) || (e.which==13)) {  
      if (!$(this).val()) {
      e.preventDefault();  $('[id$="tbHora"]').focus(); } 
      else {
      e.preventDefault();  $('[id$="comboactividad"]').focus(); }} });
      $('[id$="comboactividad"]').keypress(function(e) {
      if( (e.which==43) || (e.which==13)) {  
      if (!$(this).val()) {
      e.preventDefault();  $('[id$="comboactividad"]').focus(); } 
      else {
      e.preventDefault();  $('[id$="ChkPpal"]').focus(); }} });
      $('[id$="ChkPpal"]').keypress(function(e) {
      if( (e.which==43) || (e.which==13)) {  
      if (!$(this).val()) {
      e.preventDefault();  $('[id$="ChkPpal"]').focus(); } 
      else {
      e.preventDefault();  $('[id$="tbSalon"]').focus(); }} });
      $('[id$="tbSalon"]').keypress(function(e) {
      if( (e.which==43) || (e.which==13)) {  
      if (!$(this).val()) {
      e.preventDefault();  $('[id$="tbSalon"]').focus(); } 
      else {
      e.preventDefault();  $('[id$="tbObservaciones"]').focus(); }} });
      $('[id$="tbObservaciones"]').keypress(function(e) {
      if( (e.which==43) || (e.which==13)) {  
      e.preventDefault();  $('[id$="btnConfirmar"]').focus(); } });
    });            
</script>

<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
<%--<asp:UpdatePanel runat="server" ID="PanelUpdate">
<ContentTemplate>--%>
   <asp:Panel runat="server" ID="PanelCarga">
   <asp:Panel runat="server" ID="PanelDatosConferencia">
<table width="715" class="tablaTitulo1" border="0" cellpadding="5" cellspacing="0"  >
<tr>
<td>Fecha *</td> <td>Hora *</td><td>Act *</td><td>Lugar *</td><td>Observaciones</td><td>Ppal.</td><td></td></tr>
<tr>    
<td><asp:TextBox ID="tbFecha" runat="server" Width="75px"  ValidationGroup="MKE"></asp:TextBox><asp:CalendarExtender CssClass="black" ID="tbFecha_CalendarExtender"  runat="server" Enabled="True" TargetControlID="tbFecha"  TodaysDateFormat=" d,MMMM, yyyy"></asp:CalendarExtender></td>
<td><asp:TextBox ID="tbHora" runat="server" Width="35px" ValidationGroup="MKE" />
        <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server"   TargetControlID="tbHora" Mask="99:99" MessageValidatorTip="true"  OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"    MaskType="Time" AcceptAMPM="false" AutoComplete="true" AutoCompleteValue="00:00"  ErrorTooltipEnabled="True" />
</td>
<td><asp:DropDownList ID="comboactividad" Width="35px" runat="server"></asp:DropDownList></td>
<td><asp:TextBox ID="tbSalon" Width="150px" runat="server"></asp:TextBox></td>
<td><asp:TextBox ID="tbObservaciones" runat="server" Width="200px"></asp:TextBox></td>
<td><asp:CheckBox ID="ChkPpal" Width="20px" runat="server" /></td> 
<td><asp:ImageButton ID="btnConfirmar"  CausesValidation="true" runat="server"  width="65" height="19"  ValidationGroup="MKE"  ImageUrl="~/assets/images/boton_cargar.gif" /></td>
</tr>
<tr><td colspan="5">     
<%--validaciones--%>
  <asp:CustomValidator ID="CustomValidator1" runat="server" Display="None" OnServerValidate="ValidarFecha" ControlToValidate="tbFecha"  ValidationGroup="MKE" ErrorMessage="Formato de fecha incorrecto"></asp:CustomValidator>
    <asp:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ControlExtender="MaskedEditExtender3"  ControlToValidate="tbHora" IsValidEmpty="False" EmptyValueMessage="Ingresar la hora del evento" InvalidValueMessage="La hora es invalida" Display="None" TooltipMessage="Ingrese un horario"            EmptyValueBlurredText="Ingrese un horario" InvalidValueBlurredMessage="Horario invalido"  ValidationGroup="MKE"/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ValidationGroup="MKE"  ControlToValidate="tbSalon" runat="server" ErrorMessage="Ingresar el lugar del evento" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFecha"  ValidationGroup="MKE"  ControlToValidate="tbFecha" runat="server" ErrorMessage="Ingresar la fecha del evento" Display="None"></asp:RequiredFieldValidator>
   <asp:ValidationSummary ID="ValidationSummary1"  HeaderText="Por favor revisar los siguientes campos:"  ValidationGroup="MKE"   runat="server" />
<%-- fin de validaciones--%>    
 </td><td colspan="2" align="right">
        <asp:ImageButton ID="btnAceptar" CausesValidation="true" runat="server" width="65" height="19"  ImageUrl="~/assets/images/boton_confirmar.gif" Visible="False"    ValidationGroup="MKE"  /> &nbsp;
        <asp:ImageButton ID="btnCancelar" CausesValidation="false" runat="server" width="65" height="19"  ImageUrl="~/assets/images/boton_cancelar.gif" Visible="False"  /></td></tr>
        <tr><td colspan="7"><asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label> </td></tr>
        <tr><td colspan="7"><asp:Panel ID="PanelLugarNoExiste" runat="server" Visible="false">
        <asp:Label ID="lblLugarNoExiste" runat="server" Text="El lugar no existe, por favor para cargarlo " ></asp:Label> 
<asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/gestionzona/lugares.aspx" >haga click aqui</asp:LinkButton>
</asp:Panel>
</td></tr>
</table>
    <div class="mensaje_advertencia_715"> Los campos marcados con un (*) son obligatorios.</div>
</asp:Panel>
<br />
	    <asp:HiddenField ID="hCodigoSalon" runat="server" />	
	    <asp:HiddenField ID="hCodigoConferencia" runat="server" />	
	    <asp:HiddenField ID="hNombreSalon" runat="server" />		
<table class="tablaSeparador1"></table>

</asp:Panel> 
<asp:AutoCompleteExtender OnClientItemSelected="GetCode" ServiceMethod="SearchCustomers"  MinimumPrefixLength="2" CompletionInterval="100" EnableCaching="false" UseContextKey="True" CompletionSetCount="10" TargetControlID="tbSalon" ID="AutoCompleteExtender1" runat="server" FirstRowSelected = "false" >       </asp:AutoCompleteExtender>

<%--</ContentTemplate>
</asp:UpdatePanel>--%>