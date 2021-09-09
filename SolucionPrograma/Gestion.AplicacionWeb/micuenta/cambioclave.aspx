<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="cambioclave.aspx.vb" Inherits="Tsu.Paginas.aplicacion_cambioclave" title="Cambiar contraseña" %>
<%@ Register src="../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1"  menu="Datos"   runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">

<div class="Titulo">
     CAMBIAR CONTRASEÑA
    </div>
    <div class="subTitulo">
    Cambiar Contraseña
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript">
    $(document).ready(function()    {
    
   //pasar con el +
      $('[id$="tbContraseniaActual"]').keypress(function(e) {
      if( e.which==43)   {  e.preventDefault();  $('[id$="tbContraseniaNueva"]').focus(); } });
      
      $('[id$="tbContraseniaNueva"]').keypress(function(e) {
      if( e.which==43)   {  e.preventDefault();  $('[id$="tbContraseniaRepetir"]').focus(); } });
      
      $('[id$="tbContraseniaRepetir"]').keypress(function(e) {
      if( e.which==43)   {  e.preventDefault();  $('[id$="btnConfirmar"]').focus(); } });
      
      //pasar con el +
      $('[id$="tbContraseniaActual"]').keypress(function(e) {
      if( e.which==13)   {  e.preventDefault();  $('[id$="tbContraseniaNueva"]').focus(); } });
      
      $('[id$="tbContraseniaNueva"]').keypress(function(e) {
      if( e.which==13)   {  e.preventDefault();  $('[id$="tbContraseniaRepetir"]').focus(); } });
      
      $('[id$="tbContraseniaRepetir"]').keypress(function(e) {
      if( e.which==13)   {  e.preventDefault();  $('[id$="btnConfirmar"]').focus(); } });
    });
    </script>
    
		<div style="width:715px;  float:left;">
			<!-- InstanceBeginEditable name="Centro" -->	
			
	    <asp:Panel ID="panelexito" Visible="false" runat="server">
	        <%--<div class=" mensaje_contenedor">
    	        <div class="mensaje_ok_715">
    	        La constraseña ha sido cambiada con éxito.
    	        </div>
            </div>--%>
            <div style="width:715px;  float:left;">
		        <!-- InstanceBeginEditable name="Centro" -->
    	        <div class="mensaje_ok_505">
    	        La constraseña ha sido cambiada con éxito.
    	    </div>
            </asp:Panel>
        
        
        <asp:Panel ID="panel" runat="server">
            <table width="715" border="0" cellspacing="0" cellpadding="5">
	        <tr>
	        <td width="125" >Contrase&ntilde;a actual:</td>
	        <td width="570">
	        <asp:TextBox ID="tbContraseniaActual" runat="server" TextMode="Password" MaxLength="8"  style="border: 1px solid #999; width:250px; height:20px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbContraseniaActual" Display="Dynamic" ErrorMessage="Debe ingresar la contraseña actual" 
            ValidationGroup="VGpaso1"></asp:RequiredFieldValidator>        
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
	        <tr><td >Nueva contrase&ntilde;a:</td><td>
	       <asp:TextBox ID="tbContraseniaNueva" runat="server" TextMode="Password" MaxLength="8"   style="border: 1px solid #999; width:250px; height:20px;"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbContraseniaNueva" Display="Dynamic" ErrorMessage="Debe ingresar una contraseña nueva" ValidationGroup="VGpaso1"></asp:RequiredFieldValidator>
     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ControlToValidate="tbContraseniaNueva"
            ErrorMessage="Debe tener entre 6 y 8 letras y/o números." 
            ValidationExpression="[^\s]{6,8}" ValidationGroup="VGpaso1" />
        </td>
      </tr>
	  <tr>
	    <td >Repetir nueva contrase&ntilde;a:</td>
	    <td valign="top">
	        <asp:TextBox ID="tbContraseniaRepetir"  style="border: 1px solid #999; width:250px; height:20px;"
        runat="server" TextMode="Password" MaxLength="8"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="tbContraseniaRepetir" Display="Dynamic" 
        ErrorMessage="Debe repetir la contraseña nueva" ValidationGroup="VGpaso1"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
    controltovalidate="tbContraseniaNueva" ControlToCompare="tbContraseniaRepetir" Display="Dynamic"
    ErrorMessage="Repetir contraseña deberá ser igual a la nueva contraseña."></asp:CompareValidator>
    &nbsp;</td>
      </tr>
	  <tr>
	    <td >&nbsp;</td>
	    <td>&nbsp;</td>
      </tr>
	  <tr>
	    <td >&nbsp;</td>
	    <td><asp:ImageButton ID="btnConfirmar" alt="" width="65" height="19"   runat="server" ValidationGroup="VGpaso1" ImageUrl="~/assets/images/boton_confirmar.gif" /></td>	    
      </tr>
      <tr> <td style="height:18px"></td></tr>
                <tr>
                    <td colspan="2" style="font-size:x-small">
                        La contraseña debe tener entre 6 y 8 letras y/o números exceptuando espacios en 
                        blanco, signos y acentos.</td>
                </tr>
    </table>




</asp:Panel>
    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
   	<!-- InstanceEndEditable --> 
    	</div>
</asp:Content>

