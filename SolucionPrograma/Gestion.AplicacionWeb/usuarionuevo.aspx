<%@ Page Language="VB" MasterPageFile="~/masterlogin.master" AutoEventWireup="false" CodeFile="usuarionuevo.aspx.vb" Inherits="Tsu.Paginas.usuarionuevo" title="Solicitar clave de acceso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:Panel ID="panelRegistracion" runat="server">
    <div style="width:715px; float:left;">
    <div class=" mensaje_contenedor">
    	<div class="mensaje_info_715">
        Para solicitar una contrase&ntilde;a debe ingresar los datos de su empresa.
        <br />
    
        </div>
    </div>
    
       <br />
    <table border="0" cellspacing="0" cellpadding="0" style="width: 715px">
	  


    <tr><td style="width: 162px"><b>CUIT:</b></td><td width="570"><asp:textbox runat="server" ID="tbCuit" ></asp:textbox></td></tr>
    <tr><td style="width: 162px"><b>Razon Social:</b></td><td width="570"><asp:textbox runat="server" ID="tbRazonSocial" ></asp:textbox></td></tr>
    <tr><td style="width: 162px"><b>Domicilio:</b></td><td><asp:textbox runat="server" ID="tbDomicilio"></asp:textbox></td></tr>
    <tr><td style="width: 162px"><b>Localidad:</b></td><td><asp:textbox runat="server" ID="tbLocalidad"></asp:textbox></td></tr>
    <tr><td style="width: 162px"><b>Código Postal:</b></td><td><asp:textbox runat="server" ID="tbCodigoPostal"></asp:textbox></td></tr>
    <tr><td style="width: 162px"><b>Provincia:</b></td><td><asp:textbox runat="server" ID="tbProvincia"></asp:textbox></td></tr>
    <tr><td style="width: 162px"><b>Nº Teléfono:</b></td><td><asp:textbox runat="server" ID="tbTelefono"></asp:textbox></td></tr>
    <tr><td style="width: 162px"><b>Contacto:</b></td><td><asp:textbox runat="server" ID="tbContacto"></asp:textbox></td></tr>
    <tr><td style="width: 162px"><b>E-mail:</b></td><td><asp:textbox runat="server" ID="tbMail"></asp:textbox></td></tr>
    <tr><td style="width: 162px"><b>WEB:</b></td><td><asp:textbox runat="server" ID="tbWEB"></asp:textbox></td></tr>


	  <tr>
	    <td>&nbsp;</td>
	    <td>&nbsp;</td>
      </tr>
	  <tr>
	    <td>&nbsp;</td>
	    <td> 
	    <asp:ImageButton ID="btnEntrar" ImageUrl="~/assets/images/Boton_Solicitar_Contrasena.gif" runat="server" width="130" height="19" />
	    </td>
      </tr>
      <tr><td>&nbsp;</td></tr>
      <tr><td colspan="3"><b style="color:#09F;">El número de cuenta y documento deberán cargarse sin puntos.</b></td></tr>
      <tr><td>&nbsp;</td></tr>
    </table>  
    </div>    
</asp:Panel>

<%--mensajes --%>
 <asp:Panel ID="MensajeOK" runat="server" Visible="false" >
        <div style="width:715px; float:left;">
        <div class="mensaje_contenedor">
            <div class="mensaje_ok_715">
            <asp:Label  runat="server" ID="tbmensaje" ></asp:Label></div>
		</div>
		</div>
	</asp:Panel>  
 <asp:Panel ID="MensajeError" runat="server" Visible="false" >
        <div style="width:715px; float:left;">
        <div class="mensaje_contenedor">
            <div class="mensaje_error_505">
                <asp:Label ID="LblMensajeError" runat="server" Text=""></asp:Label>   </div>
		</div>
		</div>
	</asp:Panel>  
 <asp:Panel ID="Mensaje" runat="server" Visible="false" >
        <div style="width:715px; float:left;">
        <div class="mensaje_contenedor">
            <div class="mensaje_info_715">
                <asp:Label ID="MensajeSolicitud" runat="server"></asp:Label></div>
		</div>
		</div>
		<br /><br /><br /><br />
	</asp:Panel>   
<%--fin de mensajes --%>

  <br />
 
 
 <asp:Panel ID="MensajeError1" runat="server" Visible="false" >
        <div class=" mensaje_contenedor">
        	<div class="mensaje_ok_505">
        	    <asp:Label ID="lblError1" runat="server"></asp:Label>
        	</div>
        </div>
    </asp:Panel>      
</asp:Content>


