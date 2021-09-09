<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cargaSalon.ascx.vb" Inherits="Tsu.Paginas.controles_cargaSalon" %>


<script type="text/javascript">
    $(document).ready(function()    {
      $('[id$="combozona"]').keypress(function(e) {
      if( (e.which==43) || (e.which==13)) {  
      if (!$(this).val()) {
      e.preventDefault();  $('[id$="combozona"]').focus(); } 
      else {
      e.preventDefault();  $('[id$="tbSalon"]').focus(); }} });
      $('[id$="tbSalon"]').keypress(function(e) {
      if( (e.which==43) || (e.which==13)) {  
      if (!$(this).val()) {
      e.preventDefault();  $('[id$="tbSalon"]').focus(); } 
      else {
      e.preventDefault();  $('[id$="tbDireccion"]').focus(); }} });
      $('[id$="tbDireccion"]').keypress(function(e) {
      if( (e.which==43) || (e.which==13)) {  
      if (!$(this).val()) {
      e.preventDefault();  $('[id$="tbDireccion"]').focus(); } 
      else {
      e.preventDefault();  $('[id$="tbEntreCalles"]').focus(); }} });
      $('[id$="tbEntreCalles"]').keypress(function(e) {
      if( (e.which==43) || (e.which==13)) {  
      if (!$(this).val()) {
      e.preventDefault();  $('[id$="tbEntreCalles"]').focus(); } 
      else {
      e.preventDefault();  $('[id$="tbBarrio"]').focus(); }} });
      $('[id$="tbBarrio"]').keypress(function(e) {
      if( (e.which==43) || (e.which==13)) {  
      e.preventDefault();  $('[id$="tbLocalidad"]').focus(); } });      
      $('[id$="tbLocalidad"]').keypress(function(e) {
      if( (e.which==43) || (e.which==13)) {  
      if (!$(this).val()) {
      e.preventDefault();  $('[id$="tbLocalidad"]').focus(); } 
      else {
      e.preventDefault();  $('[id$="ComboProvincia"]').focus(); }} });
      $('[id$="ComboProvincia"]').keypress(function(e) {
      if( (e.which==43) || (e.which==13)) {  
      if (!$(this).val()) {
      e.preventDefault();  $('[id$="ComboProvincia"]').focus(); } 
      else {
      e.preventDefault();  $('[id$="tbArea1"]').focus(); }} });
      $('[id$="tbArea1"]').keypress(function(e) {
      if( (e.which==43) || (e.which==13)) {  
      e.preventDefault();  $('[id$="tbTelefono1"]').focus(); } });      
      $('[id$="tbTelefono1"]').keypress(function(e) {
      if( (e.which==43) || (e.which==13)) {  
      e.preventDefault();  $('[id$="tbArea2"]').focus(); } });      
      $('[id$="tbArea2"]').keypress(function(e) {
      if( (e.which==43) || (e.which==13)) {  
      e.preventDefault();  $('[id$="tbTelefono2"]').focus(); } });      
      $('[id$="tbTelefono2"]').keypress(function(e) {
      if( (e.which==43) || (e.which==13)) {  
      e.preventDefault();  $('[id$="btnCargar"]').focus(); } });      
    });            
</script>

<asp:HiddenField ID="hCodigoSalon" runat="server" />
<asp:Panel runat="server" ID="PanelUbicacion">

        <table width="715" border="0" cellpadding="5" cellspacing="0" >
<tr><td class="tablaTitulo1" colspan="4">Datos de la ubicación</td></tr>
<tr><td>Nombre *</td><td>Dirección *</td><td>Entre calles</td><td>Barrio</td></tr>
<tr>
<td><asp:TextBox ID="tbSalon" runat="server" Width="180" MaxLength="50"></asp:TextBox></td>
<td><asp:TextBox ID="tbDireccion" runat="server" Width="180" MaxLength="50" ></asp:TextBox></td>
<td><asp:TextBox ID="tbEntreCalles" runat="server" Width="140" MaxLength="50"></asp:TextBox></td>
<td><asp:TextBox ID="tbBarrio" runat="server" Width="140" MaxLength="50"></asp:TextBox></td>
</tr>
<tr><td>Localidad *</td><td>Provincia *</td><td>Teléfono</td><td>Teléfono alternativo</td></tr>
<tr>
<td><asp:TextBox ID="tbLocalidad" runat="server" Width="180" MaxLength="50"></asp:TextBox></td>
<td><asp:DropDownList ID="ComboProvincia" runat="server" Width="180"></asp:DropDownList></td>
<td><asp:TextBox ID="tbArea1" runat="server" Width="35px" MaxLength="5"></asp:TextBox><asp:TextBox ID="tbTelefono1" runat="server" Width="100px" MaxLength="15"></asp:TextBox></td>
<td><asp:TextBox ID="tbArea2" runat="server" Width="35px" MaxLength="5"></asp:TextBox><asp:TextBox ID="tbTelefono2" runat="server" Width="100px" MaxLength="15"></asp:TextBox></td>
</tr>

<tr><td colspan="4" align="right" >
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="None" runat="server" ControlToValidate="tbTelefono1" ErrorMessage="El número de teléfono debe ser numérico" ValidationExpression="[0-9]*" ValidationGroup="Validaciones"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="None" runat="server" ControlToValidate="tbTelefono2" ErrorMessage="El número de teléfono alternativo debe ser numérico" ValidationExpression="[0-9]*" ValidationGroup="Validaciones"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="None" runat="server" ControlToValidate="tbArea1" ErrorMessage="El código de área debe ser numérico" ValidationExpression="[0-9]*" ValidationGroup="Validaciones"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" Display="None" runat="server" ControlToValidate="tbArea2" ErrorMessage="El código de área alternativo debe ser numérico" ValidationExpression="[0-9]*" ValidationGroup="Validaciones"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="None" ValidationGroup="Validaciones" runat="server"  ControlToValidate="tbSalon" ErrorMessage="Ingresar el nombre del lugar"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="None" ValidationGroup="Validaciones"  runat="server"  ControlToValidate="tbDireccion" ErrorMessage="Ingresar la dirección del lugar"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" ValidationGroup="Validaciones"  runat="server"  ControlToValidate="tbLocalidad" ErrorMessage="Ingresar la localidad del lugar"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="None" ValidationGroup="Validaciones"  runat="server"  ControlToValidate="comboProvincia" ErrorMessage="Ingresar la provincia del lugar"></asp:RequiredFieldValidator>
<asp:ImageButton ID="btnCargar"     ValidationGroup="Validaciones" CausesValidation="true" runat="server"  width="65" height="19"  ImageUrl="~/assets/images/boton_cargar.gif" />
<asp:ImageButton ID="btnConfirmar"  ValidationGroup="Validaciones"  OnClientClick="return confirm('En el caso que existan eventos asociados a este lugar, al confirmar estarás modificando todos esos eventos. ¿Estás seguro que deseas modificar estos datos?')" CausesValidation="true" runat="server"  width="65" height="19"  ImageUrl="~/assets/images/boton_confirmar.gif" />&nbsp;<asp:ImageButton ID="btnCancelar" CausesValidation="true" runat="server"   width="65" height="19"  ImageUrl="~/assets/images/boton_cancelar.gif" />
  <tr><td colspan="4"><asp:ValidationSummary  HeaderText="Por favor revisar los siguientes campos:" ID="ValidationSummary1" ShowSummary="true" ValidationGroup="Validaciones" runat="server" /></td></tr>
 <tr><td colspan="4"><asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Text=""></asp:Label></td></tr>
 </table>
 	    <div class="mensaje_advertencia_715"> Los campos marcados con un (*) son obligatorios.</div>	
</asp:Panel>