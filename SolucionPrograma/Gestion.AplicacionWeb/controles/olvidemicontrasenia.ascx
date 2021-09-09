<%@ Control Language="VB" AutoEventWireup="false" CodeFile="olvidemicontrasenia.ascx.vb" Inherits="Tsu.Paginas.controles_olvidemicontrasenia" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %> 
<style type="text/css">
            .style1
            {
                width: 123px;
            }
        </style>
<asp:Panel ID="MensajeError" runat="server" Visible="false" >
    <div class="mensaje_contenedor"><div class="mensaje_error_505"><asp:Label ID="lblError" runat="server"></asp:Label></div></div>
</asp:Panel>
<asp:Panel runat="server" ID="panel1">
<table width="505" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="100">Usuario:</td><td width="415" height="30">
        <asp:TextBox ID="tbCuenta" runat="server"  style="border: 1px solid #999; width:300px; height:20px;" MaxLength="9"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"   ControlToValidate="tbCuenta" Display="Dynamic"         ErrorMessage="Debe ingresar un usuario" ValidationGroup="VGpaso1"></asp:RequiredFieldValidator>
        </td>
      </tr>
      <tr><td>&nbsp;</td><td>&nbsp;</td></tr>

</table>
<%--  <div style="width:505px;  float:left;">--%>
<!-- InstanceBeginEditable name="Centro" -->
  <asp:Panel runat="server" ID="paneladvertencia" Visible="false">
    <div class="mensaje_advertencia_505"> <asp:Label runat="server" ID="lblAdvertencia" ></asp:Label></div>
    </asp:Panel>
 <%--   <div class="mensaje_error_505"> Tu clave ha sido bloqueada.</div><br />--%>
    <table width="505" border="0" cellspacing="0" cellpadding="5">
	  <tr>
	    <td bgcolor="#f0f0f0"><strong>C&oacute;digo:</strong></td>
	    <td bgcolor="#f0f0f0">
	   <recaptcha:RecaptchaControl Language="es" Theme="clean" ID="recaptcha" runat="server" 
PublicKey="6LdAecYSAAAAANIfL8VgQ5b8eivKOw3hj3MiPc9T"                          
PrivateKey="6LdAecYSAAAAAGOBst8gtG9w4Hzb2ncRtEFhZqtt" TabIndex="2"      />
	    </td>
      </tr>
	  <tr>
	    <td>&nbsp;</td>
	    <td>&nbsp;</td>
      </tr>
	  <tr>
	    <td>&nbsp;</td>
	    <td>    <asp:ImageButton ID="btnSiguiente0"  ValidationGroup="VGRespuestas"  runat="server" ImageUrl="~/assets/images/boton_siguiente.gif"  />
       </td>
      </tr>
    </table>
<%--</div>--%>
<asp:Label  ID="lblResult" runat="server" />   

 </asp:Panel>  

<%-- mensajes --%>   
   <asp:Panel ID="MensajeError0" runat="server" Visible="false" >
        <div class="mensaje_contenedor">
            <div class="mensaje_error_715">
        	Hubo un error vuelva a intentar.
        	</div>
        </div>
   </asp:Panel>


<asp:Panel ID="PanelMail" runat="server" Visible="false">
<div>Haga clic en &quot;Confirmar&quot; así su contraseña será enviada por mail a la siguiente dirección:</div>
<br />
<table>
   <tr><td>E-mail:</td><td><asp:Label ID="lblMail" runat="server"></asp:Label></td></tr>
   <tr><td  style="width:75px;">&nbsp;</td><td>&nbsp;</td></tr>
   <tr><td align="center" colspan="2"><asp:ImageButton ID="btnEnviarMail" runat="server" ImageUrl="~/assets/images/boton_confirmar.gif" style="height: 19px" /></td></tr>
</table> 
</asp:Panel>
 
<p>
&nbsp;
<asp:Panel ID="MensajeError1" runat="server" Visible="false" >
        <div class=" mensaje_contenedor">
        	<div class="mensaje_ok_505">
        	    <asp:Label ID="lblError1" runat="server"></asp:Label>
        	</div>
        </div>
    </asp:Panel>   
<asp:Panel ID="MensajeRecordar" runat="server" Visible="false" >
        <div class="mensaje_info_715">
            <asp:Label ID="Label1" Text="Si recuerdas tu contraseña, puedes ingresar sin esperar que te llegue con tu próximo pedido." runat="server"></asp:Label>        	
        </div>
    </asp:Panel>   
</p>



      
