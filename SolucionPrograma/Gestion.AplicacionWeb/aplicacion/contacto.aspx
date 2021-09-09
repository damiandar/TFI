<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="contacto.aspx.vb" Inherits="aplicacion_contacto" title="Contacto" %>
<%@ Register src="../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Menu" Runat="Server">
     
    <uc1:MenuIzquierda ID="MenuIzquierda1"  menu="Ayuda"   runat="server" />
     
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<div class="Titulo">
Contacto
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Enviado" runat="server" Visible="false">
        <div class="mensaje_contenedor">
        	<div class="mensaje_ok_715" >
        	Su mensaje ha sido enviado con éxito. 
        	</div>
       	</div>      
    </asp:Panel>
    <asp:Panel ID="NOEnviado" runat="server" Visible="false">
        <div class="mensaje_contenedor">
            <div class="mensaje_error_715">
        	Se mensaje no ha podido enviarse, intente nuevamente.
        	</div>
        </div>
    </asp:Panel>
    <asp:Panel ID="MensajeError" runat="server" Visible="false">
        <div class="mensaje_contenedor">
            <div class="mensaje_error_715">
        	Debe completar todos los campos obligatorios.
        	</div>
        </div>
    </asp:Panel>
    
    <div class="mensaje_contenedor">
        <asp:Image runat="server" ImageUrl="~/assets/images/telefono_contacto.gif" Width="715" Height="50" AlternateText="0810-321-4878 (TSU)" />
    </div>
                                            
<table width="715px" border="0" cellspacing="0" cellpadding="5px">
	  <tr>
	    <td style="width: 132px" colspan="1"><b style="color:#09F;">*</b> T&eacute;lefono particular:</td>
	    <td style="width: 577px"><asp:TextBox ID="tbTelefono" style="border: 1px solid #999; width:250px; height:20px;" runat="server"></asp:TextBox></td>
      </tr>
	  <tr>
	    <td style="width: 132px" ><b style="color:#09F;">*</b> T&eacute;lefono Celular:</td>
	    <td style="width: 577px"><asp:TextBox ID="tbCelular" style="border: 1px solid #999; width:250px; height:20px;" runat="server"></asp:TextBox></td>
      </tr>
	  <tr>
	    <td style="width: 132px" >E-mail:</td>
	    <td style="width: 577px"><asp:TextBox ID="tbMail"  style="border: 1px solid #999; width:250px; height:20px;" runat="server"></asp:TextBox></td>
      </tr>
	  <tr>
	    <td style="width: 132px" >Asunto:</td>
	    <td style="width: 577px"><asp:TextBox ID="tbAsunto"  style="border: 1px solid #999; width:250px; height:20px;" runat="server" ></asp:TextBox></td>
      </tr>
	  <tr>
	    <td style="width: 132px" ><b style="color:#09F;">*</b> Consulta:</td>
	    <td style="width: 577px">
            <asp:TextBox ID="tbConsulta"  
                style="border: 1px solid #999; width:575px; height:150px;" runat="server" 
                TextMode="MultiLine" Width="526px"></asp:TextBox></td>
      </tr>
	  <tr>
	    <td style="width: 132px" >&nbsp;</td>
	    <td style="width: 577px"><asp:ImageButton ID="btnConfirmar" runat="server" ImageUrl="~/assets/images/boton_aceptar.gif" /></td>	    
      </tr>
      <tr>
	    <td style="width: 577px; color:#09F;" colspan="2">* Campos obligatorios: Teléfono particular ó 
            teléfono celular, y consulta.&nbsp;</td>        
      </tr>
 </table>         
                                            
</asp:Content>

