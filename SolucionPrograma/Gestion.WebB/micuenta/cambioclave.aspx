<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="cambioclave.aspx.vb" Inherits="Tsu.Paginas.aplicacion_cambioclave" title="Cambiar contraseña" %>
<%@ Register src="../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>
<asp:Content ID="Encabezado1" ContentPlaceHolderID="Encabezado" runat="server" >
<h1 class="page-header">
    Cambio de clave
</h1>
<ol class="breadcrumb">
    <li>
        <i class="fa fa-Inicio"></i>  <a href="default.aspx">Inicio</a>
    </li>
    <li class="active">
        <i class="fa fa-edit"></i> Cambio de clave
    </li>
</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1"  menu="Datos"   runat="server" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
        <div class="row">
<div class="col-lg-6">
    <div class="form-group">
        <label>Contrase&ntilde;a actual:</label>
       <asp:TextBox ID="tbContraseniaActual" class="form-control" runat="server" TextMode="Password" MaxLength="8" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbContraseniaActual" Display="Dynamic" ErrorMessage="Debe ingresar la contraseña actual" 
            ValidationGroup="VGpaso1"></asp:RequiredFieldValidator>    
        <p class="help-block"></p>
    </div>
    <div class="form-group">
        <label>Nueva contrase&ntilde;a:</label>
        	       <asp:TextBox ID="tbContraseniaNueva" class="form-control" runat="server" TextMode="Password" MaxLength="8"   ></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbContraseniaNueva" Display="Dynamic" ErrorMessage="Debe ingresar una contraseña nueva" ValidationGroup="VGpaso1"></asp:RequiredFieldValidator>
     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ControlToValidate="tbContraseniaNueva"
            ErrorMessage="Debe tener entre 5 y 8 letras y/o números." 
            ValidationExpression="[^\s]{5,8}" ValidationGroup="VGpaso1" />
        <p class="help-block"></p>
    </div>
    <div class="form-group">
        <label>Repetir nueva contrase&ntilde;a:</label>
          <asp:TextBox ID="tbContraseniaRepetir" class="form-control"   runat="server" TextMode="Password" MaxLength="8"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="tbContraseniaRepetir" Display="Dynamic" 
        ErrorMessage="Debe repetir la contraseña nueva" ValidationGroup="VGpaso1"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
    controltovalidate="tbContraseniaNueva" ControlToCompare="tbContraseniaRepetir" Display="Dynamic"
    ErrorMessage="Repetir contraseña deberá ser igual a la nueva contraseña."></asp:CompareValidator>
        <p class="help-block"></p>
    </div>
 </div>
 </div>  

 

 
                        La contraseña debe tener entre 6 y 8 letras y/o números exceptuando espacios en 
                        blanco, signos y acentos. 
 
            <asp:Button ID="btnConfirmar" runat="server"   class="btn btn-primary"  Text="Confirmar" />



</asp:Panel>
    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
   	<!-- InstanceEndEditable --> 
    	</div>
</asp:Content>

